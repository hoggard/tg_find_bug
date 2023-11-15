﻿using System;

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
            private string _name;
            private int _health;
            private int _damage;
            private int _armor;

            public Fighter(string name, int health, int damage, int armor)
            {
                _name = name;
                _health = health;
                _damage = damage;
                _armor = armor;
            }

            public string Name
            {
                get
                {
                    return _name;
                }
            }

            public int Health
            {
                get
                {
                    return _health;
                }
            }

            public int Damage
            {
                get
                {
                    return _damage;
                }
            }

            public void ShowStats()
            {
                Console.WriteLine($"Боец - {_name}, здоровье - {_health}, наносимый урон - {_damage}, броня - {_armor}");
            }

            public void ShowCurrentHealth()
            {
                int health = _health;
                if (_health < 0)
                {
                    health = 0;
                }
                Console.Write($"    { _name} здоровье: { health}");
            }

            public void TakeDamage(int damage)
            {
                _health -= damage - _armor;
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