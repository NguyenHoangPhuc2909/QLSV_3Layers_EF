using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

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
            return dbConText.SVs.ToList();
        }

        //Lấy thông tin sinh viên bằng MSSV
        public SV GetSVByMSSV(string _mssv)
        {
            return dbConText.SVs.Include(s => s.Class)
               .Include(s => s.Nguoidung)
               .FirstOrDefault(s => s.MSSV == _mssv);
        }

        //
    }
}
