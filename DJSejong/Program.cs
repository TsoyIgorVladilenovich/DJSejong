using System;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Extensions.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Types.ReplyMarkups;

namespace TelegramBotExperiments
{

    class Program
    {
        static ITelegramBotClient bot = new TelegramBotClient("5188626170:AAGh7ej4pY6HEKaPlX1_j9P4ue6tNpA3Vys");
        public static async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            // Некоторые действия
            Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(update));
            if (update.Type == Telegram.Bot.Types.Enums.UpdateType.Message)
            {
                var message = update.Message;

                ReplyKeyboardMarkup WelcomeKeyboard = new[]//TODO: REFACTOR
                {
                        new[] { "초급 2-A", "중급 1-B" }
                };

                ReplyKeyboardMarkup OneAKeyboard = new[]
                {
                        new[] { "1", "2", "3" },
                        new[] { "4", "5", "6" },
                        new[] { "7", "8", "9" },
                        new[] { "10", "11", "12" },
                        new[] { "Back To Main Menu"},
                };

                ReplyKeyboardMarkup OneBKeyboard = new[]
                {
                        new[] { "📕1B 1", "📕1B 2", "📕1B 3" },
                        new[] { "📕1B 4"/*, "📕1B 5", "📕1B 6" */},
                        //new[] { "📕1B 7", "📕1B 8", "📕1B 9" },
                        //new[] { "📕1B 10", "📕1B 11", "📕1B 12" },
                        new[] { "Back To Main Menu"},
                };

                ReplyKeyboardMarkup TwoAKeyboard = new[]//TODO: Rework; unusable in term of multiple levels
{
                        new[] { "📘2A 01 직업", "📘2A 02 좋아하는 것", "📘2A 03 축하" },
                        new[] { "📘2A 04 할일"/*, "📘2A 05 휴가 계획", "📘2A 06 쇼핑" */},
                        //new[] { "📘2A 07 여행과", "📘2A 08 공공 예절", "📘2A 09 생할 습관" },
                        //new[] { "📘2A 10 물건 찾기", "📘2A 11 날씨", "📘2A 12 부탁" },
                        //new[] { "📘2A 13 살고 싶은 집", "📘2A 14 꿈" },
                        new[] { "Back To Main Menu"},
                };

                ReplyKeyboardMarkup TwoBKeyboard = new[]
                {
                        new[] { "1", "2", "3" },
                        new[] { "4", "5", "6" },
                        new[] { "7", "8", "9" },
                        new[] { "10", "11", "12" },
                        new[] { "Back To Main Menu"},
                };


                switch (message.Text)//TODO: REFACTOR! Extract common functionality
                {
                    case "/start":
                        {
                            await bot.SendTextMessageAsync(message.Chat.Id, "Welcome To DJ Sejong BOT!");
                            await bot.SendTextMessageAsync(message.Chat.Id, "Please choose your level...", replyMarkup: WelcomeKeyboard);
                            break;
                        }
                    case "1-A":
                        {
                            await bot.SendTextMessageAsync(message.Chat.Id, "Choose Required Topic ", replyMarkup: OneAKeyboard);
                            break;
                        }
                    case "중급 1-B":
                        {
                            await bot.SendTextMessageAsync(message.Chat.Id, "Choose Required Topic ", replyMarkup: OneBKeyboard);
                            break;
                        }
                    case "초급 2-A":
                        {
                            await bot.SendTextMessageAsync(message.Chat.Id, "Choose Required Topic ", replyMarkup: TwoAKeyboard);
                            break;
                        }
                    case "2-B":
                        {
                            await bot.SendTextMessageAsync(message.Chat.Id, "Choose Required Topic ", replyMarkup: TwoBKeyboard);
                            break;
                        }
                    case "Back To Main Menu":
                        {
                            await bot.SendTextMessageAsync(message.Chat.Id, "Welcome To DJ Sejong BOT! Please choose your level...", replyMarkup: WelcomeKeyboard);
                            break;
                        }
                    default: break;
                }

                if (message.Text[..2] == "📘")
                {
                    switch (message.Text)
                    {
                        case "📘2A 01 직업":
                            {
                                await bot.SendAudioAsync(message.Chat.Id, "https://github.com/TsoyIgorVladilenovich/DJSejong/blob/master/DJSejong/Audio/--%2B-%C2%A6T-%C2%A6-%D1%8E%203%20TRACK%2001.mp3?raw=true");
                                await bot.SendAudioAsync(message.Chat.Id, "https://github.com/TsoyIgorVladilenovich/DJSejong/blob/master/DJSejong/Audio/--%2B-%C2%A6T-%C2%A6-%D1%8E%203%20TRACK%2002.mp3?raw=true");
                                await bot.SendAudioAsync(message.Chat.Id, "https://github.com/TsoyIgorVladilenovich/DJSejong/blob/master/DJSejong/Audio/--%2B-%C2%A6T-%C2%A6-%D1%8E%203%20TRACK%2003.mp3?raw=true");
                                await bot.SendAudioAsync(message.Chat.Id, "https://github.com/TsoyIgorVladilenovich/DJSejong/blob/master/DJSejong/Audio/--%2B-%C2%A6T-%C2%A6-%D1%8E%203%20TRACK%2004.mp3?raw=true");
                                await bot.SendAudioAsync(message.Chat.Id, "https://github.com/TsoyIgorVladilenovich/DJSejong/blob/master/DJSejong/Audio/--%2B-%C2%A6T-%C2%A6-%D1%8E%203%20TRACK%2005.mp3?raw=true");
                                break;
                            }
                        case "📘2A 02 좋아하는 것":
                            {
                                await bot.SendAudioAsync(message.Chat.Id, "https://github.com/TsoyIgorVladilenovich/DJSejong/blob/master/DJSejong/Audio/--%2B-%C2%A6T-%C2%A6-%D1%8E%203%20TRACK%2006.mp3?raw=true");
                                await bot.SendAudioAsync(message.Chat.Id, "https://github.com/TsoyIgorVladilenovich/DJSejong/blob/master/DJSejong/Audio/%D0%89%D0%89%D0%85%D0%8A%C2%AB%E2%80%94%C2%B1%D1%94%D0%8A%D0%BE%203%20TRACK%2007.mp3?raw=true");
                                await bot.SendAudioAsync(message.Chat.Id, "https://github.com/TsoyIgorVladilenovich/DJSejong/blob/master/DJSejong/Audio/%D0%89%D0%89%D0%85%D0%8A%C2%AB%E2%80%94%C2%B1%D1%94%D0%8A%D0%BE%203%20TRACK%2008.mp3?raw=true");
                                await bot.SendAudioAsync(message.Chat.Id, "https://github.com/TsoyIgorVladilenovich/DJSejong/blob/master/DJSejong/Audio/%D0%89%D0%89%D0%85%D0%8A%C2%AB%E2%80%94%C2%B1%D1%94%D0%8A%D0%BE%203%20TRACK%2009.mp3?raw=true");
                                await bot.SendAudioAsync(message.Chat.Id, "https://github.com/TsoyIgorVladilenovich/DJSejong/blob/master/DJSejong/Audio/%D0%89%D0%89%D0%85%D0%8A%C2%AB%E2%80%94%C2%B1%D1%94%D0%8A%D0%BE%203%20TRACK%2010.mp3?raw=true");
                                break;
                            }
                        case "📘2A 03 축하":
                            {
                                await bot.SendAudioAsync(message.Chat.Id, "https://github.com/TsoyIgorVladilenovich/DJSejong/blob/master/DJSejong/Audio/%D0%89%D0%89%D0%85%D0%8A%C2%AB%E2%80%94%C2%B1%D1%94%D0%8A%D0%BE%203%20TRACK%2011.mp3?raw=true");
                                await bot.SendAudioAsync(message.Chat.Id, "https://github.com/TsoyIgorVladilenovich/DJSejong/blob/master/DJSejong/Audio/%D0%89%D0%89%D0%85%D0%8A%C2%AB%E2%80%94%C2%B1%D1%94%D0%8A%D0%BE%203%20TRACK%2012.mp3?raw=true");
                                await bot.SendAudioAsync(message.Chat.Id, "https://github.com/TsoyIgorVladilenovich/DJSejong/blob/master/DJSejong/Audio/%D0%89%D0%89%D0%85%D0%8A%C2%AB%E2%80%94%C2%B1%D1%94%D0%8A%D0%BE%203%20TRACK%2013.mp3?raw=true");
                                await bot.SendAudioAsync(message.Chat.Id, "https://github.com/TsoyIgorVladilenovich/DJSejong/blob/master/DJSejong/Audio/%D0%89%D0%89%D0%85%D0%8A%C2%AB%E2%80%94%C2%B1%D1%94%D0%8A%D0%BE%203%20TRACK%2014.mp3?raw=true");
                                await bot.SendAudioAsync(message.Chat.Id, "https://github.com/TsoyIgorVladilenovich/DJSejong/blob/master/DJSejong/Audio/%D0%89%D0%89%D0%85%D0%8A%C2%AB%E2%80%94%C2%B1%D1%94%D0%8A%D0%BE%203%20TRACK%2015.mp3?raw=true");
                                break;
                            }
                        case "📘2A 04 할일":
                            {
                                await bot.SendAudioAsync(message.Chat.Id, "https://github.com/TsoyIgorVladilenovich/DJSejong/blob/master/DJSejong/Audio/%D0%89%D0%89%D0%85%D0%8A%C2%AB%E2%80%94%C2%B1%D1%94%D0%8A%D0%BE%203%20TRACK%2016.mp3?raw=true");
                                await bot.SendAudioAsync(message.Chat.Id, "https://github.com/TsoyIgorVladilenovich/DJSejong/blob/master/DJSejong/Audio/%D0%89%D0%89%D0%85%D0%8A%C2%AB%E2%80%94%C2%B1%D1%94%D0%8A%D0%BE%203%20TRACK%2017.mp3?raw=true");
                                await bot.SendAudioAsync(message.Chat.Id, "https://github.com/TsoyIgorVladilenovich/DJSejong/blob/master/DJSejong/Audio/--%2B-%C2%A6T-%C2%A6-%D1%8E%203%20TRACK%2018.mp3?raw=true");
                                await bot.SendAudioAsync(message.Chat.Id, "https://github.com/TsoyIgorVladilenovich/DJSejong/blob/master/DJSejong/Audio/--%2B-%C2%A6T-%C2%A6-%D1%8E%203%20TRACK%2019.mp3?raw=true");
                                await bot.SendAudioAsync(message.Chat.Id, "https://github.com/TsoyIgorVladilenovich/DJSejong/blob/master/DJSejong/Audio/--%2B-%C2%A6T-%C2%A6-%D1%8E%203%20TRACK%2020.mp3?raw=true");
                                break;
                            }
                        case "📘2A 05 휴가 계획":
                            {
                                await bot.SendAudioAsync(message.Chat.Id, "");
                                await bot.SendAudioAsync(message.Chat.Id, "");
                                await bot.SendAudioAsync(message.Chat.Id, "");
                                break;
                            }
                        case "📘2A 06 쇼핑":
                            {
                                await bot.SendAudioAsync(message.Chat.Id, "");
                                await bot.SendAudioAsync(message.Chat.Id, "");
                                await bot.SendAudioAsync(message.Chat.Id, "");
                                break;
                            }
                        case "📘2A 07 여행과":
                            {
                                await bot.SendAudioAsync(message.Chat.Id, "");
                                await bot.SendAudioAsync(message.Chat.Id, "");
                                await bot.SendAudioAsync(message.Chat.Id, "");
                                break;
                            }
                        case "📘2A 08 공공 예절":
                            {

                                await bot.SendAudioAsync(message.Chat.Id, "");
                                await bot.SendAudioAsync(message.Chat.Id, "");
                                await bot.SendAudioAsync(message.Chat.Id, "");
                                break;
                            }
                        case "📘2A 09 생할 습관":
                            {
                                await bot.SendAudioAsync(message.Chat.Id, "");
                                await bot.SendAudioAsync(message.Chat.Id, "");
                                await bot.SendAudioAsync(message.Chat.Id, "");
                                break;
                            }
                        case "📘2A 10 물건 찾기":
                            {
                                await bot.SendAudioAsync(message.Chat.Id, "");
                                await bot.SendAudioAsync(message.Chat.Id, "");
                                await bot.SendAudioAsync(message.Chat.Id, "");
                                break;
                            }
                        case "📘2A 11 날씨":
                            {
                                await bot.SendAudioAsync(message.Chat.Id, "");
                                await bot.SendAudioAsync(message.Chat.Id, "");
                                await bot.SendAudioAsync(message.Chat.Id, "");
                                break;
                            }
                        case "📘2A 12 부탁":
                            {
                                await bot.SendAudioAsync(message.Chat.Id, "");
                                await bot.SendAudioAsync(message.Chat.Id, "");
                                await bot.SendAudioAsync(message.Chat.Id, "");
                                break;
                            }
                        case "📘2A 13 살고 싶은 집":
                            {
                                await bot.SendAudioAsync(message.Chat.Id, "");
                                await bot.SendAudioAsync(message.Chat.Id, "");
                                await bot.SendAudioAsync(message.Chat.Id, "");
                                break;
                            }
                        case "📘2A 14 꿈":
                            {
                                await bot.SendAudioAsync(message.Chat.Id, "");
                                await bot.SendAudioAsync(message.Chat.Id, "");
                                await bot.SendAudioAsync(message.Chat.Id, "");
                                break;
                            }
                        default: break;
                    }
                }
                else if (message.Text[..2] == "📕")
                {
                    switch (message.Text)
                    {
                        case "📕1B 1":
                            {
                                await bot.SendAudioAsync(message.Chat.Id, "https://github.com/TsoyIgorVladilenovich/DJSejong/blob/master/DJSejong/Audio/%EC%B6%A9%EA%B8%89%201B/--%2B-%C2%A6T-%C2%A6-%D1%8E%206%20TRACK%2001.mp3?raw=true");
                                await bot.SendAudioAsync(message.Chat.Id, "https://github.com/TsoyIgorVladilenovich/DJSejong/blob/master/DJSejong/Audio/%EC%B6%A9%EA%B8%89%201B/--%2B-%C2%A6T-%C2%A6-%D1%8E%206%20TRACK%2002.mp3?raw=true");
                                await bot.SendAudioAsync(message.Chat.Id, "https://github.com/TsoyIgorVladilenovich/DJSejong/blob/master/DJSejong/Audio/%EC%B6%A9%EA%B8%89%201B/--%2B-%C2%A6T-%C2%A6-%D1%8E%206%20TRACK%2003.mp3?raw=true");
                                await bot.SendAudioAsync(message.Chat.Id, "https://github.com/TsoyIgorVladilenovich/DJSejong/blob/master/DJSejong/Audio/%EC%B6%A9%EA%B8%89%201B/--%2B-%C2%A6T-%C2%A6-%D1%8E%206%20TRACK%2004.mp3?raw=true");
                                await bot.SendAudioAsync(message.Chat.Id, "https://github.com/TsoyIgorVladilenovich/DJSejong/blob/master/DJSejong/Audio/%EC%B6%A9%EA%B8%89%201B/--%2B-%C2%A6T-%C2%A6-%D1%8E%206%20TRACK%2005.mp3?raw=true");

                                break;
                            }
                        case "📕1B 2":
                            {
                                await bot.SendAudioAsync(message.Chat.Id, "https://github.com/TsoyIgorVladilenovich/DJSejong/blob/master/DJSejong/Audio/%EC%B6%A9%EA%B8%89%201B/--%2B-%C2%A6T-%C2%A6-%D1%8E%206%20TRACK%2006.mp3?raw=true");
                                await bot.SendAudioAsync(message.Chat.Id, "https://github.com/TsoyIgorVladilenovich/DJSejong/blob/master/DJSejong/Audio/%EC%B6%A9%EA%B8%89%201B/--%2B-%C2%A6T-%C2%A6-%D1%8E%206%20TRACK%2007.mp3?raw=true");
                                await bot.SendAudioAsync(message.Chat.Id, "https://github.com/TsoyIgorVladilenovich/DJSejong/blob/master/DJSejong/Audio/%EC%B6%A9%EA%B8%89%201B/--%2B-%C2%A6T-%C2%A6-%D1%8E%206%20TRACK%2008.mp3?raw=true");
                                await bot.SendAudioAsync(message.Chat.Id, "https://github.com/TsoyIgorVladilenovich/DJSejong/blob/master/DJSejong/Audio/%EC%B6%A9%EA%B8%89%201B/--%2B-%C2%A6T-%C2%A6-%D1%8E%206%20TRACK%2009.mp3?raw=true");
                                await bot.SendAudioAsync(message.Chat.Id, "https://github.com/TsoyIgorVladilenovich/DJSejong/blob/master/DJSejong/Audio/%EC%B6%A9%EA%B8%89%201B/--%2B-%C2%A6T-%C2%A6-%D1%8E%206%20TRACK%2010.mp3?raw=true");

                                break;
                            }
                        case "📕1B 3":
                            {
                                await bot.SendAudioAsync(message.Chat.Id, "https://github.com/TsoyIgorVladilenovich/DJSejong/blob/master/DJSejong/Audio/%EC%B6%A9%EA%B8%89%201B/--%2B-%C2%A6T-%C2%A6-%D1%8E%206%20TRACK%2011.mp3?raw=true");
                                await bot.SendAudioAsync(message.Chat.Id, "https://github.com/TsoyIgorVladilenovich/DJSejong/blob/master/DJSejong/Audio/%EC%B6%A9%EA%B8%89%201B/--%2B-%C2%A6T-%C2%A6-%D1%8E%206%20TRACK%2012.mp3?raw=true");
                                await bot.SendAudioAsync(message.Chat.Id, "https://github.com/TsoyIgorVladilenovich/DJSejong/blob/master/DJSejong/Audio/%EC%B6%A9%EA%B8%89%201B/--%2B-%C2%A6T-%C2%A6-%D1%8E%206%20TRACK%2013.mp3?raw=true");
                                await bot.SendAudioAsync(message.Chat.Id, "https://github.com/TsoyIgorVladilenovich/DJSejong/blob/master/DJSejong/Audio/%EC%B6%A9%EA%B8%89%201B/--%2B-%C2%A6T-%C2%A6-%D1%8E%206%20TRACK%2014.mp3?raw=true");
                                await bot.SendAudioAsync(message.Chat.Id, "https://github.com/TsoyIgorVladilenovich/DJSejong/blob/master/DJSejong/Audio/%EC%B6%A9%EA%B8%89%201B/--%2B-%C2%A6T-%C2%A6-%D1%8E%206%20TRACK%2015.mp3?raw=true");

                                break;
                            }
                        case "📕1B 4":
                            {
                                await bot.SendAudioAsync(message.Chat.Id, "https://github.com/TsoyIgorVladilenovich/DJSejong/blob/master/DJSejong/Audio/%EC%B6%A9%EA%B8%89%201B/--%2B-%C2%A6T-%C2%A6-%D1%8E%206%20TRACK%2016.mp3?raw=true");
                                await bot.SendAudioAsync(message.Chat.Id, "https://github.com/TsoyIgorVladilenovich/DJSejong/blob/master/DJSejong/Audio/%EC%B6%A9%EA%B8%89%201B/--%2B-%C2%A6T-%C2%A6-%D1%8E%206%20TRACK%2017.mp3?raw=true");
                                await bot.SendAudioAsync(message.Chat.Id, "https://github.com/TsoyIgorVladilenovich/DJSejong/blob/master/DJSejong/Audio/%EC%B6%A9%EA%B8%89%201B/--%2B-%C2%A6T-%C2%A6-%D1%8E%206%20TRACK%2018.mp3?raw=true");
                                await bot.SendAudioAsync(message.Chat.Id, "https://github.com/TsoyIgorVladilenovich/DJSejong/blob/master/DJSejong/Audio/%EC%B6%A9%EA%B8%89%201B/--%2B-%C2%A6T-%C2%A6-%D1%8E%206%20TRACK%2019.mp3?raw=true");
                                await bot.SendAudioAsync(message.Chat.Id, "https://github.com/TsoyIgorVladilenovich/DJSejong/blob/master/DJSejong/Audio/%EC%B6%A9%EA%B8%89%201B/--%2B-%C2%A6T-%C2%A6-%D1%8E%206%20TRACK%2020.mp3?raw=true");
                                break;
                            }
                        case "📘2A 05 휴가 계획":
                            {
                                await bot.SendAudioAsync(message.Chat.Id, "");
                                await bot.SendAudioAsync(message.Chat.Id, "");
                                await bot.SendAudioAsync(message.Chat.Id, "");
                                break;
                            }
                        case "📘2A 06 쇼핑":
                            {
                                await bot.SendAudioAsync(message.Chat.Id, "");
                                await bot.SendAudioAsync(message.Chat.Id, "");
                                await bot.SendAudioAsync(message.Chat.Id, "");
                                break;
                            }
                        case "📘2A 07 여행과":
                            {
                                await bot.SendAudioAsync(message.Chat.Id, "");
                                await bot.SendAudioAsync(message.Chat.Id, "");
                                await bot.SendAudioAsync(message.Chat.Id, "");
                                break;
                            }
                        case "📘2A 08 공공 예절":
                            {

                                await bot.SendAudioAsync(message.Chat.Id, "");
                                await bot.SendAudioAsync(message.Chat.Id, "");
                                await bot.SendAudioAsync(message.Chat.Id, "");
                                break;
                            }
                        case "📘2A 09 생할 습관":
                            {
                                await bot.SendAudioAsync(message.Chat.Id, "");
                                await bot.SendAudioAsync(message.Chat.Id, "");
                                await bot.SendAudioAsync(message.Chat.Id, "");
                                break;
                            }
                        case "📘2A 10 물건 찾기":
                            {
                                await bot.SendAudioAsync(message.Chat.Id, "");
                                await bot.SendAudioAsync(message.Chat.Id, "");
                                await bot.SendAudioAsync(message.Chat.Id, "");
                                break;
                            }
                        case "📘2A 11 날씨":
                            {
                                await bot.SendAudioAsync(message.Chat.Id, "");
                                await bot.SendAudioAsync(message.Chat.Id, "");
                                await bot.SendAudioAsync(message.Chat.Id, "");
                                break;
                            }
                        case "📘2A 12 부탁":
                            {
                                await bot.SendAudioAsync(message.Chat.Id, "");
                                await bot.SendAudioAsync(message.Chat.Id, "");
                                await bot.SendAudioAsync(message.Chat.Id, "");
                                break;
                            }
                        case "📘2A 13 살고 싶은 집":
                            {
                                await bot.SendAudioAsync(message.Chat.Id, "");
                                await bot.SendAudioAsync(message.Chat.Id, "");
                                await bot.SendAudioAsync(message.Chat.Id, "");
                                break;
                            }
                        case "📘2A 14 꿈":
                            {
                                await bot.SendAudioAsync(message.Chat.Id, "");
                                await bot.SendAudioAsync(message.Chat.Id, "");
                                await bot.SendAudioAsync(message.Chat.Id, "");
                                break;
                            }
                        default: break;
                    }


                }

            }
        }

        public static async Task HandleErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
        {
            // Некоторые действия
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