using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
namespace LOTTO
{
    class Program
    {
        static void Main(string[] args)
        {

            Random rdn = new Random();

            bool random = true;
            int valg;
            int rigtige;

            do
            {
                rigtige = 0;
                //her spørg den brugeren hvordan han/hun ønsker at få sin Kupon
                Console.WriteLine("Velkommen til konkursLotto's lotto maskine ønsker du selv at vægle dine tal eller skal de bare være tilfældige");
                Console.WriteLine("1) Tilfældigt");
                Console.WriteLine("2) Selv-Valgt");
                if (int.Parse(Console.ReadLine()) != 1)
                {
                    random = false;
                }
                else
                    random = true;


                //her bliver værdierne skrevet ind i vindertal og brugertal
                int[] vindertal = new int[7];
                int[] brugertal = new int[7];
                for (int i = 0; i < 7; i++)
                {
                    if (random == true)
                    {
                        brugertal[i] = rdn.Next(1, 21);
                    }
                    else
                    {
                        Console.WriteLine("Intast det " + i + 1 + ". nummer du ønsker du kan vægle (1-20)");
                        do
                        {
                            valg = inputtjek();
                        } while (valg > 20 || valg < 1);
                    }
                    vindertal[i] = rdn.Next(1, 21);
                }


                //viser brugers tal til brugeren
                Console.WriteLine("Dine tal er ");
                foreach (int number in brugertal)
                {
                    Console.Write(number + "  ");
                }


                //viser vindertalne og regner ud hvor mange rigtige man har
                Console.WriteLine("trækker vindertalne");
                Thread.Sleep(3000);
                Console.WriteLine("vindertalne er");
                foreach (int number in vindertal)
                {
                    Console.Write(number + "  ");
                    foreach (int number1 in brugertal)
                    {
                        if (number == number1)
                            rigtige++;
                    }
                }
                Console.WriteLine("Beregner gevinst");
                Thread.Sleep(5000);
                switch (rigtige)
                {
                    case 0:
                        Console.WriteLine("Du vandt desvære ikke denne gang");
                        break;
                    case 1:
                        Console.WriteLine("Du vandt desvære ikke denne gang");
                        break;
                    case 2:
                        Console.WriteLine("Du har vunder 30kr.");
                        break;
                    case 3:
                        Console.WriteLine("Du har vunder 60kr.");
                        break;
                    case 4:
                        Console.WriteLine("Du har vunder 300kr.");
                        break;
                    case 5:
                        Console.WriteLine("Du har vunder 1000kr.");
                        break;
                    case 6:
                        Console.WriteLine("Du har vunder 5000kr.");
                        break;
                    default:
                        Console.WriteLine("Du har vunder 10000kr.");
                        break;
                }

                Console.WriteLine("ønsker du at prøve igen");
            } while (Console.ReadLine().ToLower() == "ja");


        }
        //denne metode er til at tjekke de tal man skriver ind i consolen for at sikre man ikke skriver noget man ikke må
        public static int inputtjek()
        {


            int res = 0;
            bool truetjek = false;
            do
            {
                truetjek = int.TryParse(Console.ReadLine(), out res);
                if (truetjek == false)
                    Console.WriteLine("Du kan kun skrive heltal her prøv igen (skirv ja eller nej)");
                if (res < 1 || res > 20)
                    Console.WriteLine("Du må kun vægle tal imellem 1 og 20");

            } while (truetjek == false || res < 1 || res > 20);

            return res;
        }
    }
}
