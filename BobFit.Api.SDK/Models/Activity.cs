using System;

namespace BobFit.Api.SDK.Models
{
    public class Activity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ActivityType { get; set; }
        public DateTime EventDate { get; set; }
        public decimal Distance { get; set; }
        public decimal Duration { get; set; }
    }
}
