using System;
using System.Threading;
using Telegram.Bot;
using Telegram.Bot.Extensions.Polling;
using System.Configuration;
using DJSejong;
using System.Collections.Generic;
using System.IO;
using DJSejong.Models;
using Telegram.Bot.Types.ReplyMarkups;
using DJSejong.Models.Constants;

namespace TelegramBotExperiments
{
    class Program
    {
        //public static List<string> bookList = new List<string>();

        //static Dictionary<string, List<string>> chaptersByBooks = new Dictionary<string, List<string>>();

        //static Dictionary<string, Dictionary<string, List<string>> > filesByChaptersByBooks = new Dictionary<string, Dictionary<string, List<string>>>();

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

            var audioFilesPath = AppContext.BaseDirectory + "AudioFiles\\";

            TraverseFolders(audioFilesPath);

            GenerateWelcomeKeyboardMarkups();
            GenerateBookKeyboardsMarkups();

            // Print the contents of each list
            Console.WriteLine("Books:");
            
            foreach (string book in HierarchicalItem.bookList)
            {
                Console.WriteLine(book);
            }

            bot.StartReceiving(
                DJSejongServiceProvider.HandleUpdateAsync,
                DJSejongServiceProvider.HandleErrorAsync,
                receiverOptions,
                cancellationToken
            );

            Console.ReadLine();
        }

        static void TraverseFolders(string folder)
        {
            try
            {
                // Get all files and directories in the current folder
                string[] entries = Directory.GetFileSystemEntries(folder);

                foreach (string entry in entries)
                {
                    if (Directory.Exists(entry))
                    {
                        // If it's a directory, it's either a book or a chapter
                        string directoryName = Path.GetFileName(entry);
                        if (ContainsSubdirectories(entry))
                        {
                            // If the directory contains subdirectories, it's a book
                            HierarchicalItem.bookList.Add(directoryName);
                            Console.WriteLine($"{directoryName}");
                            HierarchicalItem.chaptersByBooks.Add(directoryName, new List<string>());
                            TraverseFolders(entry); // Recursively traverse into subdirectories
                        }
                        else
                        {
                            var parentFolderName = Path.GetFileName(Path.GetDirectoryName(Path.GetFullPath(entry)));

                            HierarchicalItem.chaptersByBooks[parentFolderName].Add(directoryName);

                            HierarchicalItem.filesByChaptersByBooks.TryAdd(parentFolderName, new Dictionary<string, List<string>>());
                            HierarchicalItem.filesByChaptersByBooks[parentFolderName].TryAdd(directoryName, new List<string>());
                            
                            TraverseFolders(entry); // Recursively traverse into subdirectories
                        }
                    }
                    else if (File.Exists(entry))
                    {
                        // If it's a file, it's a file within a chapter
                        var parentFolderName = Path.GetFileName(Path.GetDirectoryName(Path.GetFullPath(entry)));
                        var greatParentFolderName = Path.GetFileName(Path.GetDirectoryName(Path.GetDirectoryName(Path.GetFullPath(entry))));

                        //Console.WriteLine(greatParentFolderName + " " + parentFolderName );

                        HierarchicalItem.filesByChaptersByBooks[greatParentFolderName][parentFolderName].Add(Path.GetFullPath(entry));
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error accessing folder {folder}: {ex.Message}");
            }
        }

        static bool ContainsSubdirectories(string folder)
        {
            return Directory.GetDirectories(folder).Length > 0;
        }

        static void GenerateWelcomeKeyboardMarkups()
        {
            List<List<InlineKeyboardButton>> keyboardRows = new List<List<InlineKeyboardButton>>();

            var ceiling = Math.Ceiling(HierarchicalItem.bookList.Count / (decimal)3);

            for (int i = 0; i < ceiling; i++)
            {
                List<InlineKeyboardButton> row = new List<InlineKeyboardButton>();

                for (int j = 0; j < 3; j++)
                {
                    if ((j + i * 3) < HierarchicalItem.bookList.Count)
                    {
                        row.Add(HierarchicalItem.bookList[j + i * 3]);
                    }
                    else
                    {
                        continue;
                    }
                }

                keyboardRows.Add(row);
            }
            
            GeneratedKeyboardMarkups.generatedKeyboardsDictionary.Add(KeyboardNames.WelcomeKeyboard.ToString(),new InlineKeyboardMarkup(keyboardRows));
        }

        static void GenerateBookKeyboardsMarkups()
        {
            //foreach (var book in HierarchicalItem.bookList)
            for(int k = 0; k < HierarchicalItem.bookList.Count; k++)
            {
                List<List<InlineKeyboardButton>> keyboardRows = new List<List<InlineKeyboardButton>>();

                var ceiling = Math.Ceiling(HierarchicalItem.chaptersByBooks[HierarchicalItem.bookList[k]].Count / (decimal)3);

                for (int i = 0; i < ceiling; i++)
                {
                    List<InlineKeyboardButton> row = new List<InlineKeyboardButton>();

                    for (int j = 0; j < 3; j++)
                    {
                        if ((j + i * 3) < HierarchicalItem.chaptersByBooks[HierarchicalItem.bookList[k]].Count)
                        {
                            row.Add(HierarchicalItem.chaptersByBooks[HierarchicalItem.bookList[k]][j + i * 3]);
                        }
                        else
                        {
                            continue;
                        }
                    }

                    keyboardRows.Add(row);
                }

                keyboardRows.Add(new List<InlineKeyboardButton>() { "⬅️Back To Main Menu" });

                GeneratedKeyboardMarkups.generatedKeyboardsDictionary.Add(HierarchicalItem.bookList[k], new InlineKeyboardMarkup(keyboardRows));
            }            
        }
    }
}