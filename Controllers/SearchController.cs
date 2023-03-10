using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using Web4dotnet.Models;

namespace Web4dotnet.Controllers
{
    public class SearchController : Controller
    {
        // GET: Search
        public ActionResult Index(string search)
        {
            string con = ConfigurationManager.ConnectionStrings["QuanlyLuatConnectionString"].ConnectionString;
            SqlConnection sqlcon = new SqlConnection(con);
            string sql = "SELECT * FROM [dbo].[Luat] WHERE Chuong like N'%" + search + "%' OR NDChuong like N'%" + search + "%' OR Dieu like N'%" + search + "%' OR NDDieu like N'%" + search + "%' OR Khoan like N'%" + search + "%' OR NDKhoan like N'%" + search + "%'";
            SqlCommand cmd = new SqlCommand(sql, sqlcon);
            sqlcon.Open();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            List<QLLuat> strList = new List<QLLuat>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                strList.Add(new QLLuat
                {
                    Chuong = Convert.ToString(dr["Chuong"]),
                    NDChuong = Convert.ToString(dr["NDChuong"]),
                    Dieu = Convert.ToString(dr["Dieu"]),
                    NDDieu = Convert.ToString(dr["NDDieu"]),
                    Khoan = Convert.ToString(dr["Khoan"]),
                    NDKhoan = Convert.ToString(dr["NDKhoan"]),
                });
            }
            sqlcon.Close();
            ModelState.Clear();
            return View(strList);
        }
    }
}