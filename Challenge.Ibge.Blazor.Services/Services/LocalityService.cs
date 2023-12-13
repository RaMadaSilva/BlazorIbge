﻿using Challenge.Ibge.Blazor.Applications.Extensions;
using Challenge.Ibge.Blazor.Applications.Interfaces;
using Challenge.Ibge.Blazor.Domain.Interfaces;
using Challenge.Ibge.Blazor.Presentation.ViewModel;

namespace Challenge.Ibge.Blazor.Applications.Services
{
    public class LocalityService : ILocalityService
    {
        private readonly ILocalityRepository _repository;

        public LocalityService(ILocalityRepository repository)
            =>_repository = repository;

        public async Task<IEnumerable<LocalityViewModel>> GetAsync()
        {
           var result =  await _repository.GetAllAsync();

            return result.ToListViewModel(); 
        }

        public async Task SaveAsync(LocalityViewModel viewModel)
        {
            await _repository.CreateAsync(viewModel);
        }
    }
}
