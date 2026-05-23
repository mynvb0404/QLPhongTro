using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QuanLy
{
    public class DTO_KhuVuc
    {
        public string MAKV { get; set; } = "";

        public string TENKV { get; set; } = "";

        public string DCHI { get; set; } = "";

        public int? MANV { get; set; }
        public DTO_KhuVuc() { }

        public DTO_KhuVuc(string makv, string tenkv, string dchi, int manv)
        {
            MAKV = makv;
            TENKV = tenkv;
            DCHI = dchi;
            MANV = manv;
        }
    }
}