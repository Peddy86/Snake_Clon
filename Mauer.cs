using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;

namespace Snake_Clon
{
    internal class Mauer    
    {        
        MediaElement MauerBild { get; set; }        
        protected Point position;
        protected bool dazuzaehlen;


        public Mauer(Canvas meinCanvas, int positionHoehe)
        {
            MauerBild = new MediaElement();

            position.X = positionHoehe;            
            //mittig positionieren            
            Canvas.SetTop(MauerBild, position.X);

            MauerBild.Width = 50;
            MauerBild.Height = 180;
            MauerBild.Source = new Uri(@"C:\Users\Gummi\source\repos\Snake_Clon\Snake_Clon\Grafiken\MauerHindernis.png");

            //namen vergeben            
            MauerBild.Name = "Grenze";            

            dazuzaehlen = false;
        }

        public void Entfernen(Canvas meinCanvas)
        {
            meinCanvas.Children.Remove(MauerBild);
        }

        public void Bewegen(Canvas meinCanvas, int spaltenPosition)
        {
            meinCanvas.Children.Remove(MauerBild);

            position.Y = spaltenPosition;
            Canvas.SetLeft(MauerBild, position.Y);

            if (position.X != meinCanvas.ActualHeight && dazuzaehlen == true)
            {                
                Canvas.SetTop(MauerBild, position.X++);  
                
                if (position.X == 530)
                    dazuzaehlen = false;
            }
            
            if(position.X != 0 && dazuzaehlen == false)
            {                
                Canvas.SetTop(MauerBild, position.X--);  
                
                if (position.X == 1)
                    dazuzaehlen = true;
            }

            meinCanvas.Children.Add(MauerBild);
        }

        
    }
}
