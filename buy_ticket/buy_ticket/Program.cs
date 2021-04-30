using System;


namespace buy_ticket
{

    class Program
    {
        
        static void Main(string[] args)
        {
            
            int choice;
            int place;
            int flag = 0;
            int flag2 = 0;

            Console.WriteLine("******************************************************************");
            Console.WriteLine("                     FLIGHT TICKETS SERVICE                       ");
            Console.WriteLine("******************************************************************");
            
            var ticket = new Ticket();

            ticket.menu();

            choice = ticket.checkChoice(Console.ReadLine());

            while (choice != 3)
            {
                if(flag2 == 0)
                {
                    string first, last;
                    Console.Write("Enter your first name: ");
                    first = Console.ReadLine();
                    ticket.setFirst(first);
                    Console.Write("Enter your last name: ");
                    last = Console.ReadLine();
                    ticket.setLast(last);
                }
                
                switch (choice)
                {
                    case 1:
                        ticket.vacant_first();
                        flag = 0;
                        flag2 = 0;
                        if (ticket.checkFirstClassSeat() == 5)
                        {
                            int num;
                            Console.WriteLine("");
                            Console.WriteLine("ALL FIRST CLASS TICKETS SOLD!");
                            Console.WriteLine("");
                            Console.WriteLine("If you like to buy economy class ticket press 1 and 2 to cancel.");
                            Console.Write("Your choice: ");
                            num = ticket.checkNum(Console.ReadLine());
                            if (num == 1)
                            {
                                choice = 2;
                                flag2 = 1;
                                flag = 1;
                                break;
                            }
                            else
                            {
                                Console.WriteLine("");
                                Console.WriteLine("NEXT FLIGHT IN 3 HOURS.");
                                flag2 = 1;
                                break;
                            }
                        }
                        Console.WriteLine("");
                        Console.Write("Choose a place: ");

                        place = ticket.checkFirstClassPlace(Console.ReadLine());
                        ticket.setPlace(place);
                        if (ticket.getSeat(place) == 0)
                        {
                            ticket.setSeat(place);
                        }
                        else
                        {
                            Console.WriteLine("");
                            Console.WriteLine("THIS PLACE IS ALREADY BUSY!");
                            choice = 1;
                            flag = 1;
                            flag2 = 1;
                            break;
                        }
                        ticket.printTicket();
                        if (ticket.checkFirstClassSeat() == 5) flag2 = 1;
                        break;

                    case 2:
                        ticket.vacant_econom();
                        flag = 0;
                        flag2 = 0;
                       
                        if (ticket.checkEconomClassSeat() == 5)
                        {
                            int num;
                            Console.WriteLine("");
                            Console.WriteLine("ALL ECONOMY CLASS TICKETS SOLD!");
                            Console.WriteLine("");
                            Console.WriteLine("If you like to buy first class ticket press 1 and 2 to cancel.");
                            Console.Write("Your choice: ");
                            num = ticket.checkNum(Console.ReadLine());
                            if (num == 1)
                            {
                                choice = 1;
                                flag = 1;
                                flag2 = 1;
                                break;
                            }
                            else
                            {
                                Console.WriteLine("");
                                Console.WriteLine("NEXT FLIGHT IN 3 HOURS.");
                                flag2 = 1;
                                break;
                            }
                        }
                        Console.WriteLine("");
                        Console.Write("Choose a place: ");
                        place = ticket.checkEconomyClassPlace(Console.ReadLine());
                        ticket.setPlace(place);

                        if (ticket.getSeat(place) == 0)
                        {
                            ticket.setSeat(place);
                        }
                        else
                        {
                            Console.WriteLine("");
                            Console.WriteLine("THIS PLACE IS ALREADY BUSY!");
                            choice = 2;
                            flag2 = 1;
                            break;
                        }
                        ticket.printTicket();
                        if (ticket.checkEconomClassSeat() == 5) flag2 = 1;
                        break;

                    default:
                        ticket.menu();
                        choice = ticket.checkChoice(Console.ReadLine());
                        break;

                }
                
                if (flag == 0)
                {
                    ticket.menu();
                    choice = ticket.checkChoice(Console.ReadLine());
                }
            }
        }
    }
}
