using System;
class Program
{
	static void Main()
	{
		Random random = new Random();
		int secretNumber = 0;//объявляем эту переменную чтоб она была доступна везде не только в цикле if
		int guess = 0;
		int attempts = 0; // Начинаем считать попытки
		List <int> records = new List<int>();
		Console.WriteLine("Добро пожаловать в игру 'Угадай число'!");
		Console.WriteLine("Выберите уровень сложности:");
		Console.WriteLine("1 - Лёгкий (1-50)");
		Console.WriteLine("2 - Средний (1-100)");
		Console.WriteLine("3 - Сложный (1-500)");
		Console.Write("Ваш выбор: ");
		string input = Console.ReadLine();
		if (int.TryParse(input, out int userChoice))
		{
			if (userChoice == 1)
			{
				secretNumber = random.Next(1, 51);
				Console.WriteLine("Я загадал число от 1 до 50. Попробуй угадать!");
			}
			else if (userChoice == 2) //(когда условий достаточно можно их с else if, то есть вот так If -else if (сколько нужно)-else
			{
				secretNumber = random.Next(1, 101);
				Console.WriteLine("Я загадал число от 1 до 100. Попробуй угадать!");
			}

			else if (userChoice == 3)
			{
				secretNumber = random.Next(1, 501);
				Console.WriteLine("Я загадал число от 1 до 500. Попробуй угадать!");
			}
			else //этот элс для цикла иф юзер чойс и покрывает проверку если пользователь ввел число но не 1 2 3 а 5 или 999
			{
				Console.WriteLine("Некорректный ввод. Выбран уровень сложности по умолчанию (Средний).");
				secretNumber = random.Next(1, 101);
			}
		}
		else //для всего большого цикла с трай парс тут мы проверяем если пользователь ввел вообще не число а буквы
	    {
			Console.WriteLine("Некорректный ввод. Выбран уровень сложности по умолчанию (Средний).");
			secretNumber = random.Next(1, 101);
		}

		while (guess != secretNumber && attempts < 10)
		{
			Console.Write("Введите ваше предположение: ");
			input = Console.ReadLine();

			if (int.TryParse(input, out guess))
			{
				attempts++; // Увеличиваем счётчик попыток

				if (guess < secretNumber)
				{
					Console.WriteLine("Слишком мало!");
				}
				else if (guess > secretNumber)
				{
					Console.WriteLine("Слишком много!");
				}
				else
				{
					Console.WriteLine($"Поздравляю! Вы угадали число за {attempts} попыток!");
					// Записываем рекорд, если он входит в топ-3 лучших
					if (records.Count < 3 || ( records.Count > 0 && attempts < records[^1])) // два условия можно соеденять если взять другую проверку в скобки, проверка считать рекордс>0 чтоб если список будет пуск программа не выдала ошибку, (^1 — последний элемент списка Допустим, у нас есть список рекордов:List<int> records = new List<int> { 3, 5, 7 };Если новый результат attempts = 4, то:• records[^1] — это последний элемент списка, т.е. 7.• attempts < 7 — значит, 4 лучше, чем 7, поэтому его можно добавить.Так мы гарантируем, что только лучшие рекорды останутся в списке.)
					{
						records.Add(attempts);// В Add() можно передавать как число напрямую, так и переменную, содержащую число.
						records.Sort(); // Сортируем от меньшего к большему
						if (records.Count > 3)
						{
							records.RemoveAt(3); // Удаляем самый худший рекорд, если больше 3 записей этот метод удаляет по индексу соотв у нас с индексом 3 будет лишний рекорд с самым большим кол вом попыток
						}
					}

					Console.WriteLine($"Лучшие рекорды: {string.Join(", ", records)}");// Метод string.Join(separator, collection) объединяет элементы списка в строку, разделяя их указанным символом.тут мы бделим запятыми однако помним что можно и через тире и тд string.Join("-", numbers); // "1-2-3"; string.Join(" | ", numbers); // "1 | 2 | 3"; string.Join("", numbers); // "123" (без разделителя))
					return; // Выход из программы, если угадали завершение метода Main игра заканчивается
				}
			}
			else
			{
				Console.WriteLine("Пожалуйста, введите целое число.");
			}
		}
		// Если вышли из цикла, значит попытки закончились
		Console.WriteLine($"Вы проиграли! Загаданное число было {secretNumber}.");
	}
}

