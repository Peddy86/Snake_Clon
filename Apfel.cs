using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Snake_Clon
{
    class Apfel : PunkteObjekteI
    {
        //int groesse;
        //MediaElement ApfelBild, HintergrundBild;
        //public int Puntzahl;

        public int Groesse { get; set; }
        public MediaElement PunkteBild { get; set; }
        public int Punktzahl { get; set; }
        Point position;

        public Apfel(int groesse)
        {
            PunkteBild = new MediaElement();      
            Groesse = groesse;
            Punktzahl = 10;
            position = new Point();
        }

        //Anzeigen Apfel
        public void Anzeigen(Canvas meinCanvas, int balkenbreite)
        { 
            Random zufall = new Random(GetHashCode());
            int min = balkenbreite;

            //das Maximun für das erscheinen der Äpfel ermitteln
            int maxX = (int)meinCanvas.ActualWidth - balkenbreite - Groesse;
            int maxY = (int)meinCanvas.ActualHeight - balkenbreite - Groesse;

            position.X = zufall.Next(min, maxX);
            position.Y = zufall.Next(min, maxY);

            //positionieren
            Canvas.SetLeft(PunkteBild, position.X);
            Canvas.SetTop(PunkteBild, position.Y);

            PunkteBild.Width = Groesse;
            PunkteBild.Height = Groesse;
            PunkteBild.Source = new Uri(@"C:\Users\Gummi\source\repos\Snake_Clon\Snake_Clon\Grafiken\ApfelBild.png");
           
            //namen vergeben            
            PunkteBild.Name = "Apfel";
             
            meinCanvas.Children.Add(PunkteBild);
        }

        //Apfel entfernen
        public void Entfernen(Canvas meinCanvas)
        {
            meinCanvas.Children.Remove(PunkteBild);            
        }

        public Point GetPosition()
        {
            return new Point(position.X, position.Y);
        }
    }
}
