using System;
using System.IO;


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
                    if (value > DateTime.Now)
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
                    if (value < 0)
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
            using (StreamWriter sw = File.AppendText($"D:\\Forestry\\OOP\\Lab_1\\CHashtag_Lab_1\\ConsoleApp1\\{this.Name}"))
            {
                sw.Write(text);
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
            Filee obj = null,obj1 = null;
            try
            {
                obj = new Filee("letter.txt", new DateTime(2008, 5, 1, 8, 30, 52), 45);
                obj1 = new Filee();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            try
            {
                obj.Append("Haidudu");
                obj1.Append("XAM");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
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
