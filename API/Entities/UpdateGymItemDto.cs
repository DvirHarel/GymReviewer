using System.ComponentModel.DataAnnotations;

namespace WebApplication2.API.Entities
{
    public record UpdateGymItemDto
    {
        public Guid Id { get; set; }
        public DateTimeOffset CreatedDate { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Category { get; set; }
    }
}
