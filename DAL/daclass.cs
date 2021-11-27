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
    public class daclass
    {
        public SqlConnection cn = null;
        string strcn = @"server = LAPCN-LONGPH; Database = QlSinhVien; User ID = sa; PWd=longph12345";
        public void moKetNoi()
        {
            if (cn == null)
            {
                cn = new SqlConnection(strcn);
            }
            if (cn.State == ConnectionState.Closed)
            {
                cn.Open();
            }
        }
        public void dongKetNoi()
        {
            if(cn != null&& cn.State == ConnectionState.Open)
            {
                cn.Close();
            }
        }
    }
}
