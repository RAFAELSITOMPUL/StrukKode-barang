using System;
using System.Collections.Generic;
using System.Linq;

class Produk
{
    public string Nama { get; set; }
    public double Harga { get; set; }
    public int Stok { get; set; }
}

class Member
{
    public string NoHandphone { get; set; }
    public int PoinMember { get; set; }
}

class Transaksi
{
    private List<Produk> daftarProduk;
    private List<Member> daftarMember;

    public Transaksi()
    {
        daftarProduk = InisialisasiProduk();
        daftarMember = new List<Member>();
    }

    private List<Produk> InisialisasiProduk()
    {
        return new List<Produk>
        {
            // 50 produk minimarket (contoh)
            new Produk { Nama = "Minyak Goreng", Harga = 15000, Stok = 100 },
            new Produk { Nama = "Gula Pasir", Harga = 12000, Stok = 80 },
            new Produk { Nama = "Beras", Harga = 55000, Stok = 50 },
            new Produk { Nama = "Telur", Harga = 25000, Stok = 75 },
            new Produk { Nama = "Susu Kotak", Harga = 8000, Stok = 120 },
            new Produk { Nama = "Kopi Instan", Harga = 5000, Stok = 200 },
            new Produk { Nama = "Deterjen", Harga = 20000, Stok = 60 },
            new Produk { Nama = "Sabun Mandi", Harga = 10000, Stok = 90 },
            new Produk { Nama = "Pasta Gigi", Harga = 7000, Stok = 100 },
            new Produk { Nama = "Sikat Gigi", Harga = 6000, Stok = 80 },
            new Produk { Nama = "Mie Instan", Harga = 3500, Stok = 250 },
            new Produk { Nama = "Air Mineral", Harga = 4000, Stok = 200 },
            new Produk { Nama = "Teh Botol", Harga = 5000, Stok = 150 },
            new Produk { Nama = "Kecap Manis", Harga = 12000, Stok = 70 },
            new Produk { Nama = "Saus Tomat", Harga = 8000, Stok = 90 },
            new Produk { Nama = "Minyak Wangi", Harga = 25000, Stok = 40 },
            new Produk { Nama = "Sampo", Harga = 15000, Stok = 80 },
            new Produk { Nama = "Sabun Cuci Piring", Harga = 10000, Stok = 60 },
            new Produk { Nama = "Tisu Basah", Harga = 12000, Stok = 50 },
            new Produk { Nama = "Tisu Kering", Harga = 8000, Stok = 70 },
            // Tambahkan produk lainnya hingga 50 jenis
            new Produk { Nama = "Kopi Bubuk", Harga = 18000, Stok = 45 },
            new Produk { Nama = "Sabun Cuci", Harga = 22000, Stok = 55 },
            new Produk { Nama = "Pewangi Pakaian", Harga = 15000, Stok = 65 },
            new Produk { Nama = "Sikat Lantai", Harga = 25000, Stok = 40 },
            new Produk { Nama = "Pembersih Kaca", Harga = 12000, Stok = 50 },
            new Produk { Nama = "Pembersih Toilet", Harga = 18000, Stok = 35 },
            new Produk { Nama = "Pemutih Pakaian", Harga = 20000, Stok = 45 },
            new Produk { Nama = "Pelembut Pakaian", Harga = 16000, Stok = 55 },
            new Produk { Nama = "Pembersih Lantai", Harga = 22000, Stok = 40 },
            new Produk { Nama = "Cairan Pencuci Piring", Harga = 15000, Stok = 60 },
            // Pastikan total produk mencapai 50
        };
    }

    public void DaftarMember(string noHp)
    {
        // Validasi pendaftaran member
        if (daftarMember.Any(m => m.NoHandphone == noHp))
        {
            Console.WriteLine("Nomor HP sudah terdaftar!");
            return;
        }

        Member memberBaru = new Member
        {
            NoHandphone = noHp,
            PoinMember = 0
        };

        daftarMember.Add(memberBaru);
        Console.WriteLine("Member berhasil didaftarkan!");
    }

    public void ProsesTransaksi(string noHp, List<(string NamaProduk, int Jumlah)> keranjang)
    {
        // Cari member
        Member member = daftarMember.FirstOrDefault(m => m.NoHandphone == noHp);
        if (member == null)
        {
            Console.WriteLine("Member tidak ditemukan. Silakan daftar terlebih dahulu.");
            return;
        }

        // Struktur Struk Pembelian
        Console.WriteLine("\n===== STRUK PEMBELIAN =====");
        Console.WriteLine($"Nomor HP Member: {noHp}");
        Console.WriteLine("----------------------------");

        double totalBelanja = 0;
        List<string> detailTransaksi = new List<string>();

        foreach (var item in keranjang)
        {
            // Cari produk
            Produk produk = daftarProduk.FirstOrDefault(p => p.Nama == item.NamaProduk);

            if (produk == null)
            {
                Console.WriteLine($"Produk {item.NamaProduk} tidak ditemukan!");
                continue;
            }

            // Hitung harga dengan diskon
            double hargaAkhir = produk.Harga * item.Jumlah;
            string diskonInfo = "";

            // Diskon jika membeli dalam jumlah banyak
            if (item.Jumlah >= 10)
            {
                hargaAkhir *= 0.9; // Diskon 10%
                diskonInfo = " (Diskon 10%)";
            }

            totalBelanja += hargaAkhir;
            detailTransaksi.Add($"{produk.Nama} {item.Jumlah} x Rp {produk.Harga} = Rp {hargaAkhir}{diskonInfo}");
        }

        // Cetak detail transaksi
        foreach (var detail in detailTransaksi)
        {
            Console.WriteLine(detail);
        }

        Console.WriteLine("----------------------------");
        Console.WriteLine($"Total Belanja: Rp {totalBelanja:N0}");

        // Tambah poin member
        int poinDitambah = (int)(totalBelanja / 10000);
        member.PoinMember += poinDitambah;
        Console.WriteLine($"Poin Member Ditambahkan: {poinDitambah}");
        Console.WriteLine($"Total Poin Sekarang: {member.PoinMember}");
        Console.WriteLine("===========================");
    }

    public void TampilkanDaftarProduk()
    {
        Console.WriteLine("DAFTAR PRODUK MINIMARKET:");
        Console.WriteLine("------------------------");
        foreach (var produk in daftarProduk)
        {
            Console.WriteLine($"{produk.Nama} - Rp {produk.Harga:N0} (Stok: {produk.Stok})");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Transaksi minimarket = new Transaksi();

        // Tampilkan daftar produk
        minimarket.TampilkanDaftarProduk();

        // Daftar member
        minimarket.DaftarMember("+62 831-7872-6854");

        // Contoh transaksi
        var keranjang = new List<(string, int)>
        {
            ("Minyak Goreng", 5),
            ("Gula Pasir", 12),
            ("Beras", 2)
        };

        // Proses transaksi
        minimarket.ProsesTransaksi("+62 831-7872-6854", keranjang);
    }
}