using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;


namespace Disciples
{
    public class Program
    {
        static void Main(string[] args)
        {
            //XML
            DataInit();
            BonusInit();

            Katka game = new Katka();
            game.StartGame();
        }

        private static void DataInit()
        {
            XmlDocument document = new XmlDocument();
            document.Load("Data.xml");
            XmlElement element = document.DocumentElement;
            foreach(XmlNode node in element)
            {
                LoadData(node);
            }
        }

        private static void LoadData(XmlNode node)
        {
            foreach (XmlNode kaka in node.ChildNodes)
            {
                switch (kaka.Name)
                {
                    case "Width":
                        Katka.WidthOfMap = int.Parse(kaka.InnerText);
                        break;
                    case "Height":
                        Katka.HeightOfMap = int.Parse(kaka.InnerText);
                        break;
                    case "Difficulty":
                        Katka.Difficuty = kaka.InnerText;
                        break;
                }
            }
        }

        private static void BonusInit()
        {
            XmlDocument document = new XmlDocument();
            document.Load("Bonuses.xml");
            XmlElement element = document.DocumentElement;
            foreach(XmlNode node in element)
            {
                Katka.bonuses.Add(ReadXmlBonus(node));
            }
        }

        private static Bonus ReadXmlBonus(XmlNode node)
        {
            Bonus b = new Bonus();
            foreach (XmlNode huy in node.ChildNodes)
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
    }
}
