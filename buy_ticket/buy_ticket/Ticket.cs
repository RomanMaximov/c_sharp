using System;


namespace buy_ticket
{
    public class Ticket
    {
        private string FirstName;
        private string LastName;
        private int Place;
        public DateTime CurrentDateTime { get; set; }
        

        static private int[] seat = new int[11];

        public void menu()
        {
            Console.WriteLine("");
            Console.WriteLine("To buy first class ticket press 1");
            Console.WriteLine("To buy economy class ticket press 2");
            Console.WriteLine("To exit press 3");
            Console.WriteLine("");
            Console.Write("Your choice: ");
        }

        public void printTicket()
        {
            Console.WriteLine("");
            Console.WriteLine("***************************");
            Console.WriteLine("TICKET");
            Console.WriteLine("Class: First");
            Console.WriteLine("Seat: " + getPlace());
            Console.WriteLine("First name: " + FirstName);
            Console.WriteLine("Last name: " + LastName);
            Console.WriteLine("Date: " + CurrentDateTime);
            Console.WriteLine("***************************");
        }

        public Ticket()
        {
            CurrentDateTime = DateTime.Now;
        }

        public void setPlace(int place)
        {
            Place = place;
        }

        public int getPlace()
        {
            return Place;
        }

        public void setFirst(string first)
        {
            FirstName = first;
        }

        public void setLast(string last)
        {
            LastName = last;
        }

        public int getSeat(int i)
        {
            return seat[i];
        }

        public void setSeat(int i)
        {
            seat[i] = 1;
        }

        public int checkFirstClassSeat()
        {
            int check = 0;
            for (int i = 1; i < 6; i++)
            {
                if (getSeat(i) == 1)
                {
                    ++check;
                }
            }

            return check;
        }

        public int checkEconomClassSeat()
        {
            int check = 0;
            for (int i = 6; i < 11; i++)
            {
                if (getSeat(i) == 1)
                {
                    ++check;
                }
            }

            return check;
        }

        public int checkChoice(string value)
        {
            bool b = int.TryParse(value, out int choice);
            while (!b || (choice < 1 || choice > 3))
            {
                Console.WriteLine("");
                Console.WriteLine("WRONG INPUT!");
                Console.WriteLine("");
                Console.Write("Your choice: ");
                b = int.TryParse(Console.ReadLine(), out choice);

            }
            return choice;
        }

        public int checkNum(string value)
        {
            bool b = int.TryParse(value, out int choice);
            while (!b || (choice < 1 || choice > 2))
            {
                Console.WriteLine("");
                Console.WriteLine("WRONG INPUT!");
                Console.WriteLine("");
                Console.Write("Your choice: ");
                b = int.TryParse(Console.ReadLine(), out choice);

            }
            return choice;
        }

        public int checkFirstClassPlace(string value)
        {
            bool b = int.TryParse(value, out int choice);
            while (!b || (choice < 1 || choice > 5))
            {
                Console.WriteLine("");
                Console.WriteLine("WRONG INPUT!");
                Console.WriteLine("");
                Console.Write("Your choice: ");
                b = int.TryParse(Console.ReadLine(), out choice);

            }
            return choice;
        }

        public int checkEconomyClassPlace(string value)
        {
            bool b = int.TryParse(value, out int choice);
            while (!b || (choice < 6 || choice > 10))
            {
                Console.WriteLine("");
                Console.WriteLine("WRONG INPUT!");
                Console.WriteLine("");
                Console.Write("Your choice: ");
                b = int.TryParse(Console.ReadLine(), out choice);

            }
            return choice;
        }

        public void vacant_first()
        {
            Console.WriteLine("");
            Console.WriteLine("Vacanct seats:");
            for (int i = 1; i < 6; i++)
            {
                if (seat[i] == 0)
                {
                    Console.WriteLine("First class seat[" + i + "]:        vacant");
                }
                else
                {
                    Console.WriteLine("First class seat[" + i + "]:          busy");
                }
            }
        }

        public void vacant_econom()
        {
            Console.WriteLine("");
            Console.WriteLine("Vacanct seats:");
            for (int i = 6; i < 11; i++)
            {
                if (seat[i] == 0)
                {
                    Console.WriteLine("Economy class seat[" + i + "]:        vacant");
                }
                else
                {
                    Console.WriteLine("Economy class seat[" + i + "]:          busy");
                }
            }
        }

        public override string ToString()
        {
            return CurrentDateTime.ToString();
        }
    }
}
