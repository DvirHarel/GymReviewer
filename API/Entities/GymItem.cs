namespace WebApplication2
{
    public record GymItem
    {  
            public Guid Id { get; set; }
            public DateTimeOffset CreatedDate { get; set; }
            public string Name { get; set; }
            public string Category { get; set; }
        
    }
}
