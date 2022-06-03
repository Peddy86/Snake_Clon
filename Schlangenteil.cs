using System;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Windows.Controls.Primitives;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Snake_Clon
{
    internal class Schlangenteil : Button
    {
        protected Point Position;
        protected Point AltePosition;     
        protected int Groesse;
        MediaElement SchlangenteilBild;
        protected MediaElement SchlangenKopfBild;
        public Schlangenteil(Point position)
        {
            Position.X = position.X;
            Position.Y = position.Y;    

            AltePosition.X = Position.X;
            AltePosition.Y = Position.Y; 

            Groesse = 20;
            SchlangenteilBild = new MediaElement();
        }

        //eine Leere Methode
        virtual public void Bewegen(int richtung)
        {
            
        }

        //neue Position
        public void SetzePosition(Point neuePosition)
        {
            AltePosition = Position;
            Position = neuePosition;
        }

        //das Teil im Spielfeld anzeigen
        virtual public void ZeichneTeil(Canvas meinCanvas)
        {            
            meinCanvas.Children.Remove(SchlangenteilBild);

            SchlangenteilBild.Name = "Schlange";
            SchlangenteilBild.Source = new Uri(@"C:\Users\Gummi\source\repos\Snake_Clon\Snake_Clon\Grafiken\Schlangenkörper.jpg");
            //positionieren
            Canvas.SetLeft(SchlangenteilBild, Position.X);
            Canvas.SetTop(SchlangenteilBild, Position.Y);

            //die Größe 
            SchlangenteilBild.Width = Groesse;
            SchlangenteilBild.Height = Groesse;

            //hinzufügen
            meinCanvas.Children.Add(SchlangenteilBild);               
        }

        //alte Position liefern
        public Point GetAltePosition()
        {
            return AltePosition;
        }

        //Größe liefern
        public int GetGroesse()
        {
            return Groesse;
        }

        public virtual Point GetPosition()
        {
            return Position;
        }
    }
}
