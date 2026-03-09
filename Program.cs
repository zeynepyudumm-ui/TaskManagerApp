using System;
using System.Collections.Generic;

class TaskItem
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Priority { get; set; }
    public bool IsCompleted { get; set; }

    public TaskItem(int id, string title, string priority)
    {
        Id = id;
        Title = title;
        Priority = priority;
        IsCompleted = false;
    }
}

class Program
{
    static void Main(string[] args)
    {
        List<TaskItem> tasks = new List<TaskItem>();
        int taskIdCounter = 1;
        bool running = true;

        while (running)
        {
            Console.WriteLine("1- Görev Ekle");
            Console.WriteLine("2- Görevleri Listele");
            Console.WriteLine("3- Görev Tamamla");
            Console.WriteLine("4- Görev Sil");
            Console.WriteLine("5- Çıkış");

            Console.Write("Seçiminiz: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Görev Başlığı: ");
                    string title = Console.ReadLine();

                    Console.Write("Öncelik (Düşük/Orta/Yüksek): ");
                    string priority = Console.ReadLine();

                    tasks.Add(new TaskItem(taskIdCounter++, title, priority));
                    Console.WriteLine("Görev eklendi.");
                    break;

                case "2":
                    if (tasks.Count == 0)
                    {
                        Console.WriteLine("Henüz görev yok.");
                    }
                    else
                    {
                        foreach (var task in tasks)
                        {
                            Console.WriteLine($"ID: {task.Id} | {task.Title} | Öncelik: {task.Priority} | Tamamlandı mı: {task.IsCompleted}");
                        }
                    }
                    break;

                case "3":
                    Console.Write("Tamamlanacak görev ID: ");
                    int id;
                    if (int.TryParse(Console.ReadLine(), out id))
                    {
                        var foundTask = tasks.Find(t => t.Id == id);
                        if (foundTask != null)
                        {
                            foundTask.IsCompleted = true;
                            Console.WriteLine("Görev tamamlandı.");
                        }
                        else
                        {
                            Console.WriteLine("Görev bulunamadı.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Geçersiz ID.");
                    }
                    break;

                case "4": 
                    Console.Write("Silinecek görev ID: ");
                    int deleteId;
                    if (int.TryParse(Console.ReadLine(), out deleteId))
                    {
                        var taskToRemove = tasks.Find(t => t.Id == deleteId);
                        if (taskToRemove != null)
                        {
                            tasks.Remove(taskToRemove);
                            Console.WriteLine("Görev başarıyla silindi.");
                        }
                        else
                        {
                            Console.WriteLine("Görev bulunamadı.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Geçersiz ID girdiniz.");
                    }
                    break;

                case "5": 
                    running = false;
                    break;

                default:
                    Console.WriteLine("Geçersiz seçim.");
                    break;
            }
        }
    }
}
