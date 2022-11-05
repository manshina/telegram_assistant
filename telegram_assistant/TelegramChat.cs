using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Extensions.Polling;
using Telegram.Bot.Types;

namespace telegram_assistant
{
    internal class TelegramChat : IChat
    {
        static ITelegramBotClient bot = new TelegramBotClient("Token");

        public event IChat.EventDelegate NewChatMessageRecived = delegate { };

        public async void ChatMessageSent(string answer, Message message)
        {
            await bot.SendTextMessageAsync(message.Chat, answer);
        }
        public async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            
            Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(update));
            if (update.Type == Telegram.Bot.Types.Enums.UpdateType.Message && update.Message?.Text != null)
            {
                await Task.Run(() => NewChatMessageRecived(update.Message));
            }
        }

        public async Task HandleErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
        {
            
            Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(exception));
        }
        public void Start()
        {
            Console.WriteLine("Запущен бот " + bot.GetMeAsync().Result.FirstName);

            var cts = new CancellationTokenSource();
            var cancellationToken = cts.Token;
            var receiverOptions = new ReceiverOptions
            {
                AllowedUpdates = { }, // receive all update types
            };
            bot.StartReceiving(
                HandleUpdateAsync,
                HandleErrorAsync,
                receiverOptions,
                cancellationToken
            );
            Console.ReadLine();
        }

        public void Stop()
        {
            throw new NotImplementedException();
        }
    }
}
