using System.Collections.Generic;
using MAVIDI_ENERGY.Domain.Entities;

namespace MAVIDI_ENERGY.Domain.Interfaces
{
    public interface ISolarProviderRepository
    {
        IEnumerable<SolarProvider> ObterTodos();
        IEnumerable<SolarProvider> ObterPorRegiao(string regiao);
        SolarProvider ObterPorId(int id);
        void Adicionar(SolarProvider provider);
        void Atualizar(int id, SolarProvider provider);
        void Remover(int id);
    }
}