using GetechnologiesMx.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace GetechnologiesMx.Domain.Entities
{
    public class Invoice : Entity
    {
        public required decimal Amount { get; set; }
        public required string Identification { get; set; }
        public Person? Person { get; set; }
    }
}
