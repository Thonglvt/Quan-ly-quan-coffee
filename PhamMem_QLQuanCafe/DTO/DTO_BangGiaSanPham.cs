using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_BangGiaSanPham
    {
        public int MaSP { get; set; }
        public string TenSP { get; set; }
        public string Hinh { get; set; }
        public bool TrangThai { get; set; }
        public string MaNhomSP { get; set; }
        public int MaBangGia { get; set; }
        public string MaSize { get; set; }
        public double Gia { get; set; }
        public DateTime NgayCapNhat { get; set; }

    }
}
