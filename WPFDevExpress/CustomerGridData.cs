using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Data;
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Xpf.Grid;
using WPFDevExpress.Models;

namespace WPFDevExpress
{
    class CustomerGridData : IGridData
    {
        private readonly GridControl _grid;

        public CustomerGridData(GridControl grid)
        {
            _grid = grid;
        }

        public void ConfigureGrid()
        {
            _grid.Columns.Clear();
            var column = new GridColumn { FieldName = "Customer ID", Binding = new Binding("CustomerID"), VisibleIndex = 0 };
            _grid.Columns.Add(column);
            column = new GridColumn { FieldName = "Company Name", Binding = new Binding("CompanyName"), VisibleIndex = 1 };
            _grid.Columns.Add(column);
            column = new GridColumn { FieldName = "Contact Name", Binding = new Binding("ContactName"), VisibleIndex = 2 };
            _grid.Columns.Add(column);
            column = new GridColumn { FieldName = "Contact Title", Binding = new Binding("ContactTitle"), VisibleIndex = 3 };
            _grid.Columns.Add(column);
            column = new GridColumn { FieldName = "Address", Binding = new Binding("Address"), VisibleIndex = 4 };
            _grid.Columns.Add(column);
            column = new GridColumn { FieldName = "City", Binding = new Binding("City"), VisibleIndex = 5 };
            _grid.Columns.Add(column);
            column = new GridColumn { FieldName = "Region", Binding = new Binding("Region"), VisibleIndex = 6 };
            _grid.Columns.Add(column);
            column = new GridColumn { FieldName = "Postal Code", Binding = new Binding("PostalCode"), VisibleIndex = 7 };
            _grid.Columns.Add(column);
            column = new GridColumn { FieldName = "Country", Binding = new Binding("Country"), VisibleIndex = 8 };
            _grid.Columns.Add(column);
            column = new GridColumn { FieldName = "Phone", Binding = new Binding("Phone"), VisibleIndex = 9 };
            _grid.Columns.Add(column);
            column = new GridColumn { FieldName = "Fax", Binding = new Binding("Fax"), VisibleIndex = 10 };
            _grid.Columns.Add(column);
            column = new GridColumn { FieldName = "Order IDs", Binding = new Binding("OrderIDs"), VisibleIndex = 11 };
            _grid.Columns.Add(column);
        }

        public void LoadData()
        {
            List<Customer> data;
            using (var context = new northwindContext())
            {
                data = context.Customers.Include("Orders").ToList();
            }
            _grid.ItemsSource = data;
        }

        public void LoadData(DateTime? birth,DateTime? hire)
        {
            List<Customer> data;
            using (var context = new northwindContext())
            {
                data = context.Customers.Include("Orders").ToList();
            }
            _grid.ItemsSource = data;
        }
    }
}
