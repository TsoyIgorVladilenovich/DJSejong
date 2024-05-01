namespace DJSejong.Models
{
    public class HierarchicalItem
    {
        public static List<string> bookList = new();

        public static Dictionary<string, List<string>> chaptersByBooks = new();

        public static Dictionary<string, Dictionary<string, List<string>>> filesByChaptersByBooks = new();
    }
}
