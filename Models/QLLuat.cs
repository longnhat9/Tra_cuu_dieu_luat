using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Web4dotnet.Models
{
    public class QLLuat
    {
        public int ID { set; get; }
        [Required(ErrorMessage = "Bạn cần nhập vào chương")]
        [Display(Name = "Chương")]
        public string Chuong { set; get; }
        [Required(ErrorMessage = "Bạn cần nhập vào nội dung chương")]
        [Display(Name = "Nội dung chương")]
        public string NDChuong { set; get; }
        [Required(ErrorMessage = "Bạn cần nhập vào điều")]
        [Display(Name = "Điều")]
        public string Dieu { set; get; }
        [Required(ErrorMessage = "Bạn cần nhập vào nội dung điều")]
        [Display(Name = "Nội dung điều")]
        public string NDDieu { set; get; }
        [Required(ErrorMessage = "Bạn cần nhập vào khoản")]
        [Display(Name = "Khoản")]
        public string Khoan { set; get; }
        [Display(Name = "Nội dung khoản")]
        public string NDKhoan { set; get; }
    }

    class LuatList
    {
        DBConnection db;
        public LuatList()
        {
            db = new DBConnection();
        }

        public List<QLLuat> GetLuat(string ID)
        {
            string sql;
            if (string.IsNullOrEmpty(ID))
            {
                sql = "Select * From Luat";
            }
            else
            {
                sql = "Select * From Luat Where Id = " + ID;
            }

            List<QLLuat> strList = new List<QLLuat>();
            SqlConnection con = db.GetConnection();
            SqlDataAdapter cmd = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            // Mở kết nối
            con.Open();
            cmd.Fill(dt);
            // Đóng kết nối
            cmd.Dispose();
            con.Close();

            QLLuat strLuat;
            for(int i =0; i <dt.Rows.Count; i++)
            {
                strLuat = new QLLuat();
                strLuat.ID = Convert.ToInt32(dt.Rows[i]["Id"].ToString());
                strLuat.Chuong = dt.Rows[i]["Chuong"].ToString();
                strLuat.NDChuong = dt.Rows[i]["NDChuong"].ToString();
                strLuat.Dieu = dt.Rows[i]["Dieu"].ToString();
                strLuat.NDDieu = dt.Rows[i]["NDDieu"].ToString();
                strLuat.Khoan = dt.Rows[i]["Khoan"].ToString();
                strLuat.NDKhoan = dt.Rows[i]["NDKhoan"].ToString();

                strList.Add(strLuat);
            }
            return strList;
        }
        // Thêm dữ liệu
        public void AddLuat(QLLuat strLuat)
        {
            string sql = "INSERT INTO Luat(Chuong, NDChuong, Dieu, NDDieu, Khoan, NDKhoan)VALUES(N'" + strLuat.Chuong + "',N'" + strLuat.NDChuong + "',N'" + strLuat.Dieu + "',N'" + strLuat.NDDieu + "',N'" + strLuat.Khoan + "',N'" + strLuat.NDKhoan + "')";
            SqlConnection con = db.GetConnection();
            SqlCommand cmd = new SqlCommand(sql, con);

            // Mở kết nối
            con.Open();
            cmd.ExecuteNonQuery();
            // Đóng kết nối
            cmd.Dispose();
            con.Close();
        }

        // Sửa dữ liệu
        public void EditLuat(QLLuat strLuat)
        {
            string sql = "UPDATE Luat SET Chuong = N'" + strLuat.Chuong + "',NDChuong =  N'" + strLuat.NDChuong + "',Dieu =  N'" + strLuat.Dieu + "',NDDieu =  N'" + strLuat.NDDieu + "',Khoan =  N'" + strLuat.Khoan + "',NDKhoan =  N'" + strLuat.NDKhoan + "' WHERE Id =" + strLuat.ID;
            SqlConnection con = db.GetConnection();
            SqlCommand cmd = new SqlCommand(sql, con);

            // Mở kết nối
            con.Open();
            cmd.ExecuteNonQuery();
            // Đóng kết nối
            cmd.Dispose();
            con.Close();
        }

        // Xóa dữ liệu
        public void DeleteLuat(QLLuat strLuat)
        {
            string sql = "DELETE FROM Luat WHERE Id = " + strLuat.ID;
            SqlConnection con = db.GetConnection();
            SqlCommand cmd = new SqlCommand(sql, con);

            // Mở kết nối
            con.Open();
            cmd.ExecuteNonQuery();
            // Đóng kết nối
            cmd.Dispose();
            con.Close();
        }
    }
}