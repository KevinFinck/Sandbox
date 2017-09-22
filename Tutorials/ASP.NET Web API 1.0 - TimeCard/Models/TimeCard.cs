using System;

namespace Tutorial.WebApi.TimeKeeper.Models
{
    public class TimeCard
    {
        public int Id { get; set; }
        public string Summary { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Status { get; set; }
    }
}