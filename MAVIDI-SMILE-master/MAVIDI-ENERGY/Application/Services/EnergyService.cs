using System;
using System.Collections.Generic;
using MAVIDI_ENERGY.Application.DTOs;
using MAVIDI_ENERGY.Domain.Entities;
using MAVIDI_ENERGY.Interfaces;
using MAVIDI_ENERGY.Domain.Interfaces;

namespace MAVIDI_ENERGY.Application.Services
{
    public class EnergyService : IEnergyUsageService
    {
        private readonly IEnergyUsageRepository _repository;

        public EnergyService(IEnergyUsageRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<EnergyUsage> ObterRegistrosPorUsuarioId(int userId)
        {
            return _repository.GetByUserId(userId);
        }

        public EnergyUsage SalvarRegistro(EnergyUsageDTO energyUsageDto)
        {
            var energyUsage = new EnergyUsage
            {
                UserId = energyUsageDto.UserId,
                MonthlyConsumption = energyUsageDto.MonthlyConsumption,
                Region = energyUsageDto.Region,
                EstimatedCost = CalculateEstimatedCost(energyUsageDto.MonthlyConsumption, energyUsageDto.Region),
                CO2Emissions = CalculateCO2Emissions(energyUsageDto.MonthlyConsumption),
                CreatedAt = DateTime.UtcNow
            };
            _repository.Add(energyUsage);
            return energyUsage;
        }

        public EnergyUsage AtualizarRegistro(int id, EnergyUsageDTO energyUsageDto)
        {
            var energyUsage = _repository.GetById(id);
            if (energyUsage != null)
            {
                energyUsage.MonthlyConsumption = energyUsageDto.MonthlyConsumption;
                energyUsage.Region = energyUsageDto.Region;
                energyUsage.EstimatedCost = CalculateEstimatedCost(energyUsageDto.MonthlyConsumption, energyUsageDto.Region);
                energyUsage.CO2Emissions = CalculateCO2Emissions(energyUsageDto.MonthlyConsumption);
                energyUsage.UpdatedAt = DateTime.UtcNow;
                _repository.Update(energyUsage);
            }
            return energyUsage;
        }

        public void DeletarRegistro(int id)
        {
            _repository.Delete(id);
        }

        private decimal CalculateEstimatedCost(decimal monthlyConsumption, string region)
        {
            // Simulação simples de cálculo de custo baseado em tarifas regionais
            decimal tariff = region.ToLower() switch
            {
                "norte" => 0.75m,
                "sul" => 0.65m,
                "leste" => 0.70m,
                "oeste" => 0.80m,
                _ => 0.68m // Default
            };

            return monthlyConsumption * tariff;
        }

        private decimal CalculateCO2Emissions(decimal monthlyConsumption)
        {
            // Simulação de emissões de CO2 (kWh * fator de emissão padrão)
            const decimal emissionFactor = 0.233m; // Exemplo: 0.233 kg CO2/kWh
            return monthlyConsumption * emissionFactor;
        }
    }
}
