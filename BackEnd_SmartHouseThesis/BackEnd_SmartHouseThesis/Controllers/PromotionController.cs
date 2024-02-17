using Application.Services;
using AutoMapper;
using Domain.DTOs.Request.Post;
using Domain.DTOs.Request.Put;
using Domain.DTOs.Response;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
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

        [Authorize(Roles = "Owner, Customer, Teller, Staff")]
        // GET: api/<PromotionController>/GetAllPromotion
        [HttpGet("get-all-promotions")]
        [ProducesResponseType(typeof(PromotionResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(AuthenResponse), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(AuthenResponse), StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> GetAllPromotion()
        {
            try
            {
                var promotions = await _promotionServices.GetAll();
                var listpromo = new List<PromotionResponse>();
                foreach (var promotion in promotions)
                {
                    var promo = _mapper.Map<PromotionResponse>(promotion);
                    listpromo.Add(promo);
                }
                return Ok(listpromo);
            } catch (Exception ex)
            {
                return StatusCode(500, new AuthenResponse { Message = "lỗi get-all-promotions controller !! " });
            }
            
        }
        [Authorize(Roles = "Owner, Customer, Teller, Staff")]
        // GET api/<DevicesController>/GetPromotion/5
        [HttpGet("get-promotion/{id}")]
        [ProducesResponseType(typeof(PromotionResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(AuthenResponse), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(AuthenResponse), StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> GetPromotion(Guid id)
        {
            try
            {
                var promo = await _promotionServices.GetPromotion(id);
                if (promo == null)
                {
                    return NotFound("khuyến mãi không tồn tại");
                }
                var _promo = _mapper.Map<PromotionResponse>(promo);
                return Ok(_promo);
            } catch (Exception ex)
            {
                return StatusCode(500, new AuthenResponse { Message = "lỗi get-promotion controller !! " });
            }
            
        }

        [Authorize(Roles = "Owner")]
        // POST api/<PromotionController>/CreateDevice/
        [HttpPost("create-promotion/{ownerId}")]
        public async Task<IActionResult> CreatePromotion(Guid ownerId,[FromBody] PromotionRequest promotion)
        {
            try
            {
                var owner = await _ownerService.GetOwner(ownerId);
                if (owner != null)
                {
                    var _promotion = _mapper.Map<Promotion>(promotion);
                    _promotion.CreationDate = DateTime.Now;
                    _promotion.CreatedBy = owner.Id;
                    await _promotionServices.CreatePromotion(_promotion);
                    return Ok(_promotion);
                }
                else
                {
                    return BadRequest("Tài Khoản không phải Owner");
                }
            } catch (Exception ex)
            {
                return StatusCode(500, new AuthenResponse { Message = "lỗi get-promotion controller !! " });
            }                       
        }

        [Authorize(Roles = "Owner")]
        // PUT api/<PromotionController>/UpdateDevice/5
        [HttpPut("update-promotion/{id}")]
        public async Task<IActionResult> UpdatePromotion(Guid ownerId, [FromBody] PromotionUpdate promotion)
        {

            var owner = await _ownerService.GetOwner(ownerId);
            if (owner != null)
            {
                
                var _promo = _promotionServices.GetPromotion(promotion.Id);
                if(_promo!= null)
                {
                    var _promotion = _mapper.Map<Promotion>(promotion);
                    _promotion.ModificationDate = DateTime.Now;
                    _promotion.ModificationBy = ownerId;
                    await _promotionServices.UpdatePromotion(_promotion);
                    return Ok(_promotion);
                }else
                {
                    return NotFound("khuyến mãi không tồn tại!! ");
                }                
            }
            else
            {
                return BadRequest("Tài khoản không phải Owner");
            }
        }
        [Authorize(Roles = "Owner")]
        // DELETE api/<PromotionController>/Delete/5
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var promo = await _promotionServices.GetPromotion(id);
            if (promo != null)
            {
                promo.IsDelete = false;
                await _promotionServices.UpdatePromotion(promo);
                return Ok(promo);
            }
            else
            {
                return NotFound("khuyến mãi không tồn tại!! ");
            }
        }
    }
}
