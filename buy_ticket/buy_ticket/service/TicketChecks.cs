using buy_ticket.entity;
using System;
using System.Collections.Generic;

namespace buy_ticket.service
{
    internal class TicketChecks
    {
        TicketService ticketService = new TicketService();

        public int countFirstClassBusySeats()
        {
            return ticketService.getFirstClassBusySeats();
        }

        public int countEconomClassSeats()
        {
            return ticketService.getEconomyClassBusySeats();
        }

        public int checkChoice(string value)
        {
            bool b = int.TryParse(value, out int choice);
            while (!b || (choice < 1 || choice > 4))
            {
                Console.WriteLine("");
                Console.WriteLine("Enter a number in range 1 - 4");
                Console.WriteLine("");
                Console.Write("Your choice: ");
                b = int.TryParse(Console.ReadLine(), out choice);

            }
            return choice;
        }

        public int checkTicketNumberInput(string value)
        {
            bool b = int.TryParse(value, out int choice);
            while (!b || (choice < 1 || choice > 10))
            {
                Console.WriteLine("");
                Console.WriteLine("Enter a ticket's number in range 1 - 10");
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
                Console.WriteLine("Enter a number in range 1 - 2");
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
                Console.WriteLine("Enter a number in range 1 - 5");
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
                Console.WriteLine("Enter a number in range 6 - 10");
                Console.WriteLine("");
                Console.Write("Your choice: ");
                b = int.TryParse(Console.ReadLine(), out choice);

            }
            return choice;
        }

        public void vacantFirstClass()
        {
            Console.WriteLine("");
            Console.WriteLine("Vacanct seats:");
            List<TicketDto> ticketDtos = ticketService.getVacantFirstClass();

            foreach (TicketDto dto in ticketDtos)
            {
                if (dto.getSeatStatus().Equals("vacant"))
                {
                    Console.WriteLine("First class seat[" + dto.getPlace() + "]:        vacant");
                }
                else
                {
                    Console.WriteLine("First class seat[" + dto.getPlace() + "]:          busy");
                }
            }
        }

        public void vacantEconomyClass()
        {
            Console.WriteLine("");
            Console.WriteLine("Vacanct seats:");
            List<TicketDto> ticketDtos = ticketService.getVacantEconomyClass();

            foreach (TicketDto dto in ticketDtos)
                if (dto.getSeatStatus().Equals("vacant"))
                {
                    Console.WriteLine("Economy class seat[" + dto.getPlace() + "]:        vacant");
                }
                else
                {
                    Console.WriteLine("Economy class seat[" + dto.getPlace() + "]:          busy");
                }
        }

        public void ticketsFirstClassSold(ref int choice, ref bool repeat, ref bool newPassenger)
        {
            int num;
            Console.WriteLine("");
            Console.WriteLine("ALL FIRST CLASS TICKETS SOLD!");
            Console.WriteLine("");
            Console.WriteLine("If you like to buy economy class ticket press 1 and 2 to cancel.");
            Console.Write("Your choice: ");
            num = checkNum(Console.ReadLine());
            if (num == 1)
            {
                choice = 2;
                newPassenger = true;
                repeat = false;
                return;
            }
            else
            {
                Console.WriteLine("");
                Console.WriteLine("NEXT FLIGHT IN 3 HOURS.");
                newPassenger = true;
                return;
            }
        }

        public void ticketsEconomyClassSold(ref int choice, ref bool repeat, ref bool newPassenger)
        {
            int num;
            Console.WriteLine("");
            Console.WriteLine("ALL ECONOMY CLASS TICKETS SOLD!");
            Console.WriteLine("");
            Console.WriteLine("If you like to buy first class ticket press 1 and 2 to cancel.");
            Console.Write("Your choice: ");
            num = checkNum(Console.ReadLine());
            if (num == 1)
            {
                choice = 1;
                repeat = false;
                newPassenger = true;
                return;
            }
            else
            {
                Console.WriteLine("");
                Console.WriteLine("NEXT FLIGHT IN 3 HOURS.");
                newPassenger = true;
                return;
            }
        }

        public bool firstClassBusy(int place, ref int choice, ref bool repeat, ref bool newPassenger)
        {
            if (ticketService.isVacantFirstClassSeat(place))
            {               
                return false;
            }
            else
            {
                Console.WriteLine("");
                Console.WriteLine("THIS PLACE IS ALREADY BUSY!");
                choice = 1;
                repeat = false;
                newPassenger = false;
                return true;
            }
        }

        public bool economyClassBusy(int place, ref int choice, ref bool repeat, ref bool newPassenger)
        {
            if (ticketService.isVacantEconomyClassSeat(place))
            {           
                return false;
            }
            else
            {
                Console.WriteLine("");
                Console.WriteLine("THIS PLACE IS ALREADY BUSY!");
                choice = 2;
                repeat = false;
                newPassenger = false;
                return true;
            }
        }

        public int chooseFirstClassSeat()
        {
            Console.WriteLine("");
            Console.Write("Choose a place: ");
            return checkFirstClassPlace(Console.ReadLine());
        }

        public int chooseEconomyClassSeat()
        {
            Console.WriteLine("");
            Console.Write("Choose a place: ");
            return checkEconomyClassPlace(Console.ReadLine());
        }

        public void setPassName(Ticket ticket)
        {
            string name;
            Console.Write("\nEnter your full name: ");
            name = Console.ReadLine();
            ticket.setFullName(name);
        }
    }
}
