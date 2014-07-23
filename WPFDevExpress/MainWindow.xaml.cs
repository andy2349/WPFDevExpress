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
using System.Windows.Navigation;
using System.Windows.Shapes;
using DevExpress.Data;
using DevExpress.Xpf.Bars;
using DevExpress.Xpf.Editors.Helpers;
using DevExpress.Xpf.Grid;
using WPFDevExpress.Models;

namespace WPFDevExpress
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IGridData _gridData;

        

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Refresh(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            _gridData.LoadData((DateTime?)DtpBirth.EditValue, (DateTime?)DtpHire.EditValue);
        }

        private void SelectCustomers(object sender, EventArgs e)
        {
            _gridData = new CustomerGridData(GridControl);
            _gridData.ConfigureGrid();
            _gridData.LoadData();
        }

        private void SelectEmployees(object sender, EventArgs e)
        {
            _gridData = new EmployeeGridData(GridControl);
            _gridData.ConfigureGrid();
            _gridData.LoadData((DateTime?)DtpBirth.EditValue, (DateTime?)DtpHire.EditValue);
        }

    }
}
