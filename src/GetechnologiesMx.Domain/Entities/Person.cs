

using GetechnologiesMx.Domain.Common;

namespace GetechnologiesMx.Domain.Entities{
    public class Person : Entity {

        public required string Name { get; set; }
        public required string LastName { get; set; }
        public required string MaternalSurname { get; set; } = "";
        public required string Identification { get; set; }
        public ICollection<Invoice>? Invoices { get; set; } 

    }
}
