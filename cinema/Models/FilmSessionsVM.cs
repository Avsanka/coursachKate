using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace cinema.Models
{
    public class FilmSessionsVM
    {
        public Film film { get; set; }
        public List<Session> sessions { get; set; }
    }
}