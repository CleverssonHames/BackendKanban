using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kanban.API.ExceptionsBase;
using KanBan.Domain.Models.Requests;
using KanBan.Domain.Models.Response.Quadro;
using Kanban.Infrastructure.Repositories.Quadros;
using Microsoft.EntityFrameworkCore.Query;

namespace Kanban.Application.Quadros
{
    public class QuadroService(IQuadroRepository _quadroRepository) : IQuadroService
    {
        public AddQuadroResponse AddQuadro(AddQuadroRequest request)
        {
            if (string.IsNullOrEmpty(request.Nome))
            {
                var erros = new List<string>();
                erros.Add("O nome não pode ser nulo para essa requisição");
                throw new ErrosNaValidacao(erros);
            }
            return new AddQuadroResponse(request.Nome);
        }
    }
}
