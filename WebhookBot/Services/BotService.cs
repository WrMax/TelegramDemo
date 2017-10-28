using System;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace WebApplication1.Services
{
    public sealed class BotService
    {
        private static readonly Lazy<BotService> instanceHolder =
            new Lazy<BotService>(() => new BotService());
        
        private readonly TelegramBotClient client;

        private BotService()
        {
            const string token = "457238275:AAGwAgHUq0i6PwRn2mAYufYp1yHNeJqv4RA";
            client = new TelegramBotClient(token);
            //Connect("Сервер_на_которой_работает_сервис");
        }

        public static BotService Instance
        {
            get
            {
                return instanceHolder.Value;
            }
        }

        /// <summary>Установка связи между ботом и Telegram</summary>
        public void Connect(string hostname)
        {
            client.SetWebhookAsync(string.Concat("https://", hostname, "/bot")).Wait();
        }

        /// <summary>Отключение связи между ботом и Telegram</summary>
        public void Disconnect()
        {
            client.SetWebhookAsync().Wait();
        }

        public async void Process(Message message)
        {
            if (message?.Type == MessageType.TextMessage)
            {
                await client.SendTextMessageAsync(message.Chat.Id, message.Text);
            }
        }
    }
}