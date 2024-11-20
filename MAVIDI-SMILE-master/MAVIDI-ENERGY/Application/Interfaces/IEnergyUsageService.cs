using MAVIDI_ENERGY.Application.DTOs;
using MAVIDI_ENERGY.Domain.Entities;
using System.Collections.Generic;

namespace MAVIDI_ENERGY.Interfaces
{
    public interface IEnergyUsageService
    {
        IEnumerable<EnergyUsage> ObterRegistrosPorUsuarioId(int userId);
        EnergyUsage SalvarRegistro(EnergyUsageDTO energyUsageDto);
        EnergyUsage AtualizarRegistro(int id, EnergyUsageDTO energyUsageDto);
        void DeletarRegistro(int id);
    }
}