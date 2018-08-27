using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CRUD_Angular.Models
{
    public class repository
    {
        SqlConnection con = new SqlConnection("Data Source=SUNRISE; Initial Catalog = CRUD; User ID = sa; Password = sunrise");

        public void save(Employee data) 
        {
            con.Open();
            string query = "InsertEmp)";
            
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", data.id);
            cmd.Parameters.AddWithValue("@name", data.name);
            cmd.Parameters.AddWithValue("@desg", data.designation);
            cmd.Parameters.AddWithValue("@mob", data.mobile);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public List<Employee> getList() 
        {
            con.Open();
            var emp = new List<Employee>();
            string get = "select * from employee";
            SqlCommand cmd = new SqlCommand(get, con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read()) 
            {                
                Employee e = new Employee();
                e.id = Convert.ToInt32(dr[0]);
                e.name = Convert.ToString(dr[1]);
                e.designation = Convert.ToString(dr[2]);
                e.mobile = Convert.ToInt64(dr[3]);
                emp.Add(e);
            }
            con.Close();
            return emp;
        }

        public void delete(int data)
        {
            con.Open();
            string query = "delete from employee where id=@id";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@id", data);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void update(Employee emp) 
        {
            con.Open();
            string save = "update employee set name=@nm, designation=@dg, mobile=@mb where id=@id";
            SqlCommand cmd = new SqlCommand(save, con);
            cmd.Parameters.AddWithValue("@id", emp.id);
            cmd.Parameters.AddWithValue("@nm", emp.name);
            cmd.Parameters.AddWithValue("@dg", emp.designation);
            cmd.Parameters.AddWithValue("@mb", emp.mobile);
            cmd.ExecuteNonQuery();
            con.Close();        
        }
    }
}