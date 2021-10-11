using System;
using System.Collections.Generic;

public abstract class Karyawan
{
    public string NamaAwal { get; }
    public string NamaAkhir { get; }
    public string KTP { get; }
    public Karyawan(string Namadepan, string Namabelakang, string ktp)
    {
        NamaAwal = Namadepan;
        NamaAkhir = Namabelakang;
        KTP = ktp;
    }
    public override string ToString() => $"{NamaAwal}{NamaAkhir}\n" + $"No,KTP: {KTP}";
    public abstract decimal Pendapatan();
    
}
public class GajiKaryawan : Karyawan
{
    private decimal Gajimingguan;
    public GajiKaryawan(string Namadepan, string Namabelakang, string ktp, decimal Gajimingguan)
        : base(Namadepan, Namabelakang, ktp)
    {
        GajiMingguan = Gajimingguan;
    }
    public decimal GajiMingguan
    {
        get
        {
            return Gajimingguan;
        }
        set
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(value),
                    value, $"{nameof(GajiMingguan)} harus >= 0");

            }
            Gajimingguan = value;
        }
    }
    public override decimal Pendapatan() => GajiMingguan;
    public override string ToString() => $"Gaji Karyawan: {base.ToString()}\n" +
        $"Gaji Mingguan: {GajiMingguan:C}";
}
public class KaryawanPerjam : Karyawan
{
    private decimal upah;
    private decimal jam;
    public KaryawanPerjam(string Namadepan, string Namabelakang, string ktp,
        decimal Upahperjam, decimal jamKerja)
        : base(Namadepan, Namabelakang, ktp)
    {
        Upah = Upahperjam;
        Jam = jamKerja;
    }
    public decimal Upah
    {
        get
        {
            return upah;
        }
        set
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(value),
                    value, $"{nameof(Upah)} harus >= 0");
            }
            upah = value;
        }
    }
    public decimal Jam
    {
        get
        {
            return jam;
        }
        set
        {
            if (value < 0 || value > 168)
            {
                throw new ArgumentOutOfRangeException(nameof(value), value, $"{nameof(Jam)} harus >= 0 dan <= 168");
            }
            jam = value;
        }
    }
    public override decimal Pendapatan()
    {
        if (Jam <= 40)
        {
            return Upah * Jam;
        }
        else
        {
            return (40 * Upah) + ((Jam - 40) * Upah * 1.5M);
        }
    }
    public override string ToString() => $"Karyawan Perjam: {base.ToString()}\n" +
        $"Upah Perjam: {Upah:C}\nJam Kerja: {Jam:F2}";
}
public class KomisiKaryawan : Karyawan
{
    private decimal penjualanKotor;
    private decimal tingkatKomisi;
    public KomisiKaryawan(string Namadepan, string Namabelakang,
        string ktp, decimal penjualanKotor, decimal tingkatKomisi)
        : base(Namadepan, Namabelakang, ktp)
    {
        PenjualanKotor = penjualanKotor;
        TingkatKomisi = tingkatKomisi;
    }
    public decimal PenjualanKotor
    {
        get
        {
            return penjualanKotor;
        }
        set
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(value),
                    value, $"{nameof(PenjualanKotor)} harus >= 0");
            }
            penjualanKotor = value;
        }
    }
    public decimal TingkatKomisi
    {
        get
        {
            return tingkatKomisi;
        }
        set
        {
            if (value <= 0 || value >= 1)
            {
                throw new ArgumentOutOfRangeException(nameof(value),
                    value, $"{nameof(TingkatKomisi)} harus > 0 dan < 1");
            }
            tingkatKomisi = value;
        }
    }
    public override decimal Pendapatan() => TingkatKomisi * PenjualanKotor;
    public override string ToString() => $"Karyawan Komisi: {base.ToString()}\n" +
        $"Penjualan Kotor: {PenjualanKotor:C}\n" +
        $"Tingkat Komisi: {TingkatKomisi:F2}";
}
public class KaryawanDasarKomisi : KomisiKaryawan
{
    private decimal gajiPokok;
    public KaryawanDasarKomisi(string Namadepan, string Namabelakang, string ktp,
        decimal penjualanKotor, decimal tingkatKomisi, decimal gajiPokok)
        : base(Namadepan, Namabelakang, ktp, penjualanKotor, tingkatKomisi)
    {
        GajiPokok = gajiPokok;
    }
    public decimal GajiPokok
    {
        get
        {
            return gajiPokok;
        }
        set
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(value),
                    value, $"{nameof(GajiPokok)} harus >= 0");
            }
            gajiPokok = value;
        }
    }
    public override decimal Pendapatan() => GajiPokok * base.Pendapatan();
    public override string ToString() => $"Gaji-Pokok: {base.ToString()}\nGaji Pokok: {GajiPokok:C}";
}
class tes_SistemPenggajian
{
    static void Main()
    {
        var gajiKaryawan = new GajiKaryawan("John ", "Smith", "111-11-1111", 800.00M);
        var Karyawanperjam = new KaryawanPerjam("Karen ", "Price", "222-22-2222", 16.75M, 40.0M);
        var komisiKaryawan = new KomisiKaryawan("Sue ", "Jones", "333-33-3333", 10000.00M, .06M);
        var karyawandasarkomisi = new KaryawanDasarKomisi("Bob ", "Lewts", "444-44-4444", 5000.00M, .04M, 300.00M);
        Console.WriteLine("Karyawan diproses secara Induvidu:\n");
        Console.WriteLine($"{gajiKaryawan}\ndiperoleh: " + $"{gajiKaryawan.Pendapatan():C}\n");
        Console.WriteLine($"{Karyawanperjam}\ndiperoleh: " + $"{Karyawanperjam.Pendapatan():C}\n");
        Console.WriteLine($"{komisiKaryawan}\ndiperoleh: " + $" {komisiKaryawan.Pendapatan():C}\n");
        Console.WriteLine($"{karyawandasarkomisi}\ndiperoleh: " + $"{karyawandasarkomisi.Pendapatan():C}\n");
        var karyawan = new List<Karyawan>() { gajiKaryawan, Karyawanperjam, komisiKaryawan, karyawandasarkomisi };
        Console.WriteLine("Karyawan diproses secara Pholymorphically:\n");
        foreach (var Karyawansekarang in karyawan)
        {
            Console.WriteLine(Karyawansekarang);
            if (Karyawansekarang is KaryawanDasarKomisi)
            {
                var karyawann = (KaryawanDasarKomisi)Karyawansekarang;
                karyawann.GajiPokok *= 1.10M;
                Console.WriteLine("Gaji Pokok baru dengan kenaikan 10% : " + $"{karyawann.GajiPokok:C}");
            }
            Console.WriteLine($"Diperoleh: {Karyawansekarang.Pendapatan():C}\n");
        }
        for (int j = 0; j < karyawan.Count; j++)
        {
            Console.WriteLine($"Karyawan {j} adalah {karyawan[j].GetType()}");
        }
        Console.ReadLine();
    }
}
