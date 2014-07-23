using System;

namespace WPFDevExpress
{
    interface IGridData
    {
        void ConfigureGrid();
        void LoadData();
        void LoadData(DateTime? birth, DateTime? hire);
    }
}
