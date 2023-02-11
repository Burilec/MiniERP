using MiniERP.Models.Exceptions;

namespace MiniERP.Models
{
    public sealed class Product : BaseIdentifier
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public Unit? Unit { get; set; }

        public Product(string name, string description)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException(Messages.ValueCannotBeNullOrWhitespace, nameof(name));

            if (string.IsNullOrWhiteSpace(description))
                throw new ArgumentException(Messages.ValueCannotBeNullOrWhitespace, nameof(description));

            Name = name;
            Description = description;
        }

        public void SetName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException(Messages.ValueCannotBeNullOrWhitespace, nameof(name));

            Name = name;
        }

        public void SetDescription(string description)
        {
            if (string.IsNullOrWhiteSpace(description))
                throw new ArgumentException(Messages.ValueCannotBeNullOrWhitespace, nameof(description));

            Description = description;
        }
    }
}