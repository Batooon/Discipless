using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Disciples
{
    struct GameInitData
    {
    }

    class Katka
    {
        public void LoadData()
        {
            XmlDocument document = new XmlDocument();
            document.Load("Data.xml");
            XmlElement element = document.DocumentElement;
            foreach (XmlNode node in element)
            {
                    ReadData(node);
            }
        }
        public void ReadData(XmlNode node)
        {
            foreach (XmlNode kaka in node.ChildNodes)
            {
                switch (kaka.Name)
                {
                    case "Width":
                        w = int.Parse(kaka.InnerText);
                        break;
                    case "Height":
                        h = int.Parse(kaka.InnerText);
                        break;
                }
            }
        }
        public Katka()
        {
        }

        public int w;
        public int h;
        public Bonus bonus;
        public Dude dude;
        public Field field;
        public Player player;
        public Foes enemy;
        public PlayerInputManager inputManager;
        public EnemyAI ai;
        public List<Bonus> bonuses;

        private void Init(GameInitData gameInitData)
        {
            LoadData();
            LoadDataField();
            Randomchik.Init();
            inputManager = new PlayerInputManager();
            ai = new EnemyAI();
            dude = new Dude();
            field = new Field();
            bonuses = new List<Bonus>();
            Instantiate();
            FieldInit();

            player = new Player(7, 7, 200, 20, '@');

            InitEnemy();

            InitBonus();
            AddBonus();
            RandomizeBonus();
        }

        private void RandomizeBonus()
        {
            int value = Randomchik.Next(0, 3);
            bonus = new Bonus(bonuses[value]);
        }

        private void LoadDataField()
        {
            field = new Field(w, h);
        }

        private void AddBonus()
        {
            XmlDocument document = new XmlDocument();
            document.Load("Bonuses.xml");
            XmlElement element = document.DocumentElement;
            foreach(XmlNode node in element)
            {
                bonuses.Add(ReadXmlBonus(node));
            }
        }

        private Bonus ReadXmlBonus(XmlNode node)
        {
            Bonus b = new Bonus();
            foreach(XmlNode huy in node.ChildNodes)
            {
                switch (huy.Name)
                {
                    case "name":
                        string name = huy.InnerText;
                        switch (name)
                        {
                            case "invulnerability":
                            case "SHeal":
                            case "MHeal":
                            case "BHeal":
                                b.name = name;
                                break;
                            default:
                                throw new Exception("!!!Что-то не так с именами бонуса!!!");
                        }
                        break;
                    case "FColor":
                        string FColor = huy.InnerText;
                        switch (FColor)
                        {
                            case "White":
                                b.FColor = ConsoleColor.White;
                                break;
                            case "Green":
                                b.FColor = ConsoleColor.Green;
                                break;

                            default:
                                throw new Exception("!!!Что-то не так с ForegroundColor бонуса!!!");
                        }
                        break;
                    case "BColor":
                        string BColor = huy.InnerText;
                        switch (BColor)
                        {
                            case "Black":
                                b.BColor = ConsoleColor.Black;
                                break;
                            case "DarkGreen":
                                b.BColor = ConsoleColor.DarkGreen;
                                break;
                            case "Red":
                                b.BColor = ConsoleColor.Red;
                                break;
                            case "Yellow":
                                b.BColor = ConsoleColor.Yellow;
                                break;
                            default:
                                throw new Exception("!!!Что-то не так с Background color бонуса!!!");
                        }
                        break;
                    case "IsInvulnerability":
                        b.IsInvulnerability = true;
                        break;
                    case "Heal":
                        int hp = int.Parse(huy.InnerText);
                        b.AddHp = hp;
                        break;
                    default:
                        throw new Exception("!!!Что-то не так с huy!!!");
                }
            }
                return b;
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
            } while ((x == player.X && y == player.Y) || (x == enemy.X  && y == enemy.Y));
            bonus = new Bonus(x, y);
        }

        private void Instantiate()
        {
        }

        public void StartGame()
        {
            Init(new GameInitData());
            //ReadXmlBonus();
            
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
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("You died");
        }

        /*private void ShowTimer()
        {
            while (player.IsBonus == true)
            {
                timer.InitTimer(20);
            }
            player.IsBonus = false;
        }*/

        private void IsEatBonus()
        {
            if (player.X == bonus.X && player.Y == bonus.Y && !player.IsBonus)
                bonus.Activate(ref player.IsBonus,ref player.Hp);
        }

        private bool IsEat()
        {
            if (player.X == bonus.X && player.Y == bonus.Y)
                return true;

            return false;
        }

        private bool IsCatch()
        {
            if (enemy.X == player.X && enemy.Y == player.Y && !bonus.IsInvulnerability) 
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

            if (IsEat())
                Console.ForegroundColor = ConsoleColor.Green;

            player.ShowHP();
        }

        private bool IsEndGame(Player P)
        {
            return P.Hp <= 0;
        }
    }
}
