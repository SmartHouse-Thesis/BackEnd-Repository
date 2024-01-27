using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class ChatRepository : BaseRepo<Chat>
    {
        private readonly AppDbContext _appDbContext;
        public ChatRepository(AppDbContext dbContext) : base(dbContext)
        {
            _appDbContext = dbContext;
        }
        public async Task SaveChatLog(string chatMessage, string sender, string receiver)
        {
            // Save the chat log to the database
            var chatLog = new Chat
            {
                CreationDate = DateTime.Now,
                Logchat = $"{DateTime.Now} - {sender}: {chatMessage}"
            };

             _appDbContext.Chats.Add(chatLog);
            await _appDbContext.SaveChangesAsync();
        }
        public async Task<List<Chat>> GetChatLogs(Guid senderId, Guid receiverId)
        {
            List<Chat> chatLists = await _appDbContext.Chats.Where(c => (c.Customer.Id == senderId && c.Teller.Id == receiverId) || (c.Teller.Id == senderId && c.Customer.Id == receiverId)).OrderBy(c => c.CreationDate).ToListAsync();
            return chatLists;
        }
    }
}
