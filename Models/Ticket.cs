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
            RouteId = AUserID;
            UserId = AUserID;
        }

        public Ticket() { }
    }
}
