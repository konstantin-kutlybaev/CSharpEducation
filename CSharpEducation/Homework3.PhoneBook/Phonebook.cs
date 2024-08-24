using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Homework3.PhoneBook
{
    public class Phonebook
    {
        private static Phonebook? instance;
        private List<Abonent>? _abonents;
        private string FilePhone = "phonebook.txt";
        public static Phonebook Instance => instance = new Phonebook();
        public Phonebook()
        {
            _abonents = new List<Abonent>();
            LoadFile();
        }

        public void Add(string name, string subNumber)
        {
            if(_abonents.Exists(a=>a.SubNumber == subNumber))
            {
                Console.WriteLine("Абонент уже записан");
                return;
            }

            var abonent = new Abonent(name,subNumber);
            _abonents.Add(abonent);
            SaveFile();
            Console.WriteLine("Абонент добавлен");

        }

        public void FindAboba(string subNumber)
        {
            var abonent = _abonents?.Find(a=>a.SubNumber == subNumber);
            if(abonent != null)
            {
                Console.WriteLine($"Имя {abonent.Name}, Номер {abonent.SubNumber}");
            }
            else
            {
                Console.WriteLine("Такого абонента нет");
            }
        }

        public void FindNumber(string name)
        {
            var abonent = _abonents?.Find(a=>a.Name == name);
            if(abonent != null)
            {
                Console.WriteLine($"Имя {abonent.Name}, Номер {abonent.SubNumber}");
            }
            else { Console.WriteLine("Такого абонента нет"); }   
        }

        public  void Delete(string subNumber)
        {
            var abonent = _abonents?.Find(a => a.SubNumber == subNumber);
            if (abonent != null)
            {
                _abonents.Remove(abonent);
                SaveFile();
                Console.WriteLine("Абонент был удален");
            }
            else { Console.WriteLine("Такого абонента нет"); }
        }

        private void LoadFile()
        {
            if (File.Exists(FilePhone))
            {
                var lines = File.ReadAllLines(FilePhone);
                foreach (var line in lines)
                {
                    var parts = line.Split(';');
                    if (parts.Length == 2)
                    {
                        _abonents.Add(new Abonent(parts[0], parts[1]));
                    }
                }
            }
        }

        private void SaveFile()
        {
            using (var writer = new StreamWriter(FilePhone))
            {
                foreach (var abonent in _abonents)
                {
                    writer.WriteLine($"{abonent.Name};{abonent.SubNumber}");
                }
            }
        }
    }
}
