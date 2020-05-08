using System;

namespace BobFit.Api.Domain.Models
{
    public class Activity
    {
        public int Id;
        public string Title;
        public string ActivityType;
        public DateTime EventDate;
        public decimal Distance;
        public decimal Duration;
    }
}
