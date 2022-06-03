using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Snake_Clon
{
    internal class LevelDrei
    {
        MediaElement MauerEins, MauerZwei, MauerDrei, MauerVier, MauerFünf, HoriMauerEins, HoriMauerZwei, HoriMauerDrei;
        Point position;
        Canvas meinCanvas;

        public LevelDrei(Canvas spielfeld)
        {
            MauerEins = new MediaElement();
            MauerZwei = new MediaElement();
            MauerDrei = new MediaElement();
            MauerVier = new MediaElement();
            MauerFünf = new MediaElement();
            HoriMauerEins = new MediaElement();
            HoriMauerZwei = new MediaElement();
            HoriMauerDrei = new MediaElement();

            position = new Point();
            meinCanvas = spielfeld;
        }

        public void LevelAnzeigen()
        {
            //Vertikale Mauern
            ErsteMauerSetzen();
            ZweiteMauerSetzen();
            
            
            
            
            DritteMauerSetzen();
            VierteMauerSetzen();
            FünfteMauerSetzen();
            SechsteMauerSetzen();

            //Horizontale Mauern
            SiebteMauerSetzen();
            AchteMauerSetzen();
        }

        private void ErsteMauerSetzen()
        {
            MauerEins.Height = meinCanvas.ActualHeight / 6;
            MauerEins.Width = 40;
            MauerEins.Source = new Uri(@"C:\Users\Gummi\source\repos\Snake_Clon\Snake_Clon\Grafiken\MauerHindernis.png");
            MauerEins.Stretch = System.Windows.Media.Stretch.UniformToFill;
            MauerEins.Name = "Grenze";

            //position der Mauer setzen
            position.Y = 16;
            Canvas.SetTop(MauerEins, position.Y);
            position.X = meinCanvas.ActualWidth / 2;
            Canvas.SetLeft(MauerEins, position.X);

            meinCanvas.Children.Add(MauerEins);
        }
        private void ZweiteMauerSetzen()
        {
            MauerZwei.Height = meinCanvas.ActualHeight / 6;
            MauerZwei.Width = 40;
            MauerZwei.Source = new Uri(@"C:\Users\Gummi\source\repos\Snake_Clon\Snake_Clon\Grafiken\MauerHindernis.png");
            MauerZwei.Stretch = System.Windows.Media.Stretch.UniformToFill;
            MauerZwei.Name = "Grenze";

            //position der Mauer setzen
            position.Y = meinCanvas.ActualHeight - MauerZwei.Height - 16;
            Canvas.SetTop(MauerZwei, position.Y);
            position.X = meinCanvas.ActualWidth / 2;
            Canvas.SetLeft(MauerZwei, position.X);

            meinCanvas.Children.Add(MauerZwei);
        }
        private void DritteMauerSetzen()
        {
            MauerDrei.Height = 40;
            MauerDrei.Width = 350;
            MauerDrei.Source = new Uri(@"C:\Users\Gummi\source\repos\Snake_Clon\Snake_Clon\Grafiken\MauerHindernisHori.png");
            MauerDrei.Stretch = System.Windows.Media.Stretch.UniformToFill;
            MauerDrei.Name = "Grenze";

            //position der Mauer setzen
            position.Y = meinCanvas.ActualHeight / 4;
            Canvas.SetTop(MauerDrei, position.Y);
            position.X = 150;
            Canvas.SetLeft(MauerDrei, position.X);

            meinCanvas.Children.Add(MauerDrei);
        }
        private void VierteMauerSetzen()
        {
            MauerVier.Height = 40;
            MauerVier.Width = 350;
            MauerVier.Source = new Uri(@"C:\Users\Gummi\source\repos\Snake_Clon\Snake_Clon\Grafiken\MauerHindernisHori.png");
            MauerVier.Stretch = System.Windows.Media.Stretch.UniformToFill;
            MauerVier.Name = "Grenze";

            //position der Mauer setzen
            position.Y = meinCanvas.ActualHeight / 2;
            Canvas.SetTop(MauerVier, position.Y);
            position.X = 150;
            Canvas.SetLeft(MauerVier, position.X);

            meinCanvas.Children.Add(MauerVier);
        }
        private void FünfteMauerSetzen()
        {
            MauerFünf.Height = 40;
            MauerFünf.Width = 350;
            MauerFünf.Source = new Uri(@"C:\Users\Gummi\source\repos\Snake_Clon\Snake_Clon\Grafiken\MauerHindernisHori.png");
            MauerFünf.Stretch = System.Windows.Media.Stretch.UniformToFill;
            MauerFünf.Name = "Grenze";

            //position der Mauer setzen
            position.Y = meinCanvas.ActualHeight / 4 * 3;
            Canvas.SetTop(MauerFünf, position.Y);
            position.X = 150;
            Canvas.SetLeft(MauerFünf, position.X);

            meinCanvas.Children.Add(MauerFünf);
        }

        private void SechsteMauerSetzen()
        {
            HoriMauerEins.Height = 40;
            HoriMauerEins.Width = 350;
            HoriMauerEins.Source = new Uri(@"C:\Users\Gummi\source\repos\Snake_Clon\Snake_Clon\Grafiken\MauerHindernisHori.png");
            HoriMauerEins.Stretch = System.Windows.Media.Stretch.UniformToFill;
            HoriMauerEins.Name = "Grenze";

            //position der Mauer setzen
            position.Y = meinCanvas.ActualHeight / 4;
            Canvas.SetTop(HoriMauerEins, position.Y);
            position.X = meinCanvas.ActualWidth - 500;
            Canvas.SetLeft(HoriMauerEins, position.X);

            meinCanvas.Children.Add(HoriMauerEins);
        }

        private void SiebteMauerSetzen()
        {
            HoriMauerZwei.Height = 40;
            HoriMauerZwei.Width = 350;
            HoriMauerZwei.Source = new Uri(@"C:\Users\Gummi\source\repos\Snake_Clon\Snake_Clon\Grafiken\MauerHindernisHori.png");
            HoriMauerZwei.Stretch = System.Windows.Media.Stretch.UniformToFill;
            HoriMauerZwei.Name = "Grenze";

            //position der Mauer setzen
            position.Y = meinCanvas.ActualHeight / 2;
            Canvas.SetTop(HoriMauerZwei, position.Y);

            position.X = meinCanvas.ActualWidth - 500;
            Canvas.SetLeft(HoriMauerZwei, position.X);

            meinCanvas.Children.Add(HoriMauerZwei);
        }

        private void AchteMauerSetzen()
        {
            HoriMauerDrei.Height = 40;
            HoriMauerDrei.Width = 350;
            HoriMauerDrei.Source = new Uri(@"C:\Users\Gummi\source\repos\Snake_Clon\Snake_Clon\Grafiken\MauerHindernisHori.png");
            HoriMauerDrei.Stretch = System.Windows.Media.Stretch.UniformToFill;
            HoriMauerDrei.Name = "Grenze";

            //position der Mauer setzen
            position.Y = meinCanvas.ActualHeight / 4 * 3;
            Canvas.SetTop(HoriMauerDrei, position.Y);

            position.X = meinCanvas.ActualWidth - 500;
            Canvas.SetLeft(HoriMauerDrei, position.X);

            meinCanvas.Children.Add(HoriMauerDrei);
        }
    }
}
