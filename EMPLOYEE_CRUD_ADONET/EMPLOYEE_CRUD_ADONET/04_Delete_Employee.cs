using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace EMPLOYEE_CRUD_ADONET
{
    class Delete_Employee_Method
    {
        public void EmployeeDelete()
        {
            SqlConnection connection = null;
            SqlCommand command = null;
            SqlDataReader reader = null;
            SqlTransaction transaction = null;

            String conn = System.Configuration.ConfigurationManager.ConnectionStrings["emp"].ConnectionString;
            connection = new SqlConnection(conn);


            Console.WriteLine("Enter Employee id  To Confirm ");
            String id = Console.ReadLine();
            try
            {
                if (connection.State == System.Data.ConnectionState.Closed)
                {
                    connection.Open();
                }
                String query = "select * from Employee where EmpId='" + id + "'";
                command = new SqlCommand(query, connection);
                reader = command.ExecuteReader(); //

                while (reader.Read())
                {
                    Console.WriteLine(reader["Empid"] + " " + reader["Email"] + " " + reader["EmpName"] + " " + reader["EmpAddress"] + " " + reader["EmpPhone"]);
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                    reader.Close();
                }
            }

            Console.WriteLine("\nDo you want to delete above employee details \n1=>Yes \n2=>No");

            String flag=Console.ReadLine();
            if (flag == "2")
            {
                Console.WriteLine("The Deletion of Employee is canceled ");
            }
            if (flag == "1")
            {

                try
                {
                    if (connection.State == ConnectionState.Closed)
                    {
                        connection.Open();//Opens the connection
                    }
                    transaction = connection.BeginTransaction();
                    Console.WriteLine("Test1");
                    string query = "DELETE FROM Employee where EmpId='" + id + "'";
                    command = new SqlCommand(query, connection, transaction);
                    command.ExecuteNonQuery();

                    transaction.Commit();

                    Console.WriteLine("The details of employee with " + id + " has been deleted");

                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    Console.WriteLine(e.Message);
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
   
}
