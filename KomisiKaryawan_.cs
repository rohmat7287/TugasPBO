using System;
public class KaryawanDasarKomisi
{
    public string NamaAwal { get; }
    public string NamaAkhir { get; }
    public string KTP { get; }
    private decimal penjualanKotor;
    private decimal tingkatKomisi;
    private decimal gajiPokok;
    public KaryawanDasarKomisi(string Namadepan, string Namabelakang, string ktp, decimal penjualanKotor, decimal tingkatKomisi, decimal gajiPokok)
    {
        NamaAwal = Namadepan;
        NamaAkhir = Namabelakang;
        KTP = ktp;
        PenjualanKotor = penjualanKotor;
        TingkatKomisi = tingkatKomisi;
        GajiPokok = gajiPokok;
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
                throw new ArgumentOutOfRangeException(nameof(value), value, $"{nameof(PenjualanKotor)} harus >= 0");
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
                throw new ArgumentOutOfRangeException(nameof(value), value, $"{nameof(TingkatKomisi)} harus > 0 dan < 1");
            }
            tingkatKomisi = value;
        }
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
                throw new ArgumentOutOfRangeException(nameof(value), value, $"{nameof(GajiPokok)} harus >= 0");
            }
            gajiPokok = value;
        }
    }
    public decimal Pendapatan() => gajiPokok + (tingkatKomisi * penjualanKotor);
    public override string ToString() => $"Gaji Pokok Karyawan Komisi : {NamaAwal}{NamaAkhir}\n" + $"Nomor KTP : {KTP}\n" + $"Penjualan Kotor : {penjualanKotor:C}\n" + $"Tingkat Komisi : {tingkatKomisi:F2}\n" + $"Gaji Pokok : {gajiPokok:C}";
}
class Tes_KaryawanDasarKomisi
{
    static void Main()
    {
        var karyawan = new KaryawanDasarKomisi("Bob ", "Lewis", "333-33-3333", 5000.00M, .04M, 300.00M);
        Console.WriteLine("Informasi Karyawan diperoleh dari properti dan metode : \n");
        Console.WriteLine($"Nama Depan ialah {karyawan.NamaAwal}");
        Console.WriteLine($"Nama Belakang ialah {karyawan.NamaAkhir}");
        Console.WriteLine($"Nomor KTP adalah {karyawan.KTP}");
        Console.WriteLine($"Penjualan Kotornya adalah {karyawan.PenjualanKotor:C}");
        Console.WriteLine($"Tingkat Komisinya adalah {karyawan.TingkatKomisi:F2}");
        Console.WriteLine($"Pendapatannya adalah {karyawan.Pendapatan():C}");
        Console.WriteLine($"Gaji Pokoknya adalah {karyawan.GajiPokok:C}");
        karyawan.GajiPokok = 1000.00M;
        Console.WriteLine("\nInformasi Karyawan yang diperbarui diperoleh dari ToString:\n");
        Console.WriteLine(karyawan);
        Console.WriteLine($"Pendapatan : {karyawan.Pendapatan():C}");
        Console.ReadLine();
    }
}
