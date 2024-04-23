using System;
using System.Threading;
using Telegram.Bot;
using Telegram.Bot.Extensions.Polling;
using System.Configuration;
using DJSejong;

namespace TelegramBotExperiments
{
    class Program
    {
        static void Main(string[] args)
        {
            string botToken = ConfigurationManager.AppSettings["TelegramToken"];
            ITelegramBotClient bot = new TelegramBotClient(botToken);

            Console.WriteLine($"Запущен бот {bot.GetMeAsync().Result.FirstName}");

            var cts = new CancellationTokenSource();
            var cancellationToken = cts.Token;

            var receiverOptions = new ReceiverOptions
            {
                AllowedUpdates = { }, // receive all update types
            };

            bot.StartReceiving(
                DJSejongServiceProvider.HandleUpdateAsync,
                DJSejongServiceProvider.HandleErrorAsync,
                receiverOptions,
                cancellationToken
            );

            Console.ReadLine();
        }
    }
}