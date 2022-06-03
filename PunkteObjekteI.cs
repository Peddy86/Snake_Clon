using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Snake_Clon
{
    internal interface PunkteObjekteI
    {
        int Groesse { get; set; }  
        MediaElement PunkteBild { get; set; }
        int Punktzahl { get; set; }

        void Anzeigen(Canvas meinCanvas, int balkenbreite);
        void Entfernen(Canvas meinCanvas);
        Point GetPosition();

    }
}
