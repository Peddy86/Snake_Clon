using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;

namespace Snake_Clon
{
    
    internal class LevelEinsLabyrinth
    {
        MediaElement MauerEins,MauerZwei, MauerDrei, MauerVier, MauerFünf, HoriMauerEins, HoriMauerZwei, HoriMauerDrei;
        Point position;
        Canvas meinCanvas;

        public LevelEinsLabyrinth(Canvas spielfeld)
        {
            MauerEins = new MediaElement();
            MauerZwei = new MediaElement();
            MauerDrei = new MediaElement();
            MauerVier = new MediaElement();
            MauerFünf = new MediaElement();
            HoriMauerEins = new MediaElement();
            HoriMauerZwei = new MediaElement();
            HoriMauerDrei=new MediaElement();

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

            //Horizontale Mauern
            HoriMauerEinsSetzen();
            HoriMauerZweiSetzen();
            HoriMauerDreiSetzen();
        }

        private void ErsteMauerSetzen()
        {
            MauerEins.Height = meinCanvas.ActualHeight / 3 + 100;
            MauerEins.Width = 40;
            MauerEins.Source = new Uri(@"C:\Users\Gummi\source\repos\Snake_Clon\Snake_Clon\Grafiken\MauerHindernis.png");
            MauerEins.Stretch = System.Windows.Media.Stretch.UniformToFill;
            MauerEins.Name = "Grenze";

            //position der Mauer setzen
            position.Y = 16;
            Canvas.SetTop(MauerEins, position.Y);
            position.X = 270;
            Canvas.SetLeft(MauerEins, position.X);

            meinCanvas.Children.Add(MauerEins);
        }
        private void ZweiteMauerSetzen()
        {
            MauerZwei.Height = meinCanvas.ActualHeight / 3 + 150;
            MauerZwei.Width = 40;
            MauerZwei.Source = new Uri(@"C:\Users\Gummi\source\repos\Snake_Clon\Snake_Clon\Grafiken\MauerHindernis.png");
            MauerZwei.Stretch = System.Windows.Media.Stretch.UniformToFill;
            MauerZwei.Name = "Grenze";

            //position der Mauer setzen
            position.Y = meinCanvas.ActualHeight - MauerZwei.Height - 16;
            Canvas.SetTop(MauerZwei, position.Y);
            position.X = 400;
            Canvas.SetLeft(MauerZwei, position.X);

            meinCanvas.Children.Add(MauerZwei);
        }
        private void DritteMauerSetzen()
        {
            MauerDrei.Height = meinCanvas.ActualHeight - 200;
            MauerDrei.Width = 40;
            MauerDrei.Source = new Uri(@"C:\Users\Gummi\source\repos\Snake_Clon\Snake_Clon\Grafiken\MauerHindernis.png");
            MauerDrei.Stretch = System.Windows.Media.Stretch.UniformToFill;
            MauerDrei.Name = "Grenze";

            //position der Mauer setzen
            position.Y = 16;
            Canvas.SetTop(MauerDrei, position.Y);
            position.X = 850;
            Canvas.SetLeft(MauerDrei, position.X);

            meinCanvas.Children.Add(MauerDrei);
        }
        private void VierteMauerSetzen()
        {
            MauerVier.Height = 100;
            MauerVier.Width = 40;
            MauerVier.Source = new Uri(@"C:\Users\Gummi\source\repos\Snake_Clon\Snake_Clon\Grafiken\MauerHindernis.png");
            MauerVier.Stretch = System.Windows.Media.Stretch.UniformToFill;
            MauerVier.Name = "Grenze";

            //position der Mauer setzen
            position.Y = meinCanvas.ActualHeight - MauerVier.Height - 16;
            Canvas.SetTop(MauerVier, position.Y);
            position.X = 850;
            Canvas.SetLeft(MauerVier, position.X);

            meinCanvas.Children.Add(MauerVier);
        }
        private void FünfteMauerSetzen()
        {
            MauerFünf.Height = 600;
            MauerFünf.Width = 40;
            MauerFünf.Source = new Uri(@"C:\Users\Gummi\source\repos\Snake_Clon\Snake_Clon\Grafiken\MauerHindernis.png");
            MauerFünf.Stretch = System.Windows.Media.Stretch.UniformToFill;
            MauerFünf.Name = "Grenze";

            //position der Mauer setzen
            position.Y = meinCanvas.ActualHeight - MauerFünf.Height - 16;
            Canvas.SetTop(MauerFünf, position.Y);
            position.X = 1100;
            Canvas.SetLeft(MauerFünf, position.X);

            meinCanvas.Children.Add(MauerFünf);
        }

        private void HoriMauerEinsSetzen()
        {
            HoriMauerEins.Height = 40;
            HoriMauerEins.Width = 180;
            HoriMauerEins.Source = new Uri(@"C:\Users\Gummi\source\repos\Snake_Clon\Snake_Clon\Grafiken\MauerHindernisHori.png");
            HoriMauerEins.Stretch = System.Windows.Media.Stretch.UniformToFill;
            HoriMauerEins.Name = "Grenze";

            //position der Mauer setzen
            position.Y = meinCanvas.ActualHeight / 2 + 80;
            Canvas.SetTop(HoriMauerEins, position.Y);
            position.X = 16;
            Canvas.SetLeft(HoriMauerEins, position.X);

            meinCanvas.Children.Add(HoriMauerEins);
        }

        private void HoriMauerZweiSetzen()
        {
            HoriMauerZwei.Height = 40;
            HoriMauerZwei.Width = 250;
            HoriMauerZwei.Source = new Uri(@"C:\Users\Gummi\source\repos\Snake_Clon\Snake_Clon\Grafiken\MauerHindernisHori.png");
            HoriMauerZwei.Stretch = System.Windows.Media.Stretch.UniformToFill;
            HoriMauerZwei.Name = "Grenze";

            //position der Mauer setzen
            position.Y = meinCanvas.ActualHeight / 3 - 150;
            Canvas.SetTop(HoriMauerZwei, position.Y);

            position.X = 310;
            Canvas.SetLeft(HoriMauerZwei, position.X);

            meinCanvas.Children.Add(HoriMauerZwei);
        }

        private void HoriMauerDreiSetzen()
        {
            HoriMauerDrei.Height = 40;
            HoriMauerDrei.Width = 150;
            HoriMauerDrei.Source = new Uri(@"C:\Users\Gummi\source\repos\Snake_Clon\Snake_Clon\Grafiken\MauerHindernisHori.png");
            HoriMauerDrei.Stretch = System.Windows.Media.Stretch.UniformToFill;
            HoriMauerDrei.Name = "Grenze";

            //position der Mauer setzen
            position.Y = meinCanvas.ActualHeight / 2;
            Canvas.SetTop(HoriMauerDrei, position.Y);

            position.X = meinCanvas.ActualWidth - HoriMauerDrei.Width - 16;
            Canvas.SetLeft(HoriMauerDrei, position.X);

            meinCanvas.Children.Add(HoriMauerDrei);
        }

    }
}
