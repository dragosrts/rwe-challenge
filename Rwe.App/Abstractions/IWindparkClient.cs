using Rwe.App.Entities;

namespace Rwe.App.Abstractions
{
    public interface IWindparkClient
    {
        public Task<IEnumerable<Park>> GetParks();
    }
}