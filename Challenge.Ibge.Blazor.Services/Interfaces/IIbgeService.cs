using Challenge.Ibge.Blazor.Service.Results;
using Challenge.Ibge.Blazor.Service.Dtos;

namespace Challenge.Ibge.Blazor.Services.Interfaces
{
    public interface IIbgeService
    {
        //Task<IEnumerable<IbgeDto>> GetIbges();
        Task<Result> GetIbges();
        Task<Result> UpdateIbge(int id, IbgeDto ibge);
        Task<Result> GetIbgeByCity(string city);
        Task<Result> GetIbgeByState(string state);
        Task<Result> GetIbgeById(string id);
    }    
}