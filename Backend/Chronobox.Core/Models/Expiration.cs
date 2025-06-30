namespace Chronobox.Core.Models
{
    public class Expiration
    {
        private Expiration(Guid id, DateOnly endDate, int notificationDaysBefore)
        {
            Id = id;
            EndDate = endDate;
            NotificationDaysBefore = notificationDaysBefore;
        }

        public Guid Id { get; }

        public DateOnly EndDate { get; }

        public int NotificationDaysBefore { get; }
        

        public static Expiration Create(Guid id, DateOnly endDate, int notificationDaysBefore)
        {            
            if(notificationDaysBefore < 1)
            {
                throw new ArgumentException($"");
            }

            if (endDate < DateOnly.FromDateTime(DateTime.Now))
            {
                throw new ArgumentException($"");
            }

            var expiration = new Expiration(id, endDate, notificationDaysBefore);

            return expiration;
        }
    }
}
