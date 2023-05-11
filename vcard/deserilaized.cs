using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vcard
{
    public class deserilaized
    {
        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);


        public class Name
        {
            public string title { get; set; }
            public List<string> first { get; set; }
            public List<string> last { get; set; }

            //public override string ToString()
            //{
            //    string result = "";

            //   for(int i=0;i<Math.Max(first.Count, last.Count);i++) 
            //    {string firstvalue=first.ElementAt(i);
            //        string lastvalue=last.ElementAt(i);
            //       string sorted= string.Compare(lastvalue, firstvalue) > 0 ? firstvalue : lastvalue;
            //        result += $"BEGIN:VCARD\nFN:{firstvalue} {lastvalue}\nN:{lastvalue} {firstvalue}\nSORT-STRING:{sorted}\nEND:VCARD\n\n";

            //    }

            //    return result;
            //}
        }


    }
}
