using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        // Veri yapısını oluşturun
        SortedDictionary<string, SortedDictionary<string, string>> rehber = new SortedDictionary<string, SortedDictionary<string, string>>();

        // Dosya yolunu belirleyin
        string dosyaYolu = "rehber.txt";

        // Dosyadan satırları okuyun
        foreach (string satir in File.ReadLines(dosyaYolu))
        {
            // Satırı parçalayın
            string[] parcalar = satir.Split('|');

            // Parçaları temizleyin ve değişkenlere atayın
            string isim = parcalar[0].Trim();
            string sehir = parcalar[1].Trim();
            string telefon = parcalar[2].Trim();

            // Şehir rehberde var mı kontrol edin
            if (!rehber.ContainsKey(sehir))
            {
                // Şehir yoksa, yeni bir iç SortedDictionary oluşturun
                rehber[sehir] = new SortedDictionary<string, string>();
            }

            // İçteki SortedDictionary'ye kişiyi ekleyin
            rehber[sehir][isim] = telefon;
        }

        // Rehberi ekrana yazdırın
        foreach (var sehirKayit in rehber)
        {
            Console.WriteLine($"{sehirKayit.Key} :");
            foreach (var kisiKayit in sehirKayit.Value)
            {
                Console.WriteLine($"{kisiKayit.Key} - {kisiKayit.Value}");
            }
            Console.WriteLine(); // Boş satır ekleyin
        }
    }
}
