namespace WebApp.Models.Base;

public interface IBaseEntity : ITimestampedEntity
{
    Guid Id { get; set; }
}