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

namespace FingerPrintScanner.src.view {
    /// <summary>
    /// Interaction logic for AdminPanel.xaml
    /// </summary>
    public partial class AdminPanel : Window {
        private Dashboard db;
        public AdminPanel() {
            InitializeComponent();
        }

        public void setReference( Dashboard db_param ) {
            this.db = db_param;
        }
    }
}
