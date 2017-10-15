using System;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace GetUpdatesBot.Services
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
            client.OnMessage += BotOnMessageReceived;
            client.OnMessageEdited += BotOnMessageReceived;
        }

        public static BotService Instance
        {
            get
            {
                return instanceHolder.Value;
            }
        }

        /// <summary>Установка связи между ботом и Telegram</summary>
        public void Connect()
        {
            client.SetWebhookAsync(); // Отключение webhook
            client.StartReceiving();
        }

        /// <summary>Отключение связи между ботом и Telegram</summary>
        /// <remarks>Вызывает ReceiveAsync который дергает GetUpdatesAsync</remarks>
        public void Disconnect()
        {
            client.StopReceiving();
        }

        /// <summary>Обработка сообщений от пользователя</summary>
        private void BotOnMessageReceived(object sender, MessageEventArgs messageEventArgs)
        {
            var message = messageEventArgs.Message;
            Process(message);
        }

        public async void Process(Message message)
        {
            if (message == null) return;
            if (message.Type == MessageType.TextMessage)
            {
                await client.SendTextMessageAsync(message.Chat.Id, message.Text);
            }
        }
    }
}