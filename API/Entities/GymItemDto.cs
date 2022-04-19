namespace WebApplication2.API.Entities
{
    public record GymItemDto
    {
        public Guid Id { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
    }
}
