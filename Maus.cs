using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows; 

namespace Snake_Clon
{
    internal class Maus : PunkteObjekteI
    {
        public int Groesse { get; set; }
        public MediaElement PunkteBild { get;  set; }
        public int Punktzahl { get; set; }

        Random zufall;
        Point position;

        public Maus(int groesse, Canvas meinCanvas)
        {
            Groesse = groesse;
            PunkteBild = new MediaElement();
            Punktzahl = 100;
            zufall = new Random(GetHashCode());
            position = new Point();            
        }

        public void Anzeigen(Canvas meinCanvas,int breite)
        {
            //das Maximun für das erscheinen der Mäuse ermitteln
            int maxX = (int)meinCanvas.ActualWidth - breite - Groesse;
            int maxY = (int)meinCanvas.ActualHeight - breite - Groesse;

            position.X = zufall.Next(breite, maxX);
            position.Y = zufall.Next(breite, maxY);

            //positionieren
            Canvas.SetLeft(PunkteBild, position.X);
            Canvas.SetTop(PunkteBild, position.Y);

            PunkteBild.Width = Groesse;
            PunkteBild.Height = Groesse;
            PunkteBild.Source = new Uri(@"C:\Users\Gummi\source\repos\Snake_Clon\Snake_Clon\Grafiken\Maus.jpg");           
            //namen vergeben            
            PunkteBild.Name = "Maus";

            meinCanvas.Children.Add(PunkteBild);
        }

        public void Entfernen(Canvas meinCanvas)
        {
            meinCanvas.Children.Remove(PunkteBild);
        }
        
        public void Bewegen(Canvas meinCanvas, int zufallsRichtung)
        {
            Entfernen(meinCanvas);
            switch (zufallsRichtung)
            {
                case 0:
                    Canvas.SetLeft(PunkteBild, position.X--);
                    break;
                case 1:
                    Canvas.SetLeft(PunkteBild, position.X++);
                    break;
                case 2:
                    Canvas.SetTop(PunkteBild, position.Y++);
                    break;
                case 3:
                    Canvas.SetTop(PunkteBild, position.Y--);
                    break;
            }

            meinCanvas.Children.Add(PunkteBild);
        }

        public Point GetPosition()
        {
            return new Point(position.X, position.Y);
        }
    }
}
