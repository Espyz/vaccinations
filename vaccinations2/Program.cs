using System;
using System.Collections.Generic;

namespace vaccinations2
{
    internal class Program
    {
        static List<Employers> employers = new List<Employers>();

        static void Main()
        {
            Console.WriteLine("Добро пожаловать в систему отслеживания прививок сотрудников. Для просмотра списка команд введите \"help\"");
            generateBasicsEmployersList();
            string text = "";
            while (text != "close") 
            { 
                text = Console.ReadLine().Trim().ToLower();
                switch (text)
                {
                    case "help":
                        Help();
                        break;
                    case "date":
                        DateCheck();
                        break;
                    case "list":
                        VaccinationList(); 
                        break;
                    case "add":
                        NewEmployeer(); 
                        break;
                    case "change":
                        ChangeEmployer(); 
                        break;
                    case "close":
                        break;
                    default:
                        Console.WriteLine("Команда не распознана");
                        break;
                }

            }
        }

        static void generateBasicsEmployersList()
        {
            Employers employer1 = new Employers("Карелова", "Рия", "Александровна", DateTime.Parse("2024-04-01"), employers.Count + 1);
            employers.Add(employer1);
            Employers employer2 = new Employers("Пепелышев", "Дмитрий", "Игоревич", DateTime.Parse("2024-04-01"), employers.Count + 1);
            employers.Add(employer2);
            Employers employer3 = new Employers("Трухар", "Андрей", "Леонидович", DateTime.Parse("2024-04-02"), employers.Count + 1);
            employers.Add(employer3);
        }

        static void Help()
        {
            Console.WriteLine(
                "help - Просмотр списка команд\n" +
                "list - Список всех привитых сотрудников\n" +
                "add - Добавить сотрудника\n" +
                "change - Изменить дату последней вакцинации сотрудника\n" +
                "date - Система распознавания даты\n" +
                "close - Закрытие программы\n"
                );
        }

        static void VaccinationList()
        {
            foreach (Employers employer in employers)
            {
                employer.Print();
            }
        }

        static void DateCheck()
        {
            Console.WriteLine("Введите дату в любом формате");
            while (true)
            {
                string text = Console.ReadLine().Trim().ToLower();
                if (text == "stop") break;
                Console.WriteLine(DateTime.TryParse(text, out _) ? DateTime.Parse(text).ToShortDateString().ToString() : "Не удалось распознать дату. Для прекращения попыток распознавания введите \"stop\"");
            }
        }

        static void NewEmployeer()
        {
            Console.WriteLine("Введите данные нового сотрудника в формате \"Фамилия, Имя, Отчество, Дата привития\". Данные вводить через запятую. Если отсутствует отчество или дата привития на их место ставить \"-\"");
            string line = Console.ReadLine();
            if (line.Split(',').Length < 4)
            {
                Console.WriteLine("Данные в неверном формате, обязательно расставьте знаки запятой");
                return;
            }
            string lastName = line.Split(',')[0].Trim();
            string name = line.Split(',')[1].Trim();
            string middleName = line.Split(',')[2].Trim() == "-" ? "" : line.Split(',')[2].Trim();
            DateTime date = DateTime.TryParse(line.Split(',')[3].Trim(), out _) ? DateTime.Parse(line.Split(',')[3].Trim()) : new DateTime();
            Employers newEmployeer = new Employers(lastName, name, middleName, date, employers.Count + 1);
            employers.Add(newEmployeer);
            Console.WriteLine("Успешно добавлен новый сотрудник");
            newEmployeer.Print();
        }

        static void ChangeEmployer()
        {
            int id;
            Employers employer;

            Console.WriteLine("Введите номер сотрудника");

            try
            {
                id = int.Parse(Console.ReadLine()) - 1;
                employer = employers[id];
            }
            catch
            {
                Console.WriteLine("Номер сотрудника указан в неверном формате, либо такого сотрудника не существует");
                return;
            }

            Console.Write("Выбран сотрудник: ");
            employer.Print();

            Console.WriteLine("Введите дату последней вакцинации");
            string time = Console.ReadLine();
            employer.LastVaccinationDate = DateTime.TryParse(time, out _) ? DateTime.Parse(time) : new DateTime();

            Console.WriteLine("Успешно");
            employer.Print();
        }
    }
}
