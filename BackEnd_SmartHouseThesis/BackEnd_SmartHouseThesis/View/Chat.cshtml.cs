using Application.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BackEnd_SmartHouseThesis.View
{
    public class ChatModel : PageModel
    {
        private readonly AccountService _accountService;
        public string UserId { get; set; }
        public void OnGet()
        {
            
        }
    }
}
