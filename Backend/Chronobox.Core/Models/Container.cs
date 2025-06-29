namespace Chronobox.Core.Models
{
    public class Container
    {
        public const int MAX_NAME_LENGTH = 25;

        private Container(Guid id, string name, DateOnly dateOfCreation)
        {
            Id = id;
            Name = name;
            DateOfCreation = dateOfCreation;
        }
        public Guid Id { get; }

        public string Name { get; } = string.Empty;

        public DateOnly DateOfCreation { get; }

        public static (Container Container, string Error) Create(Guid id, string name, DateOnly dateOfCreation)
        {
            var error = string.Empty;

            if(string.IsNullOrEmpty(name) || name.Length > MAX_NAME_LENGTH)
            {
                error = $"The name cannot be more than {MAX_NAME_LENGTH} characters or empty.";
            }

            var container = new Container(id, name, dateOfCreation);

            return (container, error);
        }
    }
}
