namespace Domain.Entities;

public class Article
{
	public int Id { get; set; }
	public required string Title { get; set; }
	public int? CategoryId { get; set; }
	public int? AuthorId { get; set; }
	public Category? Category { get; set; }
	public Author? Author { get; set; }
}
