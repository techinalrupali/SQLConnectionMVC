using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace SQLConnectionMVC.Models
{
    public class CourseDal
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        public CourseDal()
        {
            con = new SqlConnection(Startup.ConnectionString);
        }

        public List<Course> GetAllCourse()
        {
            List<Course> list = new List<Course>();
            string str = "select * from Course";
            cmd = new SqlCommand(str, con);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Course c = new Course();
                    c.Id = Convert.ToInt32(dr["Id"]);
                    c.CourseName = dr["CourseName"].ToString();
                    c.CourseFees = Convert.ToDecimal(dr["CourseFees"]);
                    list.Add(c);
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
        public Course GetCourseById(int id)
        {
            Course c = new Course();
            string str = "select * from Course where Id=@id";
            cmd = new SqlCommand(str, con);
            cmd.Parameters.AddWithValue("@id", id);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {

                    c.Id = Convert.ToInt32(dr["Id"]);
                    c.CourseName = dr["CourseName"].ToString();
                    c.CourseFees = Convert.ToDecimal(dr["CourseFees"]);

                }
                con.Close();
                return c;
            }
            else
            {
                con.Close();
                return c;
            }
        }
        public int Save(Course course)
        {
            string str = "insert into Course Values(@name,@fees)";
            cmd = new SqlCommand(str, con);
            con.Open();
            cmd.Parameters.AddWithValue("@name", course.CourseName);
            cmd.Parameters.AddWithValue("@fees", course.CourseFees);
            int res = cmd.ExecuteNonQuery();
            con.Close();
            return res;
        }
        public int Update(Course course)
        {
            string str = "update Course set CourseName=@name,CourseFees=@fees where Id=@id";
            cmd = new SqlCommand(str, con);
            con.Open();
            cmd.Parameters.AddWithValue("@id", course.Id);
            cmd.Parameters.AddWithValue("@name", course.CourseName);
            cmd.Parameters.AddWithValue("@fees", course.CourseFees);
            int res = cmd.ExecuteNonQuery();
            con.Close();
            return res;
        }
        public int Delete(int Id)
        {
            string str = "delete from Course where Id=@id";
            cmd = new SqlCommand(str, con);
            con.Open();
            cmd.Parameters.AddWithValue("@id", Id);
            int res = cmd.ExecuteNonQuery();
            con.Close();
            return res;
        }
    }
}

