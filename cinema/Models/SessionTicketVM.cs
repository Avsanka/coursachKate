using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace cinema.Models
{
    public class SessionTicketVM
    {
        public Session session { get; set; }
        public List<Ticket> tickets { get; set; }
    }
}