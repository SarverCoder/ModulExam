using System;
namespace _2_Modul_imtixon
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Task> tasks = new List<Task>();

            Console.WriteLine("--------Task list dasturi----------\n\n");
            
            while (true)
            {
                
                Console.WriteLine($"1. Task yaratish\n2. Tasklar ro'yxatini ko'rish\n" +
                    $"3. Taskni taxrirlash\n4. Taskni o'chirish\n5. Exit\n");
               
                Console.Write("Tanlang: ");
                string s = Console.ReadLine();
                switch(s)
                {
                        case "1": TaskService.Create(ref tasks); break;
                        case "2": TaskService.Read(tasks); break;
                        case "3": TaskService.Update(ref tasks); break;
                        case "4": TaskService.Delete(ref tasks); break;
                        case "5":  break;
                    default: Console.WriteLine("Bunday amaliyot mavjud emas !"); break;
                }
                if (s == "5")
                    break;
                
            }
             

        }
    }

    static class TaskService
    {
        public static void Create(ref List<Task> list)
        {
            Console.Clear();
            Task task = new Task();

            Console.Write("Task nomi: ");
            string nomi = Console.ReadLine();

            if (!string.IsNullOrEmpty(nomi))
            {
                task.name = nomi;
            }

            Console.Write("Task description: ");
            string des = Console.ReadLine();

            if (!string.IsNullOrEmpty(des))
                task.description = des;
            Console.Write("1.Created\n2.In_progress\n3.Done\n4.Canceled\n");
            Console.Write("statusni tanlang: ");

            int numb = int.Parse(Console.ReadLine());
            switch(numb)
            {
                case 1: task.status = TaskStatuc.CREATED; break;
                case 2: task.status = TaskStatuc.IN_PROGRESS; break;
                case 3: task.status = TaskStatuc.DONE; break;
                case 4: task.status = TaskStatuc.CANCELED; break;
                default: Console.WriteLine("Bunday task mavjud emas !"); break;
            }

            list.Add(task);
            Console.WriteLine("\nCreated task\n\n");



        }

        public static void Read(List<Task> list)
        {
            Console.Clear();

            foreach (var item  in list)
            {
                Console.WriteLine($"Name: {item.name}, Description: {item.description}, Status: {item.status}");
            }
            Console.WriteLine("\n\n------------\n\n");
        }

        public static void Update(ref List<Task> list)
        {
            Console.Clear();
            Console.WriteLine("Qaysi taskni yangilamoqchisz ?");
            int i = 1;
            foreach (var item in list)
            {
                Console.WriteLine($" {i}. Name: {item.name}, Description: {item.description}, Status: {item.status}");
                i++;
            }
            Console.Write("\nKiriting: ");
            int number = int.Parse(Console.ReadLine()) - 1; 
            
            Task task = list[number];

            Console.Write("Task nomi: ");
            string nomi = Console.ReadLine();

            if (!string.IsNullOrEmpty(nomi))
            {
                task.name = nomi;
            }

            Console.Write("Task description: ");
            string des = Console.ReadLine();

            if (!string.IsNullOrEmpty(des))
                task.description = des;
            Console.Write("1.Created\n2.In_progress\n3.Done\n4.Canceled\n");
            Console.Write("statusni tanlang: ");

            int numb = int.Parse(Console.ReadLine());
            switch (numb)
            {
                case 1: task.status = TaskStatuc.CREATED; break;
                case 2: task.status = TaskStatuc.IN_PROGRESS; break;
                case 3: task.status = TaskStatuc.DONE; break;
                case 4: task.status = TaskStatuc.CANCELED; break;
                default: Console.WriteLine("Bunday task mavjud emas !"); break;
            }

            Console.WriteLine("\nO'zgardi !\n");

        }

        public static void Delete(ref List<Task> list)
        {
            Console.Clear();

            Console.WriteLine("Qaysi taskni o'chirmoqchisz ?");
            int i = 1;
            foreach (var item in list)
            {
                Console.WriteLine($" {i}. Name: {item.name}, Description: {item.description}, Status: {item.status}");
                i++;
            }
            Console.Write("Kiriting: ");
            int k = int.Parse(Console.ReadLine());
            list.RemoveAt(k-1);
            Console.WriteLine("O'chirildi");

            Console.WriteLine("\n----------------------\n");
        }

    }

    class Task
    {
        public string name { get; set; }
        public string description { get; set; }
        public TaskStatuc status { get; set; }

    }

    enum TaskStatuc
    {
        CREATED = 1,
        IN_PROGRESS,
        DONE,
        CANCELED
    }
}
