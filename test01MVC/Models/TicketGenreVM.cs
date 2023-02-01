using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace test01MVC.Models
{
    public class TicketGenreVM
    {
        public List<Ticket>? Tickets { get; set; }
        public SelectList? Genres { get; set; }
        public string? TicketGenre { get; set; }

    }
}
