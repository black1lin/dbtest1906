using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApplication1.Models
{
    public class PeopleModel
    {
        
        public string ID;
        public string NAME;
        public string AGE;
        public string ID_Del;

        public class People {
            
            public string id;
            public string name;
            public string age;
        }

        
        public List<People> PeopleList;
        public void CreatePplList(string id,string name,string age)
        {
            string strConnString = ConfigurationManager.ConnectionStrings["connect"].ConnectionString;
            string queryString = "INSERT INTO PEOPLE (ID,NAME,AGE) VALUES("+id+",N'"+name+"',"+age+")";
            using (SqlConnection conn = new SqlConnection(strConnString))
            {
                if (id == null || id == "")
                {
                    return;
                }
         
                conn.Open();
                SqlCommand scom = new SqlCommand("", conn);
                scom.CommandText = queryString;
                scom.ExecuteScalar();

            }
        }
        public void EditPplList(string id,string name,string age)
        {
            string strConnString = ConfigurationManager.ConnectionStrings["connect"].ConnectionString;
            string queryString = "UPDATE PEOPLE SET NAME= N'"+name+"', AGE= "+age+" WHERE ID= "+id;
            using (SqlConnection conn = new SqlConnection(strConnString))
            {
                if (id == null || id == "")
                {
                    return;
                }
                conn.Open();
                SqlCommand scom = new SqlCommand("", conn);
                scom.CommandText = queryString;
                scom.ExecuteNonQuery();

            }
        }
        public void DeletePplList(string id)
        {
            string strConnString = ConfigurationManager.ConnectionStrings["connect"].ConnectionString;
            string queryString = "DELETE FROM PEOPLE WHERE ID="+ id;
            using (SqlConnection conn = new SqlConnection(strConnString))
            {
                if (id == null || id == "")
                {
                    return;
                }
                conn.Open();
                SqlCommand scom = new SqlCommand("", conn);
                scom.CommandText = queryString;
                scom.ExecuteScalar();
            }
        }
        public void EditPplMono(string id,string name,string age)
        {
            string strConnString = ConfigurationManager.ConnectionStrings["connect"].ConnectionString;
            string queryString = "UPDATE PEOPLE SET NAME=N'"+name+"', AGE="+age+" WHERE ID="+id;
            using (SqlConnection conn = new SqlConnection(strConnString))
            {
                if (id == null || id == "")
                {
                    return;
                }
                conn.Open();
                SqlCommand scom = new SqlCommand("", conn);
                scom.CommandText = queryString;
                scom.ExecuteScalar();
            }
        }
        public void DeletePplMono(string id)
        {
            string strConnString = ConfigurationManager.ConnectionStrings["connect"].ConnectionString;
            string queryString = "DELETE FROM PEOPLE WHERE ID=" + id;
            using (SqlConnection conn = new SqlConnection(strConnString))
            {
                if (id == null || id == "")
                {
                    return;
                }
                conn.Open();
                SqlCommand scom = new SqlCommand("", conn);
                scom.CommandText = queryString;
                scom.ExecuteScalar();
            }
        }

        public void GetPeopleList()
        {
            string strConnString = ConfigurationManager.ConnectionStrings["connect"].ConnectionString;
            string queryString = "SELECT ID,NAME,AGE FROM PEOPLE";
            using (SqlConnection conn = new SqlConnection(strConnString))
            {
                conn.Open();
                SqlCommand scom = new SqlCommand("", conn);
                scom.CommandText = queryString;

                SqlDataReader sread = scom.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(sread);
                if (dt.Rows.Count > 0)
                {
                    PeopleList = new List<People>();
                    foreach(DataRow item in dt.Rows)
                    {
                        PeopleList.Add(new People()
                        {
                            id = item["ID"].ToString(),
                            name = item["NAME"].ToString().Trim(),
                            age = item["AGE"].ToString()
                        });
                    }
                }
               
            }
        }
    }
}