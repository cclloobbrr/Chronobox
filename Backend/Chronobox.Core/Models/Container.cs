namespace Chronobox.Core.Models
{
    public class Container
    {
        public const int MAX_NAME_LENGTH = 25;

        private Container(Guid id, string name, DateOnly dateOfCreation, List<Object>? objects = null)
        {
            Id = id;
            Name = name;
            DateOfCreation = dateOfCreation;
            Objects = objects?.AsReadOnly() ?? new List<Object>().AsReadOnly();
        }
        public Guid Id { get; }

        public string Name { get; }

        public DateOnly DateOfCreation { get; }

        public List<Object> Objects { get; }

        public static Container Create(Guid id, string name, DateOnly dateOfCreation)
        {
            if (string.IsNullOrEmpty(name) || name.Length > MAX_NAME_LENGTH)
            {
                throw new ArgumentException($"Name cannot be empty or exceed {MAX_NAME_LENGTH} chars.");
            }

            var container = new Container(id, name, dateOfCreation);

            return container;
        }
    }
}
