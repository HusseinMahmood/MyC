using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

class Program
{
    static List<string> aa = new List<string>();
    static Random r = new Random();
    static int tot = 0, good = 0, len = 0, oo = 0;
    
    static private void Dive(string prefix, int level)
    {
        int maxLength = len;
        string chars;
        //oo++;

        while(aa.Count > 10000) Thread.Sleep(1000);
        

        chars = "lmnopqrstuvwxyzdrfghiabcjk1234567890";

        level += 1;
        foreach (var c in chars)
        {
                aa.Add(prefix + c);
            if (level < maxLength)
                Dive(prefix + c, level);
        }
    }

    static string Randoma(int size)
    {
        string Output = "";
        string a = "ikolbyhnmjupqazwsxedcrfvtg1234567890";

        Random R = new Random();
        for (int i = 0; i < size; i++) Output += a[R.Next(0, a.Length)];
        return Output;
    }

    static void Main(string[] args)
    {




        Console.Write("Name : ");
        name = Console.ReadLine();

        Console.WriteLine("Len : ");
        len = int.Parse(Console.ReadLine());


        new Task(() => Dive("", 0)).Start();

        Thread.Sleep(1000);
        for (int i = 0; i< 100; i ++)
            new Task(() => {
                start();
            }).Start();

        while(aa.Count > 0)
        {
            Console.Clear();
            Console.WriteLine("Good : " + good);
            Console.WriteLine("Totel : " + tot);
            Thread.Sleep(1000);

        }

        Console.WriteLine("done");
        Console.ReadLine();

    }
    static string name = "";
    static void start()
    {
        
        string msg = "مرحبا ♥️\r\nانا متابعك من زمان وحبيت اهديلك هدية حلوة\r\nوما شفت احسن من اني ابرمجلك بوت لتحميل القرآن الكريم على التيليجرام\r\nواتمنى تشوفة ويعجبك\r\nمعرف البوت على التليجرام \r\n@Quran_aBOT\r\n\r\nصدقة جارية لكل المسلمين ♥️\r\n";
        string url = "https://www.sarhne.com/ajax/messages/send.html";

        while (aa.Count > 0)
        {


            try { 
                string user = aa[r.Next(0, aa.Count)];
                aa.Remove(user);

                user = name + user;

                HttpWebRequest httprequest = (HttpWebRequest)HttpWebRequest.Create(url);
                httprequest.Method = "POST";
                httprequest.Headers.Add("Cookie", $"security={Randoma(32)}; __gads=ID={Randoma(32)}:T=1638888703:RT=1638888703:S={Randoma(32)}; _ga=GA1.2.1274615500.{Randoma(12)}; _gid=GA1.2.924772648.{Randoma(12)}; _gat_gtag_UA_117429964_1=1");
                httprequest.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/96.0.4664.45 Safari/537.36";
                httprequest.Host = "www.sarhne.com";
                httprequest.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
                httprequest.Timeout = 10000;

                byte[] bytedata = Encoding.UTF8.GetBytes($"msg={msg}&show_my_info=on&link={user}&bad_words=false");
                httprequest.ContentLength = bytedata.Length;
                Stream poststream = httprequest.GetRequestStream();
                poststream.Write(bytedata, 0, bytedata.Length);
                poststream.Flush();
                poststream.Close();

            


                HttpWebResponse Response;
                string Result = "";
                try
                {
                    Response = (HttpWebResponse)httprequest.GetResponse();
                    Result = new StreamReader(Response.GetResponseStream()).ReadToEnd();
                }
                catch (WebException E)
                {

                    try { 
                        //HttpWebResponse Response1 = (HttpWebResponse)E.Response;
                        //Result = new StreamReader(Response1.GetResponseStream()).ReadToEnd();
                        //Console.WriteLine(Result);
                    }
                    catch { }
                }

                // Console.WriteLine(Result);

            aa:
                {
                    try
                    {
                        if (Result.Contains("successfully")) {
                            //File.AppendAllText("good.txt", user + "\r\n");
                            StreamWriter file2 = new StreamWriter("good.txt", true);
                            file2.WriteLine(user);
                            file2.Close();
                            good++; }
                    }
                    catch { goto aa; }

                }


            }
            catch { }
            tot++;
        }



  }
}
