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

        public Bonus bonus;
        public Dude dude;
        public Field field;
        public Player player;
        public Foes enemy;
        public PlayerInputManager inputManager;
        public EnemyAI ai;

        private void Init(GameInitData gameInitData)
        {
            Randomchik.Init();
            inputManager = new PlayerInputManager();
            ai = new EnemyAI();
            dude = new Dude();
            field = new Field();
            Instantiate();
            FieldInit();
            //bonus = new Bonus(Randomchik.Next(1,2),Random);

            player = new Player(7, 7, 200, 20, '@');

            InitEnemy();

            InitBonus();
        }

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
            bonus = new Bonus(2, x, y);
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

        private bool IsEatBonus()
        {
            if (player.X == bonus.X && player.Y == bonus.Y && !bonus.Isbonus)
                return true;

            return false;
        }

        private bool IsCatch()
        {
            if (enemy.X == player.X && enemy.Y == player.Y && !bonus.Isbonus) 
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
                    else if (i == bonus.X && j == bonus.Y&&!IsEatBonus())
                    {
                        bonus.Isbonus = true;
                        switch (bonus.Id)
                        {
                            case 1:
                                Console.BackgroundColor = ConsoleColor.Green;
                                Console.ForegroundColor = ConsoleColor.Black;
                                break;
                            case 2:
                                Console.BackgroundColor = ConsoleColor.White;
                                Console.ForegroundColor = ConsoleColor.Black;
                                break;
                        }
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
