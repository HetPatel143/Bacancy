using Day2.Interfaces;

namespace Day2.Services
{
    public class ScopedService : IScopedService
    {
        public Guid Id { get; } = Guid.NewGuid();
    }
}