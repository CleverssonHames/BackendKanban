using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KanBan.Domain.Models.Requests;
using KanBan.Domain.Models.Response.Quadro;

namespace Kanban.Application.Quadros
{
    public interface IQuadroService
    {
        AddQuadroResponse AddQuadro(AddQuadroRequest request);
    }
}
