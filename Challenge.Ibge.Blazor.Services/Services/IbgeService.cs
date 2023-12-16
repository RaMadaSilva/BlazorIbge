using Challenge.Ibge.Blazor.Infra.Data.Interfaces;
using Challenge.Ibge.Blazor.Service.Results;
using Challenge.Ibge.Blazor.Service.Dtos;
using Challenge.Ibge.Blazor.Services.Interfaces;
using Challenge.Ibge.Blazor.Services.Mappers;

namespace Challenge.Ibge.Blazor.Service.Services;

public class IbgeService : IIbgeService
{
    private readonly IIbgeRepository _ibgeRepository;

    public IbgeService(IIbgeRepository ibgeRepository)
    {
        _ibgeRepository = ibgeRepository;
    }

    public async Task<Result> GetIbges()
    {
        Result result = new Result();
        try
        {
            result.Data = Mapper.ToIbges(await _ibgeRepository.GetIbges());
            result.Message = "succeed";
        }
        catch (Exception)
        {
            result.Message = "Error retrieving data from database";
        }
        return result;
    }

    public async Task<Result> UpdateIbge(int id, IbgeDto ibgeDto)
    {
        Result result = new Result();
        try
        {
            if (id.ToString() != ibgeDto.Id)
                result.Message = "Ibge id mismatch";
            else
            {
                var ibge = await _ibgeRepository.UpdateIbge(Mapper.ToIbge(ibgeDto));
                if (ibge != null)                
                {
                    result.Data = Mapper.ToIbge(ibge);
                    result.Message = "succeed"; 
                }
            }
        }
        catch (Exception)
        {
            result.Message = "Error updating data to database";
        }
        return result;
    }

    public async Task<Result> GetIbgeByCity(string city)
    {
        Result result = new Result();
        try
        {
            var ibge = await _ibgeRepository.GetIbgeByCity(city);
            if (ibge != null)
            {
                result.Data = Mapper.ToIbges(ibge.ToList());
                result.Message = "succeed"; 
            }            
        }
        catch (Exception)
        {
            result.Message = "Error retrieving data from database";
        }
        return result;
    }

    public async Task<Result> GetIbgeByState(string state)
    {
        Result result = new Result();
        try
        {
            var ibge = await _ibgeRepository.GetIbgeByState(state);
            if (ibge != null)
            {
                result.Data = Mapper.ToIbges(ibge.ToList());
                result.Message = "succeed"; 
            }            
        }
        catch (Exception)
        {
            result.Message = "Error retrieving data from database";
        }
        return result;
    }

    public async Task<Result> GetIbgeById(string id)
    {
        Result result = new Result();
        try
        {
            var ibge = await _ibgeRepository.GetIbgeById(id);
            if (ibge != null)
            {
                result.Data = Mapper.ToIbge(ibge);
                result.Message = "succeed"; 
            }            
        }
        catch (Exception)
        {
            result.Message = "Error retrieving data from database";
        }
        return result;
    }
}