using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace SQLConnectionMVC.Models
{
    public class EmployeeDal
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        public EmployeeDal()
        {
            con = new SqlConnection(Startup.ConnectionString);
        }

        public List<Employee> GetAllEmployee()
        {
            List<Employee> list = new List<Employee>();
            string str = "select * from Employee";
            cmd = new SqlCommand(str, con);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Employee e = new Employee();
                    e.Id = Convert.ToInt32(dr["Id"]);
                    e.Name = dr["Name"].ToString();
                    e.Salary = Convert.ToDecimal(dr["Salary"]);
                    e.Department = dr["Department"].ToString();
                    list.Add(e);
                }
                con.Close();
                return list;
            }
            else
            {
                con.Close();
                return list;
            }
        }
        public Employee GetEmployeeById(int id)
        {
            Employee e = new Employee();
            string str = "select * from Employee where Id=@id";
            cmd = new SqlCommand(str, con);
            cmd.Parameters.AddWithValue("@id", id);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {

                    e.Id = Convert.ToInt32(dr["Id"]);
                    e.Name = dr["Name"].ToString();
                    e.Salary = Convert.ToDecimal(dr["Salary"]);
                    e.Department = dr["Department"].ToString();

                }
                con.Close();
                return e;
            }
            else
            {
                con.Close();
                return e;
            }
        }
        public int Save(Employee emp)
        {
            string str = "insert into Employee Values(@name,@salary,@department)";
            cmd = new SqlCommand(str, con);
            con.Open();
            cmd.Parameters.AddWithValue("@name", emp.Name);
            cmd.Parameters.AddWithValue("@salary", emp.Salary);
            cmd.Parameters.AddWithValue("@department", emp.Department);
            int res = cmd.ExecuteNonQuery();
            con.Close();
            return res;
        }
        public int Update(Employee emp)
        {
            string str = "update Employee set Name=@name,Salary=@salary,Department=@department where Id=@id";
            cmd = new SqlCommand(str, con);
            con.Open();
            cmd.Parameters.AddWithValue("@id", emp.Id);
            cmd.Parameters.AddWithValue("@name", emp.Name);
            cmd.Parameters.AddWithValue("@salary", emp.Salary);
            cmd.Parameters.AddWithValue("@department", emp.Department);
            int res = cmd.ExecuteNonQuery();
            con.Close();
            return res;
        }
        public int Delete(int Id)
        {
            string str = "delete from Employee where Id=@id";
            cmd = new SqlCommand(str, con);
            con.Open();
            cmd.Parameters.AddWithValue("@id", Id);
            int res = cmd.ExecuteNonQuery();
            con.Close();
            return res;
        }
    }
}

