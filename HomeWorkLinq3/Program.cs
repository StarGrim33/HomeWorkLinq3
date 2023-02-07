namespace HomeWorkLinq3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            User user = new();
            user.Run();
        }
    }

    class Hospital
    {
        private List<Patient> _ills = new();

        public Hospital()
        {
            AddPatient();
        }

        public void AddPatient()
        {
            _ills.Add(new Patient("Александров Сергей Сергеевич", 25, "Варикоцеле"));
            _ills.Add(new Patient("Иванов Иван Иванович", 35, "Панкреатит"));
            _ills.Add(new Patient("Сорокин Валерий Витальевич", 30, "Воспаление легких"));
            _ills.Add(new Patient("Корчагов Андрей Дмитриевич", 25, "Почечная недостаточность"));
            _ills.Add(new Patient("Гладков Максим Андреевич", 64, "Инфаркт"));
            _ills.Add(new Patient("Сергеев Сергей Сергеевич", 67, "Инсуль"));
            _ills.Add(new Patient("Горбунова Ольга Дмитриевна", 78, "Сахарный диабет"));
            _ills.Add(new Patient("Сердюкова Алла Михайловна", 54, "Глаукома"));
            _ills.Add(new Patient("Малышкина Нина Вениаминовна", 66, "COVID-19"));
            _ills.Add(new Patient("Бирюкова Светлана Юрьевна", 45, "Гипертонический кризис"));
            _ills.Add(new Patient("Маслякова Анжелика Сергеевна", 61, "Сердечная недостаточость"));
        }

        public void ShowPatientsByFullName()
        {
            int index = 1;

            var orderedPatients = _ills.OrderBy(patient => patient.Name);

            foreach(var orderedPatient in orderedPatients)
            {
                Console.WriteLine($"{index}.{orderedPatient.Name}, возраст: {orderedPatient.Age}, заболевание: {orderedPatient.Disease}");
                index++;
            }

            Console.ReadKey();
        }

        public void ShowPatientsByAge()
        {
            int index = 1;

            var orderedPatients = _ills.OrderBy(patient => patient.Age);

            foreach(var orderedPatient in orderedPatients)
            {
                Console.WriteLine($"{index}.Возраст: {orderedPatient.Age}, {orderedPatient.Name}, заболевание: {orderedPatient.Disease}");
                index++;
            }

            Console.ReadKey();
        }

        public void ShowPatientsByDisease()
        {
            int index = 1;

            Console.WriteLine("Введите заболевание: ");
            string userInput = Console.ReadLine()!;

            var patientByDisease = _ills.Where(patient => patient.Disease == userInput);

            foreach (var orderedPatient in patientByDisease)
            {
                Console.WriteLine($"{index}.{orderedPatient.Name}, возраст: {orderedPatient.Age}, заболевание: {orderedPatient.Disease}");
                index++;
            }

            Console.ReadKey();
        }
    }

    class Patient
    {
        public Patient(string name, int age, string disease)
        {
            Name = name;
            Age = age;
            Disease = disease;
        }

        public string Name { get; private set; }

        public int Age { get; private set; }

        public string Disease { get; private set; }
    }

    class User
    {
        private Hospital _hospital = new();

        public User()
        {
            Name = Welcome();
        }

        public string Name { get; private set; }

        private string Welcome()
        {
            Console.WriteLine("Как Вас зовут?");
            Name = Console.ReadLine();

            if (Name == null)
                return Name = "Аноним";

            return Name;
        }

        public void Run()
        {
            const string CommandSortByFullName = "1";
            const string CommandSortByAge = "2";
            const string CommandSortByDisease = "3";
            const string CommandExit = "4";

            bool isProgramOn = true;

            while (isProgramOn)
            {
                Console.Clear();
                Console.WriteLine($"Здравствуйте, {Name}");
                Console.WriteLine($"{CommandSortByFullName}-Отсортировать больных по ФИО");
                Console.WriteLine($"{CommandSortByAge}-Отсортировать больных по возрасту");
                Console.WriteLine($"{CommandSortByDisease}-Посмотреть больных по болезням");
                Console.WriteLine($"{CommandExit}-Выйти");

                string userInput = Console.ReadLine()!;

                switch (userInput)
                {
                    case CommandSortByFullName:
                        _hospital.ShowPatientsByFullName();
                        break;

                    case CommandSortByAge:
                        _hospital.ShowPatientsByAge();
                        break;

                    case CommandSortByDisease:
                        _hospital.ShowPatientsByDisease();
                        break;

                    case CommandExit:
                        isProgramOn = false;
                        break;

                    default:
                        Console.WriteLine("Нужно ввести цифру пункта меню");
                        Console.ReadKey();
                        break;
                }
            }
        }
    }
}