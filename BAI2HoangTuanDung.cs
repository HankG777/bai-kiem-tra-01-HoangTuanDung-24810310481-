using System;
using System.Collections.Generic;
using System.Linq;

abstract class PhuongTien
{
    private string _maPT;
    private string _tenHang;
    private int _namSanXuat;
    private decimal _giaGoc;

    public string MaPT
    {
        get => _maPT;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                _maPT = "PT000";
            else
                _maPT = value;
        }
    }

    public string TenHang
    {
        get => _tenHang;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Tên hãng không được để trống!");
            _tenHang = value;
        }
    }

    public int NamSanXuat
    {
        get => _namSanXuat;
        set
        {
            int namHienTai = DateTime.Now.Year;

            if (value < 1900 || value > namHienTai)
                throw new ArgumentException("Năm sản xuất không hợp lệ!");

            _namSanXuat = value;
        }
    }

    public decimal GiaGoc
    {
        get => _giaGoc;
        set
        {
            if (value <= 0)
                throw new ArgumentException("Giá gốc phải lớn hơn 0!");

            _giaGoc = value;
        }
    }

    public PhuongTien(string maPT, string tenHang, int namSanXuat, decimal giaGoc)
    {
        MaPT = maPT;
        TenHang = tenHang;
        NamSanXuat = namSanXuat;
        GiaGoc = giaGoc;
    }

    public abstract decimal TinhGiaLanBanh();

    public virtual string GetInfo()
    {
        return $"Mã PT: {MaPT}, Hãng: {TenHang}, " +
               $"Năm SX: {NamSanXuat}, Giá gốc: {GiaGoc:N0} VNĐ";
    }
}

class OTo : PhuongTien
{
    private int _soChoNgoi;
    private double _dungTichDongCo;

    public int SoChoNgoi
    {
        get => _soChoNgoi;
        set
        {
            if (value <= 0)
                throw new ArgumentException("Số chỗ ngồi phải lớn hơn 0!");

            _soChoNgoi = value;
        }
    }

    public double DungTichDongCo
    {
        get => _dungTichDongCo;
        set
        {
            if (value <= 0)
                throw new ArgumentException("Dung tích động cơ phải lớn hơn 0!");

            _dungTichDongCo = value;
        }
    }

    public OTo(
        string maPT,
        string tenHang,
        int namSanXuat,
        decimal giaGoc,
        int soChoNgoi,
        double dungTichDongCo)
        : base(maPT, tenHang, namSanXuat, giaGoc)
    {
        SoChoNgoi = soChoNgoi;
        DungTichDongCo = dungTichDongCo;
    }

    public override decimal TinhGiaLanBanh()
    {
        if (SoChoNgoi <= 9)
        {
            return GiaGoc
                   + GiaGoc * 0.12m
                   + GiaGoc * 0.30m;
        }

        return GiaGoc + GiaGoc * 0.10m;
    }

    public override string GetInfo()
    {
        return base.GetInfo()
               + $", Số chỗ: {SoChoNgoi}"
               + $", Dung tích động cơ: {DungTichDongCo} L";
    }
}

class XeMay : PhuongTien
{
    public int DungTichXylanh { get; set; }

    public XeMay(
        string maPT,
        string tenHang,
        int namSanXuat,
        decimal giaGoc,
        int dungTichXylanh)
        : base(maPT, tenHang, namSanXuat, giaGoc)
    {
        if (dungTichXylanh <= 0)
            throw new ArgumentException("Dung tích xy-lanh phải lớn hơn 0!");

        DungTichXylanh = dungTichXylanh;
    }

    public override decimal TinhGiaLanBanh()
    {
        if (DungTichXylanh < 175)
            return GiaGoc + GiaGoc * 0.02m;

        return GiaGoc + GiaGoc * 0.05m;
    }

    public override string GetInfo()
    {
        return base.GetInfo()
               + $", Dung tích xy-lanh: {DungTichXylanh} cc";
    }
}

class QuanLyPhuongTien
{
    private List<PhuongTien> danhSach = new List<PhuongTien>();

    public void AddPhuongTien(PhuongTien pt)
    {
        if (pt == null)
            throw new ArgumentNullException(nameof(pt));

        danhSach.Add(pt);
    }

    public void DisplayAll()
    {
        foreach (PhuongTien pt in danhSach)
        {
            Console.WriteLine(pt.GetInfo());
            Console.WriteLine(
                $"Giá lăn bánh: {pt.TinhGiaLanBanh():N0} VNĐ");
            Console.WriteLine("----------------------------------");
        }
    }

    public PhuongTien FindMaxGiaLanBanh()
    {
        if (danhSach.Count == 0)
            return null;

        return danhSach
            .OrderByDescending(pt => pt.TinhGiaLanBanh())
            .First();
    }

    public List<PhuongTien> SearchByName(string keyword)
    {
        if (string.IsNullOrWhiteSpace(keyword))
            return new List<PhuongTien>();

        return danhSach
            .Where(pt => pt.TenHang.Contains(
                keyword,
                StringComparison.OrdinalIgnoreCase))
            .ToList();
    }
}

class Program
{
    static void Main()
    {
        // =========================
        // TC01: Validation năm sản xuất
        // =========================
        Console.WriteLine("=== TC01 ===");

        try
        {
            OTo otoLoi = new OTo(
                "OT001",
                "Toyota",
                1850,
                1_000_000_000m,
                5,
                2.0);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }


        // =========================
        // TC02: Tính giá lăn bánh ô tô
        // =========================
        Console.WriteLine("\n=== TC02 ===");

        OTo oto = new OTo(
            "OT002",
            "Toyota",
            2024,
            1_000_000_000m,
            5,
            2.0);

        Console.WriteLine(
            $"Giá lăn bánh: {oto.TinhGiaLanBanh():N0} VNĐ");


        // =========================
        // TC03: Tính giá lăn bánh xe máy
        // =========================
        Console.WriteLine("\n=== TC03 ===");

        XeMay xeMay = new XeMay(
            "XM001",
            "Honda",
            2023,
            50_000_000m,
            150);

        Console.WriteLine(
            $"Giá lăn bánh: {xeMay.TinhGiaLanBanh():N0} VNĐ");


        // =========================
        // TC04: Kiểm tra đa hình
        // =========================
        Console.WriteLine("\n=== TC04 ===");

        List<PhuongTien> danhSach = new List<PhuongTien>();

        danhSach.Add(oto);
        danhSach.Add(xeMay);

        foreach (PhuongTien pt in danhSach)
        {
            Console.WriteLine(
                $"{pt.TenHang}: {pt.TinhGiaLanBanh():N0} VNĐ");
        }


        // =========================
        // TC05: Tìm giá lăn bánh cao nhất
        // =========================
        Console.WriteLine("\n=== TC05 ===");

        QuanLyPhuongTien quanLy = new QuanLyPhuongTien();

        quanLy.AddPhuongTien(oto);
        quanLy.AddPhuongTien(xeMay);

        PhuongTien max = quanLy.FindMaxGiaLanBanh();

        Console.WriteLine($"Phương tiện có giá cao nhất:");
        Console.WriteLine(max.GetInfo());
        Console.WriteLine(
            $"Giá lăn bánh: {max.TinhGiaLanBanh():N0} VNĐ");
    }
}