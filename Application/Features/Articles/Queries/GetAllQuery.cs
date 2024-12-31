using Domain.Entities;
using Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Articles.Queries;

public sealed record GetAllQuery(string? Parameter) : IRequest<List<Article>>;

internal sealed class GetAllQueryHandler(DatabaseContext context) : IRequestHandler<GetAllQuery, List<Article>>
{
	public async Task<List<Article>> Handle(GetAllQuery request, CancellationToken cancellationToken)
	{
		IQueryable<Article> response = context.Articles;

		if (request.Parameter is not null)
		{
			response = response.Where(a => a.Title.Contains(request.Parameter));
		}

		return await response.ToListAsync(cancellationToken);
	}
}
