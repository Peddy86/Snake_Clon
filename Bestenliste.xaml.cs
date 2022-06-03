using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Snake_Clon
{
    /// <summary>
    /// Interaktionslogik für Bestenliste.xaml
    /// </summary>
    public partial class Bestenliste : Window
    {
        Label meinLabel;
        public Bestenliste(List<string> eintraege)
        {
            InitializeComponent();

            //zum zählen der Spalten
            int zaehlerZeile = 1;
            int zaehlerSpalte = 0;

            //die Einträge in der Liste verarbeiten
            foreach (string  zeichenkette in eintraege)
            {
                meinLabel = new Label();
                meinLabel.Content = zeichenkette;

                //im Grid Positionieren
                Grid.SetRow(meinLabel, zaehlerZeile);
                Grid.SetColumn(meinLabel, zaehlerSpalte);

                meinGrid.Children.Add(meinLabel);
                zaehlerSpalte++;

                if (zaehlerSpalte == 2)
                {
                    zaehlerSpalte = 0;
                    zaehlerZeile++;
                    meinGrid.RowDefinitions.Add(new RowDefinition());
                }


            }
        }
    }
}
