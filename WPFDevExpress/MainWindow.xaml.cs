using System;
using System.Windows;
using DevExpress.Xpf.Grid;

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

        private void CityFormat_EditValueChanged(object sender, RoutedEventArgs e)
        {
            this.TableView.FormatConditions.Clear();
            if ((string) TxtCity.EditValue == null) return;
            var format = new FormatCondition
            {
                Expression = "Contains([City], '" + TxtCity.EditValue + "')",
                FieldName = "City",
                PredefinedFormatName = "GreenFillWithDarkGreenText"
            };
            this.TableView.FormatConditions.Add(format);
        }
    }
}