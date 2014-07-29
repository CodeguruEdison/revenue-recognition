using System.Data;

namespace RevenueRecogniction.TableModule
{
    public class TableModule
    {
        protected DataTable Table;

        protected TableModule(DataSet ds, string tableName)
        {
            Table = ds.Tables[tableName];
        }
    }
}