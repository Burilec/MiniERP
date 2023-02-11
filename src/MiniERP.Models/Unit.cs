using MiniERP.Models.Exceptions;

namespace MiniERP.Models
{
    public sealed class Unit : BaseIdentifier
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public Unit(string name, string description) {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException(Messages.ValueCannotBeNullOrWhitespace, nameof(name));

            if (string.IsNullOrWhiteSpace(description))
                throw new ArgumentException(Messages.ValueCannotBeNullOrWhitespace, nameof(description));

            Name = name;
            Description = description;
        }

        public void SetName(string name) {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException(Messages.ValueCannotBeNullOrWhitespace, nameof(name));

            Name = name;
        }

        public void SetDescription(string description) {
            if (string.IsNullOrWhiteSpace(description))
                throw new ArgumentException(Messages.ValueCannotBeNullOrWhitespace, nameof(description));

            Description = description;
        }
    }
}