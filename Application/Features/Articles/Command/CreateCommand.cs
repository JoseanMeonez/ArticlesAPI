using Domain.Entities;
using Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Articles.Command;

public sealed record CreateCommand(
	string Title,
	Category? Category,
	Author? Author) : IRequest<Article>;

internal sealed class CreateCommandHandler(DatabaseContext context) : IRequestHandler<CreateCommand, Article>
{
	public async Task<Article> Handle(CreateCommand request, CancellationToken cancellationToken)
	{
		if (await context.Articles.FirstOrDefaultAsync(a => a.Title.Equals(request.Title)) is not null)
		{
			throw new Exception("El artículo ya existe.");
		}

		if (string.IsNullOrEmpty(request.Title))
		{
			throw new Exception("El titulo es requerido.");
		}

		Article article = new Article
		{
			Title = request.Title,
			Author = request.Author,
			Category = request.Category,
		};

		await context.Articles.AddAsync(article, cancellationToken);
		await context.SaveChangesAsync(cancellationToken);

		return article;
	}
}
