using System.Threading.Tasks;
using IdentityChatMail.Context;
using IdentityChatMail.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IdentityChatMail.Controllers
{
    public class MessageController : Controller
    {
        private readonly MailContext _context;
        private readonly UserManager<AppUser> _userManager;

        public MessageController(MailContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public async Task<IActionResult> Profile()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);//giris yapan kullanicinin kulllanici adini aldik burada
            ViewBag.v1 = values.Name +" "+values.Surname;
            ViewBag.v1 = values.Email;
            return View();    
        }

        public async Task<IActionResult> Inbox()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            var messagelist=_context.Messages.Where(x=>x.ReceiverEmail == values.Email).ToList();
            return View(messagelist);
        }
        public async Task<IActionResult> Sendbox()
        {
            var values=await _userManager.FindByNameAsync(User.Identity.Name);
            string email = values.Email;
            var sendMessageList=_context.Messages.Where(x=>x.SenderEmail == email).ToList();
            return View(sendMessageList);
        }
        [HttpGet]
        public IActionResult CreateMessage()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateMessage(Message message)
        {
            message.SendDate = DateTime.Now;
            message.IsRead = false;
            _context.Messages.Add(message);
            _context.SaveChanges();
            return RedirectToAction("Sendbox");
        }
    }
}
