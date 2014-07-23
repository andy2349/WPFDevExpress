using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Windows.Data;
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Xpf.Grid;
using WPFDevExpress.Models;

namespace WPFDevExpress
{
    class EmployeeGridData : IGridData
    {
        private readonly GridControl _grid;

        public EmployeeGridData(GridControl grid)
        {
            this._grid = grid;
        }

        public void ConfigureGrid()
        {
            _grid.Columns.Clear();
            var column = new GridColumn {FieldName = "Employee ID", Binding = new Binding("EmployeeID"), VisibleIndex = 0};
            _grid.Columns.Add(column);
            column = new GridColumn { FieldName = "Last Name", Binding = new Binding("LastName"), VisibleIndex = 1 };
            _grid.Columns.Add(column);
            column = new GridColumn { FieldName = "First Name", Binding = new Binding("FirstName"), VisibleIndex = 2 };
            _grid.Columns.Add(column);
            column = new GridColumn { FieldName = "Title", Binding = new Binding("Title"), VisibleIndex = 3 };
            _grid.Columns.Add(column);
            column = new GridColumn { FieldName = "Title Of Courtesy", Binding = new Binding("TitleOfCourtesy"), VisibleIndex = 4 };
            _grid.Columns.Add(column);
            column = new GridColumn { FieldName = "Birth Date", Binding = new Binding("BirthDate"), VisibleIndex = 5 };
            _grid.Columns.Add(column);
            column = new GridColumn { FieldName = "Hire Date", Binding = new Binding("HireDate"), VisibleIndex = 6 };
            _grid.Columns.Add(column);
            column = new GridColumn { FieldName = "Address", Binding = new Binding("Address"), VisibleIndex = 7 };
            _grid.Columns.Add(column);
            column = new GridColumn { FieldName = "City", Binding = new Binding("City"), VisibleIndex = 8 };
            _grid.Columns.Add(column);
            column = new GridColumn { FieldName = "Region", Binding = new Binding("Region"), VisibleIndex = 9 };
            _grid.Columns.Add(column);
            column = new GridColumn { FieldName = "Postal Code", Binding = new Binding("PostalCode"), VisibleIndex = 10 };
            _grid.Columns.Add(column);
            column = new GridColumn { FieldName = "Country", Binding = new Binding("Country"), VisibleIndex = 11 };
            _grid.Columns.Add(column);
        }

        public void LoadData()
        {
            List<Employee> data;
            using (var context = new northwindContext())
            {
                data = context.Employees.ToList();
            }
            _grid.ItemsSource = data;
        }

        public void LoadData(DateTime? birth, DateTime? hire)
        {
            List<Employee> employees;
            using (var context = new northwindContext())
            {
                IQueryable<Employee> data = context.Employees;
                if (birth != null)
                    data = data.Where(e => birth == e.BirthDate);
                if (hire != null)
                    data = data.Where(e => hire == e.HireDate);
                employees = data.ToList();
            }
            _grid.ItemsSource = employees;
        }
    }
}
