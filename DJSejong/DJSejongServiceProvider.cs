using DJSejong.Models.Constants;
using System;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot.Types.ReplyMarkups;
using Telegram.Bot.Types;
using Telegram.Bot;

namespace DJSejong
{
    class DJSejongServiceProvider
    {
        public static async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(update));
            try
            {
                if (update.Type == Telegram.Bot.Types.Enums.UpdateType.Message)
                {
                    var message = update.Message;

                    await CheckOnCommands(message, botClient);

                    await CheckOnFirstTwoChars(message, botClient);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
            }
        }

        public static async Task HandleErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
        {
            Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(exception));
        }

        private static async Task CheckOnCommands(Message message, ITelegramBotClient botClient)
        {
            switch (message.Text)
            {
                case "/start":
                    {
                        await botClient.SendTextMessageAsync(message.Chat.Id, "Welcome To DJ Sejong BOT!\nPlease choose your level...", replyMarkup: KeyboardMarkups.keyboardsDictionary[(int)KeyboardNames.WelcomeKeyboard]);

                        break;
                    }
                case "⬅️Back To Main Menu":
                    {
                        await botClient.SendTextMessageAsync(message.Chat.Id, "Please choose your level...", replyMarkup: KeyboardMarkups.keyboardsDictionary[(int)KeyboardNames.WelcomeKeyboard]);

                        break;
                    }
                default: break;
            }
        }

        private static async Task CheckOnFirstTwoChars(Message message, ITelegramBotClient botClient)
        {
            var firstTwoChars = message.Text?[..2];
            var secondTwoChars = message.Text.Substring(2, 2).Trim();

            switch (firstTwoChars)
            {
                case CodesForChecking.welcomeKeyboardCode:
                    {
                        int KeyboardNumber = Convert.ToInt32(message.Text.Substring(6, 1));

                        await SendKeyboard(botClient, message, KeyboardMarkups.keyboardsDictionary[KeyboardNumber]);

                        break;
                    }

                case CodesForChecking.firstBookCode://세종한국어 1
                    {
                        int numberOfChapter = Convert.ToInt32(secondTwoChars);

                        if (numberOfChapter == 0)//Introduction Part has 19 audio files
                        {
                            int startNumber = 1;
                            int finalNumber = 19;

                            for (int soundNumber = startNumber; soundNumber <= finalNumber; soundNumber++)
                            {
                                string soundAddress = HTMLAddresses.baseAddress + BooksDictionaries.booksDictionary[firstTwoChars] + soundNumber + HTMLAddresses.addressMP3FormatEnding;

                                await SendAudioSR(botClient, message, soundAddress);
                            }
                        }
                        else if (numberOfChapter > 0 && numberOfChapter < 11)//Every chapter from 1 to 11 has 5 audio files starting from number 20
                        {
                            int numberOfFilesInIntro = 19;
                            int defaultNumberOfFiles = 5;
                            int startNumber = numberOfFilesInIntro + 1 + defaultNumberOfFiles * (numberOfChapter - 1);
                            int finalNumber = startNumber + defaultNumberOfFiles - 1;

                            for (int soundNumber = startNumber; soundNumber <= finalNumber; soundNumber++)
                            {
                                string soundAddress = HTMLAddresses.baseAddress + BooksDictionaries.booksDictionary[firstTwoChars] + soundNumber + HTMLAddresses.addressMP3FormatEnding;

                                await SendAudioSR(botClient, message, soundAddress);
                            }
                        }
                        else//Last 2 chapters (11 and 12) has only 2 files each
                        {
                            int numberOfFilesInPreviousChapters = 70;
                            int totalNumberOfFilesInChosenChapters = numberOfFilesInPreviousChapters + 2 * (numberOfChapter - 10); //-10 is added to simplify 11 and 12 to 1 and 2
                            int startNumber = totalNumberOfFilesInChosenChapters - 2;//getting first number of 2 needed files
                            int finalNumber = totalNumberOfFilesInChosenChapters - 1;//getting last file

                            for (int soundNumber = startNumber; soundNumber <= finalNumber; soundNumber++)
                            {
                                string soundAddress = HTMLAddresses.baseAddress + BooksDictionaries.booksDictionary[firstTwoChars] + soundNumber + HTMLAddresses.addressMP3FormatEnding;

                                await SendAudioSR(botClient, message, soundAddress);
                            }
                        }

                        break;
                    }
                case CodesForChecking.secondBookCode://세종한국어 2
                case CodesForChecking.thirdBookCode://세종한국어 3
                case CodesForChecking.fourthBookCode://세종한국어 4
                case CodesForChecking.fifthBookCode://세종한국어 5
                case CodesForChecking.sixthBookCode://세종한국어 6
                case CodesForChecking.seventhBookCode://세종한국어 7
                case CodesForChecking.eighthBookCode://세종한국어 8
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
        }

        private static async Task SendKeyboard(ITelegramBotClient botClient, Message message, ReplyKeyboardMarkup keyboardMarkup)
        {
            await botClient.SendTextMessageAsync(message.Chat.Id, "Choose Required Topic ", replyMarkup: keyboardMarkup);
        }

        private static async Task SendAudioSR(ITelegramBotClient botClient, Message message, string soundAddress)
        {
            await botClient.SendAudioAsync(
                chatId: message.Chat.Id,
                audio: InputFile.FromString(soundAddress),
                replyToMessageId: message.MessageId);
        }
    }
}

