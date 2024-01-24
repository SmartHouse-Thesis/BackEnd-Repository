using Application.Services;
using AutoMapper;
using Domain.DTOs.Request;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Security.Principal;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackEnd_SmartHouseThesis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PromotionController : ControllerBase
    {
        private readonly PromotionService _promotionServices;
        private readonly OwnerService _ownerService;
        private readonly IMapper _mapper;
        public PromotionController(PromotionService promotionService,OwnerService ownerService, IMapper mapper)
        {
            _promotionServices = promotionService;
            _ownerService = ownerService;
            _mapper = mapper;
        }

        // GET: api/<PromotionController>/GetAllPromotion
        [HttpGet("GetAllPromotion")]
        public async Task<IActionResult> GetAllPromotion()
        {
            var promotions = await _promotionServices.GetAll();
            return Ok(promotions);
        }

        // GET api/<DevicesController>/GetPromotion/5
        [HttpGet("GetPromotion/{id}")]
        public async Task<IActionResult> GetPromotion(Guid id)
        {
            var promo = await _promotionServices.GetPromotion(id);
            if (promo == null)
            {
                return NotFound();
            }
            return Ok(promo);
        }

        // POST api/<PromotionController>/CreateDevice/
        [HttpPost("CreatePromotion/{ownerId}")]
        public async Task<IActionResult> CreatePromotion(Guid ownerId,[FromBody] PromotionRequest promotion)
        {
            var owner = await _ownerService.GetOwner(ownerId);
            if(owner != null)
            {
                var _promotion = _mapper.Map<Promotion>(promotion);
                _promotion.CreationDate = DateTime.Now;
                _promotion.CreatedBy= owner.Id;
                await _promotionServices.CreatePromotion(_promotion);
                return Ok(_promotion);
            }
            else
            {
                return BadRequest("Owner is not exist!! ");
            }                   
        }


        // PUT api/<PromotionController>/UpdateDevice/5
        [HttpPut("UpdateDevice/{id}")]
        public async Task<IActionResult> UpdatePromotion(Guid id, Guid ownerId, [FromBody] PromotionRequest promotion)
        {

            var owner = await _ownerService.GetOwner(ownerId);
            if (owner != null)
            {
                var _promo = _promotionServices.GetPromotion(id);
                if(_promo!= null)
                {
                    var _promotion = _mapper.Map<Promotion>(promotion);
                    _promotion.ModificationDate = DateTime.Now;
                    _promotion.ModificationBy = ownerId;
                    await _promotionServices.UpdatePromotion(_promotion);
                    return Ok(_promotion);
                }else
                {
                    return BadRequest("Promotion is not exist!! ");
                }                
            }
            else
            {
                return BadRequest("Owner is not exist!! ");
            }
        }

        // DELETE api/<PromotionController>/Delete/5
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var promo = await _promotionServices.GetPromotion(id);
            if (promo != null)
            {
                await _promotionServices.DeletePromotion(promo);
                return Ok(promo);
            }
            else
            {
                return BadRequest("Promotion can't do it right now!! ");
            }
        }
    }
}
