using System;

namespace Task3
{
    /// <summary>Співробітник: атрибути різної «жорсткості» щодо зміни після створення.</summary>
    public class Employee
    {
        // 1) Автовластивість з відкритими get і set — змінюється протягом життя об'єкта
        public string Position { get; set; }

        // 2) Обмежений аксесор запису: читати може будь-хто, записувати лише сам клас
        public string Email { get; private set; }

        // 3) Лише get: значення задається тільки в конструкторі, далі незмінне
        public int Id { get; }

        // 4) init-only: задається в ініціалізаторі об'єкта або конструкторі, далі лише читання
        public DateTime HireDate { get; init; }

        // 5) Повністю обчислювана властивість: без поля-сховища, без set
        public int YearsOfService => (int)((DateTime.Today - HireDate).TotalDays / 365.25);

        public Employee(int id, string position, string email)
        {
            Id = id;               // дозволено: get-only присвоюється в конструкторі
            Position = position;
            Email = email;
        }

        // Єдиний «легальний» спосіб змінити Email після створення
        public void ChangeEmail(string newEmail)
        {
            if (string.IsNullOrWhiteSpace(newEmail) || !newEmail.Contains('@'))
                throw new ArgumentException("Некоректна адреса e-mail.", nameof(newEmail));

            Email = newEmail;      // дозволено: private set доступний усередині класу
        }

        public override string ToString() =>
            $"#{Id} | {Position} | {Email} | з {HireDate:dd.MM.yyyy} | стаж: {YearsOfService} р.";
    }
}