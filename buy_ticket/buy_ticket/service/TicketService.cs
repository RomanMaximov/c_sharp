using buy_ticket.util;
using buy_ticket.entity;
using System;
using System.Data.SqlClient;
using System.Data;
using buy_ticket.data.enums;
using System.Collections.Generic;

namespace buy_ticket.service
{
    internal class TicketService
    {
        private string query = string.Empty;

        public DBConfiguration dBConfiguration = new DBConfiguration();

        private SqlDataReader reader = null;

        private SqlCommand sqlCommand = null;

        static SqlConnection conn = null;

        public Ticket getTicketByNumber(int number)
        {
            SqlConnection conn = dBConfiguration.GetConnection();
            conn.Open();
            query = "SELECT * FROM ticket WHERE ticket.ticket_number = " + number;
            sqlCommand = new SqlCommand(query, conn);          

            reader = sqlCommand.ExecuteReader();

            Ticket ticket = mapToTicketEntity(reader);
            
            reader?.Close();
            if (conn.State == ConnectionState.Open)
                conn.Close();
            
            return ticket;
        }

        public Ticket getTicketToRemove(int number)
        {
            Ticket ticket = null;
            SqlConnection conn = dBConfiguration.GetConnection();
            conn.Open();
            query = "SELECT count(seat) FROM ticket WHERE seat_status = 'busy' AND ticket_number = " + number;
            sqlCommand = new SqlCommand(query, conn);
            int count = (int)sqlCommand.ExecuteScalar();

            if (count == 1)
                ticket = getTicketByNumber(number);
            return ticket != null ? ticket : new Ticket();
        }

        public List<TicketDto> getVacantFirstClass()
        {
            SqlConnection conn = dBConfiguration.GetConnection();
            conn.Open();
            query = "SELECT seat, seat_status FROM ticket WHERE comfort_class = 'FIRST' ORDER BY seat";
            sqlCommand = new SqlCommand(query, conn);

            List<TicketDto> dtos = new List<TicketDto>();
            reader = sqlCommand.ExecuteReader();

            while (reader.Read())
            {
                TicketDto ticketDto = new TicketDto();
                ticketDto.setPlace(Convert.ToInt32(reader["seat"]));
                ticketDto.setSeatStatus(Convert.ToString(reader["seat_status"]));
                dtos.Add(ticketDto);
            }

            reader?.Close();
            if (conn.State == ConnectionState.Open)
                conn.Close();

            return dtos;
        }

        public List<TicketDto> getVacantEconomyClass()
        {
            SqlConnection conn = dBConfiguration.GetConnection();
            conn.Open();
            query = "SELECT seat, seat_status FROM ticket WHERE comfort_class = 'ECONOMY' ORDER BY seat";
            sqlCommand = new SqlCommand(query, conn);

            List<TicketDto> dtos = new List<TicketDto>();
            reader = sqlCommand.ExecuteReader();

            while (reader.Read())
            {
                TicketDto ticketDto = new TicketDto();
                ticketDto.setPlace(Convert.ToInt32(reader["seat"]));
                ticketDto.setSeatStatus(Convert.ToString(reader["seat_status"]));
                dtos.Add(ticketDto);
            }

            reader?.Close();
            if (conn.State == ConnectionState.Open)
                conn.Close();

            return dtos;
        }

        public int getFirstClassBusySeats()
        {
            SqlConnection conn = dBConfiguration.GetConnection();
            conn.Open();
            query = "SELECT count(seat) FROM ticket WHERE comfort_class = 'FIRST' AND seat_status = 'busy'";
            sqlCommand = new SqlCommand(query, conn);
            int count = (int)sqlCommand.ExecuteScalar();

            if (conn.State == ConnectionState.Open)
                conn.Close();

            return count;
        }

        public  int getEconomyClassBusySeats()
        {
            SqlConnection conn = dBConfiguration.GetConnection();
            conn.Open();
            query = "SELECT count(seat) FROM ticket WHERE comfort_class = 'ECONOMY' AND seat_status = 'busy'";
            sqlCommand = new SqlCommand(query, conn);
            int count = (int)sqlCommand.ExecuteScalar();

            if (conn.State == ConnectionState.Open)
                conn.Close();

            return count;
        }

        public bool isVacantFirstClassSeat(int place)
        {
            SqlConnection conn = dBConfiguration.GetConnection();
            conn.Open();
            query = "SELECT count(seat) FROM ticket WHERE comfort_class = 'FIRST' AND seat_status = 'vacant' AND seat = " + place;
            sqlCommand = new SqlCommand(query, conn);
            int count = (int)sqlCommand.ExecuteScalar();

            if (conn.State == ConnectionState.Open)
                conn.Close();

            return count == 1;
        }

        public bool isVacantEconomyClassSeat(int place)
        {
            SqlConnection conn = dBConfiguration.GetConnection();
            conn.Open();
            query = "SELECT count(seat) FROM ticket WHERE comfort_class = 'ECONOMY' AND seat_status = 'vacant' AND seat = " + place;
            sqlCommand = new SqlCommand(query, conn);
            int count = (int)sqlCommand.ExecuteScalar();

            if (conn.State == ConnectionState.Open)
                conn.Close();

            return count == 1;
        }

        public void setFirstClassSeatBusy(Ticket ticket)
        {
            SqlConnection conn = dBConfiguration.GetConnection();
            conn.Open();
            query = "UPDATE ticket SET seat_status = 'busy'" +
                    ", pass_name = '" + ticket.getFullName() +
                    "', date_at = '" + ticket.getDateAt() + 
                    "' WHERE comfort_class = 'FIRST' AND seat = " + ticket.getPlace();
            sqlCommand = new SqlCommand(query, conn);
            sqlCommand.ExecuteNonQuery();

            if (conn.State == ConnectionState.Open)
                conn.Close();
        }

        public void setEconomyClassSeatBusy(Ticket ticket)
        {
            SqlConnection conn = dBConfiguration.GetConnection();
            conn.Open();
            query = "UPDATE ticket SET seat_status = 'busy'" +
                    ", pass_name = '" + ticket.getFullName() +
                    "', date_at = '" + ticket.getDateAt() +
                    "' WHERE comfort_class = 'ECONOMY' AND seat = " + ticket.getPlace();
            sqlCommand = new SqlCommand(query, conn);
            sqlCommand.ExecuteNonQuery();

            if (conn.State == ConnectionState.Open)
                conn.Close();
        }

        public void returnTicket(Ticket removeTicket)
        {
            SqlConnection conn = dBConfiguration.GetConnection();
            conn.Open();
            query = "UPDATE ticket SET seat_status = 'vacant', pass_name = NULL, date_at = NULL WHERE ticket_number = " + removeTicket.getTicketNumber();
            sqlCommand = new SqlCommand(query, conn);
            sqlCommand.ExecuteNonQuery();

            if (conn.State == ConnectionState.Open)
                conn.Close();
        }

        public Ticket mapToTicketEntity(SqlDataReader reader)
        {
            Ticket ticket = new Ticket();

            if(reader.Read())
            {
                ticket.setFullName(Convert.ToString(reader["pass_name"]));
                ticket.setTicketNumber(Convert.ToInt32(reader["ticket_number"]));                
                TicketClass tclass = (TicketClass) Enum.Parse(typeof(TicketClass), Convert.ToString(reader["comfort_class"]));
                ticket.setTicketClass(tclass);
                ticket.setPlace(Convert.ToInt32(reader["seat"]));
                ticket.setDateAt(Convert.ToDateTime(reader["date_at"]));
            }

            return ticket;
        }

        public void fillTicket(Ticket ticket, int place)
        {
            ticket.setPlace(place);
            ticket.setTicketNumber(place);
            ticket.setDateAt(DateTime.Now);
            ticket.setTicketClass(place > 5 ? TicketClass.ECONOMY : TicketClass.FIRST);
        }
    }
}
