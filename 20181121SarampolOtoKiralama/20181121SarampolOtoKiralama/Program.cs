using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20181121SarampolOtoKiralama
{
    class Program
    {
        static void Main(string[] args)
        {
            // 20 araçlık  (Marka, plaka, fiyat, durum, gün Sayısı) bilgilerinin tutulduğu bir oto kiralama uygulaması
            //Menü  1- Araç Kirala 2- Araç Teslim  3- Araçları Listele 4- kasa 5- Bakım 6- Çıkış

            string[,] araclar = new string[20, 5]
            {
                {"BMW","34 HJ 0302","200","UYGUN","0" },
                {"BMW","34 HG 2243","200","UYGUN","0" },
                {"MERCEDES","34 FY 1135","200","UYGUN","0" },
                {"MERCEDES","34 KL 1125","200","UYGUN","0" },
                {"VOLKSWAGEN","34 TJ 0154","180","UYGUN","0" },
                {"VOLKSWAGEN","34 UZ 8992","180","UYGUN","0" },
                {"AUDI","34 BCT 099","200","UYGUN","0" },
                {"AUDI","34 BEP 105","200","UYGUN","0" },
                {"FORD","34 TY 2298","170","UYGUN","0" },
                {"FORD","34 TZ 1474","200","UYGUN","0" },
                {"RENAULT","34 GR 6585","160","UYGUN","0" },
                {"RENAULT","34 FS 9698","160","UYGUN","0" },
                {"TOYOTA","34 BP 1036","170","UYGUN","0" },
                {"TOYOTA","34 VF 2588","170","UYGUN","0" },
                {"FIAT","34 LK 3635","160","UYGUN","0" },
                {"FIAT","34 KL 6657","160","UYGUN","0" },
                {"HYUNDAI","34 ES 2257","160","UYGUN","0" },
                {"HYUNDAI","34 DF 7785","160","UYGUN","0" },
                {"OPEL","34 SA 1200","170","UYGUN","0" },
                {"OPEL","34 AS 3254","170","UYGUN","0" },
            };

            double kasa = 0;
            bool dongu = true;
            ConsoleKeyInfo menu;
            Console.Title = "ŞARAMPOL CAR RENTING";

            do
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("1- Araç Kirala\n2- Araç Teslim\n3- Araçları Listele\n4- Kasa\n5- Bakım\n6- Çıkış");
                menu = Console.ReadKey(false);

                #region araç kiralama
                if (menu.KeyChar == '1')
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Araç kirala".ToUpper());
                    #region araçları listeleyen kod

                    Console.WriteLine("{0,-3}{1,-12}{2,-12}{3,-8}{4,-8}{5,-8}", "ID", "MARKA", "PLAKA", "FİYAT", "DURUM", "GÜN");
                    for (int i = 0; i < araclar.GetLength(0); i++)
                    {
                        Console.WriteLine("{0,-3}{1,-12}{2,-12}{3,-8}{4,-8}{5,-8}", (i + 1), araclar[i, 0], araclar[i, 1], araclar[i, 2], araclar[i, 3], araclar[i, 4]);
                    }
                #endregion
                x: Console.Write("Araç seçmek için araçId'sini girin: ");
                    int aracId = int.Parse(Console.ReadLine()) - 1;

                    if (aracId < 1 || aracId > 20)
                    {
                        Console.WriteLine("Araç Id 1 ile 20 arasında olmalıdır.");
                        goto x;
                    }
                    if (araclar[aracId, 3] != "UYGUN")
                    {
                        Console.WriteLine($"Seçilen {araclar[aracId, 0]} marka, {araclar[aracId, 1]} plakalı araç kiralanmak için uygun değil. Araç Durumu: {araclar[aracId, 3]}");
                        // goto x;// kullana da biliriz (bakış açısı)
                    }
                    else
                    {
                        Console.Write("Kiralama gün sayısı: ");
                        int gun = int.Parse(Console.ReadLine());


                        Console.WriteLine($"Seçilen {araclar[aracId, 0]} marka, {araclar[aracId, 1]} plakalı aracın günlük fiyatı: {araclar[aracId, 2]} TL'dir. {gun} gün için kiralama fiyatı= {gun * int.Parse(araclar[aracId, 2])} TL.\nOnaylamak için Enter, iptal için başka tuşa basın...");
                        ConsoleKeyInfo onay = Console.ReadKey(false);
                        if (onay.Key == ConsoleKey.Enter)
                        {
                            araclar[aracId, 3] = "KİRADA";
                            araclar[aracId, 4] = gun.ToString();
                            kasa += gun * int.Parse(araclar[aracId, 2]);
                            Console.WriteLine($"Seçilen {araclar[aracId, 0]} marka, {araclar[aracId, 1]} palakalı araç kiralandı.");
                        }
                        else
                        {
                            Console.WriteLine("Kiralama işlemi iptal edildi.");
                        }
                    }
                }
                #endregion
                #region araç teslim
                else if (menu.KeyChar == '2')
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("Araç teslim".ToUpper());
                    #region araçları listeleyen kod

                    Console.WriteLine("{0,-3}{1,-12}{2,-12}{3,-8}{4,-8}{5,-8}", "ID", "MARKA", "PLAKA", "FİYAT", "DURUM", "GÜN");
                    for (int i = 0; i < araclar.GetLength(0); i++)
                    {
                        Console.WriteLine("{0,-3}{1,-12}{2,-12}{3,-8}{4,-8}{5,-8}", (i + 1), araclar[i, 0], araclar[i, 1], araclar[i, 2], araclar[i, 3], araclar[i, 4]);
                    }
                #endregion
                x: Console.Write("Teslim edilecek aracın araçId'sini girin: ");
                    int aracId = int.Parse(Console.ReadLine()) - 1;

                    if (aracId < 1 || aracId > 20)
                    {
                        Console.WriteLine("Araç Id 1 ile 20 arasında olmalıdır.");
                        goto x;
                    }
                    if (araclar[aracId, 3] != "KİRADA")
                    {
                        Console.WriteLine($"Seçilen {araclar[aracId, 0]} marka, {araclar[aracId, 1]} plakalı araç teslim edilmek için uygun değil. Araç Durumu: {araclar[aracId, 3]}");
                        // goto x;// kullana da biliriz (bakış açısı)
                    }
                    else
                    {
                        Console.WriteLine("Araçta hasar var ise 1'e değil ise herhangi bir tuşa basın..");
                        ConsoleKeyInfo teslim = Console.ReadKey(false);
                        if (teslim.KeyChar == '1')
                        {
                            Console.Write("Hasar tutarı: ");
                            int tutar = int.Parse(Console.ReadLine());
                            kasa += tutar;
                            araclar[aracId, 3] = "BAKIMDA";
                            araclar[aracId, 4] = "0";
                            Console.WriteLine("Araç teslim alınıp, bakıma gönderildi.");
                        }
                        else
                        {
                            araclar[aracId, 3] = "UYGUN";
                            araclar[aracId, 4] = "0";
                            Console.WriteLine("Araç teslim alındı..");
                        }
                    }
                }
                #endregion
                #region araç listele
                else if (menu.KeyChar == '3')
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("Araç listesi".ToUpper());
                    #region araçları listeleyen kod

                    Console.WriteLine("{0,-3}{1,-12}{2,-12}{3,-8}{4,-8}{5,-8}", "ID", "MARKA", "PLAKA", "FİYAT", "DURUM", "GÜN");
                    for (int i = 0; i < araclar.GetLength(0); i++)
                    {
                        if (araclar[i, 3] == "UYGUN")
                            Console.ForegroundColor = ConsoleColor.White;
                        if (araclar[i, 3] == "KİRADA")
                            Console.ForegroundColor = ConsoleColor.Red;
                        else
                            Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("{0,-3}{1,-12}{2,-12}{3,-8}{4,-8}{5,-8}", (i + 1), araclar[i, 0], araclar[i, 1], araclar[i, 2], araclar[i, 3], araclar[i, 4]);
                    }
                    #endregion
                    Console.WriteLine("Devam etmek için bir tuşa basın.");
                    Console.ReadKey();
                }
                #endregion
                #region kasa
                else if (menu.KeyChar == '4')
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("aman da paracıklarım".ToUpper());
                    Console.WriteLine("KASA= " + kasa + " TL");
                    Console.WriteLine("Devam etmek için bir tuşa basın...");
                    Console.ReadKey();
                }
                #endregion
                #region bakım
                else if (menu.KeyChar == '5')
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("Araç bakım".ToUpper());
                    Console.WriteLine("1- Bakım Giriş\t2- Bakım Çıkış\t3- Bakımdaki araçları gör");
                    ConsoleKeyInfo bakim = Console.ReadKey(false);
                    if (bakim.KeyChar == '1')
                    {
                        #region araçları listeleyen kod

                        Console.WriteLine("{0,-3}{1,-12}{2,-12}{3,-8}{4,-8}{5,-8}", "ID", "MARKA", "PLAKA", "FİYAT", "DURUM", "GÜN");
                        for (int i = 0; i < araclar.GetLength(0); i++)
                        {
                            if (araclar[i, 3] != "UYGUN")
                                continue;

                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("{0,-3}{1,-12}{2,-12}{3,-8}{4,-8}{5,-8}", (i + 1), araclar[i, 0], araclar[i, 1], araclar[i, 2], araclar[i, 3], araclar[i, 4]);

                        }

                    #endregion
                    x: Console.WriteLine("Bakıma sokulacak araç Id'si: ");
                        int aracId = int.Parse(Console.ReadLine()) - 1;


                        if (aracId < 1 || aracId > 20)
                        {
                            Console.WriteLine("Araç Id 1 ile 20 arasında olmalıdır.");
                            goto x;
                        }
                        if (araclar[aracId, 3] != "UYGUN")
                        {
                            Console.WriteLine($"Seçilen {araclar[aracId, 0]} marka, {araclar[aracId, 1]} plakalı araç bakıma alınmak için uygun değil. Araç Durumu: {araclar[aracId, 3]}");

                        }
                        else
                        {
                            araclar[aracId, 3] = "BAKIMDA";
                            Console.WriteLine("Araç bakıma gönderildi.");
                        }
                    }
                    else if (bakim.KeyChar == '2')
                    {
                        #region araçları listeleyen kod

                        Console.WriteLine("{0,-3}{1,-12}{2,-12}{3,-8}{4,-8}{5,-8}", "ID", "MARKA", "PLAKA", "FİYAT", "DURUM", "GÜN");
                        for (int i = 0; i < araclar.GetLength(0); i++)
                        {
                            if (araclar[i, 3] != "BAKIMDA")
                                continue;

                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("{0,-3}{1,-12}{2,-12}{3,-8}{4,-8}{5,-8}", (i + 1), araclar[i, 0], araclar[i, 1], araclar[i, 2], araclar[i, 3], araclar[i, 4]);

                        }

                    #endregion
                    x: Console.WriteLine("Bakıma sokulacak araç Id'si: ");
                        int aracId = int.Parse(Console.ReadLine()) - 1;


                        if (aracId < 1 || aracId > 20)
                        {
                            Console.WriteLine("Araç Id 1 ile 20 arasında olmalıdır.");
                            goto x;
                        }
                        if (araclar[aracId, 3] != "BAKIMDA")
                        {
                            Console.WriteLine($"Seçilen {araclar[aracId, 0]} marka, {araclar[aracId, 1]} plakalı araç bakımdan çıkarılmak için uygun değil. Araç Durumu: {araclar[aracId, 3]}");

                        }
                        else
                        {
                            araclar[aracId, 3] = "UYGUN";
                            Console.WriteLine("Araç bakımdan çıkarıldı.");
                        }
                    }
                    else if (bakim.KeyChar == '3')
                    {
                        #region araçları listeleyen kod

                        Console.WriteLine("{0,-3}{1,-12}{2,-12}{3,-8}{4,-8}{5,-8}", "ID", "MARKA", "PLAKA", "FİYAT", "DURUM", "GÜN");
                        for (int i = 0; i < araclar.GetLength(0); i++)
                        {
                            if (araclar[i, 3] != "BAKIMDA")
                                continue;

                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("{0,-3}{1,-12}{2,-12}{3,-8}{4,-8}{5,-8}", (i + 1), araclar[i, 0], araclar[i, 1], araclar[i, 2], araclar[i, 3], araclar[i, 4]);

                        }

                        #endregion

                        Console.WriteLine("Devam etmek için bir tuşa basın.");
                    }
                }
                #endregion
                else if (menu.KeyChar == '6')
                {
                    Console.WriteLine("Uygulamadan çıkış yapılıyor. Güle Güle");
                    System.Threading.Thread.Sleep(2500);
                    //Environment.Exit(0);
                    dongu = false;
                }
                else
                {

                    Console.WriteLine("Hatalı menü seçimi");
                    Console.Beep(1000, 1000);
                }

                if (dongu)
                    Console.WriteLine("Menüye Yönleniyor....");
                System.Threading.Thread.Sleep(2000);

            } while (dongu);

        }
    }
}
