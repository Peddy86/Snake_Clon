using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Snake_Clon
{
    internal class HorizontaleMauer : Mauer
    {
        MediaElement HorizontaleMauerBild;
        public HorizontaleMauer(Canvas meinCanvas, int positionHoehe) : base(meinCanvas, positionHoehe)
        {
            HorizontaleMauerBild = new MediaElement();
            Canvas.SetTop(HorizontaleMauerBild, position.X);

            HorizontaleMauerBild.Width = 180;
            HorizontaleMauerBild.Height = 50;
            HorizontaleMauerBild.Source = new Uri(@"C:\Users\Gummi\source\repos\Snake_Clon\Snake_Clon\Grafiken\MauerHindernisHori.png");

            //namen vergeben            
            HorizontaleMauerBild.Name = "Grenze";
        }

        public void BewegenHori(Canvas meinCanvas, int HorizontalePosition)
        {
            meinCanvas.Children.Remove(HorizontaleMauerBild);

            position.Y = HorizontalePosition;
            Canvas.SetLeft(HorizontaleMauerBild, position.Y);

            if (position.X != meinCanvas.ActualWidth && dazuzaehlen == true)
            {
                Canvas.SetLeft(HorizontaleMauerBild, position.X++);

                if (position.X == 1250)
                    dazuzaehlen = false;
            }

            if (position.X != 0 && dazuzaehlen == false)
            {
                Canvas.SetLeft(HorizontaleMauerBild, position.X--);

                if (position.X == 1)
                    dazuzaehlen = true;
            }

            meinCanvas.Children.Add(HorizontaleMauerBild);
        }
    }
}
