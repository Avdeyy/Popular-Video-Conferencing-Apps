// See https://aka.ms/new-console-template for more information
using AngleSharp.Dom;
using laba3;
using System.Globalization;
using System.Linq;

string name, institute, program;

lT list = new();

bool inf = true;
int j = 0;

list.Teachers.Add(new Teacher("Абрамчик Екатерина Васильевна", "ИКИТ", Services.WebinarSFU));
list.Teachers.Add(new Teacher("Никонов Василий Николаевич", "ИКИТ", Services.Zoom));
list.Teachers.Add(new Teacher("Апанова Ирина Сергеевна", "ИКИТ", Services.Discord));
list.Teachers.Add(new Teacher("Марков Александр Юрьевич", "ИКИТ", Services.Discord));



while (inf)
{
    Console.Clear();
    Console.WriteLine("Выберите один из пунктов:\n" +
                  "1) Пройти опрос\n" +
                  "2) Посмотреть результаты\n" +
                  "3) Список прошедших опрос\n" +
                  "4) Завершить программу\n" +
                  "Номер: ");
    string a = Console.ReadLine();
    switch (a)
    {
        case "1":
            Console.Clear();
            Console.WriteLine("Ваше ФИО: ");
            name = Console.ReadLine();
            for (int i = 0; i < list.Teachers.Count; i++)
            {
                IsCanAddTeacher IsCanAddTeacher = (name) => name == list.Teachers[i].Name;
                if (IsCanAddTeacher(name))
                {
                    Console.WriteLine("Вы уже прошли опрос");
                    j = 1;
                    break;
                }
            }
            if (j != 1)
            {
                Console.WriteLine("Институт, в котором вы работаете: ");
                institute = Console.ReadLine();
                Console.WriteLine("Выберите программу, которую вы используете:\n" +
                            "1) Discord\n2) SberJazz\n3) Zoom\n4) Skype\n5) WebinarSFU");

                int chosenServiceNumber = Convert.ToInt32(Console.ReadLine());


                if (chosenServiceNumber > 5 || chosenServiceNumber < 1)
                {
                    Console.WriteLine("Неверный ввод. Придётся начать всё сначала =)");
                    return;
                }


                list.Teachers.Add(new Teacher(name: name, instute: institute, service: (Services)chosenServiceNumber));
                break;
            }
            else
            {
                Console.ReadKey();
                break;
            }
        case "2":
            Console.Clear();
            Console.WriteLine("-------------Топ 3 приложений-------------");
            List<TopServices> topprograms;
            topprograms = Teacher.Top(list.Teachers);
            for (int i = 0; i < topprograms.Count; i++)
            {
                if (topprograms[i].Program == Services.Discord)
                {
                    Console.Write($"{i + 1}) ");
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    Console.Write(" Discord ");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine($"\t {topprograms[i].Rating}");
                }
                else if (topprograms[i].Program == Services.SberJazz)
                {
                    Console.Write($"{i + 1}) ");
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.Write(" SberJazz ");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine($"\t {topprograms[i].Rating}");
                }
                else if (topprograms[i].Program == Services.Zoom)
                {
                    Console.Write($"{i + 1}) ");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write(" Zoom ");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine($"\t {topprograms[i].Rating}");
                }
                else if (topprograms[i].Program == Services.Skype)
                {
                    Console.Write($"{i + 1}) ");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write(" Skype ");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine($"\t {topprograms[i].Rating}");
                }
                else if (topprograms[i].Program == Services.WebinarSFU)
                {
                    Console.Write($"{i + 1}) ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(" WebinarSFU ");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine($"\t {topprograms[i].Rating}");
                }
            }
            Console.ReadKey();
            break;
        case "3":
            Console.Clear();
            for (int i = 0; i < list.Teachers.Count; i++)
            {
                if (list.Teachers[i].Program == Services.Discord)
                {
                    Console.Write($"{i + 1}) ");
                    Console.Write($"{list.Teachers[i].Name.Rename()}");
                    Console.Write($"\t {list.Teachers[i].Institute}");
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    Console.WriteLine("\t[Discord]");
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
                else if (list.Teachers[i].Program == Services.SberJazz)
                {
                    Console.Write($"{i + 1}) ");
                    Console.Write($"{list.Teachers[i].Name.Rename()}");
                    Console.Write($"\t {list.Teachers[i].Institute}");
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.WriteLine("\t[SberJazz]");
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
                else if (list.Teachers[i].Program == Services.Zoom)
                {
                    Console.Write($"{i + 1}) ");
                    Console.Write($"{list.Teachers[i].Name.Rename()}");
                    Console.Write($"\t {list.Teachers[i].Institute}");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("\t[Zoom]");
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
                else if (list.Teachers[i].Program == Services.Skype)
                {
                    Console.Write($"{i + 1}) ");
                    Console.Write($"{list.Teachers[i].Name.Rename()}");
                    Console.Write($"\t {list.Teachers[i].Institute}");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("\t[Skype]");
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
                else if (list.Teachers[i].Program == Services.WebinarSFU)
                {
                    Console.Write($"{i + 1}) ");
                    Console.Write($"{list.Teachers[i].Name.Rename()}");
                    Console.Write($"\t {list.Teachers[i].Institute}");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\t[WebinarSFU]");
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
            }
            Console.ReadKey();
            break;
        case "4":
            Console.Clear();
            inf = false;
            break;
    }
}