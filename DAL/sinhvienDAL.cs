using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DTO;

namespace DAL
{
    public class sinhvienDAL:daclass
    {
        List<SinhVien> dssv = new List<SinhVien>();
        public List<SinhVien> getSinhVien()
        {
            moKetNoi();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from SinhVien";
            cmd.Connection = cn;
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                string msv = reader.GetString(0);
                string ten = reader.GetString(1);
                string sdt = reader.GetString(2);
                string noio = reader.GetString(3);
                string malop = reader.GetString(4);
                SinhVien sv = new SinhVien();
                sv.msv = msv;
                sv.ten = ten;
                sv.sdt = sdt;
                sv.noio = noio;
                sv.malop = malop;
                dssv.Add(sv);
            }
            reader.Close();
            return dssv;
        }
        public bool deleteSinhVien(string msv)
        {
            moKetNoi();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "delete from SinhVien where MaSinhVien = @ma";
            cmd.Connection = cn;
            cmd.Parameters.Add("@ma", SqlDbType.NVarChar).Value = msv;
            int kq = cmd.ExecuteNonQuery();
            return kq > 0;
        }
        public bool addSinhVien(SinhVien sv)
        {
            moKetNoi();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into SinhVien values(@ma,@ten,@sdt,@noio,@malop)";
            cmd.Connection = cn;
            cmd.Parameters.Add("@ma", SqlDbType.NVarChar).Value = sv.msv;
            cmd.Parameters.Add("@ten", SqlDbType.NVarChar).Value = sv.ten;
            cmd.Parameters.Add("@sdt", SqlDbType.NVarChar).Value = sv.sdt;
            cmd.Parameters.Add("@noio", SqlDbType.NVarChar).Value = sv.noio;
            cmd.Parameters.Add("@malop", SqlDbType.NVarChar).Value = sv.malop;
            int kq = cmd.ExecuteNonQuery();
            return kq > 0;
        }
        public bool updateSinhVien(SinhVien sv)
        {
            moKetNoi();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "update from SinhVien set MaSinhVien = @ma, TenSinhVien = @ten, SoDienThoai = @sdt, NoiO = @noio, MaLop= @malop where MaSinhVien = @ma";
            cmd.Connection = cn;
            cmd.Parameters.Add("@ma", SqlDbType.NVarChar).Value = sv.msv;
            cmd.Parameters.Add("@ten", SqlDbType.NVarChar).Value = sv.ten;
            cmd.Parameters.Add("@sdt", SqlDbType.NVarChar).Value = sv.sdt;
            cmd.Parameters.Add("@noio", SqlDbType.NVarChar).Value = sv.noio;
            cmd.Parameters.Add("@malop", SqlDbType.NVarChar).Value = sv.malop;
            int kq = cmd.ExecuteNonQuery();
            return kq > 0;
        }
    }
}
