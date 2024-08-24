namespace Homework3.PhoneBook
{
   public static class Program
    {
       public static void Main()
        {
            var phonebook = Phonebook.Instance;
            while (true)
            {
                Console.WriteLine("1. Добавить абонента");
                Console.WriteLine("2. Получить абонента по имени");
                Console.WriteLine("3. Получить абонента по номеру");
                Console.WriteLine("4. Удалить абонента");
                Console.WriteLine("5. Выключить программу");
                Console.Write("Выберите действие: ");

                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.WriteLine("Введите Имя: ");
                        var name = Console.ReadLine();
                        Console.WriteLine("Введите номер: ");
                        var subNumber = Console.ReadLine();
                        phonebook.Add(name, subNumber);
                        break;
                    case "2":
                        Console.WriteLine("Введите имя");
                        var findNumber = Console.ReadLine();
                        phonebook.FindNumber(findNumber);
                        break;
                    case "3":
                        Console.WriteLine("Введите номер телефона");
                        var findName = Console.ReadLine();
                        phonebook.FindAboba(findName);
                        break;
                    case "4":
                        Console.WriteLine("Введите номер для удаления");
                        var deleteNumber = Console.ReadLine();
                        phonebook.Delete(deleteNumber);
                        break;
                    case "5":
                        return;
                }
            }
        }
    }
}
