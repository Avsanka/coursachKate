using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace cinema.Controllers
{
    public class MainController : Controller
    {
        // GET: Main
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult testAddCountry()
        {
            return View();
        }

        [HttpPost]
        public ActionResult testAddCountry(Country country) {
            if (ModelState.IsValid) {
                using (var db = new Database1Entities()) {
                    db.Country.Add(country);
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            return View(country);
        }


        [HttpGet]
        public ActionResult ListOfFilms() {
            List<Film> films = new List<Film>();
            using (var db = new Database1Entities()) {
                films = db.Film.OrderBy(x => x.release_date_from).ToList();
                //db.Database.ExecuteSqlCommand("TRUNCATE TABLE [Ticket]");
            }
            return View(films);
        }
        [HttpGet]
        public ActionResult FilmDetails(int id) {
            Models.FilmSessionsVM output = new Models.FilmSessionsVM();
            using (var db = new Database1Entities()) {
                output.film = db.Film.Find(id);
                output.sessions = db.Session.OrderBy(x => x.session_datetime).Where(x => x.ID_Film == id).ToList();
                foreach (var item in output.sessions) {
                    item.Hall = db.Hall.Find(item.ID_Hall);
                }
            }
            return View(output);
        }

        [HttpGet]
        public ActionResult BuyTicket(int sessionId) {
            using (var db = new Database1Entities()) {
                Models.SessionTicketVM output = new Models.SessionTicketVM();
                output.session = db.Session.Find(sessionId);
                output.session.Hall = db.Hall.Find(output.session.ID_Hall);
                output.tickets = db.Ticket.OrderBy(x => x.row).ThenBy(x => x.place).Where(x => x.ID_Session == sessionId).ToList();
                return View(output);
            }
        }

        [HttpGet]
        public ActionResult ConfirmBuy(int ID_Session, int row, int place, int price) {
            Ticket ticket = new Ticket();
            Session session = new Session();
            using (var db = new Database1Entities()) {
                session = db.Session.Find(ID_Session);
            }
            ticket.ID_Session = ID_Session;
            ticket.row = row;
            ticket.place = place;
            ticket.price = price;
            return View(ticket);
        }
        [HttpPost]
        [ValidateAntiForgeryToken()]
        public ActionResult ConfirmBuy(Ticket ticket) {
            using (var db = new Database1Entities())
            {
                ticket.purchase_datetine = DateTime.Now;
                ticket.Ticket_ID = db.Ticket.Count() + 1;
                db.Ticket.Add(ticket);
                db.SaveChanges();
            }
            return RedirectToAction("ListOfFilms");
        }
    }
}