using RemoteInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsRemoteFileExist
{
    class Program
    {
        private static List<string> computers = new List<string>() {
            "PGRITSEN2",
"DLEVSHEN",
"MSEMERNI",
"KOLEKSUK2",
"SMARKOV2",
"RGRIGORIAN",
"ASKLYARO",
"AVAVILOV2",
"YGURA2",
"PBABESHK2",
"SKLIMENKO",
"ZHURAVLYOV",
"MANTONOV",
"ESAMKO",
"NSIDORCHENKO",
"MLOGVINOV",
"TSKLYAR",
"MACHINE06",
"MSTARIKOV",
"MSHLAKHT2",
"SREBNYUK",
"MACHINE03",
"OBAIBENK2",
"ALOTNIK2",
"VSHUVAEV2",
"WIN-0BCG8NF5NND",
"EORLOV2",
"MVDOVARE",
"YVDOVITSA",
"DSHEVCHUK",
"AGANYSH2",
"KMARTYNUK",
"AKUTSENK2",
"MLUGIN2",
"AISAEV",
"PSREBNYUK",
"ASUVOROVA",
"AVALINOV",
"AROSINSKAYA",
"STRUBAEVA",
"ANIKULSHIN",
"OSETINSKIY",
"ESOSNOVA",
"ABUDNYK",
"VANANYEV",
"VCHUPRYNIN",
"MEDVEDEV2",
"SREBROV",
"ASKLYAROV",
"KBABENKO2",
"CHETVERTAK2",
"DGOLDINER",
"LKHOPRIA",
"TTSARENKO",
"KPUSICH",
"ASHULIKA2",
"KNAUMYCH",
"AKOLIADE2",
"AVELICHKO",
"ADIDENKO",
"MTARAN",
"YKOVAL",
"TOPCHIY2",
"NFIRSTOV2",
"RMIROSHN",
"IDENISENKO2",
"MNARTOV2",
"IGORMAK",
"MACHINE05",
"ABURYK",
"IPLUSHKO",
"AKHURDEI",
"MVYSOCHI2",
"AKURISHE2",
"VSINKOVA2",
"DVOLOKH",
"TMILOVA2",
"ACHERNYAVSKIY",
"ISUKHOTIN",
"ACHYSTYK2",
"EANDRUSH2",
"SCHESHKOV",
"MACHINE07",
"ASOLOVEV",
"OZHDANOV",
"AKUZMENKO",
"MDOROSHENKO2",
"VSTRELNIKOVA2",
"MACHINE09",
"ZBOKOVEN",
"EGLADISH2",
"MACHINE08",
"MACHINE10",
"MDOROSHENKO",
"NZAGREB2",
"EPOZDORO2",
"SHUVAEVA2",
"DUDACHIN2",
"YTKACHENKO",
"KHARCHEVNIKOVA",
"VSHVED",
"VERBA",
"AKISLOV",
"VKOTEL",
"KOLEKSYUK",
"AHONCHAROVA",
"YONISHCH2",
"VKUZNETSOVA2",
"AGANYSH",
"MACHINE01",
"MACHINE11",
"YGLADKOVA",
"DLEVSHENKOV",
"MACHINE02",
"BUROVSKAYA2",
"MSHELYAGOV",
"EPIVOVAR",
"ARACHOV2",
"NSIDORCHENKO2",
"2818-OC",
"ADUBROVSKAYA",
"SPODLESN2",
"WIN-B9F9SIRKFFG",
"APAVLOVA2",
"YVDOVITSA3",
"IBRIZHYK2",
"IUMNOV",
"ASTEGANC2",
"VMALINOV2",
"ESEMCHEN2",
"MACHINE04",
"MVDOVAREIZE",
"MKRASNOVSK2",
"ITSKHOVR2",
"APONOMAR",
"APLAKHOT",
"AFEDOTOV",
"VBALAGUT"
        };

        public static object lockObj = new object();
        
        static void Main(string[] args)
        {           
            List<Task> tasks = new List<Task>();

            ConsoleColor oldColor = Console.ForegroundColor;
            int c = 0;
            foreach (string computer in computers)
            {
                //GetHWInfoAsync(computer as string);
                //tasks.Add(Task.Factory.StartNew(() => GetHWInfoAsync(computer)));
                tasks.Add(Task.Factory.StartNew(
                    () => {
                        if(Check.IsMachineUp(computer) == true)
                        {
                            if (System.IO.File.Exists($@"\\{computer}\D$\vpn\InKhHERE.exe") == true)
                            {
                                lock (lockObj)
                                {
                                    Console.ForegroundColor = ConsoleColor.Green;
                                }
                                Console.WriteLine("{0, -20} \t file exist", $"{computer}");
                            }
                            else
                            {
                                lock (lockObj)
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                }
                                Console.WriteLine("{0, -20} \t not found", $"{computer}");
                            }
                        }
                        else
                        {
                            Console.WriteLine("{0, -20} \t connection failed", $"{computer}");
                        }
                        

                        lock (lockObj)
                        {
                            Console.ForegroundColor = oldColor;
                        }
                    }));
                //if (c >= 10) break;
                c++;
            }

            Task.WaitAll(tasks.ToArray());

            Console.WriteLine("\nAll done.");


            //WriteToFile();
            Console.WriteLine("Press eny key for exit.");
            Console.Read();
        }

        //static void WriteToFile()
        //{
        //    string file = @"HostsHWInfo.csv";

        //    try
        //    {
        //        using (StreamWriter sw = new StreamWriter(file, false, System.Text.Encoding.Default))
        //        {
        //            foreach (var info in _allCompInfo)
        //            {
        //                sw.WriteLine($"{info}");
        //            }
        //        }

        //        Console.WriteLine($"Hardware information was saved to file {file}.");
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e.Message);
        //    }
        //}
    }
}
