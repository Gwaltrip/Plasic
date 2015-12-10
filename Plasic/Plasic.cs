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
        //plp code
        private List<string> plp; 
        //plasic code
        private List<string> code;
        //contains all lables
        private HashSet<string> lables; 
        // register number, register attributes
        private Dictionary<string, Register> heap;
        // name, register number
        private Dictionary<string, string> references; 
        // holds all keywords for refrence
        private string[] keywords = {"global","local","sub","for","to","if","is","then","end","next","clear", "j"};

        private StringBuilder sb = new StringBuilder();


        //Inits the compiler
        public Plasic(string fileloc)
        {
            lables = new HashSet<string>();
            heap = new Dictionary<string, Register>();
            references = new Dictionary<string, string>();
            plp = new List<string>();
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

        public void run()
        {
            foreach (var line in code)
            {
                Linescan(line);
            }
            foreach (var v in plp)
            {
                Console.WriteLine(v);
            }
            Console.Read();
        }

        public void Add(string name, int value)
        {
            foreach (KeyValuePair<string,Register> h in heap)
            {
                //Finds the first register which holds no values
                if (h.Value.Inscope == false)
                {
                    h.Value.Inscope = true;
                    h.Value.Name = name;
                    h.Value.Value = value;
                    references[name] = h.Key;
                    return;
                }
            }

            //If all registers are in use then an exception is thrown
            throw new Exception();
        }

        //clears the dics at the locations of name.
        public bool Clear(string name)
        {
            heap[references[name]] = new Register();
            return references.Remove(name);
        }

        public void Linescan(string line)
        {
            string[] segments = line.Split(' ');
            sb.Clear();
            //Checks if it is a varrible or it is a leading keyword
            if (segments[0][0] != '$')
            {
                if (keywords.Contains(segments[0]))
                {
                    //Determines which function is currently being used.
                    switch (segments[0])
                    {
                        case "global":
                        case "local":
                            if (segments.Length > 1)
                            {
                                if (segments.Length == 2)
                                {
                                    Add(segments[1], 0);
                                }
                                else if (segments.Length == 4)
                                {
                                    Add(segments[1], Int32.Parse(segments[3]));
                                }
                                else
                                {
                                    //If there isn't the right number of elements it will throw errors
                                    throw new Exception();
                                }
                                sb.Append("li ");
                                sb.Append(references[segments[1]]);
                                sb.Append(", ");
                                sb.Append(heap[references[segments[1]]].Value);
                                heap[references[segments[1]]].Type = segments[0].Equals("local") ? true : false;
                                plp.Add(sb.ToString());
                            }
                            break;
                        case "sub":
                            if (segments.Length == 2)
                            {
                                if (lables.Add(segments[1]))
                                {
                                    sb.Append(segments[1]);
                                    sb.Append(":");
                                    plp.Add(sb.ToString());
                                }
                                else
                                {
                                    //Error if label already exists
                                    throw new Exception();
                                }
                            }
                            else
                            {
                                //If there is nothing behind sub
                                throw new Exception();
                            }
                            break;
                        case "for":
                            break;
                        case "to":
                            break;
                        case "if":
                            break;
                        case "end":
                            if (segments.Length == 2)
                            {
                                if (lables.Contains(segments[1]))
                                {
                                    sb.Append("j ");
                                    sb.Append(segments[1]);
                                    plp.Add(sb.ToString());
                                    plp.Add("nop");
                                }
                            }
                            else
                                //If there isn't two parts
                                throw new Exception();
                            break;
                        case "next":
                            break;
                        case "clear":
                            if (segments.Length == 2)
                            {
                                sb.Append("li ");
                                sb.Append(references[segments[1]]);
                                sb.Append(", 0");
                                plp.Add(sb.ToString());
                                Clear(segments[1]);
                            }
                            else
                                throw new Exception();
                            break;
                        case "j":
                            if (segments.Length == 2)
                            {
                                sb.Append("j ");
                                sb.Append(segments[1]);
                                plp.Add(sb.ToString());
                                plp.Add("nop");
                            }
                            else
                                //If there isn't two parts
                                throw new Exception();
                            break;
                    }
                }
                else
                {
                    throw  new Exception();
                }
            }
        }
    }
}
