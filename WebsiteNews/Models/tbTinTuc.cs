//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebsiteNews.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tbTinTuc
    {
        public int MaTinTuc { get; set; }
        public string TenTinTuc { get; set; }
        public Nullable<int> MaLoaiTinTuc { get; set; }
        public string NoiDungTinTuc { get; set; }
        public Nullable<System.DateTime> NgayDangTinTuc { get; set; }
        public Nullable<int> LuotXemTinTuc { get; set; }
        public Nullable<int> MaNguoiDung { get; set; }
        public string AnhTinTuc { get; set; }
        public string IfrVideo { get; set; }
        public string video { get; set; }
        public Nullable<bool> TrangThaiTin { get; set; }
    
        public virtual tbLoaiTinTuc tbLoaiTinTuc { get; set; }
        public virtual tbNguoiDung tbNguoiDung { get; set; }
    }
}
