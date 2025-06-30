namespace Chronobox.DataAccess.Entities
{
    public class ObjectEntity
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public bool HasExpirationDate { get; set; }

        public Guid ContainerId { get; set; }

        public ContainerEntity? Container { get; set; }

        public Guid ExpirationId { get; set; }

        public ExpirationEntity? Expiration { get; set; }
    }
}
