using Application.Services;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackEnd_SmartHouseThesis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PromotionController : ControllerBase
    {
        private readonly PromotionService _promotionServices;

        public PromotionController(PromotionService promotionService)
        {
            _promotionServices = promotionService;
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
        [HttpPost("CreatePromotion")]
        public async Task<IActionResult> CreatePromotion([FromBody] Promotion promotion)
        {
            var promo = await _promotionServices.GetPromotion(promotion.Id);
            if(promo != null)
            {
                return BadRequest("Promotion is exist!!");
            } else
            {
                await _promotionServices.CreatePromotion(promo);
                return Ok();
            }            
        }


        // PUT api/<PromotionController>/UpdateDevice/5
        [HttpPut("UpdateDevice/{id}")]
        public async Task<IActionResult> UpdatePromotion(Guid id, [FromBody] Promotion promotion)
        {
            var promo = await _promotionServices.GetPromotion(id);
            if (promo != null)
            {
                await _promotionServices.UpdatePromotion(promotion);
                return Ok(promo); 
            }
            else
            {
                return BadRequest("Promotion can't do it right now!! ");
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
