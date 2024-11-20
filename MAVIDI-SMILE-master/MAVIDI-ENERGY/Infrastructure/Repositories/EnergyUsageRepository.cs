﻿using System.Collections.Generic;
using System.Linq;
using MAVIDI_ENERGY.Infrastructure.Data;
using MAVIDI_ENERGY.Domain.Entities;
using MAVIDI_ENERGY.Domain.Interfaces;

namespace MAVIDI_ENERGY.Infrastructure.Repositories
{
    public class EnergyUsageRepository : IEnergyUsageRepository
    {
        private readonly AppData _context;

        public EnergyUsageRepository(AppData context)
        {
            _context = context;
        }

        // Método para obter registro de consumo pelo ID
        public EnergyUsage? GetById(int id)
        {
            return _context.EnergyUsages.FirstOrDefault(e => e.Id == id);
        }

        // Método para obter todos os registros de consumo de um usuário específico
        public IEnumerable<EnergyUsage> GetByUserId(int userId)
        {
            return _context.EnergyUsages.Where(e => e.UserId == userId).ToList();
        }

        // Método para adicionar um novo registro de consumo
        public void Add(EnergyUsage energyUsage)
        {
            _context.EnergyUsages.Add(energyUsage);
            _context.SaveChanges();
        }

        // Método para atualizar um registro de consumo existente
        public void Update(EnergyUsage energyUsage)
        {
            var existingUsage = _context.EnergyUsages.FirstOrDefault(e => e.Id == energyUsage.Id);
            if (existingUsage != null)
            {
                existingUsage.MonthlyConsumption = energyUsage.MonthlyConsumption;
                existingUsage.Region = energyUsage.Region;
                existingUsage.EstimatedCost = energyUsage.EstimatedCost;
                existingUsage.CO2Emissions = energyUsage.CO2Emissions;
                existingUsage.UpdatedAt = energyUsage.UpdatedAt;

                _context.EnergyUsages.Update(existingUsage);
                _context.SaveChanges();
            }
        }

        // Método para deletar um registro de consumo
        public void Delete(int id)
        {
            var energyUsage = _context.EnergyUsages.FirstOrDefault(e => e.Id == id);
            if (energyUsage != null)
            {
                _context.EnergyUsages.Remove(energyUsage);
                _context.SaveChanges();
            }
        }
    }
}