using Day2.Interfaces;

namespace Day2.Services
{
    public class SingletonService : ISingletonService
    {
        public Guid Id { get; } = Guid.NewGuid();
    }
}