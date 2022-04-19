using GymReviewer.API.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.API.Entities;

namespace WebApplication2.API
{
    [ApiController]
    [Route("gymItems")]
    public class GymItemsController: ControllerBase
    {
        private readonly GymItemsRepository repository;
        private readonly ILogger<GymItemsController> logger;

        public GymItemsController(GymItemsRepository repository, ILogger<GymItemsController> logger)
        {
            this.repository = repository;
            this.logger = logger;
        }


        // GET /gymItems
        [HttpGet]
        public IEnumerable<GymItemDto> GetItems()
        {
            var items =  repository.GetItems().Select(item => item.AsDto());
            return items;
        }



        // GET /gymItems/{id}
        [HttpGet("{id}")]
        public  ActionResult<GymItemDto> GetItem(Guid id)
        {
            var item = repository.GetItem(id);

            if (item is null)
            {
                return NotFound();
            }

            return item.AsDto();
        }



        // POST /gymItems
        [HttpPost]
        public ActionResult<GymItemDto> CreateItemAsync(CreateGymItemDto itemDto)
        {
            GymItem gymItem = new()
            {
                Id = Guid.NewGuid(),
                CreatedDate = DateTimeOffset.UtcNow,
                Name = itemDto.Name,
                Category = itemDto.Category,
            };
            //Sending the order to create this GymItem
             repository.CreateItem(gymItem);
            //Checking if the item was created
            return CreatedAtAction(nameof(GetItem), new { id = gymItem.Id }, gymItem.AsDto());
        }

        // PUT /gymItems/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateItem(Guid id, UpdateGymItemDto itemDto)
        {
            var existingItem =  repository.GetItem(id);

            if (existingItem is null)
            {
                return NotFound();
            }

            existingItem.Name = itemDto.Name;
            existingItem.Category = itemDto.Category;

            repository.UpdateItem(existingItem);

            return NoContent();
        }

        // DELETE /gymItems/{id}
        [HttpDelete("id")]
        public ActionResult DeleteItem(Guid id)
        {
            var existingItem =  repository.GetItem(id);

            if (existingItem is null)
            {
                return NotFound();
            }

             repository.DeleteItem(id);

            return NoContent();
        }
    }
}
