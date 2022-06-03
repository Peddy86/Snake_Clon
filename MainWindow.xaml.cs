using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Threading;
using Pong_Teil_1;



namespace Snake_Clon
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int Punkte { get; set; }    
        int Zeit { get; set; }  
        int Richtung { get; set; }  
        int Balkenbreite { get; set; }  
        List<Schlangenteil> schlange;
        DispatcherTimer timerSchlange, timerSpielzeit, timerObjectBewegen;
        Schlangenkopf kopf;
        Apfel ApfelObject;
        Maus MausObject;
        bool SpielUnterbrochen, MausIstda, pilzDa, sternDa, spielGestartet;
        Label ZeitAnzeige_lab, PunktAnzeige_lab;
        int zufallsRichtung, zaehler, zaelerPilz, sternZaehler;
        double geschwindigkeit;
        Random zufall;
        Pilz pilz;
        Stern stern;
        Score spielpunkte;
        Mauer mauerEins, mauerZwei, mauerDrei, mauerVier;
        HorizontaleMauer mauerEinsHori, mauerZweiHori;
        LevelEinsLabyrinth levelEins;
        LevelZwei levelZwei;
        LevelDrei levelDrei;
        static RoutedCommand pause = new RoutedCommand();


        void Start()
        {
            LabelSetzen();

            spielGestartet = true;

            Punkte = 0;
            Zeit = 0;
            Richtung = 0;                   

            DieTimer();

            //liste und Spielfeld Leeren und neues Spielfeld erstellen
            schlange.Clear();
            Spielfeld.Children.Clear();
            ZeichneSpielfeld();

            ObjectInitialisierung();
            //levelEins.LevelAnzeigen();
            //levelZwei.LevelAnzeigen();
            levelDrei.LevelAnzeigen();

            ZeitAnzeige_lab.Content = Zeit;
            PunktAnzeige_lab.Content = Punkte;
            
            //Schlangenkopf erzeugen/positionieren
            kopf = new Schlangenkopf(new Point(Spielfeld.ActualWidth / 2, Spielfeld.ActualHeight / 2));

            //setzen
            schlange.Add(kopf);

            ApfelObject = new Apfel(25);
            ApfelObject.Anzeigen(Spielfeld, Balkenbreite);

            GrenzeNixGut(ApfelObject.GetPosition(), ApfelObject);            

            zufall = new Random();
            //zaehler der Methoden
            zaehler = 0;
            zaelerPilz = 0;
            sternZaehler = 0;
        }

        //gut Deutsch
        private void GrenzeNixGut(Point trefferPosition, object fragezeichen)
        {
            HitTestResult treffer = VisualTreeHelper.HitTest(Spielfeld, trefferPosition);
            MediaElement kollisionsBild;
            string kollisionsName;

            if (treffer != null)
            {
                //name der Kollision Beschaffen
                kollisionsBild = treffer.VisualHit as MediaElement;
                if (kollisionsBild == null)
                    return;

                kollisionsName = kollisionsBild.Name;

                //was wurde getroffen
                if (kollisionsName == "Grenze" && fragezeichen == ApfelObject)
                {
                    ApfelObject.Entfernen(Spielfeld);
                    ApfelObject.Anzeigen(Spielfeld, Balkenbreite);

                }
                if (kollisionsName == "Grenze" && fragezeichen == pilz)
                {
                    pilz.Entfernen(Spielfeld);
                    PilzAnzeigen();
                }
                if (kollisionsName == "Grenze" && fragezeichen == stern)
                {
                    stern.Entfernen(Spielfeld);
                    SternAnzeigen();
                }
            }
        }

        private void ObjectInitialisierung()
        {
            levelEins = new LevelEinsLabyrinth(Spielfeld);
            levelZwei = new LevelZwei(Spielfeld);
            levelDrei = new LevelDrei(Spielfeld);
            MausObject = new Maus(35, Spielfeld);
            pilz = new Pilz(25);
            stern = new Stern(25);
            mauerEins = new Mauer(Spielfeld, 200);
            mauerZwei = new Mauer(Spielfeld, 350);
            mauerDrei = new Mauer(Spielfeld, 500);
            mauerVier = new Mauer(Spielfeld, 400);

            mauerEinsHori = new HorizontaleMauer(Spielfeld, 300);
            mauerZweiHori = new HorizontaleMauer(Spielfeld, 500);
        }
        public MainWindow()
        {
            //System.Threading.Thread.Sleep(5000);

            InitializeComponent();
            Balkenbreite = 15;
            schlange = new List<Schlangenteil>();            

            SpielUnterbrochen = true;            

            PunktAnzeige_lab = new Label();
            ZeitAnzeige_lab = new Label();

            PunktAnzeige_lab.Name = "labelName";
            ZeitAnzeige_lab.Name = "LabelZeit";

            MausIstda = false;
            pilzDa = false;
            sternDa = false;

            spielpunkte = new Score();
            spielpunkte.LoeschePunkte();
            
            spielGestartet = false;
        }

        public static RoutedCommand Pause
        {
            get
            {
                return pause;
            }
        }

        private void Pause_CanExecute(object sender,CanExecuteRoutedEventArgs e)

        {
            //gibt es das Spielfeld und läuft ein Spiel?
            if (Spielfeld != null && spielGestartet == true)
                e.CanExecute = true;
        }

        private void Pause_Executed(object sender,ExecutedRoutedEventArgs e)
        {            
            SpielPause();
        }


        private void DieTimer()
        {
            geschwindigkeit = 1000 - Geschwindigkeit_Slider.Value;

            //timer setzen,intervall einstellen und starten
            timerSchlange = new DispatcherTimer();
            timerSchlange.Interval = TimeSpan.FromMilliseconds(geschwindigkeit);
            timerSchlange.Tick += new EventHandler(Timer_SchlangeBewegen);
            timerSchlange.Start();

            //timer für die Spielzeit
            timerSpielzeit = new DispatcherTimer();
            timerSpielzeit.Interval = TimeSpan.FromSeconds(1);
            timerSpielzeit.Tick += new EventHandler(Timer_Spielzeit);
            timerSpielzeit.Start();

            //timer für die bewegung der Objekte
            timerObjectBewegen = new DispatcherTimer();
            timerObjectBewegen.Interval = TimeSpan.FromMilliseconds(15);
            timerObjectBewegen.Tick += new EventHandler(TimerObject_Spielzeit);
            timerObjectBewegen.Start();
        }

        void Timer_Spielzeit(object e, EventArgs arg)
        {
            ZeitAnzeige_lab.Content = Zeit++;

            if (Zeit < 2)
            {
                LabelSetzen();
                Spielfeld.Children.Add(ZeitAnzeige_lab);
                Spielfeld.Children.Add(PunktAnzeige_lab);
            }
            
            if (SpielUnterbrochen)
                Geschwindigkeit_Slider.IsEnabled = true;
            else
                Geschwindigkeit_Slider.IsEnabled = false;

            zaehler++;

            //Muáus Richtungswechsel
            if (Zeit % 1 == 0)
                zufallsRichtung = zufall.Next(1, 4);

            if (Pilz_MI.IsChecked)
                PilzAnzeigen();
            if(Stern_MI.IsChecked)
                SternAnzeigen();
        }


        //Der Stern
        private void SternAnzeigen()
        {   
            if (Zeit % 120 == 0 && sternDa == false)
            {
                stern.Anzeigen(Spielfeld, Balkenbreite);
                GrenzeNixGut(stern.GetPosition(), stern);

                sternDa = true;
                sternZaehler = 0;
            }

            sternZaehler++;
            if (sternZaehler == 7 && sternDa == true)
            {    
                stern.Entfernen(Spielfeld);    
                sternZaehler = 0;    
                sternDa = false;
            }                        
        }
        private void PilzAnzeigen()
        {
            if (zaehler % 40 == 0 && pilzDa == false)
            {
                pilz.Anzeigen(Spielfeld, Balkenbreite);
                GrenzeNixGut(pilz.GetPosition(), pilz);
            }

            if (zaehler % 60 == 0 && pilzDa == false)
                pilz.Entfernen(Spielfeld);

            if (pilzDa == true)
            {
                zaelerPilz++;
                if (zaelerPilz == 10)
                {
                    //erhöht die geschwindigkeit auf Maximum und setzt sie zurück wie beim Startbeginn
                    geschwindigkeit = 1000 - Geschwindigkeit_Slider.Value;
                    timerSchlange.Interval = TimeSpan.FromMilliseconds(geschwindigkeit);
                    zaelerPilz = 0;
                    pilzDa = false;
                }
            }
        }
        void ZeichneRechteck(Point position, double laenge, double breite)
        {
            MediaElement balken = new MediaElement();
            balken.Name = "Grenze";

            Canvas.SetLeft(balken, position.X);
            Canvas.SetTop(balken, position.Y);  

            balken.Width = laenge;
            balken.Height = breite;

            balken.Stretch = Stretch.UniformToFill;
            balken.Source = new Uri(@"C:\Users\Gummi\source\repos\Snake_Clon\Snake_Clon\Grafiken\MauerBild.png");

            Spielfeld.Children.Add(balken);
        }

        void ZeichneSpielfeld()
        {
            //oben
            ZeichneRechteck(new Point(0, 0), Spielfeld.ActualWidth, Balkenbreite);
            //rechts
            ZeichneRechteck(new Point(Spielfeld.ActualWidth - Balkenbreite, 0), Balkenbreite, Spielfeld.ActualHeight);
            //unten
            ZeichneRechteck(new Point(0, Spielfeld.ActualHeight - Balkenbreite), Spielfeld.ActualWidth, Balkenbreite);
            //links
            ZeichneRechteck(new Point(0, 0), Balkenbreite, Spielfeld.ActualHeight);
        }
                
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ZeichneSpielfeld();
            SliderEinstellungen();
        }

        private void SliderEinstellungen()
        {
            SenkrechtePositionEins_Slider.Maximum = Spielfeld.ActualWidth - 100;
            SenkrechtePositionEins_Slider.Value = Spielfeld.ActualWidth - 300;
            SenkrechtePositionZwei_Slider.Maximum = Spielfeld.ActualWidth - 100;
            SenkrechtePositionZwei_Slider.Value = 300;
            SenkrechtePositionDrei_Slider.Maximum = Spielfeld.ActualWidth - 100;
            SenkrechtePositionDrei_Slider.Value = 400;
            SenkrechtePositionVier_Slider.Maximum = Spielfeld.ActualWidth - 100;
            SenkrechtePositionVier_Slider.Value = Spielfeld.ActualWidth - 400;
            HorizontalePositionEins_Slider.Maximum = Spielfeld.ActualHeight - 100;
            HorizontalePositionEins_Slider.Value = Spielfeld.ActualHeight / 1.5;
            HorizontalePositionZwei_Slider.Maximum = Spielfeld.ActualHeight - 100;
            HorizontalePositionZwei_Slider.Value= Spielfeld.ActualHeight /3;
        }

        private void MausAnzeigen()
        {
            if (zaehler % 30 == 0 && MausIstda == false)
            {
                MausObject.Anzeigen(Spielfeld, Balkenbreite);                
                MausIstda = true;
            }
            if (zaehler % 60 == 0 && MausIstda == true)
            {
                MausObject.Entfernen(Spielfeld);                
                MausIstda = false;
            }
        }
        private void Timer_SchlangeBewegen(object sender, EventArgs e)
        {
            schlange[0].Bewegen(Richtung);
            schlange[0].ZeichneTeil(Spielfeld);

            for (int index = 1; index < schlange.Count; index++)
            {
                schlange[index].SetzePosition(schlange[index - 1].GetAltePosition());
                schlange[index].ZeichneTeil(Spielfeld);
            }

            if(Maus_MI.IsChecked)
                MausAnzeigen();

            Kollision();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            //je nach Taste die Richtung setzen
            if (e.Key == Key.Up)
            {
                Richtung = 0;                
            }
                
            if(e.Key == Key.Down)
            {
                Richtung= 2;                
            }
                
            if (e.Key == Key.Left)
            {
                Richtung = 3;                
            }
                
            if (e.Key == Key.Right)
            {
                Richtung = 1;                
            }
        }

        private void Kollision()
        {
            //eine Trefferabfrage // Hier!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!>>>>>>>>>>>>>>>>>>>>>><<<<<<<<<<<<<<<<<<<<
            HitTestResult treffer = VisualTreeHelper.HitTest(Spielfeld, schlange[0].GetPosition());
            MediaElement kollisionsBild;
            string kollisionsName;
            
            if (treffer != null)
            {
                //name der Kollision Beschaffen
                kollisionsBild = treffer.VisualHit as MediaElement;
                if (kollisionsBild == null)
                    return;

                kollisionsName = kollisionsBild.Name;

                //was wurde getroffen
                if (kollisionsName == "Grenze" || kollisionsName == "Schlange")
                {
                    timerSchlange.Stop();
                    Spielende();
                }                    
                if (kollisionsName == "Apfel")
                {
                    PlussPunktApfel();
                }
                if(kollisionsName == "Maus")
                {
                    PlussPunktMaus();
                }
                if (kollisionsName == "Pilz")
                {
                    PilzDauer();
                }
                if (kollisionsName == "Stern")
                {
                    Punkte = spielpunkte.VeraenderePunkte(stern.Punktzahl);
                    PunktAnzeige_lab.Content = Punkte;
                    stern.Entfernen(Spielfeld);
                }
            }
        }

        private void PilzDauer()
        {
            pilzDa = true;
            timerSchlange.Interval = TimeSpan.FromMilliseconds(50);
            Punkte = spielpunkte.VeraenderePunkte(pilz.Punktzahl);
            PunktAnzeige_lab.Content = Punkte;
            pilz.Entfernen(Spielfeld);
        }
        private void Anhängen()
        {
            //hinten an die Schlange anhängen
            Schlangenteil sTeil = new Schlangenteil(new Point(schlange[schlange.Count - 1].GetAltePosition().X,
            schlange[schlange.Count - 1].GetAltePosition().Y + schlange[schlange.Count - 1].GetGroesse()));

            schlange.Add(sTeil);
        }

        private void PlussPunktMaus()
        {
            Punkte = spielpunkte.VeraenderePunkte(MausObject.Punktzahl); 
            PunktAnzeige_lab.Content = Punkte;
            MausObject.Entfernen(Spielfeld);
            MausIstda = false;            
            Anhängen();
        }

        private void Bestenliste_MenuItem_Click(object sender, RoutedEventArgs e)
        {
            spielpunkte.ListeAusgeben(this);
        }

        private void PlussPunktApfel()
        {
            //hier wurde was geändert gebenfalls auch in den anderen PunkteMethoden
            Punkte = spielpunkte.VeraenderePunkte(ApfelObject.Punktzahl);            
            PunktAnzeige_lab.Content = Punkte;

            if (Punkte % 20 == 0 && geschwindigkeit >= 50)
            {
                if (ErsteGeschwindigkeit_MenuItem.IsChecked == true)
                    geschwindigkeit = geschwindigkeit - 10;
                if(ZweiteGeschwindigkeit_MenuItem.IsChecked == true)
                    geschwindigkeit = geschwindigkeit - 20;
                if (DritteGeschwindigkeit_MenuItem.IsChecked == true)
                    geschwindigkeit = geschwindigkeit - 30;

                timerSchlange.Interval = TimeSpan.FromMilliseconds(geschwindigkeit);
            }

            //alter Apfel löschen und einen neuen einsetzen
            ApfelObject.Entfernen(Spielfeld);
            ApfelObject = new Apfel(25);
            ApfelObject.Anzeigen(Spielfeld, Balkenbreite);
            GrenzeNixGut(ApfelObject.GetPosition(), ApfelObject);
            Anhängen();
        }

        private void Pause_Click(object sender, RoutedEventArgs e)
        {
            SpielPause();
        }

        private void SpielPause()
        {
            if (SpielUnterbrochen == false)
            {
                //alle Timer anhalten
                timerSchlange.Stop();
                timerSpielzeit.Stop();
                timerObjectBewegen.Stop();
                Pause_MenuItem.IsChecked = true;
                SpielUnterbrochen = true;
                Title = "Snake - Pause";
            }
            else
            {
                //Timer wieder starten
                timerSpielzeit.Start();
                timerSchlange.Start();
                timerObjectBewegen.Start();
                Pause_MenuItem.IsChecked = false;
                SpielUnterbrochen = false;
                Title = "Snake";
            }
        }

        private void NeuesSpiel_Click(object sender, RoutedEventArgs e)
        {
            //lauft ein Spiel, dann anhlaten
            if(SpielUnterbrochen == false)
            {
                SpielPause();
                NeuesSpiel();
                SpielPause();
            }
            else
            {
                if (NeuesSpiel() == true)
                    SpielPause();
            }
        }

        private void Beenden_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        bool NeuesSpiel()
        {
            bool ergebnis = false;

            MessageBoxResult abfrage = MessageBox.Show(
                "Neues Spiel Starten?", "Neues Spiel", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (abfrage == MessageBoxResult.Yes)
            {
                Start();
                ergebnis = true;
            }

            return ergebnis;
        }

        private void Spielende()
        {
            SpielPause();

            //reicht es für ein Eintrag?
            if (spielpunkte.NeuerEintrag(this) == true)
                spielpunkte.ListeAusgeben(this);

            MessageBox.Show("Das Spiel ist zuende!", "Snake-Ende", MessageBoxButton.OK, MessageBoxImage.Information);

            //neues Spiel?
            if (NeuesSpiel() == true)
            {
                spielpunkte.LoeschePunkte();
                SpielPause();
            }
            else
                Close();
        }

        private void LabelSetzen()
        {            
            ZeitAnzeige_lab.Name = "zeitAnzeige_lab";
            ZeitAnzeige_lab.FontSize = 20;
            ZeitAnzeige_lab.FontWeight = FontWeights.Bold;
            Canvas.SetLeft(ZeitAnzeige_lab, 600);
            Canvas.SetTop(ZeitAnzeige_lab, 10);
            ZeitAnzeige_lab.Content = 0;
            
            PunktAnzeige_lab.Name = "punktAnzeige_lab";
            PunktAnzeige_lab.FontSize = 20;
            PunktAnzeige_lab.FontWeight = FontWeights.Bold;
            Canvas.SetLeft(PunktAnzeige_lab, 760);
            Canvas.SetTop(PunktAnzeige_lab, 10);
            PunktAnzeige_lab.Content = 0;            
        }

        private void TimerObject_Spielzeit(object sender, EventArgs e)
        {
            if (MausIstda == true)
                MausObject.Bewegen(Spielfeld, zufallsRichtung);

            MauerBewegen();
        }

        private void MauerBewegen()
        {
            if (MauerEins_chb.IsChecked == true)
                mauerEins.Bewegen(Spielfeld, (int)SenkrechtePositionEins_Slider.Value);
            if (MauerZwei_chb.IsChecked == true)
                mauerZwei.Bewegen(Spielfeld, (int)SenkrechtePositionZwei_Slider.Value);
            if (MauerDrei_chb.IsChecked == true)
                mauerDrei.Bewegen(Spielfeld, (int)SenkrechtePositionDrei_Slider.Value);
            if (MauerVier_chb.IsChecked == true)
                mauerVier.Bewegen(Spielfeld, (int)SenkrechtePositionVier_Slider.Value);

            if (MauerEinsHori_chb.IsChecked == true)
                mauerEinsHori.BewegenHori(Spielfeld, (int)SenkrechtePositionEins_Slider.Value);
            if (MauerZweiHori_chb.IsChecked == true)
                mauerZweiHori.BewegenHori(Spielfeld, (int)SenkrechtePositionZwei_Slider.Value);

        }

        

    }
}
