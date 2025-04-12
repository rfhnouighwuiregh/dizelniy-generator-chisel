using System;
using System.Collections.Generic;

class RandomNumbers
{
    private Random random = new Random();

    public IEnumerable<int> GetRandoms(int limit)
    {
        for (int i = 0; i < limit; i++)
        {
            yield return random.Next(1, 100);
        }
    }

    public IEnumerable<int> GetAllRandoms()
    {
        while (true)
        {
            yield return random.Next(1, 100);
        }
    }

    public IEnumerable<int> SkipRandoms(int count)
    {
        int skipped = 0;
        while (true)
        {
            int number = random.Next(1, 100);
            if (skipped >= count)
            {
                yield return number;
            }
            else
            {
                skipped++;
            }
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        RandomNumbers generator = new RandomNumbers();

        Console.WriteLine("Первые 5 случайных чисел до лимита 10:");
        int limit = 5; // Объявляем limit перед циклом
        foreach (int number in generator.GetRandoms(10))
        {
            Console.Write(number + " ");
            limit--;
            if (limit == 0) break;
        }
        Console.WriteLine();

        Console.WriteLine("Бесконечная последовательность (первые 5 чисел):");
        limit = 5; // Снова объявляем limit
        foreach (int number in generator.GetAllRandoms())
        {
            Console.Write(number + " ");
            limit--;
            if (limit == 0) break;
        }
        Console.WriteLine();

        Console.WriteLine("Пропускаем 2 числа, выводим следующие 5:");
        limit = 5; // И ещё раз для третьего цикла
        foreach (int number in generator.SkipRandoms(2))
        {
            Console.Write(number + " ");
            limit--;
            if (limit == 0) break;
        }
        Console.WriteLine();
    }
}