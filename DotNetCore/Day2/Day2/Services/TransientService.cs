using Day2.Interfaces;

namespace Day2.Services
{
    public class TransientService : ITransientService
    {
        public Guid Id { get; } = Guid.NewGuid();
    }
}