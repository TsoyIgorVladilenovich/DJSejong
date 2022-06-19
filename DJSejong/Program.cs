﻿using System;
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
                        new[] { "1-A", "1-B" },
                        new[] { "2-A", "2-B" },
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
                        new[] { "1", "2", "3" },
                        new[] { "4", "5", "6" },
                        new[] { "7", "8", "9" },
                        new[] { "10", "11", "12" },
                        new[] { "Back To Main Menu"},
                };

                ReplyKeyboardMarkup TwoAKeyboard = new[]//TODO: Rework; unusable in term of multiple levels
{
                        new[] { "📘2A 01 직업", "📘2A 02 좋아하는 것", "📘2A 03 축하" },
                        new[] { "📘2A 04 할일", "📘2A 05 휴가 계획", "📘2A 06 쇼핑" },
                        new[] { "📘2A 07 여행과", "📘2A 08 공공 예절", "📘2A 09 생할 습관" },
                        new[] { "📘2A 10 물건 찾기", "📘2A 11 날씨", "📘2A 12 부탁" },
                        new[] { "📘2A 13 살고 싶은 집", "📘2A 14 꿈" },
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
                    case "1-B":
                        {
                            await bot.SendTextMessageAsync(message.Chat.Id, "Choose Required Topic ", replyMarkup: OneBKeyboard);
                            break;
                        }
                    case "2-A":
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
                        case "📘2A 02":
                            {
                                await bot.SendAudioAsync(message.Chat.Id, "");
                                await bot.SendAudioAsync(message.Chat.Id, "");
                                await bot.SendAudioAsync(message.Chat.Id, "");

                                break;
                            }
                        case "📘2A 03":
                            {
                                await bot.SendAudioAsync(message.Chat.Id, "");
                                await bot.SendAudioAsync(message.Chat.Id, "");
                                await bot.SendAudioAsync(message.Chat.Id, "");
                                break;
                            }
                        case "📘2A 04":
                            {
                                await bot.SendAudioAsync(message.Chat.Id, "");
                                await bot.SendAudioAsync(message.Chat.Id, "");
                                await bot.SendAudioAsync(message.Chat.Id, "");
                                break;
                            }
                        case "📘2A 05":
                            {
                                await bot.SendAudioAsync(message.Chat.Id, "");
                                await bot.SendAudioAsync(message.Chat.Id, "");
                                await bot.SendAudioAsync(message.Chat.Id, "");
                                break;
                            }
                        case "📘2A 06":
                            {
                                await bot.SendAudioAsync(message.Chat.Id, "");
                                await bot.SendAudioAsync(message.Chat.Id, "");
                                await bot.SendAudioAsync(message.Chat.Id, "");
                                break;
                            }
                        case "📘2A 07":
                            {
                                await bot.SendAudioAsync(message.Chat.Id, "");
                                await bot.SendAudioAsync(message.Chat.Id, "");
                                await bot.SendAudioAsync(message.Chat.Id, "");
                                break;
                            }
                        case "📘2A 08":
                            {

                                await bot.SendAudioAsync(message.Chat.Id, "");
                                await bot.SendAudioAsync(message.Chat.Id, "");
                                await bot.SendAudioAsync(message.Chat.Id, "");
                                break;
                            }
                        case "📘2A 09":
                            {
                                await bot.ForwardMessageAsync(message.Chat.Id, "-1756022225", 9);
                                break;
                            }
                        case "📘2A 10":
                            {
                                await bot.ForwardMessageAsync(message.Chat.Id, "-1756022225", 9);
                                break;
                            }
                        case "📘2A 11":
                            {
                                await bot.ForwardMessageAsync(message.Chat.Id, "-1756022225", 9);
                                break;
                            }
                        case "📘2A 12":
                            {
                                await bot.ForwardMessageAsync(message.Chat.Id, "-1756022225", 9);
                                break;
                            }
                        case "📘2A 13":
                            {
                                await bot.ForwardMessageAsync(message.Chat.Id, "-1756022225", 9);
                                break;
                            }
                        case "📘2A 14":
                            {
                                await bot.ForwardMessageAsync(message.Chat.Id, "-1756022225", 9);
                                break;
                            }
                        default: break;
                    }
                }
                else
                {
                    Console.WriteLine(message.Text);
                    Console.WriteLine("failed");
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