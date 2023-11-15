using System;

namespace CSharpLight
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Fighter[] fighters =
            {
                new Fighter("Терминатор", 500, 50, 0),
                new Fighter("Рэмбо", 250, 25, 20),
                new Fighter("Шредер", 150, 100, 10),
                new Fighter("Марио", 300, 75, 5)
            };
            int fighterNumber;

            for (int i = 0; i < fighters.Length; i++)
            {
                Console.Write(i + 1 + " ");
                fighters[i].ShowStats();
            }

            Console.Write("Выберите номер первого бойца: ");
            fighterNumber = (Convert.ToInt16(Console.ReadLine()) - 1);
            Fighter firstFighter = fighters[fighterNumber];

            Console.Write("Выберите номер второго бойца: ");
            fighterNumber = (Convert.ToInt16(Console.ReadLine()) - 1);
            Fighter secondFighter = fighters[fighterNumber];

            Console.CursorVisible = false;

            while (firstFighter.Health > 0 && secondFighter.Health > 0)
            {
                Console.Clear();
                firstFighter.TakeDamage(secondFighter.Damage);
                secondFighter.TakeDamage(firstFighter.Damage);
                Console.ForegroundColor = ConsoleColor.Red;
                firstFighter.ShowCurrentHealth();
                Console.ForegroundColor = ConsoleColor.Blue;
                secondFighter.ShowCurrentHealth();
                Thread.Sleep(500);
            }

            ShowWinner(firstFighter, secondFighter);
            Console.ReadKey();
        }

        class Fighter
        {
            private int _armor;

            public Fighter(string name, int health, int damage, int armor)
            {
                Name = name;
                Health = health;
                Damage = damage;
                _armor = armor;
            }

            public string Name { get; }

            public int Health { get; private set; }

            public int Damage { get; }

            public void ShowStats()
            {
                Console.WriteLine($"Боец - {Name}, здоровье - {Health}, наносимый урон - {Damage}, броня - {_armor}");
            }

            public void ShowCurrentHealth()
            {
                int health = Health;
                if (Health < 0)
                {
                    health = 0;
                }
                Console.Write($"    { Name} здоровье: { health}");
            }

            public void TakeDamage(int damage)
            {
                Health -= damage - _armor;
            }
        }

        static void ShowWinner(Fighter firstFighter, Fighter secondFighter)
        {
            string winner;
            if (firstFighter.Health < 0)
            {
                winner = secondFighter.Name;
            }
            else
            {
                winner = firstFighter.Name;
            }
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Победил игрок: {winner}");
        }
    }
}
