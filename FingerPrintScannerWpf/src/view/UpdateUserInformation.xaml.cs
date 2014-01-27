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
using FingerPrintScanner.src.controller ;

namespace FingerPrintScanner.src.view {
    /// <summary>
    /// Interaction logic for UpdateUserInformation.xaml
    /// </summary>
    public partial class UpdateUserInformation : Window {
        private Dashboard dashboard_obj;

        private NewUserAddition nua_obj;        
        private SearchInformation si_obj;
        private ExportDataToPdfCsv edpc_obj;
        private PrintSearchResult psr_obj;
        private RecoverAdminPassword rap_obj;
        private UpdateAdminInformation uai_obj;
        private UsageManual um_obj;       

        private UserHandler uh ;
 
        private string user_id ;

        public UpdateUserInformation() {
            InitializeComponent() ;
            this.dashboard_obj = null ;
            XamlEntityDesignerReference.designNewMenu( this.menu1 ) ;
            this.initAllObjects() ;            
        }

        private void initAllObjects() {
            this.uh = new UserHandler() ;
        }

        private void setInformation() {
            
            int i , sz , fl ;
            string[,] arr = this.uh.getAllUserInfo() ;
            sz = this.uh.getDataSize() ;
            fl = 0 ;            
            for( i = 0 ; i < sz ; i++ ) {
                if( this.user_id.CompareTo( arr[ i , 0 ] ) == 0 ) {
                    fl = 1 ;
                    break ;
                }
            }
            if( fl == 1 ) {
                tbx7.Text = arr[ i , 0 ] ;
                tbx1.Text = arr[ i , 1 ] ;
                tbx2.Text = arr[ i , 2 ] ;
                tbx3.Text = arr[ i , 3 ] ;
                dtp1.Text = arr[ i , 4 ] ;
                tbx4.Text = arr[ i , 5 ] ;
                tbx5.Text = arr[ i , 6 ] ;
                tbx6.Text = arr[ i , 7 ] ;
                dtp2.Text = arr[ i , 8 ] ;
            }            
        }

        private void Window_Closed( object sender , EventArgs e ) {
            this.cleanObjects();
        }

        private void cleanObjects() {
            if( this.dashboard_obj != null ) {
                this.dashboard_obj.Close();
            }
            if( this.nua_obj != null ) {
                this.nua_obj.Close();
            }            
            if( this.si_obj != null ) {
                this.si_obj.Close();
            }
            if( this.edpc_obj != null ) {
                this.edpc_obj.Close();
            }
            if( this.psr_obj != null ) {
                this.psr_obj.Close();
            }
            if( this.rap_obj != null ) {
                this.rap_obj.Close();
            }
            if( this.uai_obj != null ) {
                this.uai_obj.Close();
            }
            if( this.um_obj != null ) {
                this.um_obj.Close();
            }
        }

        public void setReference( Dashboard dashboard_obj_param ) {
            if( this.dashboard_obj == null ) {
                this.dashboard_obj = dashboard_obj_param;
            }
            //this.initAllChildObjects();
        }

        private void initAllChildObjects() {
            this.nua_obj = new NewUserAddition();
            this.nua_obj.setReference( this.dashboard_obj );
            this.nua_obj.Visibility = Visibility.Hidden;            
            this.si_obj = new SearchInformation();
            this.si_obj.setReference( this.dashboard_obj );
            this.si_obj.Visibility = Visibility.Hidden;
            this.edpc_obj = new ExportDataToPdfCsv();
            this.edpc_obj.setReference( this.dashboard_obj );
            this.edpc_obj.Visibility = Visibility.Hidden;
            this.psr_obj = new PrintSearchResult();
            this.psr_obj.setReference( this.dashboard_obj );
            this.psr_obj.Visibility = Visibility.Hidden;
            this.rap_obj = new RecoverAdminPassword();
            this.rap_obj.setReference( this.dashboard_obj );
            this.rap_obj.Visibility = Visibility.Hidden;
            this.uai_obj = new UpdateAdminInformation();
            this.uai_obj.setReference( this.dashboard_obj );
            this.uai_obj.Visibility = Visibility.Hidden;
            this.um_obj = new UsageManual();
            this.um_obj.setReference( this.dashboard_obj );
            this.um_obj.Visibility = Visibility.Hidden;
        }

        public void homeClick( Object o , EventArgs ea ) {
            this.Visibility = Visibility.Hidden;
            this.dashboard_obj.Visibility = Visibility.Visible;
        }

        public void newUserAdditionClick( Object o , EventArgs ea ) {
            this.Visibility = Visibility.Hidden;
            this.dashboard_obj.doStateTransition( 1 );
        }

        public void viewUserDetailsClick( Object o , EventArgs ea ) {
            this.Visibility = Visibility.Hidden;
            this.dashboard_obj.doStateTransition( 2 );
        }

        public void updateUserInformationClick( Object o , EventArgs ea ) {            
        }

        public void searchInformationClick( Object o , EventArgs ea ) {
            this.Visibility = Visibility.Hidden;
            this.dashboard_obj.doStateTransition( 4 );
        }

        public void exportDataToPdfCsvClick( Object o , EventArgs ea ) {
            this.Visibility = Visibility.Hidden;
            this.dashboard_obj.doStateTransition( 5 );
        }

        public void printSearchResultClick( Object o , EventArgs ea ) {
            this.Visibility = Visibility.Hidden;
            this.dashboard_obj.doStateTransition( 6 );
        }

        public void recoverAdminPaswordClick( Object o , EventArgs ea ) {
            this.Visibility = Visibility.Hidden;
            this.dashboard_obj.doStateTransition( 7 );
        }

        public void updateAdminInformationClick( Object o , EventArgs ea ) {
            this.Visibility = Visibility.Hidden;
            this.dashboard_obj.doStateTransition( 8 );
        }

        public void usageManualClick( Object o , EventArgs ea ) {
            this.Visibility = Visibility.Hidden;
            this.dashboard_obj.doStateTransition( 9 );
        }

        public void exitClick( Object o , EventArgs ea ) {
            this.Close();
        }        

        public void setUserId( string user_id_param ) {
            this.user_id = user_id_param ;
            this.setInformation() ;
        }

        private void Button_Click( object sender , RoutedEventArgs e ) {
            string[] brr;
            brr = new string[ 20 ];
            brr[ 0 ] = this.tbox7.Text;
            brr[ 1 ] = this.tbx1.Text;
            brr[ 2 ] = this.tbx2.Text;
            brr[ 3 ] = this.tbx3.Text;
            brr[ 4 ] = this.tbx4.Text;
            brr[ 5 ] = this.dtp1.Text;
            brr[ 6 ] = this.tbx5.Text;
            brr[ 7 ] = this.tbx6.Text;
            brr[ 8 ] = this.tbx6.Text;
            this.uh.updateUser( brr );
            System.Windows.MessageBox.Show( "User Information Updated Successfully!" );
            this.dashboard_obj.Visibility = Visibility.Visible;
            this.Visibility = Visibility.Hidden;
        }

        private void Button_Click_1( object sender , RoutedEventArgs e ) {
        }
    }
}
