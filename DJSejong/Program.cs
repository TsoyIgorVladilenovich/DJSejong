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
            {0, new[]//Welcome Keyboard
                {
                         new[] { "세종한국어 1", "세종한국어 2", "세종한국어 3" },
                         new[] { "세종한국어 4", "세종한국어 5", "세종한국어 6" },
                         new[] { "세종한국어 7", "세종한국어 8" }
                }
            },

            {1, new[]//세종한국어 1
                {
                    new[] { "📗00 Introduction. Hangeul"},
                    new[] { "📗01 자기소개", "📗02 일상생활", "📗03위치" },
                    new[] { "📗04 물건 사기 1", "📗05 물건 사기 2", "📗06 어제 일과" },
                    new[] { "📗07 날씨", "📗08 시간", "📗09 역속" },
                    new[] { "📗10 주말 활동", "📗11 한국어 공부", "📗12 계획" },
                    new[] { "⬅️Back To Main Menu"}
                }
             },

            {2, new[]//세종한국어 2
                {
                    new[] { "📙01 안부", "📙02 취미 활동", "📙03 음식" },
                    new[] { "📙04 교통", "📙05 길 찾기", "📙06 전화" },
                    new[] { "📙07 외모", "📙08 가족", "📙09 여행" },
                    new[] { "📙10 건강", "📙11 모임", "📙12 고향" },
                    new[] { "📙13 기분과 감정", "📙14 미래"},
                    new[] { "⬅️Back To Main Menu"}
                }
             },

            //{3, new[]//세종한국어 3
            {30, new[]//세종한국어 3
                {
                    new[] { "📘01 직업", "📘02 좋아하는 것", "📘03 축하" },
                    new[] { "📘04 할일", "📘05 휴가 계획", "📘06 쇼핑" },
                    new[] { "📘07 여행과", "📘08 공공 예절", "📘09 생할 습관" },
                    new[] { "📘10 물건 찾기", "📘11 날씨", "📘12 부탁" },
                    new[] { "📘13 살고 싶은 집", "📘14 꿈" },
                    new[] { "⬅️Back To Main Menu"}
                }
             },

            {4, new[]//세종한국어 4
                {
                    new[] { "📔01 근황", "📔02 외국 생활", "📔03 초대" },
                    new[] { "📔04 결심", "📔05 문화 차이", "📔06 감사" },
                    new[] { "📔07 공공시설 이용", "📔08 예약", "📔09 경험" },
                    new[] { "📔10 요리", "📔11 영화와 드라마", "📔12 패션" },
                    new[] { "📔13 성격", "📔14 소감"},
                    new[] { "⬅️Back To Main Menu"}
                }
             },

            {5, new[]//세종한국어 5
                {
                    new[] { "📓01 진로", "📓02 널씨와 계절", "📓03 대중음악" },
                    new[] { "📓04 길 묻기", "📓05 기념일", "📓06 쇼핑" },
                    new[] { "📓07 여가 생활", "📓08 약속", "📓09 안부" },
                    new[] { "📓10 명절", "📓11 부탁과 거절", "📓12 감정" },
                    new[] { "📓13 전자 제품", "📓14 소원"},
                    new[] { "⬅️Back To Main Menu"}
                }
             },

            {6, new[]//세종한국어 6
                {
                    new[] { "📕01 여행 경험", "📕02 사과", "📕03 나라에 따라 다른 문화" },
                    new[] { "📕04 도시", "📕05 동물", "📕06 예절과 규칙" },
                    new[] { "📕07 우리 집", "📕08 스타와 팬", "📕09 일하고 싶은 회사" },
                    new[] { "📕10 소식", "📕11 전달", "📕12 수선과 수리" },
                    new[] { "📕13 언어와 문화", "📕14 이별"},
                    new[] { "⬅️Back To Main Menu"}
                }
             },

            {7, new[]//세종한국어 7
                {
                    new[] { "📒01 취미 생활", "📒02 증상과 치료", "📒03 인터냇과 컴퓨터" },
                    new[] { "📒04 가족", "📒05 구인 구직", "📒06 소비 습관" },
                    new[] { "📒07 첫인상", "📒08 소문", "📒09 결혼" },
                    new[] { "📒10 방송", "📒11 사고 경험", "📒12 면점" },
                    new[] { "📒13 지리", "📒14 나라 소개"},
                    new[] { "⬅️Back To Main Menu"}
                }
             },

            {8, new[]//세종한국어 8
                {
                     new[] { "📖01 인생 계획", "📖02 건강과 운동", "📖03 존경하는 인물" },
                     new[] { "📖04 건축", "📖05 자연", "📖06 기술의 발전" },
                     new[] { "📖07 찬성과 반대", "📖08 자얀재해", "📖09 업무 지시" },
                     new[] { "📖10 이야기", "📖11 습관", "📖12 사회 변화" },
                     new[] { "📖13 업무 협의", "📖14 졸업"},
                     new[] { "⬅️Back To Main Menu"}
                }
             },
            //TODO: Rework this array
            // 🖊🖋 ✒️ 🖌🖍📝✏️🔏
            {11, new[]//세종한국어 1
                {
                    new[] { "1️⃣00 Introduction. Hangeul"},
                    new[] { "1️⃣01 자기소개", "1️⃣02 일상생활", "1️⃣03위치" },
                    new[] { "1️⃣04 물건 사기 1", "1️⃣05 물건 사기 2", "1️⃣06 어제 일과" },
                    new[] { "1️⃣07 날씨", "1️⃣08 시간", "1️⃣09 역속" },
                    new[] { "1️⃣10 주말 활동", "1️⃣11 한국어 공부", "1️⃣12 계획" },
                    new[] { "⬅️Back To Main Menu"}
                }
             },

            {22, new[]//세종한국어 2
                {
                    new[] { "2️⃣01 안부", "2️⃣02 취미 활동", "2️⃣03 음식" },
                    new[] { "2️⃣04 교통", "2️⃣05 길 찾기", "2️⃣06 전화" },
                    new[] { "2️⃣07 외모", "2️⃣08 가족", "2️⃣09 여행" },
                    new[] { "2️⃣10 건강", "2️⃣11 모임", "2️⃣12 고향" },
                    new[] { "2️⃣13 기분과 감정", "2️⃣14 미래"},
                    new[] { "⬅️Back To Main Menu"}
                }
             },

            {33, new[]//세종한국어 3
                {
                    new[] { "✒️01 직업", "✒️02 좋아하는 것", "✒️03 축하" },
                    new[] { "✒️04 할일", "✒️05 휴가 계획", "✒️06 쇼핑" },
                    new[] { "✒️07 여행과", "✒️08 공공 예절", "✒️09 생할 습관" },
                    new[] { "✒️10 물건 찾기", "✒️11 날씨", "✒️12 부탁" },
                    new[] { "✒️13 살고 싶은 집", "✒️14 꿈" },
                    new[] { "⬅️Back To Main Menu"}
                }
             },

            {44, new[]//세종한국어 4
                {
                    new[] { "4️⃣01 근황", "4️⃣02 외국 생활", "4️⃣03 초대" },
                    new[] { "4️⃣04 결심", "4️⃣05 문화 차이", "4️⃣06 감사" },
                    new[] { "4️⃣07 공공시설 이용", "4️⃣08 예약", "4️⃣09 경험" },
                    new[] { "4️⃣10 요리", "4️⃣11 영화와 드라마", "4️⃣12 패션" },
                    new[] { "4️⃣13 성격", "4️⃣14 소감"},
                    new[] { "⬅️Back To Main Menu"}
                }
             },

            {55, new[]//세종한국어 5
                {
                    new[] { "5️⃣01 진로", "5️⃣02 널씨와 계절", "5️⃣03 대중음악" },
                    new[] { "5️⃣04 길 묻기", "5️⃣05 기념일", "5️⃣06 쇼핑" },
                    new[] { "5️⃣07 여가 생활", "5️⃣08 약속", "5️⃣09 안부" },
                    new[] { "5️⃣10 명절", "5️⃣11 부탁과 거절", "5️⃣12 감정" },
                    new[] { "5️⃣13 전자 제품", "5️⃣14 소원"},
                    new[] { "⬅️Back To Main Menu"}
                }
             },

            {66, new[]//세종한국어 6
                {
                    new[] { "6️⃣01 여행 경험", "6️⃣02 사과", "6️⃣03 나라에 따라 다른 문화" },
                    new[] { "6️⃣04 도시", "6️⃣05 동물", "6️⃣06 예절과 규칙" },
                    new[] { "6️⃣07 우리 집", "6️⃣08 스타와 팬", "6️⃣09 일하고 싶은 회사" },
                    new[] { "6️⃣10 소식", "6️⃣11 전달", "6️⃣12 수선과 수리" },
                    new[] { "6️⃣13 언어와 문화", "6️⃣14 이별"},
                    new[] { "⬅️Back To Main Menu"}
                }
             },

            {77, new[]//세종한국어 7
                {
                    new[] { "7️⃣01 취미 생활", "7️⃣02 증상과 치료", "7️⃣03 인터냇과 컴퓨터" },
                    new[] { "7️⃣04 가족", "7️⃣05 구인 구직", "7️⃣06 소비 습관" },
                    new[] { "7️⃣07 첫인상", "7️⃣08 소문", "7️⃣09 결혼" },
                    new[] { "7️⃣10 방송", "7️⃣11 사고 경험", "7️⃣12 면점" },
                    new[] { "7️⃣13 지리", "7️⃣14 나라 소개"},
                    new[] { "⬅️Back To Main Menu"}
                }
             },

            {88, new[]//세종한국어 8
                {
                     new[] { "8️⃣01 인생 계획", "8️⃣02 건강과 운동", "8️⃣03 존경하는 인물" },
                     new[] { "8️⃣04 건축", "8️⃣05 자연", "8️⃣06 기술의 발전" },
                     new[] { "8️⃣07 찬성과 반대", "8️⃣08 자얀재해", "8️⃣09 업무 지시" },
                     new[] { "8️⃣10 이야기", "8️⃣11 습관", "8️⃣12 사회 변화" },
                     new[] { "8️⃣13 업무 협의", "8️⃣14 졸업"},
                     new[] { "⬅️Back To Main Menu"}
                }
             },

            //1📗 2📙 3📘 4📔 5📓 6📕 7📒 8📖
            {10, new[]//세종한국어 1
                {
                    new[] { "📗Student Book", "📗Work Book"},
                    new[] { "⬅️Back To Main Menu"}
                }
             },

            {20, new[]//세종한국어 2
                {
                    new[] { "📙Student Book", "📙Work Book"},
                    new[] { "⬅️Back To Main Menu"}
                }
             },

            {3, new[]//세종한국어 3
                {
                    new[] { "📘Student Book", "📘Work Book"},
                    new[] { "⬅️Back To Main Menu"}
                }
             },

            {40, new[]//세종한국어 4
                {
                    new[] { "📔Student Book", "📔Work Book"},
                    new[] { "⬅️Back To Main Menu"}
                }
             },

            {50, new[]//세종한국어 5
                {
                    new[] { "📓Student Book", "📓Work Book"},
                    new[] { "⬅️Back To Main Menu"}
                }
             },

            {60, new[]//세종한국어 6
                {
                    new[] { "📕Student Book", "📕Work Book"},
                    new[] { "⬅️Back To Main Menu"}
                }
             },

            {70, new[]//세종한국어 7
                {
                    new[] { "📒Student Book", "📒Work Book"},
                    new[] { "⬅️Back To Main Menu"}
                }
             },

            {80, new[]//세종한국어 8
                {
                    new[] { "📖Student Book", "📖Work Book"},
                    new[] { "⬅️Back To Main Menu"}
                }
             },

        };

        static readonly Dictionary<int, int[]> keyboardWBDictionary = new Dictionary<int, int[]>()//TODO: FIX Rework//TEMPORARY
        {
            {
                1, new[]{1, 4}
            },

            {
                2, new[]{5, 8}
            },

            {
                3, new[]{9, 12}
            },

            {
                4, new[]{13, 15}
            },

            {
                5, new[]{16, 19}
            },

            {
                6, new[]{20, 23}
            },

            {
                7, new[]{24, 27}
            },

            {
                8, new[]{28, 31}
            },

            {
                9, new[]{32, 35}
            },

            {
                10, new[]{36, 39}
            },

            {
                11, new[]{40, 43}
            },

            {
                12, new[]{44, 47}
            },

            {
                13, new[]{48, 51}

            },

            {
                14, new[]{52, 55}
            },
        };

        static readonly Dictionary<int, string> linksictionary = new Dictionary<int, string>()//TODO: FIX Rework//TEMPORARY
        {
            {
                1, "https://github.com/TsoyIgorVladilenovich/DJSejong/blob/master/DJSejong/Audio/%EC%84%B8%EC%A2%85%ED%95%9C%EA%B5%AD%EC%96%B4%201/TRACK%20("
            },

            {
                2, ""
            },

            {
                3, ""
            },

            {
                4, ""
            },

            {
                5, ""
            },

            {
                6, ""
            },

            {
                7, ""
            },

            {
                8, ""
            }
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
                                await bot.SendTextMessageAsync(message.Chat.Id, "Welcome To DJ Sejong BOT!\nPlease choose your level...", replyMarkup: keyboardDictionary[0]);
                                
                                break;
                            } 
                        case "⬅️Back To Main Menu":
                            {
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
                    else if (firstTwo == "📘" || firstTwo == "✒️")//세종한국어 3
                    {
                        if (message.Text.Substring(2, 2).Trim() == "St" )
                        {
                            await SendKeyboard(message, keyboardDictionary[30]);
                        }
                        else if (message.Text.Substring(2, 2).Trim() == "Wo")
                        {
                            await SendKeyboard(message, keyboardDictionary[33]);
                        }
                        else
                        {
                            int num = Convert.ToInt32(message.Text.Substring(2, 2).Trim());

                            switch (firstTwo)
                            {
                                case "📘":

                                    await SendAudio(message, "https://github.com/TsoyIgorVladilenovich/DJSejong/blob/master/DJSejong/Audio/%EC%84%B8%EC%A2%85%ED%95%9C%EA%B5%AD%EC%96%B4%203/TRACK%20(", ").mp3?raw=true", (num * 5) - 4, num * 5);
                                    break;

                                case "✒️":

                                    await SendAudio(message, "https://github.com/TsoyIgorVladilenovich/DJSejong/blob/master/DJSejong/Audio/%EC%84%B8%EC%A2%85%ED%95%9C%EA%B5%AD%EC%96%B4%203/WORKBOOK/TRACK%20(", ").mp3?raw=true", keyboardWBDictionary[num][0], keyboardWBDictionary[num][1]);
                                    break;

                                default: break;
                            }

                            //await SendAudio(message, "https://github.com/TsoyIgorVladilenovich/DJSejong/blob/master/DJSejong/Audio/%EC%84%B8%EC%A2%85%ED%95%9C%EA%B5%AD%EC%96%B4%203/TRACK%20(", ").mp3?raw=true", (num * 5) - 4, num * 5);
                        }
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

            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
            }
        }

        public static async Task SendKeyboard(Telegram.Bot.Types.Message message, ReplyKeyboardMarkup keyboardMarkup)
        {
            await bot.SendTextMessageAsync(message.Chat.Id, "Choose Required Topic ", replyMarkup: keyboardMarkup);
        }

        public static async Task SendAudio(Telegram.Bot.Types.Message message, string address, string format, int startIndex, int finalIndex)
        {
            Console.WriteLine("i = " + startIndex);
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