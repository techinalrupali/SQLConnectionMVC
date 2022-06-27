﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace SQLConnectionMVC.Models
{
    public class ProductDal
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        public ProductDal()
        {
            con = new SqlConnection(Startup.ConnectionString);
        }

        public List<Product> GetAllProducts()
        {
            List<Product> list = new List<Product>();
            string str = "select * from Product";
            cmd = new SqlCommand(str, con);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Product p = new Product();
                    p.Id = Convert.ToInt32(dr["Id"]);
                    p.Name = dr["Name"].ToString();
                    p.Price = Convert.ToDecimal(dr["Price"]);
                    list.Add(p);
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
        public Product GetProductById(int id)
        {
            Product p = new Product();
            string str = "select * from Product where Id=@id";
            cmd = new SqlCommand(str, con);
            cmd.Parameters.AddWithValue("@id",id);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {

                    p.Id = Convert.ToInt32(dr["Id"]);
                    p.Name = dr["Name"].ToString();
                    p.Price = Convert.ToDecimal(dr["Price"]);

                }
                con.Close();
                return p;
            }
            else
            {
                con.Close();
                return p;
            }
        }
        public int Save(Product prod)
        {
            string str = "insert into Product Values(@name,@price)";
            cmd =new SqlCommand(str, con);
            con.Open();
            cmd.Parameters.AddWithValue("@name", prod.Name);
            cmd.Parameters.AddWithValue("@price", prod.Price);
            int res = cmd.ExecuteNonQuery();
            con.Close();
            return res;
        }
        public int Update(Product prod)
        {
            string str = "update Product set Name=@name,Price=@price where Id=@id";
            cmd = new SqlCommand(str, con);
            con.Open();
            cmd.Parameters.AddWithValue("@id", prod.Id);
            cmd.Parameters.AddWithValue("@name", prod.Name);
            cmd.Parameters.AddWithValue("@price", prod.Price);
            int res = cmd.ExecuteNonQuery();
            con.Close();
            return res;
        }
        public int Delete(int Id)
        {
            string str = "delete from Product where Id=@id";
            cmd = new SqlCommand(str, con);
            con.Open();
            cmd.Parameters.AddWithValue("@id", Id);
            int res = cmd.ExecuteNonQuery();
            con.Close();
            return res;
        }
    }
}
