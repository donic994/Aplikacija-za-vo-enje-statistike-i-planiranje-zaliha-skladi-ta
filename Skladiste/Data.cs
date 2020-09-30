using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skladiste
{
    class Data
    {

        public static List<string> getItems()
        {
            List<string> itemList = new List<string>();

            itemList.Add("Čips");
            itemList.Add("Krumpir");
            itemList.Add("Luk");
            itemList.Add("Pepsi");
            itemList.Add("Sprite");
            itemList.Add("Fanta");
            itemList.Add("Zubna pasta");
            itemList.Add("Sapun");
            itemList.Add("Salama");
            itemList.Add("Sir");
            itemList.Add("Pašteta");
            itemList.Add("Tuna");
            itemList.Add("Mesni narezak");
            itemList.Add("Pile");
            itemList.Add("Salata");
            itemList.Add("Ketchup");
            itemList.Add("Majoneza");
            itemList.Add("Ljuti umak");
            itemList.Add("Kokošja juha");
            itemList.Add("Alpska juha");
            itemList.Add("Kiseli krastavci");
            itemList.Add("Maska za lice");
            itemList.Add("Sredstvo za dezinfekciju");
            itemList.Add("Rukavice");
            itemList.Add("Kruškovac");
            itemList.Add("Crno vino");
            itemList.Add("Bijelo vino");

            return itemList;
        }


        public static List<string> getNames()
        {
            List<string> nameList = new List<string>();

            nameList.Add("Filip");
            nameList.Add("Jakov");
            nameList.Add("Luka");
            nameList.Add("Agata");
            nameList.Add("Katarina");
            nameList.Add("Valentina");
            nameList.Add("Josip");
            nameList.Add("Fran");
            nameList.Add("Marko");
            nameList.Add("Matija");
            nameList.Add("David");
            nameList.Add("Larisa");
            nameList.Add("Ramona");
            nameList.Add("Borna");
            nameList.Add("Bruno");
            nameList.Add("Tin");
            nameList.Add("Klaudia");
            nameList.Add("Veronika");
            nameList.Add("Tena");
            nameList.Add("Izabela");
            nameList.Add("Hana");
            nameList.Add("Karolina");
            nameList.Add("Dražen");
            nameList.Add("Sofija");
            nameList.Add("Ines");
            nameList.Add("Krunoslav");
            nameList.Add("Krešimir");

            return nameList;
        }


        public static int getQuantity()
        {
            Random r = new Random();
            int quantity = r.Next(100, 800);

            return quantity;
        }

        public static int getMinimum()
        {
            Random r = new Random();
            int minimum = r.Next(0, 100);

            return minimum;
        }

        public static int getMaximum()
        {
            Random r = new Random();
            int maximum = r.Next(800, 1000);

            return maximum;
        }

        public static int getExpiration()
        {
            Random r = new Random();
            int expiration = r.Next(0, 1095); //1095 days = 3 years

            return expiration;
        }

        public static string getItem()
        {
            Random r = new Random();
            int index = r.Next(0, getItems().Count);

            return getItems()[index];
        }

        public static string getName()
        {
            Random r = new Random();
            int index = r.Next(0, getNames().Count);

            return getNames()[index];
        }

    }
}
