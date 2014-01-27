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
using FingerPrintScannerWpf.src.view;
using FingerPrintScanner.src.view ;
using FingerPrintScanner.src.controller;

namespace FingerPrintScanner.src.view {
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window {
        private Landing landing_obj ;
        private Dashboard dashboard_obj;
        public Login() {
            InitializeComponent();
            this.initializeScreen();
            this.init();
        }

        private void init() {
            XamlEntityDesignerReference.designNewLabel( "User Name:" , this.lbl1 );
            XamlEntityDesignerReference.designNewLabel( "Password:" , this.lbl2 );
            XamlEntityDesignerReference.designNewTextBox( this.tbox1 );
            XamlEntityDesignerReference.designNewPasswordBox( this.tbox2 );
            XamlEntityDesignerReference.designNewButton( "Login" , this.btn1 );
            dashboard_obj = new Dashboard();
            dashboard_obj.setReference( this );
        }

        public void setReference( Landing landing_obj_param ) {
            this.landing_obj = landing_obj_param ;
        }

        private void initializeScreen() {
            this.WindowState = System.Windows.WindowState.Maximized ;
            this.ResizeMode = ResizeMode.CanMinimize ;
            this.main_grid.VerticalAlignment = VerticalAlignment.Top ;
            this.main_grid.HorizontalAlignment = HorizontalAlignment.Left ;
        }

        private void Window_Closing( object sender , System.ComponentModel.CancelEventArgs e ) {            
        }

        private void btn1_Click( object sender , RoutedEventArgs e ) {            
            Button local_btn;
            local_btn = ( Button ) sender;
            UserHandler uh;
            int res;
            uh = new UserHandler();
            res = uh.checkAdmin( this.tbox1.Text , this.tbox2.Password );
            if( res == 1 ) {
                //login ok
                this.Visibility = Visibility.Hidden;
                this.dashboard_obj.Visibility = Visibility.Visible;
            }
            else {
                if( res == 2 ) {
                    MessageBox.Show( "Please Provide a User Name!" );
                }
                else if( res == 3 ) {
                    MessageBox.Show( "Please Provide Your Password!" );
                }
                else if( res == 4 ) {
                    MessageBox.Show( "Wrong Username Password Combination!" );
                }
            }
            this.tbox1.Text = "";
            this.tbox2.Password = "";
        }

        private void Window_Closed( object sender , EventArgs e ) {
            if( this.landing_obj != null ) {
                this.landing_obj.Close();
            }
        }
    }
}
