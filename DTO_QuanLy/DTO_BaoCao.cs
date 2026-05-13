using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QuanLy
{
    public class DTO_BAOCAO
    {
        public int MABC { get; set; }

        public int MAKH { get; set; }

        public string NOIDUNGBC { get; set; } = "";

        public DateTime THOIGIANBC { get; set; }

        public DTO_BAOCAO() { }

        public DTO_BAOCAO(int mabc, int makh, string noidungbc, DateTime thoigianbc)
        {
            MABC = mabc;
            MAKH = makh;
            NOIDUNGBC = noidungbc;
            THOIGIANBC = thoigianbc;
        }
    }
}