using System;
using System.Collections.Generic;

namespace Viet231230961.Models;

public partial class LoaiKhach
{
    public int MaLoai { get; set; }

    public string? TenLoai { get; set; }

    public virtual ICollection<HanhKhach> HanhKhaches { get; set; } = new List<HanhKhach>();
}
