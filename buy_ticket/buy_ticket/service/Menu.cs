using System;
using buy_ticket.data.enums;
using buy_ticket.entity;

namespace buy_ticket.service
{
    internal class Menu
    {
        TicketChecks check = new TicketChecks();
        TicketService ticketService = new TicketService();
        public void logo()
        {
            Console.WriteLine("******************************************************************");
            Console.WriteLine("                     FLIGHT TICKETS SERVICE                       ");
            Console.WriteLine("******************************************************************");
        }

        public void ticketMenu()
        {
            Console.WriteLine();
            Console.WriteLine("To buy first class ticket press 1");
            Console.WriteLine("To buy economy class ticket press 2");
            Console.WriteLine("To return ticket press 3");
            Console.WriteLine("To exit press 4");
            Console.WriteLine();
            Console.Write("Your choice: ");
        }

        public void printTicket(Ticket ticket)
        {
            Console.WriteLine();
            Console.WriteLine("*************************************************************");
            Console.WriteLine("*                         TICKET                            *");
            Console.WriteLine("*************************************************************");
            Console.WriteLine("* Full name: " + ticket.getFullName());
            if (ticket.getPlace() != 10)
                Console.WriteLine("* Ticket number: " + " " + ticket.getTicketNumber() + "                  Seat: " + " " + ticket.getPlace() + "               *");
            else
                Console.WriteLine("* Ticket number: " + ticket.getTicketNumber() + "                  Seat: " + ticket.getPlace() + "               *");
            if (ticket.getTicketClass().Equals(TicketClass.FIRST))
            { 
                string tc = " " + ticket.getTicketClass();
                Console.WriteLine("* Class: " + tc + "                                             *");
            }
            else
                Console.WriteLine("* Class: " + ticket.getTicketClass() + "                                            *");
            Console.WriteLine("* Date: 24.02.2023, 14:08:01                                *");
            Console.WriteLine("*************************************************************");
        }

        public void returnMenu()
        {
            Console.WriteLine();
            Console.WriteLine("*************************************************************");
            Console.WriteLine("*                       RETURN TICKET                       *");
            Console.WriteLine("*************************************************************");
            Console.Write("To return ticket enter ticket's number, please: ");
        }

        public void printRemoveTicket(Ticket ticket)
        {
            while(ticket.getFullName() == null)
            {
                Console.WriteLine();
                Console.Write("This ticket doesn't exist!\nPlease, check your ticket's number and enter again: ");
                int ticketNumber = check.checkTicketNumberInput(Console.ReadLine());
                ticket = ticketService.getTicketToRemove(ticketNumber);
            }

            printTicket(ticket);

            Console.WriteLine();
            Console.Write("Would you like to return this ticket? Press 1 to return or 2 to cancel: ");
        }

        public void printSuccess()
        {
            Console.WriteLine();
            Console.WriteLine("*************************************************************");
            Console.WriteLine("*               Ticket returned successfully!               *");
            Console.WriteLine("*************************************************************");
            Console.WriteLine();
        }
    }
}
