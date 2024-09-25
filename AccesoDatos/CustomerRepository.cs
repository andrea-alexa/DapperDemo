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

        public int insertarCliente(Customers customer)
        {
            using (var conexion = DataBase.GetSqlConnection())
            {
                String Insertar = "";
                Insertar = Insertar + "INSERT INTO [dbo].[Customers] " + "\n";
                Insertar = Insertar + "           ([CustomerID] " + "\n";
                Insertar = Insertar + "           ,[CompanyName] " + "\n";
                Insertar = Insertar + "           ,[ContactName] " + "\n";
                Insertar = Insertar + "           ,[ContactTitle] " + "\n";
                Insertar = Insertar + "           ,[Address]) " + "\n";
                Insertar = Insertar + "     VALUES " + "\n";
                Insertar = Insertar + "           (@customerID " + "\n";
                Insertar = Insertar + "           ,@companyName " + "\n";
                Insertar = Insertar + "           ,@contactName " + "\n";
                Insertar = Insertar + "           ,@contactTitle " + "\n";
                Insertar = Insertar + "           ,@address)";

                var insertadas = conexion.Execute(Insertar, new
                {
                    CustomerID = customer.CustomerID,
                    CompanyName = customer.CompanyName,
                    ContactName = customer.ContactName,
                    ContactTitle = customer.ContactTitle,
                    Address = customer.Address,
                });
                return insertadas;
            }
        }

        public int EliminarCliente(string id)
        {
            using (var conexion = DataBase.GetSqlConnection())
            {
                string Delete = "";
                Delete = Delete + "DELETE FROM [dbo].[Customers] " + "\n";
                Delete = Delete + "      WHERE CustomerID = @CustomerID";

                var eliminadas = conexion.Execute(Delete, new
                {
                    CustomerID = id
                });
                return eliminadas;
            }
        }
    }
}
