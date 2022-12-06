using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace EMPLOYEE_CRUD_ADONET
{
    class Insert_Employee_Method
    {
        public void EmployeeCreate()
        {
            //One way of getting connction 
            //SqlConnection _Con = new SqlConnection("Data Source= (local); Initial Catalog= EmployeeDataBase; User ID=User Name; pwd=User Password" Integrated Security=”True”);  

            /*Second way of conncting to Database
            <connectionStrings>
  <add name="emp" connectionString="Data Source=(localdb)\ProjectsV13;Initial Catalog=EmployeeSchema;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False" providerName="System.Data.SqlClient"/>
</connectionStrings>
 add above in App.config or Web.config
             */
            /*First step to make a connection to the sql database*/
            SqlConnection Connection = null;
            SqlCommand Command = null;
            SqlTransaction transaction  = null;//it starts the current Transaction ;
            String _ConStr = System.Configuration.ConfigurationManager.ConnectionStrings["emp"].ConnectionString;
             
            Connection = new SqlConnection(_ConStr);

            /*Second step is to make a sql query to execute so it manipulates the data storage in a Data base*/
            Console.WriteLine("Enter Employee Email");
            String mail = Console.ReadLine() ;
            Console.WriteLine("Enter Employee name");
            String name = Console.ReadLine();
            Console.WriteLine("Enter Employee Address");
            String address = Console.ReadLine();
            Console.WriteLine("Enter Employee Phone Number");
            String phone = Console.ReadLine();
          
            try
            {
                if (Connection.State == ConnectionState.Closed)
                {
                    Connection.Open();//Opens the connection
                }
                
                transaction = Connection.BeginTransaction();
                String query = "insert into Employee(Email,EmpName,EmpAddress,EmpPhone) values('" + mail + "','" + name + "','" + address + "','" + phone + "')";
                Command = new SqlCommand(query, Connection, transaction);
              
                Command.ExecuteNonQuery();//this method executes changes in db i:e;Update,insert,delete
                transaction.Commit();//Data Insert will be done in DB.

                Console.WriteLine("\n\nThe Employee details " + mail + "\n" + name + "\n"+address+"\n"+phone+"has been Added");
            }
            catch(SqlException exception)
            {
                transaction.Rollback(); //it takes back trascation i:e; data will not be reflected in DB
            }
            finally
            {
                if(Connection.State==ConnectionState.Open)
                    Connection.Close();
            }
           
            

        }
    }
}
