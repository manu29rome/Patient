using Patent.Application.Interfaces;
using Patent.Domain.Entities;

namespace Patent.Application.Services
{
    public class PatentService(IPatentRepository patentRepository): IPatentService
    {
        public async Task<IEnumerable<PatientEntity>> GetListParent()
        {
            return await patentRepository.GetListAsync();
        }
    }
}
