using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using MultiTenantApi.Common.Services;
using MultiTenantApi.Contract.Services.Item;
using MultiTenantApi.Models.Item;

namespace MultiTenantApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly IItemService _itemService;
        private readonly IMapper _mapper;

        public ItemController(IItemService itemService, IMapper mapper)
        {
            _itemService = itemService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Create(ItemModel itemModel)
        {
            var itemDto = _mapper.Map<ItemDto>(itemModel);
            var createdItemDto = await _itemService.CreateAsync(itemDto);

            if (createdItemDto != null)
            {
                var createdItemModel = _mapper.Map<ItemModel>(createdItemDto);
                return Created($"/item/{createdItemDto.Id}", createdItemModel);
            }

            return StatusCode(StatusCodes.Status500InternalServerError);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Read(Guid id)
        {
            var itemDto = await _itemService.GetAsync(id);
            return itemDto != null
                ? Ok(_mapper.Map<ItemModel>(itemDto))
                : NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> ReadAll()
        {
            var itemsDto = await _itemService.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<ItemDto>>(itemsDto));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, ItemModel itemModel)
        {
            itemModel.Id = id;
            var itemDto = _mapper.Map<ItemDto>(itemModel);

            var result = await _itemService.UpdateAsync(itemDto);

            return result
                ? Ok()
                : StatusCode(StatusCodes.Status500InternalServerError);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _itemService.DeleteAsync(id);
            return result
                ? Ok()
                : StatusCode(StatusCodes.Status500InternalServerError);
        }
    }
}
