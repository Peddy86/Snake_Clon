using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Controls;

namespace Snake_Clon
{
    internal class Schlangenkopf : Schlangenteil
    {
        
        public Schlangenkopf(Point position) : base(position)
        {
            SchlangenKopfBild = new MediaElement();
        }

        public override void ZeichneTeil(Canvas meinCanvas)
        {
            meinCanvas.Children.Remove(SchlangenKopfBild);
            SchlangenKopfBild.Source = new Uri(@"C:\Users\Gummi\source\repos\Snake_Clon\Snake_Clon\Grafiken\SchlangeKopf.jpg");     
            
            //positionieren
            Canvas.SetLeft(SchlangenKopfBild, Position.X);
            Canvas.SetTop(SchlangenKopfBild, Position.Y);

            //die Größe 
            SchlangenKopfBild.Width = Groesse;
            SchlangenKopfBild.Height = Groesse;

            //hinzufügen
            meinCanvas.Children.Add(SchlangenKopfBild);
        }
        public override void Bewegen(int richtung)
        {
            //alte Position speichern
            AltePosition = Position;
            //richtung wechseln
            switch (richtung)
            {
                //oben
                case 0:
                    Position.Y = Position.Y - Groesse;
                    break;
                //rechts
                case 1:
                    Position.X = Position.X + Groesse;
                    break;
                //unten
                case 2:
                    Position.Y = Position.Y + Groesse;
                    break;
                //links
                case 3:
                    Position.X = Position.X - Groesse;
                    break;
            }
        }

        public override Point GetPosition()
        {
            return (new Point(Position.X + (Groesse/2), Position.Y + (Groesse / 2)));
        }

    }
}
