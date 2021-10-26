using System;

namespace Epicfight2
{
    class Program
    {
        static void Main(string[] args)
        {
            string hero, villain;
            string heroWeapon, villainWeapon;
            hero = RandomHero();
            heroWeapon = RandomWeapon();
            villain = RandomVillain();
            villainWeapon = RandomWeapon();
            int heroHp = GenerateHP(hero);
            int villianHp = GenerateHP(villain);
            Console.WriteLine($"{hero} will fight {villain} ({villianHp})");
            Console.WriteLine($"{hero} will fight with {heroWeapon}.");
            Console.WriteLine($"{villain} will fight with {villainWeapon}.");

            while (heroHp > 0 && villianHp > 0)
            {
                heroHp = heroHp - Hit(villain, hero, villainWeapon);
                villianHp = villianHp - Hit(hero, villain, heroWeapon);
            }

            if(heroHp <= 0)
            {
                Console.WriteLine("Darkside wins");
            }

            else
            {
                Console.WriteLine($"{hero} saves the day");
            }



        }
        private static int Hit(string characterOne, string charactertwo, string weapon)
        {
            Random rnd = new Random();
            int strike = rnd.Next(0, weapon.Length / 2);
            Console.WriteLine($"{characterOne} hit {strike} ");

            if(strike == weapon.Length/2 - 1)
            {
                Console.WriteLine($"Awasome! {characterOne} made critical hit!!");
            }

            else if (strike == 0)
            {
                Console.WriteLine($"{charactertwo} ignored the attack!");

            }


            return strike;

        }
        private static int GenerateHP(string SomeCharacter)
        {
            Random rnd = new Random();
            return rnd.Next(SomeCharacter.Length, SomeCharacter.Length + 10);

        }

        private static int RandomIndex(string[] someArray)
        {
            Random rnd = new Random();
            int randomIndex = rnd.Next(0, someArray.Length);

            return randomIndex;
        }

        private static string RandomHero()
        {
            string[] heroes = { "Hiirmees", "KaskaBob", "Ussmees", "Emil", "Lara Croft" };

            return heroes[RandomIndex(heroes)];
        }

        private static string RandomVillain()
        {
            string[] villains = { "raivo", "Toomas", "vadim", "Loki", "T-1000" };
            Random rnd = new Random();
            int randomIndex = rnd.Next(0, villains.Length);

            string randomVillain = villains[randomIndex];
            return randomVillain;
        }

        private static string RandomWeapon()
        {
            string[] weapon = { "foot gun", "plactic fork", "flip-flop", "lusikas", "võinuga" };

            return weapon[RandomIndex(weapon)];




        }
    }
}
