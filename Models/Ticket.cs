namespace eCB_Transport.Models
{
    public class Ticket
    {
        public Guid Id { get; set; }
        public string RouteId { get; set; }
        public string UserId { get; set; }

        public Ticket(string ARouteId, string AUserID)
        {
            Id = Guid.NewGuid();
            RouteId = ARouteId;
            UserId = AUserID;
        }

        public Ticket()
        {
            Id = Guid.NewGuid();
            RouteId = "0";
            UserId = "0";  
        }

        public Ticket(string ARouteId)
        {
            Id = Guid.NewGuid();
            RouteId = ARouteId;
            UserId = "0";
        }
    }
}
