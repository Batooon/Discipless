using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disciples
{
    struct GameInitData
    {
    }

    class Katka
    {
        public Katka()
        {
        }

        public Food food;
        public Bonus bonus;
        public Dude dude;
        public Field field;
        public Player player;
        public Foes enemy;
        public PlayerInputManager inputManager;
        public EnemyAI ai;
        public static List<Bonus> bonuses = new List<Bonus>();
        public static int WidthOfMap;
        public static int HeightOfMap;
        public static string Difficuty;

        private void Init(GameInitData gameInitData)
        {
            Randomchik.Init();
            inputManager = new PlayerInputManager();
            ai = new EnemyAI();
            dude = new Dude();
            field = new Field();
            Instantiate();
            field = new Field(WidthOfMap, HeightOfMap);
            FieldInit();


            player = new Player(7, 7, 200, 20, '@');

            InitEnemy();

            InitBonus();
            RandomizeBonus();
            InitFood();
        }

        private void RandomizeBonus()
        {
            int value = Randomchik.Next(0, 3);
            bonus = new Bonus(bonuses[value]);
        }
        private void InitFood()
        {
            int N;
            switch (Difficuty)
            {
                case "Easy":
                    N = 15;
                    break;
                case "Normal":
                    N = 20;
                    break;
                case "Hard":
                    N = 30;
                    break;
                default:
                    throw new Exception("!!!Что-то не так со сложностью!!!");
            }
            int x, y;

            do
            {
                x = Randomchik.Next(0, WidthOfMap);
                y = Randomchik.Next(0, HeightOfMap);
            } while ((x == player.X && y == player.Y) || (x == enemy.X && y == enemy.Y) || (x == bonus.X && y == bonus.Y));
            food = new Food(x, y, N);
        }

        private void InitEnemy()
        {
            int x, y;

            do
            {
                x = Randomchik.Next(0, WidthOfMap);
                y = Randomchik.Next(0, HeightOfMap);
            } while (x == player.X && y == player.Y);
            enemy = new Foes(x, y, 100, 10, '*');
        }

        private void InitBonus()
        {
            int x, y;

            do
            {
                x = Randomchik.Next(0, WidthOfMap);
                y = Randomchik.Next(0, HeightOfMap);
            } while ((x == player.X && y == player.Y) || (x == enemy.X  && y == enemy.Y));
            bonus = new Bonus(x, y);
        }

        private void Instantiate()
        {
        }

        public void StartGame()
        {
            Init(new GameInitData());
            
            while (!IsEndGame())
            {
                AI();
                EnemyUpdate();
                Input();
                PlayerUpdate();
                Attack();
                IsEatBonus();
                IsEatFood();

                Console.Clear();
                Draw();

                System.Threading.Thread.Sleep(100);
            }
            StartNewGame();
        }

        private void Die()
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("You died");
        }

        private bool IsDie()
        {
            return player.Hp <= 0;
        }

        private void IsEatFood()
        {
            if (player.X == food.X && player.Y == food.Y)
                UpdateScore(ref player.score);
        }

        private void UpdateScore(ref int score)
        {
                score += 1;
        }

        private void Win()
        {
            Console.Clear();
            Console.WriteLine("YOU WIN");
        }

        private void IsEatBonus()
        {
            if (player.X == bonus.X && player.Y == bonus.Y && !player.IsBonus)
                bonus.Activate(ref player.IsBonus,ref player.Hp);
        }

        private bool IsEat()
        {
            return player.X == bonus.X && player.Y == bonus.Y;
        }

        private bool IsFood()
        {
            if (player.X == food.X && player.Y == food.Y)
            {
                InitFood();
                return true;
            }

            return false;
        }

        private bool IsCatch()
        {
            return enemy.X == player.X && enemy.Y == player.Y && !bonus.IsInvulnerability;
        }

        private void Attack()
        {
            if (IsCatch())
                player.Hp -= enemy.Damage;
        }

        public void FieldInit()
        {
            for (int i = 0; i < HeightOfMap; i++)
                for (int j = 0; j < WidthOfMap; j++)
                    field.field[i, j] = ' ';
        }

        public void Input()
        {
            inputManager.RefreshInput();
        }

        public void AI()
        {
            ai.RefreshPosition(player, enemy);
        }

        public void PlayerUpdate()
        {
            int newX = player.X + inputManager.ChangeX;
            int newY = player.Y + inputManager.ChangeY;
            if (player.CanMoveTo(newX, newY,WidthOfMap,HeightOfMap))
            {
                player.MoveTo(newX, newY);
            }
        }

        public void EnemyUpdate()
        {
            int newX = enemy.X + ai.ChangeX;
            int newY = enemy.Y + ai.ChangeY;
            if (enemy.CanMoveTo(newX, newY, WidthOfMap, HeightOfMap))
            {
                enemy.MoveTo(newX, newY);
            }
        }

        private void Draw()
        {
            for (int i = 0; i < WidthOfMap; i++)
            {
                for (int j = 0; j < HeightOfMap; j++)
                {
                    if (i == player.X && j == player.Y)
                    {
                        Console.BackgroundColor = ConsoleColor.Yellow;
                        Console.ForegroundColor = ConsoleColor.Black;
                        player.Draw();
                        continue;
                    }
                    if (i == enemy.X && j == enemy.Y)
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.ForegroundColor = ConsoleColor.Black;
                        enemy.Draw();
                        continue;
                    }
                    if (i == bonus.X && j == bonus.Y&&!player.IsBonus)
                    {
                        Console.BackgroundColor = bonus.BColor;
                        Console.ForegroundColor = bonus.FColor;
                        bonus.DrawBonus();
                        continue;
                    }
                    if (i == food.X && j == food.Y)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        food.DrawFood();
                        continue;
                    }
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write(field.field[i, j]);
                }
                Console.WriteLine();
            }
            ShowHP();
            Console.WriteLine();
            ShowScore();
        }

        private void ShowHP()
        {
            Console.ForegroundColor = ConsoleColor.White;

            if (IsCatch())
                Console.ForegroundColor = ConsoleColor.Red;

            if (IsEat())
                Console.ForegroundColor = ConsoleColor.Green;

            player.ShowHP();
        }

        private void ShowScore()
        {
            Console.ForegroundColor = ConsoleColor.White;

            if (IsFood())
                Console.ForegroundColor = ConsoleColor.Green;

            player.ShowScore();
        }

        private bool IsEndGame()
        {
            if (player.score == food.AmountOfFood)
            {
                Win();
                return true;
            }
            if (player.Hp <= 0) 
            {
                Die();
                return true;
            }
            return false;
        }

        private void StartNewGame()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Do you want to start a new game?");

            ConsoleKey key = Console.ReadKey().Key;

            switch (key)
            {
                case ConsoleKey.Enter:
                    StartGame();
                    break;
                case ConsoleKey.Backspace:
                    Console.Clear();
                    Console.ReadKey();
                    break;
            }
        }
    }
}
