using System;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Extensions.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;
using System.Collections.Generic;
using System.Configuration;
using DJSejong.Models;
using DJSejong.Models.Constants;
using System.IO;

namespace TelegramBotExperiments
{
    class Program
    {
        public static async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(update));
            try 
            {
                if (update.Type == Telegram.Bot.Types.Enums.UpdateType.Message)
                {
                    var message = update.Message;

                    switch (message.Text)//TODO: REFACTOR! Extract common functionality
                    {
                        case "/start":
                            {         
                                await botClient.SendTextMessageAsync(message.Chat.Id, "Welcome To DJ Sejong BOT!\nPlease choose your level...", replyMarkup: KeyboardMarkups.keyboardsDictionary[0]);
                                
                                break;
                            } 
                        case "⬅️Back To Main Menu":
                            {
                                await botClient.SendTextMessageAsync(message.Chat.Id, "Please choose your level...", replyMarkup: KeyboardMarkups.keyboardsDictionary[0]);
                                
                                break;
                            }
                        default: break;
                    }

                    //1📗 2📙 3📘 4📔 5📓 6📕 7📒 8📖

                    var firstTwoChars = message.Text?[..2];
                    var secondTwoChars = message.Text.Substring(2, 2).Trim();

                    switch (firstTwoChars)
                    {
                        case "📙"://세종한국어 2
                        case "📔"://세종한국어 4
                        case "📓"://세종한국어 5
                        case "📕"://세종한국어 6
                        case "📒"://세종한국어 7
                        case "📖"://세종한국어 8
                            {
                                int numberOfChapter = Convert.ToInt32(secondTwoChars);

                                int defaultNumberOfFiles = 5;
                                int finalNumber = numberOfChapter * defaultNumberOfFiles; //Total number of files up to next chapter
                                int startNumber = finalNumber - (defaultNumberOfFiles - 1); //Each chapter has 5 audio files, so first file of every chapter is total number of files until next chapter minus 4 remainder files

                                for (int soundNumber = startNumber; soundNumber <= finalNumber; soundNumber++)
                                {
                                    string soundAddress = HTMLAddresses.baseAddress + BooksDictionaries.booksDictionary[firstTwoChars] + soundNumber + HTMLAddresses.addressMP3FormatEnding;
                                    await SendAudioSR(botClient, message, soundAddress);
                                }

                                break; 
                            }
                    }

                    if (firstTwoChars == "📗")//세종한국어 1
                    {
                        int num = Convert.ToInt32(secondTwoChars);

                        if (num == 0)
                        {
                            await SendAudio(botClient, message, HTMLAddresses.bookOneAddress, 1, 19);
                        }
                        else if (num > 0 && num < 11)
                        {                            
                            await SendAudio(botClient, message, HTMLAddresses.bookOneAddress, 20 + 5 * (num - 1), (20 + 5 * (num - 1)) + 4);
                        }
                        else
                        {
                            await SendAudio(botClient, message, HTMLAddresses.bookOneAddress, 70 + 2 * (num - 10) - 2, 70 + 2 * (num - 10) - 1);
                        }
                    }
                    //else if (firstTwoChars == "📙")//세종한국어 2
                    //{
                    //    int num = Convert.ToInt32(secondTwoChars);

                    //    await SendAudio(botClient, message, HTMLAddresses.bookTwoAddress, (num * 5) - 4, num * 5);
                    //}
                    else if (firstTwoChars == "📘" || firstTwoChars == "✒️")//세종한국어 3
                    {
                        if (secondTwoChars == "St" )
                        {
                            await SendKeyboard(botClient, message, KeyboardMarkups.keyboardsDictionary[30]);
                        }
                        else if (secondTwoChars == "Wo")
                        {
                            await SendKeyboard(botClient, message, KeyboardMarkups.keyboardsDictionary[33]);
                        }
                        else
                        {
                            int num = Convert.ToInt32(secondTwoChars);

                            switch (firstTwoChars)
                            {
                                case "📘":

                                    await SendAudio(botClient, message, HTMLAddresses.bookThreeAddress, (num * 5) - 4, num * 5);
                                    break;

                                case "✒️":

                                    await SendAudio(botClient, message, HTMLAddresses.workBookThreeAddress, KeyboardMarkups.keyboardsWBDictionary[num][0], KeyboardMarkups.keyboardsWBDictionary[num][1]);
                                    break;

                                default: break;
                            }
                        }
                    }
                    //else if (firstTwoChars == "📔") //세종한국어 4
                    //{
                    //    int num = Convert.ToInt32(secondTwoChars);

                    //    await SendAudio(botClient, message, HTMLAddresses.bookFourAddress, (num * 5) - 4, num * 5);
                    //}
                    //else if (firstTwoChars == "📓") //세종한국어 5
                    //{
                    //    int num = Convert.ToInt32(secondTwoChars);

                    //    await SendAudio(botClient, message, HTMLAddresses.bookFiveAddress, (num * 5) - 4, num * 5);
                    //}
                    //else if (firstTwoChars == "📕") //세종한국어 6
                    //{
                    //    int num = Convert.ToInt32(secondTwoChars);

                    //    await SendAudio(botClient, message, HTMLAddresses.bookSixAddress, (num * 5) - 4, num * 5);
                    //}
                    //else if (firstTwoChars == "📒") //세종한국어 7
                    //{
                    //    int num = Convert.ToInt32(secondTwoChars);

                    //    await SendAudio(botClient, message, HTMLAddresses.bookSevenAddress, (num * 5) - 4, num * 5);
                    //}
                    //else if (firstTwoChars == "📖") //세종한국어 8
                    //{
                    //    int num = Convert.ToInt32(secondTwoChars);

                    //    await SendAudio(botClient, message, HTMLAddresses.bookEightAddress,  (num * 5) - 4, num * 5);
                    //}
                    else if (firstTwoChars == "세종")
                    {
                        int numberOfKeyboard = Convert.ToInt32(message.Text.Substring(6,1));

                        await SendKeyboard(botClient, message, KeyboardMarkups.keyboardsDictionary[numberOfKeyboard]);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
            }
        }

        public static async Task SendKeyboard(ITelegramBotClient botClient, Message message, ReplyKeyboardMarkup keyboardMarkup)
        {
            await botClient.SendTextMessageAsync(message.Chat.Id, "Choose Required Topic ", replyMarkup: keyboardMarkup);
        }

        public static async Task SendAudio(ITelegramBotClient botClient, Message message, string bookAddress, int startNumber, int finalNumber)
        {
            for (int soundNumber = startNumber; soundNumber <= finalNumber; soundNumber++)//SHITTY CODE REWORK
            {
                string soundAddress = HTMLAddresses.baseAddress + bookAddress + soundNumber + HTMLAddresses.addressMP3FormatEnding;
                
                Console.WriteLine(soundAddress);

                await botClient.SendAudioAsync(
                    chatId: message.Chat.Id,
                    audio: InputFile.FromString(soundAddress) ,
                    replyToMessageId: message.MessageId);                
            }
        }

        public static async Task SendAudioSR(ITelegramBotClient botClient, Message message, string soundAddress)
        {
                await botClient.SendAudioAsync(
                    chatId: message.Chat.Id,
                    audio: InputFile.FromString(soundAddress),
                    replyToMessageId: message.MessageId);
        }

        public static async Task HandleErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
        {
            Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(exception));
        }

        private int GetFileNumeration(int num)
        {
            return (num * 5) - 4;
        }

        static void Main(string[] args)
        {
            string botToken = ConfigurationManager.AppSettings["TelegramToken"];
            ITelegramBotClient bot = new TelegramBotClient(botToken);

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
    }
}