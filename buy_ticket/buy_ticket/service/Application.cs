using buy_ticket.entity;
using buy_ticket.data.enums;
using System;
using System.Diagnostics.Eventing.Reader;

namespace buy_ticket.service
{
    internal class Application
    {
        private TicketChecks check = new TicketChecks();
        private Menu menu = new Menu();
        private Ticket ticket = new Ticket();
        private TicketService ticketService = new TicketService();
        public void init()
        {
            int choice;
            int place;
            bool repeat = true;
            bool newPassenger = true;
           
            menu.logo();            
            menu.ticketMenu();

            choice = check.checkChoice(Console.ReadLine());

            while (choice != 4)
            {
                switch (choice)
                {
                    case 1:
                        repeat = true;
                        newPassenger = true;
                        check.vacantFirstClass();

                        if (newPassenger && check.countFirstClassBusySeats() != 5)
                            check.setPassName(ticket);

                        if (check.countFirstClassBusySeats() == 5)
                        {
                            check.ticketsFirstClassSold(ref choice, ref repeat, ref newPassenger);
                            break;
                        }
                        
                        place = check.chooseFirstClassSeat();
                        if (check.firstClassBusy(place, ref choice, ref repeat, ref newPassenger))
                            break;
                        
                        ticketService.fillTicket(ticket, place);
                        ticketService.setFirstClassSeatBusy(ticket);
                        menu.printTicket(ticket);

                        if (check.countFirstClassBusySeats() == 5)
                            newPassenger = false;
                        break;

                    case 2:
                        repeat = true;
                        newPassenger = true;
                        check.vacantEconomyClass();

                        if (newPassenger && check.countEconomClassSeats() != 5)
                            check.setPassName(ticket);

                        if (check.countEconomClassSeats() == 5)
                        {
                            check.ticketsEconomyClassSold(ref choice, ref repeat, ref newPassenger);
                            break;        
                        }
                       
                        place = check.chooseEconomyClassSeat();
                        if (check.economyClassBusy(place, ref choice, ref repeat, ref newPassenger))
                            break;

                        ticketService.fillTicket(ticket, place);
                        ticketService.setEconomyClassSeatBusy(ticket);
                        menu.printTicket(ticket);
                        if (check.countEconomClassSeats() == 5)
                            newPassenger = false;
                        break;

                    case 3:
                        menu.returnMenu();
                        int ticketNumber = check.checkTicketNumberInput(Console.ReadLine());

                        Ticket removeTicket = ticketService.getTicketToRemove(ticketNumber);
                        menu.printRemoveTicket(removeTicket);
                        int num = check.checkNum(Console.ReadLine());
                        if (num == 1)
                            ticketService.returnTicket(removeTicket);
                        else
                            break;

                        ticket = ticketService.getTicketToRemove(removeTicket.getTicketNumber());

                        if (ticket.getFullName() == null)
                        {
                            menu.printSuccess();
                            repeat = true;
                        }                           

                        break;

                    default:
                        menu.ticketMenu();
                        choice = check.checkChoice(Console.ReadLine());
                        break;
                }

                if (repeat)
                {
                    menu.ticketMenu();
                    choice = check.checkChoice(Console.ReadLine());
                }
            }
        }
    }
}
