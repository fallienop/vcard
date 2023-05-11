using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Globalization;
using System.Net.Http;
using System.Threading.Tasks;
using System.Runtime.InteropServices.WindowsRuntime;
using static vcard.deserilaized;
using System.Xml.Linq;

namespace vcard
{
    public class Program
    {
        static readonly HttpClient client = new HttpClient();

        static void Main(string[] args)
        {
            string path = @"C:\Users\sahin\source\repos\vcard\vcard\vcards\";
            //  var deserializedObject = new deserilaized.Name();
            var namee = new Name
            {
                title = "",
                first = new List<string>(),
                last = new List<string>()
            };


            string s = http().GetAwaiter().GetResult();
            for (int i = 1; i <= 25; i++)
            {
                int ifn = s.IndexOf("first\":");
                s = s.Remove(0, ifn + 8);
                int dfn = s.IndexOf("\"");
                string name = s.Substring(0, dfn);
                int iln = s.IndexOf("last\":");
                s = s.Remove(0, iln + 7);
                int dln = s.IndexOf("\"");
                string surname = s.Substring(0, dln);
                namee.first.Add(name);
                namee.last.Add(surname);
            }

            for (int i = 0; i < Math.Max(namee.first.Count, namee.last.Count); i++)
            {
                string result = "";
                string firstvalue = namee.first.ElementAt(i);
                string lastvalue = namee.last.ElementAt(i);
                string sorted = string.Compare(lastvalue, firstvalue) > 0 ? firstvalue : lastvalue;
                result += $"BEGIN:VCARD\nFN:{firstvalue} {lastvalue}\nN:{lastvalue} {firstvalue}\nSORT-STRING:{sorted}\nEND:VCARD\n\n";
                var filename = $"{path}vcf{i + 1}.vcf";
                File.WriteAllText(filename, result);

            }
            //string ss=namee.ToString();
            //   Console.WriteLine(ss);


        }





        public static async Task<string> http()
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync("https://randomuser.me/api?results=50");
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                return responseBody;
            }
            catch (Exception ex) { return null; }
        }
    }
}
