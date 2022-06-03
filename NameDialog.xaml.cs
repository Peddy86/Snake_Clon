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
    /// Interaktionslogik für NameDialog.xaml
    /// </summary>
    public partial class NameDialog : Window
    {
        public NameDialog()
        {
            InitializeComponent();
        }

        public string GetNamen()
        {
            return Name_txb.Text;   
        }

        private void Uebernehmen_btn_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}
