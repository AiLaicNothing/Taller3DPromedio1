﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TallerSem5
{
    internal class Menu
    {
        private List<Player> player;
        private List<Ability> abilities;
        private List<Enemy> enemys;
        public Menu()
        {
            player = new List<Player>();
            enemys = new List<Enemy>();
        }

        public void Execute()
        {
            StartGame();
        }

        public void StartGame()
        {
            bool isCreatingEnemy = true;
            Console.WriteLine("Bienvenido dungeon master");
            Console.ReadKey();
            while (isCreatingEnemy)
            {
                string name;
                float hp;
                float damage;
                Console.Clear();
                Console.WriteLine("Crea un tipo de enemigo");
                Console.WriteLine("Escriba el nombre del enemigo");
                name = Console.ReadLine();
                Console.WriteLine("Escribe la vida del enemigo");
                hp = float.Parse(Console.ReadLine());
                Console.WriteLine("Escribe el daño del enemigo");
                damage = float.Parse(Console.ReadLine());
                Enemy newEnemy = new Enemy(name, hp, damage);

                Console.ReadKey();
                Console.Clear();

                Console.WriteLine($"Vas a crear el enemigo: {newEnemy.GetInfo()}");
                Console.WriteLine("Esta correcto los datos");
                Console.WriteLine("Si-No");

                string decisión = Console.ReadLine();
                switch (decisión)
                {
                    case "Si":
                        Console.WriteLine("Se agrego a la lista");
                        enemys.Add(newEnemy);
                        break;
                    case "No":
                        Console.WriteLine("No se agrego a la lista");
                        break;
                }
                ShowEnemyList();
                Console.ReadKey();
                Console.Clear();
                Console.WriteLine("Seguir agregando enemigos");
                Console.WriteLine("Si-No");
                string desicion2 = Console.ReadLine();
                switch (desicion2)
                {
                    case "Si":
                        isCreatingEnemy = true;
                        break;
                    case "No":
                        isCreatingEnemy = false;
                        break;
                }
            }
            Console.Clear ();
            Console.WriteLine("Crea al jugador");
            CreatePlayer();
            Console.ReadKey();
            Console.Clear ();
            Console.WriteLine("Te adentras a la mazmorra");
            Combat();
            
        }

        public void CreatePlayer()
        {
            bool creatingPlayer = true;
            while (creatingPlayer)
            {
                string name;
                float hp;
                float mana;
                float damage;
                Console.WriteLine("Escribe el nombre del jugador");
                name = Console.ReadLine();
                Console.WriteLine("Escribe tus puntos de vida");
                hp = float.Parse(Console.ReadLine());
                Console.WriteLine("Escribe tus puntos de mana");
                mana = float.Parse(Console.ReadLine());
                Console.WriteLine("Escribe tus puntos de daño");
                damage = float.Parse(Console.ReadLine());
                Console.ReadKey();
                Console.Clear();

                Player newPlayer = new Player(name, hp, mana, damage);
                Console.WriteLine("La informacion es correcta?");
                Console.WriteLine($"Jugador: {newPlayer.GetInfo()}");
                Console.WriteLine($"Si-No");


                string decisión = Console.ReadLine();
                switch (decisión)
                {
                    case "Si":
                        Console.WriteLine("Se creo al jugador");
                        player.Add(newPlayer);
                        creatingPlayer = false;
                        break;
                    case "No":
                        Console.WriteLine("No se creo al jugador");
                        creatingPlayer = true;
                        break;
                }
            }
        }

        public void ShowEnemyList()
        {
            int code = -1;
            foreach (Enemy enemy in enemys)
            {
                code++;
                Console.WriteLine($"{code}. {enemy.GetInfo()}");
            }
        }

        public void Combat()
        {
            Console.WriteLine("Te encuentras con enemigos");
            Console.ReadKey();
            bool inCombat = true;
            bool playerTurn = true;
            bool enemyTurn = false;
            while (inCombat)
            {
                while (playerTurn)
                {
                    int enemySelect;
                    //Show actions
                    Console.Clear();
                    Console.WriteLine("Enemigos");
                    ShowEnemyList();
                    Console.WriteLine();
                    Console.WriteLine($"Jugador: {player.ElementAt(0).GetInfo()}");
                    Console.WriteLine("Opciones de acción");
                    Console.WriteLine("1. Atacar al enemigo");
                    Console.WriteLine("2. Usar una abilidad");
                    Console.WriteLine("3. Usar objeto");

                    string decisión = Console.ReadLine();
                    switch (decisión)
                    {
                        case "1":
                            Console.WriteLine("Selecciona al enemigo");
                            enemySelect = int.Parse(Console.ReadLine());
                            enemys.ElementAt(enemySelect).GetDamaged(player.ElementAt(0).damage);
                            Console.WriteLine($"Le inflingiste {player.ElementAt(0).damage} de daño a {enemys.ElementAt(enemySelect).name}");
                            if(enemys.ElementAt(enemySelect).hp > 0)
                            {
                                Console.WriteLine($"Le queda {enemys.ElementAt(enemySelect).hp} de vida");
                                Console.ReadKey();
                            }
                            else if (enemys.ElementAt(enemySelect).hp <= 0)
                            {
                                Console.WriteLine($"Mataste a {enemys.ElementAt(enemySelect).name}");
                                enemys.RemoveAt(enemySelect);
                            }

                            playerTurn = false;
                            enemyTurn = true;
                            break;
                        case "2":
                            //Seleccionar habilidad 
                            //Seleccion del enemigo
                            Console.WriteLine("Selecciona al enemigo");
                            enemySelect = int.Parse(Console.ReadLine());
                            //cambiar variable al daño de habilidad
                            enemys.ElementAt(enemySelect).GetDamaged(2);
                            playerTurn = false;
                            enemyTurn = true;
                            break;
                        case "3":
                            //Usar item
                            break;
                    }
                }
                while (enemyTurn)
                {
                    Console.Clear();
                    if (enemys.Count > 0)
                    {
                        bool randomize = true;
                        int randEnemy;
                        int enemyList = enemys.Count;

                        while (randomize)
                        {
                            Random randomizer = new Random();
                            randEnemy = randomizer.Next(enemyList);
                        }


                        if (enemys.ElementAt(randEnemy).hp <= 0) 
                        {
                            randomize = true ;
                        }
                        else
                        {
                            randomize = false ;
                        }

                        Console.WriteLine("Turno del enemigo");
                        Console.WriteLine($"El enemigo {enemys.ElementAt(randEnemy).name} ataca");
                        Console.WriteLine($"Recibiste {enemys.ElementAt(randEnemy).damage} de daño");
                        player.ElementAt(0).GetDamaged(enemys.ElementAt(randEnemy).damage);
                        Console.WriteLine($"Tienes de {player.ElementAt(0).hp} vida");
                        Console.WriteLine("Termino el turno del enemigo");
                        Console.ReadKey();
                        playerTurn = true;
                        enemyTurn = false;
                    }
                    else if(enemys.Count == 0)
                    {
                        Console.Clear();
                        Console.WriteLine("Mataste a todos tus enemigos");
                        Console.WriteLine("Ganaste el combate");
                    }
                }

                if (player.ElementAt(0).hp <= 0)
                {
                    Console.WriteLine("Has muerto");
                    inCombat = false;
                    Console.ReadKey();
                }
            }
        }
    }
}
