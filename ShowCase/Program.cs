using System;
using System.Windows.Forms;
using flaUIlibrary;

class Program
{
    static void Main(string[] args)
    {
        IFlaUiItems lib = new FlaUiItems();
        

        while (true)
        {
            Console.WriteLine("Enter input (enter \"Help\" to see list of possible inputs):");
            string line = Console.ReadLine();

            switch (line)
            {
                case "Launch":
                    lib.Launch();
                    break;
                case "Exit":
                    break;
                case "Help":
                    lib.Help();
                    break;
                case "Open":
                    lib.Open();
                    break;
                case "Download":
                    lib.Download();
                    break;
                case "Close":
                    lib.MyClose();
                    break;
                case "Kill":
                    lib.Kill();
                    break;
                case "StartNew":
                    lib.StartNew();
                    break;
                case "TypeText":
                    lib.TypeText();
                    break;
                case "DrawShape":
                    lib.DrawShape();
                    break;
                default: 
                    Console.Write("Input not valid. ");
                    break;
            }
        }
    }
}