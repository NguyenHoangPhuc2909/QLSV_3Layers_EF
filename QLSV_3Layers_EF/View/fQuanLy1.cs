using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLSV_3Layers_EF.DAL;
using QLSV_3Layers_EF.DTO;

namespace QLSV_3Layers_EF
{
    public partial class fQuanLy1 : Form
    {
        private DAL_QLSV dAL_QLSV;
        public fQuanLy1()
        {
            dAL_QLSV = new DAL_QLSV();
            LoadClasses();
            LoadStudents();
            InitializeComponent();
        }
        private void LoadClasses()
        {
            cbBLSH.DataSource = dAL_QLSV.GetAllClasses();
        }

        private void LoadStudents()
        {
            dataGridView1.Rows.Clear();
            List<SV> stds;
            if(cbBLSH.SelectedIndex != -1)
                stds = dAL_QLSV.GetSVByClassId((int)cbBLSH.SelectedValue);
            else
                stds = dAL_QLSV.GetAllSV();

            foreach (var std in stds)
            {
                dataGridView1.Rows.Add(std.MSSV, std.FullName, std.Class?.ClassName);
            }
        }

        private void cbBLSH_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadStudents();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            new fQuanLy2(null).ShowDialog();
            LoadStudents();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if(dataGridView1.SelectedRows.Count > 0)
            {
                string mssv = dataGridView1.SelectedRows[0].Cells["MSSV"].Value.ToString();
                new fQuanLy2(mssv).ShowDialog();
                LoadStudents();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một sinh viên!");
            }
        }
    }
}
