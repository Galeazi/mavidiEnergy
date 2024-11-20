using MAVIDI_ENERGY.Domain.Entities;
using System.Collections.Generic;

namespace MAVIDI_ENERGY.Domain.Interfaces
{
    public interface IEnergyUsageRepository
    {
        EnergyUsage? GetById(int id);
        IEnumerable<EnergyUsage> GetByUserId(int userId);
        void Add(EnergyUsage energyUsage);
        void Update(EnergyUsage energyUsage);
        void Delete(int id);
    }
}