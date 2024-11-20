using System.Collections.Generic;
using System.Linq;
using MAVIDI_ENERGY.Domain.Entities;
using MAVIDI_ENERGY.Infrastructure.Data;
using MAVIDI_ENERGY.Domain.Interfaces;

namespace MAVIDI_ENERGY.Infrastructure.Repositories
{
    public class SolarProviderRepository : ISolarProviderRepository
    {
        private readonly AppData _context;

        public SolarProviderRepository(AppData context)
        {
            _context = context;
        }

        // Método para obter fornecedor pelo ID
        public SolarProvider? ObterPorId(int id)
        {
            return _context.SolarProviders.FirstOrDefault(p => p.Id == id);
        }

        // Método para obter todos os fornecedores
        public IEnumerable<SolarProvider> ObterTodos()
        {
            return _context.SolarProviders.ToList();
        }

        // Método para obter fornecedores por região
        public IEnumerable<SolarProvider> ObterPorRegiao(string location)
        {
            return _context.SolarProviders.Where(p => p.Location.ToLower() == location.ToLower()).ToList();
        }

        // Método para adicionar um novo fornecedor
        public void Adicionar(SolarProvider provider)
        {
            _context.SolarProviders.Add(provider);
            _context.SaveChanges();
        }

        // Método para atualizar um fornecedor existente
        public void Atualizar(int id, SolarProvider providerAtualizado)
        {
            var providerExistente = _context.SolarProviders.FirstOrDefault(p => p.Id == id);
            if (providerExistente != null)
            {
                providerExistente.Name = providerAtualizado.Name;
                providerExistente.Location = providerAtualizado.Location;
                providerExistente.ContactInfo = providerAtualizado.ContactInfo;
                providerExistente.Rating = providerAtualizado.Rating;

                _context.SolarProviders.Update(providerExistente);
                _context.SaveChanges();
            }
        }

        // Método para remover um fornecedor
        public void Remover(int id)
        {
            var provider = _context.SolarProviders.FirstOrDefault(p => p.Id == id);
            if (provider != null)
            {
                _context.SolarProviders.Remove(provider);
                _context.SaveChanges();
            }
        }
    }
}
