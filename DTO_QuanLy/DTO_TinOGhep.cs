using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QuanLy
{
    public class DTO_TinOGhep
    {
        public int MATINOG { get; set; }

        public int MAPHONG { get; set; }

        public int MAKH { get; set; }

        public int SONGUOICAN { get; set; }

        public string GIOITINH { get; set; } = "";

        public decimal GIACHIA { get; set; }

        public string MOTA { get; set; } = "";

        public string TRANGTHAITIN { get; set; } = "";

        public DTO_TinOGhep() { }

        public DTO_TinOGhep(int matinog, int maphong, int makh, int songuoican,
                            string gioitinh, decimal giachia,
                            string mota, string trangthaitin)
        {
            MATINOG = matinog;
            MAPHONG = maphong;
            MAKH = makh;
            SONGUOICAN = songuoican;
            GIOITINH = gioitinh;
            GIACHIA = giachia;
            MOTA = mota;
            TRANGTHAITIN = trangthaitin;
        }
    }
}