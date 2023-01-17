namespace EmployeeCrudOpsApi.DAL;

using EmployeeCrudOpsApi.Model;
using System.Data;
using MySql.Data.MySqlClient;

public class EmployeeDataAccess
{
    public static string conString = @"server=localhost; port=3306; user=root; password=Msit@1234; database=Employeedata";
    public static List<Employee> GetAllEmployees()
    {
        List<Employee> allData = new List<Employee>();
        MySqlConnection con = new MySqlConnection(conString);
        
        try
        {
            string query = "select * from Employee";
            DataSet ds = new DataSet();
            MySqlCommand cmd = new MySqlCommand(query,con);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(ds);

            DataTable dt = ds.Tables[0];
            DataRowCollection rows = dt.Rows;
            foreach(DataRow row in rows){
                Employee employee = new Employee{
                    empid = int.Parse(row["empid"].ToString()),
                    empname =row["empname"].ToString(),
                    job= row["job"].ToString(),
                    joiningdate= row["joiningdate"].ToString()

                };
                allData.Add(employee);
            }
        }
        catch (System.Exception e)
        {
            System.Console.WriteLine(e.Message);
            throw;
        }
        return allData;
    }

    public static Employee GetEmployeeById(int id){
        Employee employee = null;
        MySqlConnection con = new MySqlConnection(conString);

        try
        {
            con.Open();
            string query = "select * from employee where empid="+id;
            MySqlCommand command = new MySqlCommand(query,con);
            MySqlDataReader reader = command.ExecuteReader();

            if(reader.Read()){
                 employee = new Employee{
                    empid = int.Parse(reader["empid"].ToString()),
                    empname = reader["empname"].ToString(),
                    job = reader["job"].ToString(),
                    joiningdate = reader["joiningdate"].ToString()

                };
            }
        }
        catch (System.Exception e)
        {
            System.Console.WriteLine(e.Message);
            throw;
        }
        finally
        {
            con.Close();
        }
        return employee;
    }

    public static void SaveNewEmp(Employee employee){
        MySqlConnection con = new MySqlConnection(conString);

        try
        {
            con.Open();
            string query  = $"insert into employee(empname,job,joiningdate) values('{employee.empname}','{employee.job}','{employee.joiningdate}')";
            MySqlCommand command = new MySqlCommand(query,con);
            command.ExecuteNonQuery();
            con.Close();
        }       
        catch (System.Exception e)
        {
            System.Console.WriteLine(e.Message);
            throw;
        }
        finally
        {
            con.Close();
        }

    }

    public static void DeleteEmpById(int id){

        MySqlConnection con = new MySqlConnection(conString);

        try{
            con.Open();
            string query = "delete from employee where empid = "+id;
            MySqlCommand command = new MySqlCommand(query,con);
            command.ExecuteNonQuery();
            con.Close();
        }
        catch(Exception e){
            System.Console.WriteLine(e.Message);

        }
        finally{
            con.Close();
        }
    }
}