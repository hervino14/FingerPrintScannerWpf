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
    /// Interaction logic for Dashboard.xaml
    /// </summary>
    public partial class Dashboard : Window {        
        private UserLogHandler ulh;
        private Login login_object;
        private NewUserAddition nua_obj;
        private VIewUserDetails vud_obj;
        public UpdateUserInformation uui_obj;
        private SearchInformation si_obj;
        private ExportDataToPdfCsv edpc_obj;
        private PrintSearchResult psr_obj;
        private RecoverAdminPassword rap_obj;
        private UpdateAdminInformation uai_obj;
        private UsageManual um_obj;

        public Dashboard() {
            InitializeComponent();
            this.initializeScreen();
            this.init();
        }

        private void init() {
            /*
            XamlEntityDesignerReference.designNewButton( "Logoff" , this.btn1 ) ;
            XamlEntityDesignerReference.designNewButton( "Admin Panel" , this.btn2 ) ;
            XamlEntityDesignerReference.designNewButton( "Search" , this.btn3 ) ;
            XamlEntityDesignerReference.designNewButton( "Export To PDF" , this.btn4 ) ;
            XamlEntityDesignerReference.designNewLabel( "Start Time:" , this.lbl1 ) ;
            XamlEntityDesignerReference.designNewLabel( "End Time:" , this.lbl2 ) ;
            XamlEntityDesignerReference.designNewLabel( "Latest Login Information:" , this.lbl3 ) ;
            XamlEntityDesignerReference.designNewDataGrid( this.dgrid1 ) ;
            this.ulh = new UserLogHandler() ;
            */
            XamlEntityDesignerReference.designNewMenu( this.menu1 ) ;
            this.initAllChildObjects() ;
            this.loadDataGridData() ;
            //PdfHandler.exportToPdf( this.dgrid1 );
        }

        private void loadDataGridData() {
            UserEntryHandler ueh = new UserEntryHandler() ;
            ueh.loadLastTenEntryToDataGrid( this.dgrid1 ) ;
        }

        public void doStateTransition( int state_id_param ) {
            this.Visibility = Visibility.Hidden ;
            this.nua_obj.Visibility = Visibility.Hidden ;
            this.vud_obj.Visibility = Visibility.Hidden ;
            this.uui_obj.Visibility = Visibility.Hidden ;
            this.si_obj.Visibility = Visibility.Hidden ;
            this.edpc_obj.Visibility = Visibility.Hidden ;
            this.psr_obj.Visibility = Visibility.Hidden ;
            this.rap_obj.Visibility = Visibility.Hidden ;
            this.uai_obj.Visibility = Visibility.Hidden ;
            this.um_obj.Visibility = Visibility.Hidden ;
            if( state_id_param == 1 ) {
                this.nua_obj.Visibility = Visibility.Visible ;
            }
            else if( state_id_param == 2 ) {
                this.vud_obj.Visibility = Visibility.Visible;
            }
            else if( state_id_param == 3 ) {
                this.uui_obj.Visibility = Visibility.Visible ;
            }
            else if( state_id_param == 4 ) {
                this.si_obj.Visibility = Visibility.Visible ;
            }
            else if( state_id_param == 5 ) {
                this.edpc_obj.Visibility = Visibility.Visible ;
            }
            else if( state_id_param == 6 ) {
                this.psr_obj.Visibility = Visibility.Visible ;
            }
            else if( state_id_param == 7 ) {
                this.rap_obj.Visibility = Visibility.Visible ;
            }
            else if( state_id_param == 8 ) {
                this.uai_obj.Visibility = Visibility.Visible ;
            }
            else if( state_id_param == 9 ) {
                this.um_obj.Visibility = Visibility.Visible ;
            }
        }

        private void initAllChildObjects() {
            this.nua_obj = new NewUserAddition() ;
            this.nua_obj.setReference( this ) ;
            this.vud_obj = new VIewUserDetails();
            this.vud_obj.setReference( this );
            this.nua_obj.Visibility = Visibility.Hidden ;
            this.uui_obj = new UpdateUserInformation() ;
            this.uui_obj.setReference( this ) ;
            this.uui_obj.Visibility = Visibility.Hidden ;
            this.si_obj = new SearchInformation() ;
            this.si_obj.setReference( this ) ;
            this.si_obj.Visibility = Visibility.Hidden ;
            this.edpc_obj = new ExportDataToPdfCsv() ;
            this.edpc_obj.setReference( this ) ;
            this.edpc_obj.Visibility = Visibility.Hidden ;
            this.psr_obj = new PrintSearchResult() ;
            this.psr_obj.setReference( this ) ;
            this.psr_obj.Visibility = Visibility.Hidden ;
            this.rap_obj = new RecoverAdminPassword() ;
            this.rap_obj.setReference( this ) ;
            this.rap_obj.Visibility = Visibility.Hidden ;
            this.uai_obj = new UpdateAdminInformation() ;
            this.uai_obj.setReference( this ) ;
            this.uai_obj.Visibility = Visibility.Hidden ;
            this.um_obj = new UsageManual() ;
            this.um_obj.setReference( this ) ;
            this.um_obj.Visibility = Visibility.Hidden ;
        }

        public void setReference( Login login_param ) {
            this.login_object = login_param ;
        }

        private void initializeScreen() {
            this.WindowState = System.Windows.WindowState.Maximized ;
            this.ResizeMode = ResizeMode.CanMinimize ;
            this.main_grid.VerticalAlignment = VerticalAlignment.Top ;
            this.main_grid.HorizontalAlignment = HorizontalAlignment.Left ;
        }

        private void Window_Closed( object sender , EventArgs e ) {
            this.cleanObjects() ;
        }

        private void cleanObjects() {
            if( this.login_object != null ) {
                this.login_object.Close() ;
            }
            if( this.nua_obj != null ) {
                this.nua_obj.Close() ;
            }
            if( this.vud_obj != null ) {
                this.vud_obj.Close();
            }
            if( this.uui_obj != null ) {
                this.uui_obj.Close() ;
            }
            if( this.si_obj != null ) {
                this.si_obj.Close() ;
            }
            if( this.edpc_obj != null ) {
                this.edpc_obj.Close() ;
            }
            if( this.psr_obj != null ) {
                this.psr_obj.Close() ;
            }
            if( this.rap_obj != null ) {
                this.rap_obj.Close() ;
            }
            if( this.uai_obj != null ) {
                this.uai_obj.Close() ;
            }
            if( this.um_obj != null ) {
                this.um_obj.Close() ;
            }
        }

        private void btn1_Click( object sender , RoutedEventArgs e ) {
            this.Close() ;
        }

        private void btn3_Click( object sender , RoutedEventArgs e ) {
            /*
            string start_time = this.dtp1.Text.ToString();
            string end_time = this.dtp2.Text.ToString();
            if( start_time == "" ) {
                MessageBox.Show( "Please Provide Start-Time!" ) ;
                return ;
            }
            if( end_time == "" ) {
                MessageBox.Show( "Please Provide End-Time!" ) ;
                return ;
            }            
            this.ulh.getAndSetQueryResult( this.dgrid1 , start_time , end_time ) ;
            */
        }

        private void Button_Click( object sender , RoutedEventArgs e ) {
            /*
            DataGridViewLoader.exportToPdf( this.dgrid1 );
            */
        }

        public void homeClick( Object o , EventArgs ea ) {

        }

        public void newUserAdditionClick( Object o , EventArgs ea ) {            
            this.Visibility = Visibility.Hidden;
            this.nua_obj.Visibility = Visibility.Visible ;
        }

        public void viewUserDetailsClick( Object o , EventArgs ea ) {
            this.Visibility = Visibility.Hidden;
            this.vud_obj.Visibility = Visibility.Visible ;
        }

        public void updateUserInformationClick( Object o , EventArgs ea ) {
            this.Visibility = Visibility.Hidden;
            this.uui_obj.Visibility = Visibility.Visible ;
        }

        public void searchInformationClick( Object o , EventArgs ea ) {
            this.Visibility = Visibility.Hidden;
            this.si_obj.Visibility = Visibility.Visible ;
        }

        public void exportDataToPdfCsvClick( Object o , EventArgs ea ) {
            this.Visibility = Visibility.Hidden;
            this.edpc_obj.Visibility = Visibility.Visible ;
        }

        public void printSearchResultClick( Object o , EventArgs ea ) {
            this.Visibility = Visibility.Hidden;
            this.psr_obj.Visibility = Visibility.Visible ;
        }

        public void recoverAdminPaswordClick( Object o , EventArgs ea ) {
            this.Visibility = Visibility.Hidden;
            this.rap_obj.Visibility = Visibility.Visible ;
        }

        public void updateAdminInformationClick( Object o , EventArgs ea ) {
            this.Visibility = Visibility.Hidden;
            this.uai_obj.Visibility = Visibility.Visible ;
        }

        public void usageManualClick( Object o , EventArgs ea ) {
            this.Visibility = Visibility.Hidden;
            this.um_obj.Visibility = Visibility.Visible ;
        }

        public void exitClick( Object o , EventArgs ea ) {
            this.Close() ;
        }

        private void Window_IsVisibleChanged( object sender , DependencyPropertyChangedEventArgs e ) {
            if( this.Visibility == Visibility.Visible ) {
                this.loadDataGridData() ;
            }
        }
    }
}

