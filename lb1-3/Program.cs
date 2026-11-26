using System;

namespace Task3
{
    internal class Program
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            // HireDate (init-only) задаємо в ініціалізаторі об'єкта
            var emp = new Employee(1, "Junior Developer", "ivan@company.com")
            {
                HireDate = new DateTime(2020, 3, 15)
            };
            Console.WriteLine("Створено:   " + emp);

            // Дозволені зміни
            emp.Position = "Senior Developer";          // відкритий set
            emp.ChangeEmail("ivan.p@company.com");      // зміна через метод (private set)
            Console.WriteLine("Після змін:  " + emp);

            // ===== Спроби порушити обмеження =====
            // Розкоментовуйте по ОДНОМУ рядку, робіть скріншот помилки й коментуйте назад.

            // emp.Email = "hack@mail.com";   // CS0272: set недоступний (private set)
            // emp.Id = 99;                   // CS0200: властивість лише для читання (немає set)
            // emp.HireDate = DateTime.Now;   // CS8852: init-only можна задати лише в ініціалізаторі/конструкторі
            // emp.YearsOfService = 10;       // CS0200: обчислювана властивість без set

            Console.WriteLine("\nГотово. Натисніть Enter...");
            Console.ReadLine();
        }
    }
}