namespace WebApp.Models.Base;

public interface ITimestampedEntity
{
    DateTime DateCreated { get; set; }
    DateTime DateModified { get; set; }    
}