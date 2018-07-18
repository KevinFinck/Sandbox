using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AspNetSamples
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CreateReport();
        }

        private void CreateReport()
        {
            var data = CreateDummyTable();
            if (tblReport.Rows.Count == 0)
            {
                InitializeTable(data);
            }

            BindData(data);
        }



        private void InitializeTable(DataTable data)
        {
            var row = new TableRow();

            for (int j = 0; j < data.Columns.Count; j++)
            {
                TableHeaderCell headerCell = new TableHeaderCell
                {
                    Text = data.Columns[j].ColumnName
                };
                row.Cells.Add(headerCell);
            }

            tblReport.Rows.Add(row);
        }

        private void BindData(DataTable data)
        {
            //Add the Column values
            for (int i = 0; i < (data?.Rows ?? new DataTable().Rows).Count; i++)
            {
                var row = new TableRow();
                for (int j = 0; j < data.Columns.Count; j++)
                {
                    TableCell cell = new TableCell
                    {
                        Text = data.Rows[i][j].ToString()
                    };
                    row.Cells.Add(cell);
                }

                // Add the TableRow to the Table
                tblReport.Rows.Add(row);
            }
        }

        private DataTable CreateDummyTable()
        {
            DataTable dt = new DataTable();
            DataRow dr = null;

            //Create the Columns Definition
            dt.Columns.Add(new DataColumn("Column1", typeof(string)));
            dt.Columns.Add(new DataColumn("Column2", typeof(string)));
            dt.Columns.Add(new DataColumn("Column3", typeof(string)));


            //Add the first Row to each columns defined
            dr = dt.NewRow();

            dr["Column1"] = "A";
            dr["Column2"] = "B";
            dr["Column3"] = "C";

            dt.Rows.Add(dr);

            //Add the second Row to each columns defined
            dr = dt.NewRow();

            dr["Column1"] = "D";
            dr["Column2"] = "E";
            dr["Column3"] = "F";

            dt.Rows.Add(dr);

            return dt;
        }


    }
}