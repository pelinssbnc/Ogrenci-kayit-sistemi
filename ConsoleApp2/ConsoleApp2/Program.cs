using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Öğretim Görevlisi ve Dersler
        OgretimGorevlisi ogretimGorevlisi1 = new OgretimGorevlisi { Name = "Dr. Kaan Çapanoğlu", Id = "OGR1234", Departman = "Bilgisayar Mühendisliği" };
        OgretimGorevlisi ogretimGorevlisi2 = new OgretimGorevlisi { Name = "Prof. Dr. Öykü Yarıcı", Id = "OGR5678", Departman = "Elektrik-Elektronik Mühendisliği" };
        OgretimGorevlisi ogretimGorevlisi3 = new OgretimGorevlisi { Name = "Doç. Dr. Pelin Su Sabancı", Id = "OGR9101", Departman = "Yazılım Mühendisliği" };
        OgretimGorevlisi ogretimGorevlisi4 = new OgretimGorevlisi { Name = "Dr. Gülay Sabancı", Id = "OGR1122", Departman = "Yapay Zeka Mühendisliği" };

        // Dersler
        Ders ders1 = new Ders("C# Programlama", 4, ogretimGorevlisi1);
        Ders ders2 = new Ders("Veri Yapıları Ve Algoritmalar", 3, ogretimGorevlisi2);
        Ders ders3 = new Ders("İşletim Sistemleri", 3, ogretimGorevlisi3);
        Ders ders4 = new Ders("Elektronik", 4, ogretimGorevlisi2);
        Ders ders5 = new Ders("Makine Öğrenmesi", 3, ogretimGorevlisi1);
        Ders ders6 = new Ders("İnternet Programcılığı", 3, ogretimGorevlisi3);
        Ders ders7 = new Ders("Nesneye Dayalı Programlama", 4, ogretimGorevlisi4);

        // Öğrenciler
        List<Ogrenci> ogrenciListesi = new List<Ogrenci>();

        // Öğretim Görevlisi Listesi
        List<OgretimGorevlisi> ogretimGorevlisiListesi = new List<OgretimGorevlisi> { ogretimGorevlisi1, ogretimGorevlisi2, ogretimGorevlisi3, ogretimGorevlisi4 };

        // Ders Listesi
        List<Ders> tumDersler = new List<Ders> { ders1, ders2, ders3, ders4, ders5, ders6, ders7 };

        // Öğrenci
        Ogrenci ogrenciGiren = null;

        bool devamEt = true;

        while (devamEt)
        {
            Console.WriteLine("\n1. Öğrenci Girişi");
            Console.WriteLine("2. Öğretim Görevlisi ve Ders Görüntüle");
            Console.WriteLine("3. Derse Kayıt Ol");
            Console.WriteLine("4. Dersten Kayıt Sil");
            Console.WriteLine("5. Öğrenci Listesini Görüntüle");
            Console.WriteLine("6. Admin Girişi");
            Console.WriteLine("7. Çıkış");
            Console.Write("Seçiminizi yapın: ");
            string secim = Console.ReadLine();

            switch (secim)
            {
                case "1":
                    // Öğrenci Girişi
                    Console.Write("Öğrenci Adı: ");
                    string ogrenciAd = Console.ReadLine();
                    ogrenciGiren = new Ogrenci { Name = ogrenciAd, Id = "OGRE" + new Random().Next(1000, 9999) };
                    ogrenciGiren.Login();
                    ogrenciGiren.BilgiGoster();
                    ogrenciListesi.Add(ogrenciGiren);
                    break;
                case "2":
                    // Öğretim Görevlisi ve Ders Görüntüle
                    Console.WriteLine("\nÖğretim Görevlileri:");
                    for (int i = 0; i < ogretimGorevlisiListesi.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. {ogretimGorevlisiListesi[i].Name}");
                    }
                    Console.Write("Bir öğretim görevlisi seçin (numara): ");
                    int ogretmenSecim = int.Parse(Console.ReadLine()) - 1;

                    if (ogretmenSecim >= 0 && ogretmenSecim < ogretimGorevlisiListesi.Count)
                    {
                        OgretimGorevlisi seciliOgretmen = ogretimGorevlisiListesi[ogretmenSecim];
                        Console.WriteLine($"{seciliOgretmen.Name} tarafından verilen dersler:");
                        foreach (var ders in seciliOgretmen.VerilenDersler)
                        {
                            Console.WriteLine($"- {ders.DersAdi} (Kredi: {ders.Kredi})");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Geçersiz seçim.");
                    }
                    break;
                case "3":
                    // Derse Kayıt Ol
                    if (ogrenciGiren == null)
                    {
                        Console.WriteLine("Öğrenci girişi yapmadınız. Lütfen önce giriş yapın.");
                    }
                    else
                    {
                        Console.WriteLine("\nMevcut Dersler:");
                        int dersIndex = 1;
                        foreach (var ders in tumDersler)
                        {
                            Console.WriteLine($"{dersIndex}. {ders.DersAdi} - Kredi: {ders.Kredi}");
                            dersIndex++;
                        }
                        Console.Write("Kayıt olmak istediğiniz dersin numarasını yazın: ");
                        int dersNo = int.Parse(Console.ReadLine());
                        if (dersNo > 0 && dersNo <= tumDersler.Count)
                        {
                            ogrenciGiren.KayitOl(tumDersler[dersNo - 1]);
                        }
                        else
                        {
                            Console.WriteLine("Geçersiz ders numarası.");
                        }
                    }
                    break;
                case "4":
                    // Dersten Kayıt Sil
                    if (ogrenciGiren == null)
                    {
                        Console.WriteLine("Öğrenci girişi yapmadınız. Lütfen önce giriş yapın.");
                    }
                    else
                    {
                        Console.WriteLine("\nKayıtlı Olduğunuz Dersler:");
                        ogrenciGiren.BilgiGoster();
                        Console.Write("Kayıt silmek istediğiniz dersin numarasını yazın: ");
                        int silinecekDersNo = int.Parse(Console.ReadLine());
                        if (silinecekDersNo > 0 && silinecekDersNo <= ogrenciGiren.Courses.Count)
                        {
                            ogrenciGiren.KayitSil(ogrenciGiren.Courses[silinecekDersNo - 1]);
                        }
                        else
                        {
                            Console.WriteLine("Geçersiz ders numarası.");
                        }
                    }
                    break;
                case "5":
                    // Öğrenci Listesini Görüntüle
                    Console.WriteLine("\nÖğrenci Listesi ve Aldıkları Dersler:");
                    foreach (var ogrenci in ogrenciListesi)
                    {
                        Console.WriteLine($"Öğrenci: {ogrenci.Name} ({ogrenci.Id})");
                        ogrenci.BilgiGoster();
                    }
                    break;
                case "6":
                    // Admin Girişi
                    Console.Write("Admin Kullanıcı Adı: ");
                    string kullaniciAdi = Console.ReadLine();
                    Console.Write("Admin Şifre: ");
                    string sifre = Console.ReadLine();

                    if (kullaniciAdi == "admin" && sifre == "admin")
                    {
                        bool adminDevam = true;
                        while (adminDevam)
                        {
                            Console.WriteLine("\nAdmin Paneli");
                            Console.WriteLine("1. Öğretim Görevlisi Ekle");
                            Console.WriteLine("2. Öğretim Görevlisi Sil");
                            Console.WriteLine("3. Öğretim Görevlisine Ders Ekle");
                            Console.WriteLine("4. Öğretim Görevlisinden Ders Sil");
                            Console.WriteLine("5. Çıkış");
                            string adminSecim = Console.ReadLine();

                            switch (adminSecim)
                            {
                                case "1":
                                    // Öğretim Görevlisi Ekle
                                    Console.Write("Yeni öğretim görevlisi adı: ");
                                    string ogretimAd = Console.ReadLine();
                                    Console.Write("Departman: ");
                                    string departman = Console.ReadLine();
                                    ogretimGorevlisiListesi.Add(new OgretimGorevlisi { Name = ogretimAd, Departman = departman });
                                    Console.WriteLine("Yeni öğretim görevlisi eklendi.");
                                    break;
                                case "2":
                                    // Öğretim Görevlisi Sil
                                    Console.WriteLine("Öğretim Görevlisi Sil:");
                                    Console.WriteLine("Öğretim Görevlileri:");
                                    for (int i = 0; i < ogretimGorevlisiListesi.Count; i++)
                                    {
                                        Console.WriteLine($"{i + 1}. {ogretimGorevlisiListesi[i].Name}");
                                    }
                                    Console.Write("Silmek istediğiniz öğretim görevlisini seçin: ");
                                    int silinecekOgretmenNo = int.Parse(Console.ReadLine()) - 1;
                                    if (silinecekOgretmenNo >= 0 && silinecekOgretmenNo < ogretimGorevlisiListesi.Count)
                                    {
                                        ogretimGorevlisiListesi.RemoveAt(silinecekOgretmenNo);
                                        Console.WriteLine("Öğretim görevlisi başarıyla silindi.");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Geçersiz seçim.");
                                    }
                                    break;
                                case "3":
                                    // Öğretim Görevlisine Ders Ekle
                                    Console.WriteLine("Öğretim Görevlisi Seç:");
                                    for (int i = 0; i < ogretimGorevlisiListesi.Count; i++)
                                    {
                                        Console.WriteLine($"{i + 1}. {ogretimGorevlisiListesi[i].Name}");
                                    }
                                    int ogretmenIndex = int.Parse(Console.ReadLine()) - 1;
                                    Console.Write("Ders adı: ");
                                    string dersAdi = Console.ReadLine();
                                    Console.Write("Kredi: ");
                                    int dersKredi = int.Parse(Console.ReadLine());
                                    ogretimGorevlisiListesi[ogretmenIndex].VerilenDersler.Add(new Ders(dersAdi, dersKredi, ogretimGorevlisiListesi[ogretmenIndex]));
                                    Console.WriteLine("Ders başarıyla eklendi.");
                                    break;
                                case "4":
                                    // Öğretim Görevlisinden Ders Sil
                                    Console.WriteLine("Öğretim Görevlisi Seç:");
                                    for (int i = 0; i < ogretimGorevlisiListesi.Count; i++)
                                    {
                                        Console.WriteLine($"{i + 1}. {ogretimGorevlisiListesi[i].Name}");
                                    }
                                    int silinecekOgretmenIndex = int.Parse(Console.ReadLine()) - 1;
                                    Console.WriteLine("Verilen Dersler:");
                                    for (int i = 0; i < ogretimGorevlisiListesi[silinecekOgretmenIndex].VerilenDersler.Count; i++)
                                    {
                                        Console.WriteLine($"{i + 1}. {ogretimGorevlisiListesi[silinecekOgretmenIndex].VerilenDersler[i].DersAdi}");
                                    }
                                    Console.Write("Silmek istediğiniz dersi seçin: ");
                                    int silinecekDersIndex = int.Parse(Console.ReadLine()) - 1;
                                    if (silinecekDersIndex >= 0 && silinecekDersIndex < ogretimGorevlisiListesi[silinecekOgretmenIndex].VerilenDersler.Count)
                                    {
                                        ogretimGorevlisiListesi[silinecekOgretmenIndex].VerilenDersler.RemoveAt(silinecekDersIndex);
                                        Console.WriteLine("Ders başarıyla silindi.");
                                    }
                                    break;
                                case "5":
                                    adminDevam = false;
                                    break;
                                default:
                                    Console.WriteLine("Geçersiz seçim.");
                                    break;
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Geçersiz kullanıcı adı veya şifre.");
                    }
                    break;
                case "7":
                    // Çıkış
                    devamEt = false;
                    break;
                default:
                    Console.WriteLine("Geçersiz seçim, tekrar deneyin.");
                    break;
            }
        }
    }
}

public class OgretimGorevlisi
{
    public string Name { get; set; }
    public string Id { get; set; }
    public string Departman { get; set; }
    public List<Ders> VerilenDersler { get; set; } = new List<Ders>();

    public void BilgiGoster()
    {
        Console.WriteLine($"Öğretim Görevlisi Adı: {Name}");
        Console.WriteLine($"Departman: {Departman}");
    }
}

public class Ders
{
    public string DersAdi { get; set; }
    public int Kredi { get; set; }
    public OgretimGorevlisi Ogretmen { get; set; }

    public Ders(string dersAdi, int kredi, OgretimGorevlisi ogretmen)
    {
        DersAdi = dersAdi;
        Kredi = kredi;
        Ogretmen = ogretmen;
        ogretmen.VerilenDersler.Add(this);
    }
}

public class Ogrenci
{
    public string Name { get; set; }
    public string Id { get; set; }
    public List<Ders> Courses { get; set; } = new List<Ders>();

    public void Login()
    {
        Console.WriteLine($"Hoşgeldiniz {Name}, giriş yapıldı.");
    }

    public void BilgiGoster()
    {
        Console.WriteLine($"Öğrenci Adı: {Name}");
        Console.WriteLine($"Kayıtlı Dersler:");
        int index = 1;
        foreach (var ders in Courses)
        {
            Console.WriteLine($"{index}. {ders.DersAdi} - Kredi: {ders.Kredi}");
            index++;
        }
    }

    public void KayitOl(Ders ders)
    {
        Courses.Add(ders);
        Console.WriteLine($"Başarıyla {ders.DersAdi} dersine kayıt oldunuz.");
    }

    public void KayitSil(Ders ders)
    {
        Courses.Remove(ders);
        Console.WriteLine($"Başarıyla {ders.DersAdi} dersinden kaydınız silindi.");
    }
}
