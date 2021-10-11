using System;
public class KomisiKaryawan : Object
{
    public string NamaAwal { get; }
    public string NamaAkhir { get; }
    public string KTP { get; }
    private decimal PenjualanKotor;
    private decimal tingkatkomisi;
    public KomisiKaryawan(string namaawal, string namaakhir, string ktp, decimal PenjualanKotor, decimal tingkatkomisi)
    {
        NamaAwal = namaawal;
        NamaAkhir = namaakhir;
        KTP = ktp;
        penjualankotor = PenjualanKotor;
        Tingkatkomisi = tingkatkomisi;
    }
    public decimal penjualankotor
    {
        get
        {
            return PenjualanKotor;
        }
        set
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(value), value, $"{ nameof(PenjualanKotor)} harus >=0");
            }
            PenjualanKotor = value;
        }
    }
    public decimal Tingkatkomisi
    {
        get
        {
            return tingkatkomisi;
        }
        set
        {
            if (value <= 0 || value >= 1)
            {
                throw new ArgumentOutOfRangeException(nameof(value), value, $"{ nameof(tingkatkomisi)} harus > 0 dan < 1");
            }
            tingkatkomisi = value;
        }
    }
    public decimal Pendapatan() => tingkatkomisi * PenjualanKotor;
    public override string ToString() => $"Karyawan Komisi : {NamaAwal}{NamaAkhir}\n" + $"Nomor KTP : {KTP}\n" + $"Penjualan Kotor : {penjualankotor:C}\n" + $"Tingkat Komisi : {tingkatkomisi:F2}";
}
class Tes_KomisiKaryawan
{
    static void Main(string[] args)
    {
        var karyawan = new KomisiKaryawan("Sue ", "Jones", "222-22-2222", 10000.00M, .06M);
        Console.WriteLine("Informasi Karyawan diperoleh dengan properti dan metode : \n");
        Console.WriteLine($"Nama depan ialah {karyawan.NamaAwal}");
        Console.WriteLine($"Nama belakang ialah {karyawan.NamaAkhir}");
        Console.WriteLine($"Nomor KTP : {karyawan.KTP}");
        Console.WriteLine($"Penjualan Kotor ialah {karyawan.penjualankotor:C}");
        Console.WriteLine($"Tingkat Komisi ialah {karyawan.Tingkatkomisi:F2}");
        Console.WriteLine($"Pendapatan ialah {karyawan.Pendapatan():C}");
        karyawan.penjualankotor = 5000.00M;
        karyawan.Tingkatkomisi = .1M;
        Console.WriteLine("\nInformasi Karyawan yang diperbarui diperoleh dari ToString:\n");
        Console.WriteLine(karyawan);
        Console.WriteLine($"Pendapatan : {karyawan.Pendapatan():C}");
        Console.ReadLine();
    }

}
