using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Drawing;

namespace QLSV_3Layers_EF.DAL
{
    public class DAL_QLSV
    {
        private Model1 dbConText;
        private static DAL_QLSV _QLSV;

        public DAL_QLSV()
        {
            dbConText = new Model1();
        }

        public static DAL_QLSV QLSV
        {
            get
            {
                if (_QLSV == null)
                    _QLSV = new DAL_QLSV();
                return _QLSV;
            }
            private set { }
        }

        public List<SV> GetAllSV()
        {
            return dbConText.SVs.Include(s => s.Class).Include(s => s.Grades).ToList();
        }

        //Lấy thông tin sinh viên bằng MSSV
        public SV GetSVByMSSV(string _mssv)
        {
            return dbConText.SVs.Include(s => s.Class)
               .Include(s => s.Nguoidung)
               .Include(s => s.Grades)
               .FirstOrDefault(s => s.MSSV == _mssv);
        }

        //Lấy danh sách sinh viên theo ClassId
        public List<SV> GetSVByClassId(int classId)
        {
            return dbConText.SVs.Include(s => s.Class)
                .Where(s => s.ClassId == classId).ToList();
        }

        public List<LSH> GetAllClasses()
        {
            return dbConText.LSHs.ToList();
        }

        public List<MonHoc> GetFixedCourses()
        {
            return dbConText.MonHocs.ToList();
        }

        public List<Diem> GetGradesByMSSV(string _mssv)
        {
            return dbConText.Diems.Where(d => d.MSSV == _mssv)
                .Include(d => d.Course).ToList();
        }

        //Thêm mới sinh viên
        public void AddStudent(SV std)
        {
            dbConText.SVs.Add(std);
            dbConText.SaveChanges();
        }

        //Cập nhật thông tin sinh viên
        public void UpdateStudent(SV std)
        {
            var existStd = dbConText.SVs.Find(std.MSSV);
            if(existStd != null)
            {
                dbConText.Entry(existStd).CurrentValues.SetValues(std);
                dbConText.SaveChanges();
            }
        }
 
    }
}
