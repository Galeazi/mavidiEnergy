using System.Collections.Generic;
using System.Linq;
using MAVIDI_ENERGY.Application.DTOs;
using MAVIDI_ENERGY.Domain.Entities;
using MAVIDI_ENERGY.Domain.Interfaces;
using MAVIDI_ENERGY.Interfaces;

namespace MAVIDI_ENERGY.Application.Services
{
    public class ProviderService : ISolarProviderService
    {
        private readonly ISolarProviderRepository _repository;

        public ProviderService(ISolarProviderRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<SolarProviderDTO> ObterTodosFornecedores()
        {
            return _repository.ObterTodos().Select(provider => new SolarProviderDTO
            {
                Name = provider.Name,
                Location = provider.Location,
                ContactInfo = provider.ContactInfo,
                Rating = provider.Rating
            });
        }

        public IEnumerable<SolarProviderDTO> ObterFornecedoresPorLocalizacao(string location)
        {
            return _repository.ObterPorRegiao(location).Select(provider => new SolarProviderDTO
            {
                Name = provider.Name,
                Location = provider.Location,
                ContactInfo = provider.ContactInfo,
                Rating = provider.Rating
            });
        }

        public SolarProviderDTO AdicionarFornecedor(SolarProviderDTO providerDto)
        {
            var provider = new SolarProvider
            {
                Name = providerDto.Name,
                Location = providerDto.Location,
                ContactInfo = providerDto.ContactInfo,
                Rating = providerDto.Rating
            };

            _repository.Adicionar(provider);

            return new SolarProviderDTO
            {
                Name = provider.Name,
                Location = provider.Location,
                ContactInfo = provider.ContactInfo,
                Rating = provider.Rating
            };
        }

        public SolarProviderDTO AtualizarFornecedor(int id, SolarProviderDTO providerDto)
        {
            var provider = _repository.ObterPorId(id);
            if (provider != null)
            {
                provider.Name = providerDto.Name;
                provider.Location = providerDto.Location;
                provider.ContactInfo = providerDto.ContactInfo;
                provider.Rating = providerDto.Rating;

                _repository.Atualizar(id, provider);

                return new SolarProviderDTO
                {
                    Name = provider.Name,
                    Location = provider.Location,
                    ContactInfo = provider.ContactInfo,
                    Rating = provider.Rating
                };
            }

            return null;
        }

        public void RemoverFornecedor(int id)
        {
            _repository.Remover(id);
        }
    }
}
