namespace Chronobox.DataAccess.Entities
{
    public class ExpirationEntity
    {
        public Guid Id { get; set; }

        public DateOnly EndDate { get; set; }

        public int NotificationDaysBefore { get; set; }
    }
}
