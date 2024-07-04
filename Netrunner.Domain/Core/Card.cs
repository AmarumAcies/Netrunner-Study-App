using Netrunner.Domain.Common;

namespace Netrunner.Domain.Core
{
    public class Card //CardDTO - то, что хранится в базе данных и имеет полноценный вид
    {
        public Guid? CardId { get; set; }
        public int Cost { get; set; }

        public string? Name { get; set; }

        public PlayerType PlayerType { get; set; }

        public string? Description { get; set; }

        //public Card(string name, string description)
        //{
        //    Name = name;
        //    Description = description;
        //}

   
    }
}
