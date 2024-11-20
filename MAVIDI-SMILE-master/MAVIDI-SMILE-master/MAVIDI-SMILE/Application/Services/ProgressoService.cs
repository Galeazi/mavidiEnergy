using System.Collections.Generic;
using MAVIDI_SMILE.mavidiSmile.Application.DTOs;
using MAVIDI_SMILE.mavidiSmile.Domain.Entities;
using MAVIDI_SMILE.mavidiSmile.Domain.Interfaces;
using MAVIDI_SMILE.mavidiSmile.Interfaces;

namespace MAVIDI_SMILE.mavidiSmile.Application.Services
{
    public class ProgressoService : IProgressoService
    {
        private readonly IProgressoRepository _repository;

        public ProgressoService(IProgressoRepository repository)
        {
            _repository = repository;
        }

        public Progresso? ObterProgressoPorId(int id)
        {
            return _repository.ObterProgressoPorId(id);
        }

        public IEnumerable<Progresso> ObterProgressoPorUsuarioId(int usuarioId)
        {
            return _repository.ObterProgressoPorUsuarioId(usuarioId);
        }

        public Progresso SalvarProgresso(RegistroProgressoDTO progressoDto)
        {
            var progresso = new Progresso
            {
                UsuarioId = progressoDto.UsuarioId,
                Atividade = progressoDto.Atividade,
                Data = progressoDto.Data
            };
            _repository.AdicionarProgresso(progresso);
            return progresso;
        }

        public Progresso AtualizarProgresso(int id, RegistroProgressoDTO progressoDto)
        {
            var progresso = _repository.ObterProgressoPorId(id);
            if (progresso != null)
            {
                progresso.Atividade = progressoDto.Atividade;
                progresso.Data = progressoDto.Data;
                _repository.AtualizarProgresso(id, progresso);
            }
            return progresso;
        }

        public void DeletarProgresso(int id)
        {
            _repository.DeletarProgresso(id);
        }
    }
}