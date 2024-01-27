using Application.Services;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Plugins;
using System;

namespace BackEnd_SmartHouseThesis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatController : ControllerBase
    {
        private readonly ChatService _chatService;
        public ChatController(ChatService chatService)
        {
            _chatService = chatService;
        }
        [HttpGet("GetChat/{senderId}/{receiverId}")]
        public async Task<IActionResult> GetChat(Guid senderId, Guid receiverId)
        {
            var chatList = await _chatService.GetChatLogs(senderId, receiverId);
            if (chatList == null)
            {
                return NotFound();
            }
            return Ok(chatList);
        }
    }
}
