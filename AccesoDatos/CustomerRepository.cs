using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos
{
    public class CustomerRepository
    {
        public List<Customers> ObtenerTodos()
        {
            using (var conexion = DataBase.GetSqlConnection())
            {
                String SelectAll = "";
                SelectAll = SelectAll + "SELECT [CustomerID] " + "\n";
                SelectAll = SelectAll + "      ,[CompanyName] " + "\n";
                SelectAll = SelectAll + "      ,[ContactName] " + "\n";
                SelectAll = SelectAll + "      ,[ContactTitle] " + "\n";
                SelectAll = SelectAll + "      ,[Address] " + "\n";
                SelectAll = SelectAll + "      ,[City] " + "\n";
                SelectAll = SelectAll + "      ,[Region] " + "\n";
                SelectAll = SelectAll + "      ,[PostalCode] " + "\n";
                SelectAll = SelectAll + "      ,[Country] " + "\n";
                SelectAll = SelectAll + "      ,[Phone] " + "\n";
                SelectAll = SelectAll + "      ,[Fax] " + "\n";
                SelectAll = SelectAll + "  FROM [dbo].[Customers]";

                var cliente = conexion.Query<Customers>(SelectAll).ToList();
                return cliente;
            }
        }

        public Customers ObtenerPorID(string id)
        {
            using (var conexion = DataBase.GetSqlConnection())
            {
                String SelectForID = "";
                SelectForID = SelectForID + "SELECT [CustomerID] " + "\n";
                SelectForID = SelectForID + "      ,[CompanyName] " + "\n";
                SelectForID = SelectForID + "      ,[ContactName] " + "\n";
                SelectForID = SelectForID + "      ,[ContactTitle] " + "\n";
                SelectForID = SelectForID + "      ,[Address] " + "\n";
                SelectForID = SelectForID + "      ,[City] " + "\n";
                SelectForID = SelectForID + "      ,[Region] " + "\n";
                SelectForID = SelectForID + "      ,[PostalCode] " + "\n";
                SelectForID = SelectForID + "      ,[Country] " + "\n";
                SelectForID = SelectForID + "      ,[Phone] " + "\n";
                SelectForID = SelectForID + "      ,[Fax] " + "\n";
                SelectForID = SelectForID + "  FROM [dbo].[Customers] " + "\n";
                SelectForID = SelectForID + "  WHERE CustomerID = @CustomerID";

                var cliente = conexion.QueryFirstOrDefault<Customers>(SelectForID, new {CustomerID = id});
                return cliente;
            }
        }
    }
}
