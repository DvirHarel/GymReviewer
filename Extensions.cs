using WebApplication2.API.Entities;

namespace WebApplication2
{
    public static class Extensions
    {
        public static GymItemDto AsDto(this GymItem item)
        {
            return new GymItemDto
            {
                Id = item.Id,
                CreatedDate = item.CreatedDate,
                Name = item.Name,
                Category = item.Category,

            };
        }
    }
}