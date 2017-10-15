using Microsoft.AspNetCore.Mvc;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [Route("bot")]
	public class BotController : Controller
    {
        // GET bot/ping
        [HttpGet]
        public string Ping()
        {
            return "Бот работает.";
        }

        /// <summary>Метод нужен только для тестирования через Ngrok</summary>
        // GET bot/Ngrok/hostname
        [HttpGet("Ngrok/{hostname}")]
        public RedirectResult Ngrok(string hostname)
        {
            BotService.Instance.Connect(hostname);
            return Redirect(string.Concat("https://", hostname, "/bot"));
        }

        // POST bot/update
        [HttpPost]
		public void Post([FromBody]Update update)
        {
            BotService.Instance.Process(update);
        }
	}
}
