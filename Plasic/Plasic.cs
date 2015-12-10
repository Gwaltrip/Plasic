using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plasic
{
    class Plasic
    {
        private List<string> code;
        // register number, register attributes
        private Dictionary<string, Register> heap;
        // name, register number
        private Dictionary<string, string> references; 
        
        //Inits the compiler
        public Plasic(string fileloc)
        {
            code = new List<string>();
            List<string> rawcode = File.ReadAllLines(fileloc).ToList();
            for (int i = 0; i < rawcode.Count; i++)
            {
                //removes comments
                rawcode[i] = rawcode[i].Split('#')[0].Trim();
                //takes all lines with commands and places within code list
                if (!Equals(rawcode[i], ""))
                {
                    code.Add(rawcode[i]);
                }
            }

            heap = new Dictionary<string, Register>();
            references = new Dictionary<string, string>();

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < 10; i++)
            {
                sb.Append("$t").Append(i);
                heap.Add(sb.ToString(), new Register());
                sb.Clear();
            }
            for (int i = 0; i < 8; i++)
            {
                sb.Append("$s").Append(i);
                heap.Add(sb.ToString(), new Register());
                sb.Clear();
            }
        }

        //clears the dics at the locations of name.
        public bool Clear(string name)
        {
            heap[references[name]] = new Register();
            return references.Remove(name);
        }
    }
}
