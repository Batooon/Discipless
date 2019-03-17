using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

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

        public Bonus bonus;
        public Dude dude;
        public Field field;
        public Player player;
        public Foes enemy;
        public PlayerInputManager inputManager;
        public EnemyAI ai;
        public Timer timer;

        private void Init(GameInitData gameInitData)
        {
            Randomchik.Init();
            inputManager = new PlayerInputManager();
            ai = new EnemyAI();
            dude = new Dude();
            field = new Field();
            timer = new Timer(25, 10);
            Instantiate();
            FieldInit();

            player = new Player(7, 7, 200, 20, '@');

            InitEnemy();

            InitBonus();
        }

        /*private void InitTimer(int seconds)
        {
            if (player.IsBonus == true)
            {
                for (int s = seconds; s >= seconds; s--)
                {
                    Console.SetCursorPosition(10, 10);
                    if (s == 0)
                        Console.ForegroundColor = ConsoleColor.Red;

                    Console.Write($"\r{s}");
                    System.Threading.Thread.Sleep(1000);
                }
            }
        }*/

        private void InitEnemy()
        {
            int x, y;

            do
            {
                x = Randomchik.Next(0, field.Width);
                y = Randomchik.Next(0, field.Height);
            } while (x == player.X && y == player.Y);
            enemy = new Foes(x, y, 100, 10, '*');
        }

        private void InitBonus()
        {
            int x, y;

            do
            {
                x = Randomchik.Next(0, field.Width);
                y = Randomchik.Next(0, field.Height);
            } while (x == player.X && x == enemy.X && y == player.Y && y == enemy.Y);
            bonus = new Bonus(x, y);
        }

        private void Instantiate()
        {
        }

        public void StartGame()
        {
            Init(new GameInitData());

            while (!IsEndGame(player))
            {
                AI();
                EnemyUpdate();
                Input();
                PlayerUpdate();
                Attack();
                IsEatBonus();

                Console.Clear();
                Draw();

                System.Threading.Thread.Sleep(100);
            }
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("You died");
        }

        private void ShowTimer()
        {
            while (player.IsBonus == true)
            {
                timer.InitTimer(20);
            }
            player.IsBonus = false;
        }

        private void IsEatBonus()
        {
            if (player.X == bonus.X && player.Y == bonus.Y)
            {
                ShowTimer();
                player.IsBonus = true;
            }
        }

        private bool IsCatch()
        {
            if (enemy.X == player.X && enemy.Y == player.Y && !player.IsBonus) 
                return true;

            return false;
        }

        private void Attack()
        {
            if (IsCatch())
                player.Hp -= enemy.Damage;
        }

        public void FieldInit()
        {
            for (int i = 0; i < field.Height; i++)
                for (int j = 0; j < field.Width; j++)
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
            if (player.CanMoveTo(newX, newY,field.Width,field.Height))
            {
                player.MoveTo(newX, newY);
            }
        }

        public void EnemyUpdate()
        {
            int newX = enemy.X + ai.ChangeX;
            int newY = enemy.Y + ai.ChangeY;
            if (enemy.CanMoveTo(newX, newY, field.Width, field.Height))
            {
                enemy.MoveTo(newX, newY);
            }
        }

        private void Draw()
        {
            for (int i = 0; i < field.Width; i++)
            {
                for (int j = 0; j < field.Height; j++)
                {
                    if (i == player.X && j == player.Y)
                    {
                        Console.BackgroundColor = ConsoleColor.Yellow;
                        Console.ForegroundColor = ConsoleColor.Black;
                        player.Draw();
                        continue;
                    }
                    else if (i == enemy.X && j == enemy.Y)
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.ForegroundColor = ConsoleColor.Black;
                        enemy.Draw();
                        continue;
                    }
                    else if (i == bonus.X && j == bonus.Y&&!player.IsBonus)
                    {
                        Console.BackgroundColor = ConsoleColor.Green;
                        Console.ForegroundColor = ConsoleColor.Black;
                        bonus.DrawBonus();
                        continue;
                    }
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write(field.field[i, j]);
                }
                Console.WriteLine();
            }
            ShowHP();
        }

        private void ShowHP()
        {
            Console.ForegroundColor = ConsoleColor.White;

            if (IsCatch())
                Console.ForegroundColor = ConsoleColor.Red;
            player.ShowHP();
        }

        private bool IsEndGame(Player P)
        {
            if (P.Hp <= 0)
                return true;

            return false;
        }
    }
}
