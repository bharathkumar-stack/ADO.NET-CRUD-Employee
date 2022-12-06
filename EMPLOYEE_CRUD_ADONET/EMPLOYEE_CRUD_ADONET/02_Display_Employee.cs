using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace EMPLOYEE_CRUD_ADONET
{
    class Display_Employee_Method
    {
        public void EmployeeDisplay ()
        {
            SqlConnection connection = null;
            SqlCommand command = null;
            SqlTransaction transaction = null;
            SqlDataReader reader = null;
            //making sql Connection to DB
            String conn = System.Configuration.ConfigurationManager.ConnectionStrings["Emp"].ConnectionString;
            connection = new SqlConnection(conn);
            try
            {
                if (connection.State == System.Data.ConnectionState.Closed)
                {
                    connection.Open();
                }
               // transaction = connection.BeginTransaction();
                String query = "select * from Employee";
                command = new SqlCommand(query,connection);
                reader= command.ExecuteReader();

                while (reader.Read())
                {
                    Console.WriteLine(reader["Empid"] +" "+reader["Email"]+" "+ reader["EmpName"] + " " + reader["EmpAddress"]+" "+reader["EmpPhone"]);
                }
                //transaction.Commit();
         
            }
            catch (Exception e)
            {
                //transaction.Rollback();
            }
            finally
            {
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                } 
            }




        }
    }
}
