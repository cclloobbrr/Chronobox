namespace Chronobox.DataAccess.Entities
{
    public class ContainerEntity
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public DateOnly DateOfCreation { get; set; }

        public IReadOnlyList<ObjectEntity> Objects { get; } = [];
    }
}
