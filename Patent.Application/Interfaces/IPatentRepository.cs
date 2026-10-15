using Patent.Domain.Entities;

namespace Patent.Application.Interfaces
{
    public interface IPatentRepository
    {
        Task<IEnumerable<PatientEntity>> GetListAsync();
    }
}
