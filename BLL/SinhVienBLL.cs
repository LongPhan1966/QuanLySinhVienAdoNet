using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;

namespace BLL
{
    public class SinhVienBLL
    {
        sinhvienDAL svdal = new sinhvienDAL();
        
        public List<SinhVien> GetSinhVien()
        {
            return svdal.getSinhVien();
        }

        public bool xoaSinhVien(string msv)
        {
            return svdal.deleteSinhVien(msv);
        }
        public bool themSinhVien(SinhVien sv)
        {
            return svdal.addSinhVien(sv);
        }

        public bool suaSinhVien(SinhVien sv)
        {
            return svdal.updateSinhVien(sv);
        }
    }
}
