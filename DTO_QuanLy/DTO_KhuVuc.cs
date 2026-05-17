using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QuanLy
{
    public class DTO_KHUVUC
    {
        public string MAKV { get; set; } = "";

        public int MANV { get; set; }

        public string TENKV { get; set; } = "";

        public string DCHI { get; set; } = "";

        public DTO_KHUVUC() { }

        public DTO_KHUVUC(string makv, string tenkv, string dchi, int manv)
        {
            MAKV = makv;
            MANV = manv;
            TENKV = tenkv;
            DCHI = dchi;
        }
    }
}