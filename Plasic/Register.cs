namespace Plasic
{
    class Register
    {
        public string Name { get; set; }
        public int Value { get; set; }
        public bool Inscope { get; set; }
        public bool Type { get; set; }

        public Register()
        {
            this.Name = string.Empty;
            this.Value = 0;
            this.Inscope = false;
            this.Type = false;
        }

        public Register(string name)
        {
            this.Name = name;
            this.Value = 0;
            this.Inscope = true;
            this.Type = false;
        }

        public Register(string name, int value)
        {
            this.Name = name;
            this.Value = value;
            this.Inscope = true;
            this.Type = false;
        }

        public Register(string name, int value, bool inscope)
        {
            this.Name = name;
            this.Value = value;
            this.Inscope = inscope;
            this.Type = false;
        }

        public Register(string name, int value, bool inscope, bool type)
        {
            this.Name = name;
            this.Value = value;
            this.Inscope = inscope;
            this.Type = type;
        }
    }
}
