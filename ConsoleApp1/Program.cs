﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{

    class Filee
    {
        private string name;
        private DateTime dateCreation;
        private long length;

        public Filee(string name, DateTime dateCreation, long length)
        {
            Name = name;
            DateCreation = dateCreation;
            Length = length;
        }
        public Filee()
        {
            Name = "D:\\Forestry\\OOP\\Lab_1\\ConsoleApp1\\ConsoleApp1\\default.txt";
            DateCreation = new DateTime(2022,02,21,22,00,00);
            Length= 0;
        }
        public string Name
        {
            get => name;
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("The name cannot be empty!!!");
                }
                name = value;
            }
        }
        public DateTime DateCreation
        {
            get => dateCreation;

            set
            {
                if(value > DateTime.Now)
                {
                    throw new ArgumentException("Creation Date cannot be current");
                }
                dateCreation = value;
                
            }
        }
        public long Length
        {
            get => length;

            set
            {
                if(value < 0)
                {
                    throw new ArgumentException("Length cannot be zero or less");
                }
                length = value;
            }
        }
        public void Append(string text)
        {
            if(string.IsNullOrEmpty(text))
            {
                throw new ArgumentException("Text cannot be empty!!!");
            }
            try
            {
                using (StreamWriter sw = File.AppendText(this.Name))
                {
                    sw.Write(text);
                }

            }
            catch(IOException e)    
            {
                throw new Exception($"Failed to append to file '{name}'.", e);
            }
        }
        public override string ToString()
        {
            return $"Info about object\nName: {Name}, Creation Date: {dateCreation}, Length: {Length}";
        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Filee obj = new Filee("D:\\Forestry\\OOP\\Lab_1\\ConsoleApp1\\ConsoleApp1\\letter.txt", new DateTime(2008, 5, 1, 8, 30, 52), 45);
            Filee obj1 = new Filee();
            obj.Append("Haidudu");
            obj1.Append("XAM");
            Console.WriteLine(obj);
            Console.WriteLine(obj1);
            Console.ReadKey();
        }
    }

}