﻿namespace Plasic
{
    class Program
    {
        static void Main(string[] args)
        {
            string fileloc = @"c:\users\gabe\documents\visual studio 2015\Projects\Plasic\Plasic\main.plc";
            if (args.Length > 1)
            {
                fileloc = args[0];
            }

            Plasic p = new Plasic(fileloc);
            p.Run();
        }
    }
}
