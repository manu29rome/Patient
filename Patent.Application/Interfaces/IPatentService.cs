using Patent.Domain.Entities;

namespace Patent.Application.Interfaces
{
    public interface IPatentService
    {
        Task<IEnumerable<PatientEntity>> GetListParent();
    }
}
