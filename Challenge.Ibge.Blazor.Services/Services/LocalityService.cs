﻿using Challenge.Ibge.Blazor.Applications.Extensions;
using Challenge.Ibge.Blazor.Applications.Interfaces;
using Challenge.Ibge.Blazor.Domain.Interfaces;
using Challenge.Ibge.Blazor.Presentation.ViewModel;

namespace Challenge.Ibge.Blazor.Applications.Services
{
    public class LocalityService : ILocalityService
    {
        private readonly ILocalityRepository _repository;
        private readonly ILocalityRemovedRepository _removedRepository;

        public LocalityService(ILocalityRepository repository, ILocalityRemovedRepository removedRepository)
            =>(_repository, _removedRepository) = (repository, removedRepository);

        public async Task<IEnumerable<LocalityViewModel>> GetAsync()
        {
           var result =  await _repository.GetAllAsync();

            return result.ToListViewModel(); 
        }
        public async Task<LocalityViewModel> GetbyId(long id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task SaveAsync(LocalityViewModel viewModel)
        {
            await _repository.CreateAsync(viewModel);
        }

        public async Task RemoveAsync(long id)
        {
            var locality = await _repository.GetByIdAsync(id);

            if (locality is null)
                throw new Exception("Não existe essa localidade");

           var isSucess=  await _removedRepository
                                .CreateAsync(new(locality.Id, locality.City, locality.State, locality.DateCreate));
            if (!isSucess)
                throw new Exception("Não é possivel Remover essa Localidade!");

           await _repository.RemoveAsync(locality);
        }
    }
}
