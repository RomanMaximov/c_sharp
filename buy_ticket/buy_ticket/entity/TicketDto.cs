using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace buy_ticket.entity
{
    internal class TicketDto
    {
        private int place;
        private string seatStatus;

        public void setPlace(int seat)
        {
            place = seat;
        }

        public int getPlace()
        {
            return place;
        }

        public void setSeatStatus(string status)
        {
            seatStatus = status;
        }

        public string getSeatStatus()
        {
            return seatStatus;
        }
    }
}
