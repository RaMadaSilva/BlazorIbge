using Challenge.Ibge.Blazor.Infra.Data.Entities;
using Challenge.Ibge.Blazor.Service.Dtos;

namespace Challenge.Ibge.Blazor.Services.Mappers;

public static class Mapper
{
    public static IbgeDto ToIbge(IbgeEntity ibge)
    {
        if (ibge == null)
            return new IbgeDto();
        return new IbgeDto
        {
            Id = ibge.Id,
            State = ibge.State,
            City = ibge.City
        };
    }

    public static IbgeEntity ToIbge(IbgeDto ibge)
    {
        if (ibge == null)
            return new IbgeEntity();
        return new IbgeEntity
        {
            Id = ibge.Id,
            State = ibge.State,
            City = ibge.City
        };
    }

    public static IList<IbgeDto> ToIbges(IList<IbgeEntity?> ibges)
    {
        IList<IbgeDto> ibgeDtos = new List<IbgeDto>();
        if (ibges.Any())
        {
            foreach (IbgeEntity? ibge in ibges)
                ibgeDtos.Add(Mapper.ToIbge(ibge));
        }
        return ibgeDtos;
    }
}