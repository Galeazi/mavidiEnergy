using MAVIDI_SMILE.Domain.Entities;
using MAVIDI_SMILE.mavidiSmile.Application.DTOs;
using MAVIDI_SMILE.mavidiSmile.Application.Interfaces;
using MAVIDI_SMILE.mavidiSmile.Domain.Interfaces;
using System.Collections.Generic;
using MAVIDI_SMILE.mavidiSmile.Domain.Entities;

namespace MAVIDI_SMILE.Application.Services
{
    public class AmigosService : IAmigosService
    {
        private readonly IAmigosRepository _repository;

        public AmigosService(IAmigosRepository repository)
        {
            _repository = repository;
        }

        public Amigo? ObterPorId(int id)
        {
            return _repository.ObterAmizadePorId(id);
        }

        public IEnumerable<Amigo> ObterTodos()
        {
            return _repository.ObterAmizades();
        }

        public void Adicionar(Amigo amigo)
        {
            _repository.AdicionarAmigo(amigo);
        }

        public void Atualizar(Amigo amigo)
        {
            _repository.AtualizarAmizade(amigo.Id, amigo);
        }

        public void Remover(int id)
        {
            _repository.RemoverAmigo(id);
        }

        public IEnumerable<Amigo> ObterAmizadesPorUsuarioId(int usuarioId)
        {
            return _repository.ObterAmizadesPorUsuarioId(usuarioId);
        }

        public Amigo AdicionarAmigo(AmigosDTO amigoDto)
        {
            var amigo = new Amigo
            {
                UsuarioId = amigoDto.UsuarioId,
                AmigoId = amigoDto.AmigoId,
                Usuario = new Usuario { Id = amigoDto.UsuarioId },
                AmigoUsuario = new Usuario { Id = amigoDto.AmigoId }
            };
            _repository.AdicionarAmigo(amigo);
            return amigo;
        }

        public Amigo AtualizarAmizade(int id, AmigosDTO amigoDto)
        {
            var amigo = _repository.ObterAmizadePorId(id);
            if (amigo != null)
            {
                amigo.UsuarioId = amigoDto.UsuarioId;
                amigo.AmigoId = amigoDto.AmigoId;
                _repository.AtualizarAmizade(id, amigo);
            }
            return amigo;
        }
    }
}
