using System;

namespace IJ_homeWork_RPGFight
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string CommandOne = "D1";
            const string CommandTwo = "D2";
            const string CommandThree = "D3";

            const int EnemyTailAttackID = 0;
            const int EnemyFireAttackID = 1;

            Random random = new Random();
            string userInput = string.Empty;

            bool isPlayerTurn = true;
            int playerHealth = 100;
            int playerFireStatus = 0;
            int playerFireStatusDamage = 5;
            int playerFrozenStatus = 0;
            int playerSwordAttackDamage = 45;
            int playerFireBombDamage = 56;
            int playerFireBombStatus = 3;
            int playerFireBombsInInventory = 10;
            int playerIceBombDamage = 40;
            int playerIceBombStatus = 3;
            int playerIceBombsInInventory = 7;
            int playerHealingPotionsInInventory = 12;
            int playerHealInHealingPotion = 60;

            bool isEnemyTurn = false;
            int enemyHealth = 500;
            double enemyFireResist = 0.80;
            int enemyFrozenStatus = 0;
            int enemyTailAttackDamage = 30;
            int enemyFireAttackDamage = 22;
            int enemyFireAttackStatus = 4;

            bool isFight = (playerHealth > 0 && enemyHealth > 0) ||
                            playerFireStatus > 0 ||
                            playerFrozenStatus > 0 ||
                            enemyFrozenStatus > 0;

            int shardsOfIceDamage = 5;

            Console.CursorVisible = false;

            while(isFight)
            {
                isFight = (playerHealth > 0 && enemyHealth > 0) ||
                            playerFireStatus > 0 ||
                            playerFrozenStatus > 0 ||
                            enemyFrozenStatus > 0;

                while (isPlayerTurn)
                {
                    Console.Clear();

                    if (playerHealth <= 0)
                    {
                        playerFireStatus = 0;
                        playerFrozenStatus = 0;
                        Console.WriteLine("Вы мертвы. Пропуск хода.");
                        Console.ReadKey();
                        isPlayerTurn = false;
                        isEnemyTurn = true;
                    }
                    else
                    {
                        Console.WriteLine($"ваш персонаж:" +
                                          $"\nЗдоровье: {playerHealth}" +
                                          $"\nСтатусы:");

                        if (playerFireStatus > 0)
                        {
                            Console.WriteLine($"Горение {playerFireStatus}");
                        }

                        Console.WriteLine();
                        Console.WriteLine($"дракон:" +
                                          $"\nЗдоровье: {enemyHealth}" +
                                          $"\nСтатусы:");

                        if (enemyFrozenStatus > 0)
                        {
                            Console.WriteLine($"Заморожен {enemyFrozenStatus}");
                        }

                        Console.WriteLine();

                        if (playerFireStatus > 0)
                        {
                            playerHealth -= playerFireStatusDamage;
                            playerFireStatus--;
                            Console.WriteLine($"Вы горите. Вы получили {playerFireStatusDamage} ед. урона.");
                        }

                        Console.WriteLine("Ваш ход.");
                        Console.WriteLine($"\n({CommandOne}) - удар мечом" +
                                          $"\n({CommandTwo}) - бомбы" +
                                          $"\n({CommandThree}) - зелье лечения");
                        userInput = Console.ReadKey(true).Key.ToString();

                        switch (userInput)
                        {
                            default:
                                Console.WriteLine("Вы замешкались, дав противнику шанс сделать ход раньше.");
                                Console.ReadKey();
                                isPlayerTurn = false;
                                isEnemyTurn = true;
                                break;

                            case CommandOne:
                                Console.Clear();
                                Console.WriteLine($"Режущий удар мечом. Наносит {playerSwordAttackDamage} ед. урона цели." +
                                                  $"\nПри использовании на себе убивает персонажа.");
                                Console.WriteLine("На ком использовать?");
                                Console.WriteLine($"\n({CommandOne}) - на себе" +
                                                  $"\n({CommandTwo}) - на противнике");
                                userInput = Console.ReadKey(true).Key.ToString();

                                switch (userInput)
                                {
                                    default:
                                        Console.WriteLine("Вы замешкались, дав противнику шанс сделать ход раньше.");
                                        Console.ReadKey();
                                        isPlayerTurn = false;
                                        isEnemyTurn = true;
                                        break;

                                    case CommandOne:
                                        playerHealth = 0;
                                        Console.WriteLine("Вы совершили сеппуку. Противник не понимает зачем вы это сделали.");
                                        Console.ReadKey();
                                        isPlayerTurn = false;
                                        isEnemyTurn = true;
                                        break;

                                    case CommandTwo:
                                        enemyHealth -= playerSwordAttackDamage;

                                        Console.WriteLine($"Вы совершили удар мечом, нанеся {playerSwordAttackDamage} ед. урона противнику.");

                                        if (enemyFrozenStatus > 0)
                                        {
                                            enemyFrozenStatus = 0;
                                            playerHealth -= shardsOfIceDamage;
                                            Console.WriteLine($"Вы разбили лёд, получив {shardsOfIceDamage} ед. урона от его осколков.");
                                        }

                                        Console.ReadKey();
                                        isPlayerTurn = false;
                                        isEnemyTurn = true;
                                        break;
                                }
                                break;

                            case CommandTwo:
                                Console.Clear();
                                Console.WriteLine($"Выберите бомбу.");
                                Console.WriteLine($"\n({CommandOne}) - огненная бомба {playerFireBombsInInventory}" +
                                                  $"\n({CommandTwo}) - ледяная бомба {playerIceBombsInInventory}");
                                userInput = Console.ReadKey(true).Key.ToString();

                                switch (userInput)
                                {
                                    default:
                                        Console.WriteLine("Вы замешкались, дав противнику шанс сделать ход раньше.");
                                        Console.ReadKey();
                                        isPlayerTurn = false;
                                        isEnemyTurn = true;
                                        break;

                                    case CommandOne:
                                        Console.Clear();
                                        Console.WriteLine($"Склянка с горючей смесью. Наносит {playerFireBombDamage} ед. урона цели, и накладывает {playerFireBombStatus} статусов \"горение\"");
                                        Console.WriteLine("На ком использовать?");
                                        Console.WriteLine($"\n({CommandOne}) - на себе" +
                                                          $"\n({CommandTwo}) - на противнике");
                                        userInput = Console.ReadKey(true).Key.ToString();

                                        switch (userInput)
                                        {
                                            default:
                                                Console.WriteLine("Вы замешкались, дав противнику шанс сделать ход раньше.");
                                                Console.ReadKey();
                                                isPlayerTurn = false;
                                                isEnemyTurn = true;
                                                break;

                                            case CommandOne:
                                                if (playerFireBombsInInventory > 0)
                                                {
                                                    playerHealth -= playerFireBombDamage;
                                                    playerFireStatus += playerFireBombStatus;
                                                    playerFireBombsInInventory--;
                                                    Console.WriteLine($"Вы кинули огненную бомбу под себя, получив {playerFireBombDamage} ед. урона. Врятли это действие вам как-то помогло.");
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Проверив карманы вы обнаруживаете, что у вас нет огненных бомб.");
                                                }

                                                Console.ReadKey();
                                                isPlayerTurn = false;
                                                isEnemyTurn = true;
                                                break;

                                            case CommandTwo:
                                                if (playerFireBombsInInventory > 0)
                                                {
                                                    if (enemyFrozenStatus > 0)
                                                    {
                                                        enemyFrozenStatus = 0;
                                                        playerFireBombsInInventory--;
                                                        Console.WriteLine("Вы кинули огненную бомбу,  разморозив противника.");
                                                        Console.WriteLine("Урон не нанесён.");
                                                    }
                                                    else
                                                    {
                                                        enemyHealth -= playerFireBombDamage - (int)(playerFireBombDamage * enemyFireResist);
                                                        playerFireBombsInInventory--;
                                                        Console.WriteLine("У противника сопротивление к огню. Статусы не наложены.");
                                                        Console.WriteLine($"Вы кинули огненную бомбу в противника, нанеся ему {playerFireBombDamage - (int)(playerFireBombDamage * enemyFireResist)} ед. урона.");
                                                    }
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Проверив карманы вы обнаруживаете, что у вас нет огненных бомб.");
                                                }

                                                Console.ReadKey();
                                                isPlayerTurn = false;
                                                isEnemyTurn = true;
                                                break;
                                        }
                                        break;

                                    case CommandTwo:
                                        Console.Clear();
                                        Console.WriteLine($"Склянка с замораживающим газом. Наносит {playerIceBombDamage} ед. урона цели, и накладывает {playerIceBombStatus} статусов \"Заморожен\"");
                                        Console.WriteLine("На ком использовать?");
                                        Console.WriteLine($"\n({CommandOne}) - на себе" +
                                                          $"\n({CommandTwo}) - на противнике");
                                        userInput = Console.ReadKey(true).Key.ToString();

                                        switch (userInput)
                                        {
                                            default:
                                                Console.WriteLine("Вы замешкались, дав противнику шанс сделать ход раньше.");
                                                Console.ReadKey();
                                                isPlayerTurn = false;
                                                isEnemyTurn = true;
                                                break;

                                            case CommandOne:
                                                if (playerIceBombsInInventory > 0)
                                                {
                                                    if (playerFireStatus > 0)
                                                    {
                                                        playerFireStatus = 0;
                                                        playerIceBombsInInventory--;
                                                        Console.WriteLine("Вы потушили себя.");
                                                        Console.WriteLine("Урон не нанесён.");
                                                    }
                                                    else
                                                    {
                                                        playerHealth -= playerIceBombDamage;
                                                        playerFrozenStatus += playerIceBombStatus;
                                                        playerIceBombsInInventory--;
                                                        Console.WriteLine($"Вы кинули ледяную бомбу под себя, получив {playerIceBombDamage} ед. урона. Вы отдаёте себе отчет, что это не спасёт от физических атак.");
                                                    }
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Проверив карманы вы обнаруживаете, что у вас нет ледяных бомб.");
                                                }

                                                Console.ReadKey();
                                                isPlayerTurn = false;
                                                isEnemyTurn = true;
                                                break;

                                            case CommandTwo:
                                                if (playerIceBombsInInventory > 0)
                                                {
                                                    enemyHealth -= playerIceBombDamage;
                                                    enemyFrozenStatus += playerIceBombStatus;
                                                    playerIceBombsInInventory--;
                                                    Console.WriteLine($"Вы кинули ледяную бомбу в противника, нанеся ему {playerIceBombDamage} ед. урона.");
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Проверив карманы вы обнаруживаете, что у вас нет ледяных бомб.");
                                                }

                                                Console.ReadKey();
                                                isPlayerTurn = false;
                                                isEnemyTurn = true;
                                                break;
                                        }
                                        break;
                                }
                                break;

                            case CommandThree:
                                Console.Clear();
                                Console.WriteLine($"Склянка с лечащим зельем. востанавливает {playerHealInHealingPotion} ед. здоровья.");
                                Console.WriteLine("На ком использовать?");
                                Console.WriteLine($"\n({CommandOne}) - на себе" +
                                                  $"\n({CommandTwo}) - на противнике");
                                userInput = Console.ReadKey(true).Key.ToString();

                                switch (userInput)
                                {
                                    default:
                                        Console.WriteLine("Вы замешкались, дав противнику шанс сделать ход раньше.");
                                        Console.ReadKey();
                                        isPlayerTurn = false;
                                        isEnemyTurn = true;
                                        break;

                                    case CommandOne:
                                        if (playerHealingPotionsInInventory > 0)
                                        {
                                            playerHealingPotionsInInventory--;
                                            playerHealth += playerHealInHealingPotion;
                                            Console.WriteLine("Вы вылечили себя.");
                                        }
                                        else
                                        {
                                            Console.WriteLine("Проверив карманы вы обнаруживаете, что у вас нет лечебных зелий.");
                                        }

                                        Console.ReadKey();
                                        isPlayerTurn = false;
                                        isEnemyTurn = true;
                                        break;

                                    case CommandTwo:
                                        if (playerHealingPotionsInInventory > 0)
                                        {
                                            playerHealingPotionsInInventory--;
                                            enemyHealth += playerHealInHealingPotion;
                                            Console.WriteLine("Вы вылечили противника. Противник это не оценил.");
                                        }
                                        else
                                        {
                                            Console.WriteLine("Проверив карманы вы обнаруживаете, что у вас нет лечебных зелий.");
                                        }

                                        Console.ReadKey();
                                        isPlayerTurn = false;
                                        isEnemyTurn = true;
                                        break;
                                }
                                break;
                        }
                    }
                }

                isFight = (playerHealth > 0 && enemyHealth > 0) ||
                            playerFireStatus > 0 ||
                            playerFrozenStatus > 0 ||
                            enemyFrozenStatus > 0;

                while (isEnemyTurn)
                {
                    Console.Clear();

                    if (enemyHealth <= 0)
                    {
                        enemyFrozenStatus = 0;
                        Console.WriteLine("Противник мёртв. Пропуск хода.");
                        Console.ReadKey();
                        isPlayerTurn = true;
                        isEnemyTurn = false;
                    }
                    else if (enemyFrozenStatus > 0)
                    {
                        enemyFrozenStatus--;
                        Console.WriteLine("Противник заморожен. Пропуск хода.");
                        Console.ReadKey();
                        isPlayerTurn = true;
                        isEnemyTurn = false;
                    }
                    else
                    {
                        Console.WriteLine($"ваш персонаж:" +
                                          $"\nЗдоровье: {playerHealth}" +
                                          $"\nСтатусы:");

                        if (playerFireStatus > 0)
                        {
                            Console.WriteLine($"Горение {playerFireStatus}");
                        }

                        if (playerFrozenStatus > 0)
                        {
                            Console.WriteLine($"Заморожен {playerFrozenStatus}");
                        }

                        Console.WriteLine();
                        Console.WriteLine($"дракон:" +
                                          $"\nЗдоровье: {enemyHealth}" +
                                          $"\nСтатусы:");

                        Console.WriteLine();
                        Console.WriteLine("Ход противника.");

                        if (playerHealth > 0)
                        {
                            switch (random.Next(EnemyTailAttackID, EnemyFireAttackID + 1))
                            {
                                case EnemyTailAttackID:
                                    playerHealth -= enemyTailAttackDamage;
                                    Console.WriteLine($"Противник ударил своим хвостом, нанеся вам {enemyTailAttackDamage} ед. Урона.");

                                    if (playerFrozenStatus > 0)
                                    {
                                        playerFrozenStatus = 0;
                                        enemyHealth -= shardsOfIceDamage;
                                        Console.WriteLine($"Противник разбиллёд, получив {shardsOfIceDamage} ед. урона от его осколков.");
                                    }

                                    Console.ReadKey();
                                    isPlayerTurn = true;
                                    isEnemyTurn = false;
                                    break;

                                case EnemyFireAttackID:
                                    if (playerFrozenStatus > 0)
                                    {
                                        playerFrozenStatus = 0;
                                        Console.WriteLine("Противник выпустил струю пламени из своей пасти, разморозив вас.");
                                        Console.WriteLine("Урон не нанесён.");
                                    }
                                    else
                                    {
                                        playerHealth -= enemyFireAttackDamage;
                                        playerFireStatus += enemyFireAttackStatus;
                                        Console.WriteLine($"Противник выпустил струю пламени из своей пасти, нанеся вам {enemyFireAttackDamage} ед. урона.");
                                    }

                                    Console.ReadKey();
                                    isPlayerTurn = true;
                                    isEnemyTurn = false;
                                    break;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Противник смотрит на ваше бездыханное тело");
                            Console.ReadKey();
                            isPlayerTurn = true;
                            isEnemyTurn = false;
                        }
                    }
                }
            }

            Console.Clear();

            if (enemyHealth <= 0 && playerHealth > 0)
            {
                Console.WriteLine("Вы победили.");
            }
            else if (playerHealth <= 0 && enemyHealth > 0)
            {
                Console.WriteLine("Вы проиграли.");
            }
            else
            {
                Console.WriteLine("Ничья.");
            }

            Console.ReadKey();
        }
    }
}