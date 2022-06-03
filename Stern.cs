using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Snake_Clon
{
    internal class Stern : PunkteObjekteI
    {
        public int Groesse { get; set; }
        public MediaElement PunkteBild { get; set; }
        public int Punktzahl { get; set; }
        Point position;

        public Stern(int groesse)
        {
            PunkteBild = new MediaElement();
            Groesse = groesse;
            Punktzahl = 300;
            position = new Point();
            PunkteBild.Source = new Uri(@"C:\Users\Gummi\source\repos\Snake_Clon\Snake_Clon\Grafiken\Stern.png");
        }

        public void Anzeigen(Canvas meinCanvas, int balkenbreite)
        {
            Random zufall = new Random();
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
            PunkteBild.Source = new Uri(@"C:\Users\Gummi\source\repos\Snake_Clon\Snake_Clon\Grafiken\Stern.png");

            //namen vergeben            
            PunkteBild.Name = "Stern";

            meinCanvas.Children.Add(PunkteBild);
        }

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
