using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LibrarySystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Store kütüp = null;
            bool bul = false;

            if (kütüp == null)
            {
                Console.WriteLine("Mağaza Oluşturunuz.");
                Console.WriteLine("....");
                Thread.Sleep(1000);
                Console.Write("Mağzaya Stok Sayısı Giriniz: ");
                int stok = Int32.Parse(Console.ReadLine());
                kütüp = new Store(stok);
            }

            List<Kitap> kitaplar = new List<Kitap>();
            List<Kitap> sepet = new List<Kitap>();

            while (true)
            {
                for (int i = kitaplar.Count - 1; i >= 0; i--)
                {
                    if (kitaplar[i].stok == 0)
                    {
                        kitaplar.RemoveAt(i);
                    }
                }

                Console.WriteLine("İŞLEM\n1.Kitap Ekle\n2.Kitapları Listele\n3.Satın Al\n4.Çıkış");
                int menü = Int32.Parse(Console.ReadLine());

                if (menü == 1)
                {
                    if (kütüp.stok == 0)
                    {
                        Console.WriteLine("Stok Sınırı Aşıldı.");
                        continue;
                    }

                    bul = false;

                    Console.Write("Kitap İsmi: ");
                    string ad = Console.ReadLine();
                    Console.Write("Kitap Yazarı: ");
                    string yazar = Console.ReadLine();
                    Console.Write("Fiyat: ");
                    int fiyat = Int32.Parse(Console.ReadLine());

                    for (int i = 0; i < kitaplar.Count; i++)
                    {
                        if (kitaplar[i].ad.ToLower() == ad.ToLower() && kitaplar[i].yazar.ToLower() == yazar.ToLower() && kitaplar[i].fiyat == fiyat)
                        {
                            kitaplar[i].stok++;
                            kütüp.stok--;
                            bul = true;
                            break;
                        }
                    }

                    if (!bul)
                    {
                        Kitap kitap = new Kitap(ad, yazar, fiyat, 1);
                        kitaplar.Add(kitap);
                        kütüp.stok--;
                    }
                    else
                    {
                        Console.WriteLine("Stok Artırıldı.");
                    }
                }
                else if (menü == 2)
                {
                    foreach (var kitap in kitaplar)
                    {
                        Console.WriteLine(kitap);
                    }
                }
                else if (menü == 3)
                {
                    while (true)
                    {
                        Console.Write("MENÜ\n1.Sepete Ekle\n2.Sepeti Görüntüle\n3.Satın Al\n4.Çıkış");
                        int satın = Int32.Parse(Console.ReadLine());

                        if (satın == 1)
                        {
                            Console.Write("Kitap İsmi: ");
                            string kitapis = Console.ReadLine();

                            for (int i = 0; i < kitaplar.Count; i++)
                            {
                                if (kitaplar[i].ad.ToLower() == kitapis.ToLower())
                                {
                                    if (kitaplar[i].stok > 0)
                                    {
                                        bool varMi = false;

                                        for (int j = 0; j < sepet.Count; j++)
                                        {
                                            if (sepet[j].ad == kitapis)
                                            {
                                                sepet[j].stok++;
                                                varMi = true;
                                                break;
                                            }
                                        }

                                        if (!varMi)
                                        {
                                            sepet.Add(new Kitap(kitaplar[i].ad, kitaplar[i].yazar, kitaplar[i].fiyat, 1));
                                        }

                                        kitaplar[i].stok--;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Stok yok!");
                                    }
                                    break;
                                }
                            }
                        }
                        else if (satın == 2)
                        {
                            int ücret = 0;
                            foreach (var kitap in sepet)
                            {
                                Console.WriteLine(kitap);
                                ücret += kitap.fiyat * kitap.stok;
                            }
                            Console.WriteLine("Toplam Ücret: " + ücret);
                        }
                        else if (satın == 3)
                        {
                            if (sepet.Count > 0)
                            {
                                sepet.Clear();
                                Console.WriteLine("Satın alındı.");
                            }
                            else
                            {
                                Console.WriteLine("sepet boş");
                            }
                        }
                        else
                        {
                            break;
                        }
                    }
                }
                else if (menü == 4)
                {
                    break;
                }
            }
        }
    }
}
