using System.ComponentModel.DataAnnotations;

namespace eCB_Transport.Models
{
    public class Route
    {
        public string Id { get; set; }
        public string BusId { get; set; }
        public string Dep { get; set; }
        public string Arr { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public string When { get; set; }

        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:hh-mm}", ApplyFormatInEditMode = true)]
        public string Time { get; set; }
        public int SeatsLeft { get; set; }

        public Route(string AId, string ABusId, string ADep, string AArr, string AWhen, string ATime, int ASeats)
        {
            Id = AId;
            BusId = ABusId;
            Dep = ADep;
            Arr = AArr;
            When = AWhen;
            Time = ATime;
            SeatsLeft = ASeats;
        }

        public Route() { }
    }
}
