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
using FingerPrintScanner.src.controller;

namespace FingerPrintScanner.src.view {
    /// <summary>
    /// Interaction logic for NewUserAddition.xaml
    /// </summary>
    public partial class NewUserAddition : Window {
        private Dashboard dashboard_obj;
        
        private UpdateUserInformation uui_obj;
        private SearchInformation si_obj;
        private ExportDataToPdfCsv edpc_obj;
        private PrintSearchResult psr_obj;
        private RecoverAdminPassword rap_obj;
        private UpdateAdminInformation uai_obj;
        private UsageManual um_obj;

        private UserHandler uh ;        

        public NewUserAddition() {
            InitializeComponent();
            this.dashboard_obj = null;
            XamlEntityDesignerReference.designNewMenu( this.menu1 ) ;
            this.uh = new UserHandler() ;            
        }

        private void loadDataToGroupBox() {
            int i , sz ;
            List< string > adj = new List<string>() ;
            string[ , ] arr = this.uh.getAllEmptyFullNameUsers() ;
            sz = this.uh.getDataSize() ;            
            for( i = 0 ; i < sz ; i++ ) {
                adj.Add( arr[ i , 0 ] ) ;
            }
            this.combobox1.ItemsSource = adj ;
        }

        private void Window_Closed( object sender , EventArgs e ) {
            this.cleanObjects();
        }

        private void cleanObjects() {
            if( this.dashboard_obj != null ) {
                this.dashboard_obj.Close();
            }            
            if( this.uui_obj != null ) {
                this.uui_obj.Close();
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
            this.uui_obj = new UpdateUserInformation();
            this.uui_obj.setReference( this.dashboard_obj );
            this.uui_obj.Visibility = Visibility.Hidden;
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
            this.Visibility = Visibility.Hidden ;
            this.dashboard_obj.Visibility = Visibility.Visible ;
        }

        public void newUserAdditionClick( Object o , EventArgs ea ) {            
        }

        public void viewUserDetailsClick( Object o , EventArgs ea ) {
            this.Visibility = Visibility.Hidden ;
            this.dashboard_obj.doStateTransition( 2 ) ;
        }

        public void updateUserInformationClick( Object o , EventArgs ea ) {
            this.Visibility = Visibility.Hidden ;
            this.dashboard_obj.doStateTransition( 3 ) ;
        }

        public void searchInformationClick( Object o , EventArgs ea ) {
            this.Visibility = Visibility.Hidden ;
            this.dashboard_obj.doStateTransition( 4 ) ;
        }

        public void exportDataToPdfCsvClick( Object o , EventArgs ea ) {
            this.Visibility = Visibility.Hidden ;
            this.dashboard_obj.doStateTransition( 5 ) ;
        }

        public void printSearchResultClick( Object o , EventArgs ea ) {
            this.Visibility = Visibility.Hidden ;
            this.dashboard_obj.doStateTransition( 6 ) ;
        }

        public void recoverAdminPaswordClick( Object o , EventArgs ea ) {
            this.Visibility = Visibility.Hidden ;
            this.dashboard_obj.doStateTransition( 7 ) ;
        }

        public void updateAdminInformationClick( Object o , EventArgs ea ) {
            this.Visibility = Visibility.Hidden ;
            this.dashboard_obj.doStateTransition( 8 ) ;
        }

        public void usageManualClick( Object o , EventArgs ea ) {
            this.Visibility = Visibility.Hidden ;
            this.dashboard_obj.doStateTransition( 9 ) ;
        }

        public void exitClick( Object o , EventArgs ea ) {
            this.Close() ;
        }

        private void Button_Click( object sender , RoutedEventArgs e ) {
            if( this.combobox1.Items.Count == 0 ) {
                System.Windows.MessageBox.Show( "All the enroll ids has already been assigned!" ) ;
                return ;
            }
            if( this.combobox1.Text == "" || this.tbx1.Text == "" || this.tbx2.Text == "" || this.tbx3.Text == "" || this.tbx4.Text == "" || this.tbx5.Text == "" || this.tbx6.Text == "" || this.dtp1.Text == "" ) {
                System.Windows.MessageBox.Show( "Please Fill Out All the Required Information!" ) ;
                return ;
            }
            string[] brr ;
            brr = new string[ 20 ] ;
            brr[ 0 ] = this.combobox1.Text ;
            brr[ 1 ] = this.tbx1.Text ;
            brr[ 2 ] = this.tbx2.Text ;
            brr[ 3 ] = this.tbx3.Text ;
            brr[ 4 ] = this.dtp1.Text;
            brr[ 5 ] = this.tbx4.Text;
            brr[ 6 ] = this.tbx5.Text ;
            brr[ 7 ] = this.tbx6.Text ;
            brr[ 8 ] = this.dtp2.Text ;
            this.uh.updateUser( brr ) ;
            System.Windows.MessageBox.Show( "User Created Successfully!" ) ;
            this.dashboard_obj.Visibility = Visibility.Visible ;
            this.Visibility = Visibility.Hidden ;
        }

        private void Window_IsVisibleChanged( object sender , DependencyPropertyChangedEventArgs e ) {
            if( this.Visibility == Visibility.Visible ) {
                this.loadDataToGroupBox();
            }
        }
    }
}
