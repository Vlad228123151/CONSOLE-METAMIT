// Добавление пользователей
using CONSOLE_BD;

using (var db = new ApplicationContext()) // var - компилятор автоматически определяет тип ApplicationContext
{
    Console.WriteLine("Сколько пользователей хотите добавить?");
    if (int.TryParse(Console.ReadLine(), out int numberOfUsers)) // TryParse - преобразует строку в int, если успешно
    {
        for (int i = 0; i < numberOfUsers; i++) // for - цикл, выполняющийся заданное количество раз
        {
            Console.WriteLine("Введите имя пользователя:");
            string name = Console.ReadLine();

            Console.WriteLine("Введите возраст пользователя:");
            if (int.TryParse(Console.ReadLine(), out int age)) // int - целочисленный тип данных
            {
                var newUser = new User(name, age); // var - тип переменной автоматически определен как User
                db.Users.Add(newUser);
                db.SaveChanges();
                Console.WriteLine("Пользователь успешно добавлен.");
            }
            else
            {
                Console.WriteLine("Некорректный возраст. Попробуйте снова.");
            }
        }

        // Отображение списка пользователей
        Console.WriteLine("\nТекущий список пользователей:");
        foreach (var user in db.Users.ToList()) // foreach - цикл для прохода по каждому элементу в коллекции
        {
            Console.WriteLine($"{user.Id}. {user.Name} - {user.Age}");
        }
    }
    else
    {
        Console.WriteLine("Ошибка: введите корректное число пользователей.");
    }
}

// Редактирование пользователя
using (var db = new ApplicationContext()) // var - тип определяется как ApplicationContext
{
    Console.WriteLine("Введите ID пользователя для редактирования:");
    if (int.TryParse(Console.ReadLine(), out int userIdToEdit)) // TryParse - преобразует строку в int
    {
        var userToEdit = db.Users.FirstOrDefault(u => u.Id == userIdToEdit); // var - тип определяется как User
        if (userToEdit != null)
        {
            Console.WriteLine("Введите новое имя:");
            userToEdit.Name = Console.ReadLine();

            Console.WriteLine("Введите новый возраст:");
            if (int.TryParse(Console.ReadLine(), out int newAge)) // int - целочисленный тип данных
            {
                userToEdit.Age = newAge;
                db.Users.Update(userToEdit);
                db.SaveChanges();
                Console.WriteLine($"Пользователь с ID {userIdToEdit} успешно обновлен.");
            }
            else
            {
                Console.WriteLine("Некорректный возраст.");
            }
        }
        else
        {
            Console.WriteLine($"Пользователь с ID {userIdToEdit} не найден.");
        }
    }
    else
    {
        Console.WriteLine("Ошибка: некорректный ввод ID.");
    }

    // Отображение списка пользователей после редактирования
    Console.WriteLine("\nОбновленный список пользователей:");
    foreach (var user in db.Users.ToList()) // foreach - цикл для прохода по каждому элементу в списке
    {
        Console.WriteLine($"{user.Id}. {user.Name} - {user.Age}");
    }
}

// Удаление пользователя
using (var db = new ApplicationContext()) // var - тип определяется как ApplicationContext
{
    Console.WriteLine("Введите ID пользователя для удаления:");
    if (int.TryParse(Console.ReadLine(), out int userIdToDelete)) // TryParse - пытается преобразовать строку в int
    {
        var userToDelete = db.Users.FirstOrDefault(u => u.Id == userIdToDelete); // var - определяется как User
        if (userToDelete != null)
        {
            db.Users.Remove(userToDelete);
            db.SaveChanges();
            Console.WriteLine($"Пользователь с ID {userIdToDelete} успешно удален.");
        }
        else
        {
            Console.WriteLine($"Пользователь с ID {userIdToDelete} не найден.");
        }
    }
    else
    {
        Console.WriteLine("Ошибка: некорректный ввод ID.");
    }

    // Отображение списка пользователей после удаления
    Console.WriteLine("\nСписок пользователей после удаления:");
    foreach (var user in db.Users.ToList()) // foreach - цикл для прохода по всем элементам в списке
    {
        Console.WriteLine($"{user.Id}. {user.Name} - {user.Age}");
    }
}