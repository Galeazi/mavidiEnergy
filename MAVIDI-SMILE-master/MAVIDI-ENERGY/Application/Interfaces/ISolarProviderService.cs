using System.Collections.Generic;
using MAVIDI_ENERGY.Application.DTOs;

namespace MAVIDI_ENERGY.Interfaces
{
    public interface ISolarProviderService
    {
        IEnumerable<SolarProviderDTO> ObterTodosFornecedores();
        IEnumerable<SolarProviderDTO> ObterFornecedoresPorLocalizacao(string location);
        SolarProviderDTO AdicionarFornecedor(SolarProviderDTO providerDto);
        SolarProviderDTO AtualizarFornecedor(int id, SolarProviderDTO providerDto);
        void RemoverFornecedor(int id);
    }
}