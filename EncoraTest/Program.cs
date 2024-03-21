// See https://aka.ms/new-console-template for more information
using EncoraTest.Business;
using EncoraTest.Utils;

using System;

namespace EncoraTest // Note: actual namespace depends on the project name.
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            Options options = new();
            options.WriteOptions();
        }
    }
}
