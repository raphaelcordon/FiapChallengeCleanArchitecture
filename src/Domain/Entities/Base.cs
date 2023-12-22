namespace Domain.Entities;

public abstract class Base
{
    public Guid Id { get; } = Guid.NewGuid();
}