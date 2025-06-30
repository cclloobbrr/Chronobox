namespace Chronobox.Core.Models
{
    public class Object
    {
        public const int MAX_NAME_LENGTH = 25;

        private Object(Guid id, string name, bool hasExpirationDate, Guid containerId, Container? container, Guid expirationId, Expiration? expiration)
        {
            Id = id;
            Name = name;
            HasExpirationDate = hasExpirationDate;
            ContainerId = containerId;
            Container = container;
            ExpirationId = expirationId;
            Expiration = expiration;
        }

        public Guid Id { get; }

        public string Name { get; } = string.Empty;

        public bool HasExpirationDate { get; }

        public Guid ContainerId { get; }

        public Container? Container { get; }

        public Guid ExpirationId { get; }

        public Expiration? Expiration { get; }

        public Object Create(Guid id, string name, bool hasExpirationDate, Guid containerId, Container? container, Guid expirationId, Expiration? expiration)
        {
            if(name == null || name.Length > MAX_NAME_LENGTH)
            {
                throw new ArgumentException($"");
            }

            if(container == null || containerId == Guid.Empty)
            {
                throw new ArgumentException($"");
            }

            var @object = new Object(id, name, hasExpirationDate, containerId, container, expirationId, expiration);

            return @object;
        }
    }
}
