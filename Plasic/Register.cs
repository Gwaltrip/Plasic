using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plasic
{
    class Register
    {
        public string Name { get; }
        public int Initval { get; }
        public bool Inscope { get; }

        public Register()
        {
            this.Name = string.Empty;
            this.Initval = 0;
            this.Inscope = false;
        }

        public Register(int initval)
        {
            this.Name = string.Empty;
            this.Initval = initval;
            this.Inscope = false;
        }

        public Register(string name, int initval)
        {
            this.Name = name;
            this.Initval = initval;
            this.Inscope = false;
        }

        public Register(string name, int initval, bool inscope)
        {
            this.Name = name;
            this.Initval = initval;
            this.Inscope = inscope;
        }
    }
}
