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


        public Field field;
        public Player player;
        public Foes enemy;
        public PlayerInputManager inputManager;

        private void Init(GameInitData gameInitData)
        {
            Randomchik.Init();
            inputManager = new PlayerInputManager();
            field = new Field();
            FieldInit();

            player = new Player(0, 0, 200, 20, '@');
            int x, y;

            do
            {
                x = Randomchik.Next(0, field.x);
                y = Randomchik.Next(0, field.y);
            } while (field.field[x, y] == '@');
            enemy = new Foes(1, x, y, 100, 10, '*');
        }

        public void StartGame()
        {
            Init(new GameInitData());

            while (!IsEndGame(player,enemy))
            {
                Input();
                PlayerUpdate();

                Console.Clear();
                Draw();

                System.Threading.Thread.Sleep(100);
            }
        }

        public void FieldInit()
        {
            for (int i = 0; i < field.y; i++)
                for (int j = 0; j < field.x; j++)
                    field.field[i, j] = ' ';
        }

        public void Input()
        {
            inputManager.RefreshInput();
        }

        public void PlayerUpdate()
        {
            int newX = player.X + inputManager.ChangeX;
            int newY = player.Y + inputManager.ChangeY;
            if (CanMoveTo(newX, newY))
            {
                player.MoveTo(newX, newY);
            }
        }

        private void Draw()
        {
            for (int i = 0; i < field.x; i++)
            {
                for (int j = 0; j < field.y; j++)
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
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write(field.field[i, j]);
                }
                Console.WriteLine();
            }
            player.ShowScore();
        }

        private bool IsEndGame(Player P, Foes F)
        {
            if (P.Hp <= 0)
                return true;

            return false;
        }

        public bool CanMoveTo(int x, int y)
        {
            if (x < 0 || y < 0 || x > field.x || y > field.y)
                return false;

            return true;
        }
    }
}
