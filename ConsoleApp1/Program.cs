using System;
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
            Name = "default.txt";
            var fileName = $"D:\\Forestry\\OOP\\Lab_1\\CHashtag_Lab_1\\ConsoleApp1\\{this.Name}";
            FileInfo file_1 = new FileInfo(fileName);
            var size = file_1.Length;
            var date = file_1.CreationTime;
            DateCreation = date;
            Length = size;
        }
        public string Name
        {
            get => name;
            set
            {
                try
                {
                    if (String.IsNullOrEmpty(value))
                    {
                        throw new ArgumentException("The name cannot be empty!!!");
                    }
                    name = value;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message,"Try Again: \n");
                    value = Convert.ToString(Console.ReadLine());
                    Name = value;
                }
            }
        }
        public DateTime DateCreation
        {
            get => dateCreation;

            set
            {
                try
                {
                    if (value > DateTime.Now)
                    {
                        throw new ArgumentException("Creation Date cannot be current");
                    }
                    dateCreation = value;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message, "Try Again: \n");
                    value = Convert.ToDateTime(Console.ReadLine());
                    DateCreation = value;
                } 
            }
        }
        public long Length
        {
            get => length;

            set
            {
                try
                {
                    if (value < 0)
                    {
                        throw new ArgumentException("Length cannot be zero or less");
                    }
                    length = value;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message, "Try Again: \n");
                    value = Convert.ToInt64(Console.ReadLine());
                    Length = value;
                }
       
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
                using (StreamWriter sw = File.AppendText($"D:\\Forestry\\OOP\\Lab_1\\CHashtag_Lab_1\\ConsoleApp1\\{this.Name}"))
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
            Filee obj = new Filee("letter.txt", new DateTime(2008, 5, 1, 8, 30, 52), 45);
            Filee obj1 = new Filee();
            obj.Append("Haidudu");
            obj1.Append("XAM");
            Console.WriteLine(obj);
            Console.WriteLine(obj1);
            string fileName;
            DateTime creationDate;
            long length;
            fileName = Console.ReadLine();
            creationDate = Convert.ToDateTime(Console.ReadLine());
            length = Convert.ToInt64(Console.ReadLine());
            Filee obj2 = new Filee(fileName,creationDate,length);
            Console.WriteLine(obj2);
            Console.ReadKey();
        }
    }

}
