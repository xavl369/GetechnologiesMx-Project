using GetechnologiesMx.Domain.Contracts;

namespace GetechnologiesMx.Domain.Common {
    public abstract class Entity : AuditableEntity, IEntity {
        public Guid Id { get; set; }
    }
}
