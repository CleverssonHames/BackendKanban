using Kanban.Infrastructure.Data;
using KanBan.Domain.Models;
using KanBan.Domain.Models.DTOs;
using KanBan.Domain.Models.Requests;
using Microsoft.EntityFrameworkCore;

namespace KanbanApi.Quadros;

public static class QuadrosRotas
{
    public static void AddRotasQuadros(this WebApplication app)
    {
        var rotasQuadros = app.MapGroup("quadros");
        
        //app.MapGet("quadros", () => new Quadro("Backlog"));
        rotasQuadros.MapGet("", async (AppDbContext context) =>
        {
            var quadros = await context
                .Quadros
                .Select(q => new QuadroDto(q.Id, q.Nome))
                .ToListAsync();
            return quadros;
        });

        rotasQuadros.MapPost("", async (AddQuadroRequest request, AppDbContext context, CancellationToken ct) =>
        {
            var jaExiste = await context.Quadros.AnyAsync(q => q.Nome == request.Nome);
            if (jaExiste)
                return Results.Conflict("Esse nome de quadro já existe!");
            var novoQuadro = new Quadro(request.Nome);
            await context.Quadros.AddAsync(novoQuadro, ct);
            await context.SaveChangesAsync(ct);
            var quadroRetorno = new QuadroDto(novoQuadro.Id, novoQuadro.Nome);
            return Results.Ok(novoQuadro);
        });

        rotasQuadros.MapDelete("{id}", async (Guid id,AppDbContext context) =>
        {
            var quadro = await context.Quadros.FirstOrDefaultAsync(q => q.Id == id);
            if (quadro == null)
            {
                return Results.NotFound();
            }
            context.Quadros.Remove(quadro);
            await context.SaveChangesAsync();
            return Results.Ok();
        });

        rotasQuadros.MapPut("{id}", async (Guid id, UpdateQuadroRequest request, AppDbContext context) =>
        {
            var quadro = await context.Quadros.FirstOrDefaultAsync(q => q.Id == id);

            if (string.IsNullOrEmpty(quadro.Nome))
            {
                return Results.NotFound();
            }
            quadro.AtualizarNome(request.Nome);
            await context.SaveChangesAsync();
            return Results.Ok(quadro);
        });
    }
}