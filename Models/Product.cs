using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;
public class Product
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? Detail { get; set; }
    public decimal Price { get; set; }
    public string? ImageUrl { get; set; }

    [NotMapped]
    public IFormFile? ImageFile { get; set; }
}