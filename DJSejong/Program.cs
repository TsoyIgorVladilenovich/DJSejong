using System;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Extensions.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Types.ReplyMarkups;
using System.Collections.Generic;

namespace TelegramBotExperiments
{

    class Program
    {
        static ITelegramBotClient bot = new TelegramBotClient("5188626170:AAGh7ej4pY6HEKaPlX1_j9P4ue6tNpA3Vys");

        static readonly Dictionary<int, ReplyKeyboardMarkup> keyboardDictionary = new Dictionary<int, ReplyKeyboardMarkup>()
        {
            {1, new[]//세종한국어 1 TODO: REFACTOR
                {
                    new[] { "📗00 Introduction. Hangeul"},
                    new[] { "📗01", "📗02", "📗03" },
                    new[] { "📗04", "📗05", "📗06" },
                    new[] { "📗07", "📗08", "📗09" },
                    new[] { "📗10", "📗11", "📗12" },
                    new[] { "⬅️Back To Main Menu"},
                }
             },

            {2, new[]//세종한국어 2 TODO: REFACTOR
                {
                    new[] { "📙01", "📙02", "📙03" },
                    new[] { "📙04", "📙05", "📙06" },
                    new[] { "📙07", "📙08", "📙09" },
                    new[] { "📙10", "📙11", "📙12" },
                    new[] { "📙13", "📙14"},
                    new[] { "⬅️Back To Main Menu"},
                }
             },

            {3, new[]//세종한국어 3 TODO: REFACTOR
                {
                    new[] { "📘01 직업", "📘02 좋아하는 것", "📘03 축하" },
                    new[] { "📘04 할일", "📘05 휴가 계획", "📘06 쇼핑" },
                    new[] { "📘07 여행과", "📘08 공공 예절", "📘09 생할 습관" },
                    new[] { "📘10 물건 찾기", "📘11 날씨", "📘12 부탁" },
                    new[] { "📘13 살고 싶은 집", "📘14 꿈" },
                    new[] { "⬅️Back To Main Menu"},
                }
             },

            {4, new[]//세종한국어 4 TODO: REFACTOR
                {
                    new[] { "📔01", "📔02", "📔03" },
                    new[] { "📔04", "📔05", "📔06" },
                    new[] { "📔07", "📔08", "📔09" },
                    new[] { "📔10", "📔11", "📔12" },
                    new[] { "📔13", "📔14"},
                    new[] { "⬅️Back To Main Menu"},
                }
             },

            {5, new[]//세종한국어 5 TODO: REFACTOR
                {
                    new[] { "📓01", "📓02", "📓03" },
                    new[] { "📓04", "📓05", "📓06" },
                    new[] { "📓07", "📓08", "📓09" },
                    new[] { "📓10", "📓11", "📓12" },
                    new[] { "📓13", "📓14"},
                    new[] { "⬅️Back To Main Menu"},
                }
             },

            {6, new[]//세종한국어 6TODO: REFACTOR
                {
                    new[] { "📕01", "📕02", "📕03" },
                    new[] { "📕04", "📕05", "📕06" },
                    new[] { "📕07", "📕08", "📕09" },
                    new[] { "📕10", "📕11", "📕12" },
                    new[] { "📕13", "📕14"},
                    new[] { "⬅️Back To Main Menu"},
                }
             },

            {7, new[]//세종한국어 7 TODO: REFACTOR
                {
                    new[] { "📒01", "📒02", "📒03" },
                    new[] { "📒04", "📒05", "📒06" },
                    new[] { "📒07", "📒08", "📒09" },
                    new[] { "📒10", "📒11", "📒12" },
                    new[] { "📒13", "📒14"},
                    new[] { "⬅️Back To Main Menu"},
                }
             },

            {8, new[]//세종한국어 8 TODO: REFACTOR
                {
                     new[] { "📖01", "📖02", "📖03" },
                     new[] { "📖04", "📖05", "📖06" },
                     new[] { "📖07", "📖08", "📖09" },
                     new[] { "📖10", "📖11", "📖12" },
                     new[] { "📖13", "📖14"},
                     new[] { "⬅️Back To Main Menu"},
                }
             },

            {0, new[]//Welcome Keyboard TODO: REFACTOR
                {
                         new[] { "세종한국어 1", "세종한국어 2", "세종한국어 3" },
                         new[] { "세종한국어 4", "세종한국어 5", "세종한국어 6" },
                         new[] { "세종한국어 7", "세종한국어 8" }
                }
             },

            //{0, new[]//Welcome Keyboard TODO: REFACTOR
            //    {
            //         new[] { "세종한국어 1", "세종한국어 2" },
            //         new[] { "세종한국어 3", "세종한국어 4" },
            //         new[] { "세종한국어 5", "세종한국어 6" },
            //         new[] { "세종한국어 7", "세종한국어 8" },
            //    }
            // },
        };

        public static async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            // Некоторые действия
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
                                //await bot.SendTextMessageAsync(message.Chat.Id, "");
                                
                                //keyboardDictionary[0].ResizeKeyboard = true;
                                
                                await bot.SendTextMessageAsync(message.Chat.Id, "Welcome To DJ Sejong BOT!\nPlease choose your level...", replyMarkup: keyboardDictionary[0]);
                                
                                break;
                            } 
                        case "⬅️Back To Main Menu":
                            {
                                //keyboardDictionary[0].ResizeKeyboard = true;

                                await bot.SendTextMessageAsync(message.Chat.Id, "Please choose your level...", replyMarkup: keyboardDictionary[0]);
                                
                                break;
                            }
                        default: break;
                    }

                    //1📗 2📙 3📘 4📔 5📓 6📕 7📒 8📖

                    var firstTwo = message.Text?[..2];
                    //TODO Add two additional dictionaries with links and formulas
                    if (firstTwo == "📗")//세종한국어 1
                    {
                        int num = Convert.ToInt32(message.Text.Substring(2, 2).Trim());

                        if (num == 0)
                        {
                            await SendAudio(message, "https://github.com/TsoyIgorVladilenovich/DJSejong/blob/master/DJSejong/Audio/%EC%84%B8%EC%A2%85%ED%95%9C%EA%B5%AD%EC%96%B4%201/TRACK%20(", ").mp3?raw=true", 1, 19);
                        }
                        else if (num > 0 && num < 11)
                        {                            
                            await SendAudio(message, "https://github.com/TsoyIgorVladilenovich/DJSejong/blob/master/DJSejong/Audio/%EC%84%B8%EC%A2%85%ED%95%9C%EA%B5%AD%EC%96%B4%201/TRACK%20(", ").mp3?raw=true", 20 + 5 * (num - 1), (20 + 5 * (num - 1)) + 4);
                        }
                        else
                        {
                            await SendAudio(message, "https://github.com/TsoyIgorVladilenovich/DJSejong/blob/master/DJSejong/Audio/%EC%84%B8%EC%A2%85%ED%95%9C%EA%B5%AD%EC%96%B4%201/TRACK%20(", ").mp3?raw=true", 70 + 2 * (num - 10) - 2, 70 + 2 * (num - 10) - 1);
                        }
                    }
                    else if (firstTwo == "📙")//세종한국어 2
                    {
                        int num = Convert.ToInt32(message.Text.Substring(2, 2).Trim());

                        await SendAudio(message, "https://github.com/TsoyIgorVladilenovich/DJSejong/blob/master/DJSejong/Audio/%EC%84%B8%EC%A2%85%ED%95%9C%EA%B5%AD%EC%96%B4%202/TRACK%20(", ").mp3?raw=true", (num * 5) - 4, num * 5);
                    }
                    else if (firstTwo == "📘")//세종한국어 3
                    {
                        int num = Convert.ToInt32(message.Text.Substring(2, 2).Trim());

                        await SendAudio(message, "https://github.com/TsoyIgorVladilenovich/DJSejong/blob/master/DJSejong/Audio/%EC%84%B8%EC%A2%85%ED%95%9C%EA%B5%AD%EC%96%B4%203/TRACK%20(", ").mp3?raw=true", (num * 5) - 4, num * 5);
                    }
                    else if (firstTwo == "📔") //세종한국어 4
                    {
                        int num = Convert.ToInt32(message.Text.Substring(2, 2).Trim());

                        await SendAudio(message, "https://github.com/TsoyIgorVladilenovich/DJSejong/blob/master/DJSejong/Audio/%EC%84%B8%EC%A2%85%ED%95%9C%EA%B5%AD%EC%96%B4%204/TRACK%20(", ").mp3?raw=true", (num * 5) - 4, num * 5);
                    }
                    else if (firstTwo == "📓") //세종한국어 5
                    {
                        int num = Convert.ToInt32(message.Text.Substring(2, 2).Trim());

                        await SendAudio(message, "https://github.com/TsoyIgorVladilenovich/DJSejong/blob/master/DJSejong/Audio/%EC%84%B8%EC%A2%85%ED%95%9C%EA%B5%AD%EC%96%B4%205/TRACK%20(", ").mp3?raw=true", (num * 5) - 4, num * 5);
                    }
                    else if (firstTwo == "📕") //세종한국어 6
                    {
                        int num = Convert.ToInt32(message.Text.Substring(2, 2).Trim());

                        await SendAudio(message, "https://github.com/TsoyIgorVladilenovich/DJSejong/blob/master/DJSejong/Audio/%EC%84%B8%EC%A2%85%ED%95%9C%EA%B5%AD%EC%96%B4%206/TRACK%20(", ").mp3?raw=true", (num * 5) - 4, num * 5);
                    }
                    else if (firstTwo == "📒") //세종한국어 7
                    {
                        int num = Convert.ToInt32(message.Text.Substring(2, 2).Trim());

                        await SendAudio(message, "https://github.com/TsoyIgorVladilenovich/DJSejong/blob/master/DJSejong/Audio/%EC%84%B8%EC%A2%85%ED%95%9C%EA%B5%AD%EC%96%B4%207/TRACK%20(", ").mp3?raw=true", (num * 5) - 4, num * 5);
                    }
                    else if (firstTwo == "📖") //세종한국어 8
                    {
                        int num = Convert.ToInt32(message.Text.Substring(2, 2).Trim());

                        await SendAudio(message, "https://github.com/TsoyIgorVladilenovich/DJSejong/blob/master/DJSejong/Audio/%EC%84%B8%EC%A2%85%ED%95%9C%EA%B5%AD%EC%96%B4%208/TRACK%20(", ").mp3?raw=true", (num * 5) - 4, num * 5);
                    }
                    else if (firstTwo == "세종")
                    {
                        int numberOfKeyboard = Convert.ToInt32(message.Text.Substring(6,1));

                        await SendKeyboard(message, keyboardDictionary[numberOfKeyboard]);
                    }
                }
            }
            catch { }
        }

        public static async Task SendKeyboard(Telegram.Bot.Types.Message message, ReplyKeyboardMarkup keyboardMarkup)
        {
            await bot.SendTextMessageAsync(message.Chat.Id, "Choose Required Topic ", replyMarkup: keyboardMarkup);
        }

            public static async Task SendAudio(Telegram.Bot.Types.Message message, string address, string format, int startIndex, int finalIndex)
        {
            for (int i = startIndex; i <= finalIndex; i++)//SHITTY CODE REWORK
            {
                Console.WriteLine("i = " + i);

                await bot.SendAudioAsync(
                    chatId: message.Chat.Id,
                    audio: address + i + format,
                    replyToMessageId: message.MessageId);

                Console.WriteLine(address + i + format);
            }
        }

        public static async Task HandleErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
        {
            Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(exception));
        }

        static void Main(string[] args)
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
    }
}