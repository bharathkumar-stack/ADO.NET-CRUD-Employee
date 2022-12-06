using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace EMPLOYEE_CRUD_ADONET
{
    class Update_Employee_Method
    {
        //We can only update parameters other then Employee Id 
        public void EmployeeUpdate()
        {
            // we need to get the details by employee id and update other details
            SqlConnection connection = null;
            SqlCommand command = null;
            SqlTransaction transaction = null;
            SqlDataReader reader = null;
            String conn = System.Configuration.ConfigurationManager.ConnectionStrings["Emp"].ConnectionString;
            connection = new SqlConnection(conn);

            //1=>Feteching the details of an employee

            Console.WriteLine("Enter Employee id to edit");
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
                    //reader.Close();
                }
            }


            //below code does the update in employee Table
            try {
                if (connection.State == System.Data.ConnectionState.Closed)
                {
                    connection.Open();
                }
                /*Second step is to make a sql query to execute so it manipulates the data storage in a Data base*/
                Console.WriteLine("Enter Employee Email");
                String mail = Console.ReadLine();
                Console.WriteLine("Enter Employee name");
                String name = Console.ReadLine();
                Console.WriteLine("Enter Employee Address");
                String address = Console.ReadLine();
                Console.WriteLine("Enter Employee Phone Number");
                String phone = Console.ReadLine();

                transaction = connection.BeginTransaction();
                String quer1 = "Update Employee set Email='"+mail+"',EmpName='"+name+"',EmpAddress='"+address+"',EmpPhone='"+phone+"'where EmpId='"+id+"'";
                command = new SqlCommand(quer1, connection,transaction);
                command.ExecuteNonQuery();
               // reader = command.ExecuteReader();
                transaction.Commit();//Data Insert will be done in DB.

                Console.WriteLine("The Table has been updated with new values");
                /*while (reader.Read())
                {
                    Console.WriteLine(reader["Empid"] + " " + reader["Email"] + " " + reader["EmpName"] + " " + reader["EmpAddress"] + " " + reader["EmpPhone"]);
                }*/
                connection.Close();
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
                }
            }

        }
    }
}
