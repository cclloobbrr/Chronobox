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
            Objects = new List<Object>().AsReadOnly();
        }
        public Guid Id { get; }

        public string Name { get; }

        public DateOnly DateOfCreation { get; }

        public IReadOnlyList<Object> Objects { get; }

        public static (Container Container, string Error) Create(Guid id, string name, DateOnly dateOfCreation)
        {
            var error = string.Empty;

            if(id == Guid.Empty)
            {
                error = ($"You can't send an empty id.");
            }
            else if (string.IsNullOrEmpty(name) || name.Length > MAX_NAME_LENGTH)
            {
                error = ($"Name cannot be empty or exceed {MAX_NAME_LENGTH} chars.");
            }

            var container = new Container(id, name, dateOfCreation);

            return (container, error);
        }
    }
}
