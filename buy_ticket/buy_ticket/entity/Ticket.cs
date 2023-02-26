using buy_ticket.data.enums;
using System;
using System.Data.Entity.Core;

namespace buy_ticket.entity
{
    public class Ticket
    {
        private string fullName;
        private int place;
        private int ticketNumber;
        private TicketClass ticketClass;
        private DateTime dateAt;

        public void setPlace(int seat)
        {
            place = seat;
        }

        public int getPlace()
        {
            return place;
        }

        public string getFullName()
        {
            return fullName;
        }

        public void setFullName(string name)
        {
            fullName = name;
        }

        public void setTicketNumber(int number)
        {
            ticketNumber = number;
        }

        public int getTicketNumber()
        {
            return ticketNumber;
        }

        public void setTicketClass(TicketClass tClass)
        {
            ticketClass = tClass;
        }

        public TicketClass getTicketClass()
        {
            return ticketClass;
        }

        public void setDateAt(DateTime date)
        {
            dateAt = date;
        }

        public DateTime getDateAt()
        {
            return dateAt;
        }
    }
}
