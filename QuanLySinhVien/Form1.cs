using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using DTO;

namespace QuanLySinhVien
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        

        private void btnShow_Click(object sender, EventArgs e)
        {
            SinhVienBLL svbll = new SinhVienBLL();
            List<SinhVien> dssvUI = svbll.GetSinhVien();
            sinhvienList.Items.Clear();
            foreach( SinhVien sv in dssvUI)
            {
                ListViewItem lvi = new ListViewItem(sv.msv + "");
                lvi.SubItems.Add(sv.ten);
                lvi.SubItems.Add(sv.sdt);
                lvi.SubItems.Add(sv.noio);
                lvi.SubItems.Add(sv.malop);
                sinhvienList.Items.Add(lvi);
                lvi.Tag = sv;
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (sinhvienList.SelectedItems.Count > 0)
            {
                ListViewItem lvi = sinhvienList.SelectedItems[0];
                SinhVien sv = lvi.Tag as SinhVien;
                SinhVienBLL svbll = new SinhVienBLL();
                bool kq = svbll.xoaSinhVien(sv.msv);
                if (kq)
                {
                    MessageBox.Show("Xóa sinh viên " + sv.ten + " thành công !");
                    btnShow.PerformClick();
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            SinhVien sv = new SinhVien();
            sv.msv = txtmsv.Text;
            sv.ten = txtten.Text;
            sv.sdt = txtsdt.Text;
            sv.noio = txtnoio.Text;
            sv.malop= txtmalop.Text;
            SinhVienBLL svbll = new SinhVienBLL();
            bool kq = svbll.themSinhVien(sv);
            if (kq)
            {
                btnShow.PerformClick();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            SinhVien sv = new SinhVien();
            sv.msv = txtmsv.Text;
            sv.ten = txtten.Text;
            sv.sdt = txtsdt.Text;
            sv.noio = txtnoio.Text;
            sv.malop = txtmalop.Text;
            SinhVienBLL svbll = new SinhVienBLL();
            bool kq = svbll.suaSinhVien(sv);
            if (kq)
            {
                btnShow.PerformClick();
            }
        }
    }
}
