//namespace GlosApp.Models
//{
//    public class WordAnswer
//    {
//        public int Id { get; set; }
//        public string Swedish { get; set; }
//        public string English { get; set; }
//        public string UserAnswer { get; set; }
//        public string Language { get; set; }
//        public DateTime Timestamp { get; set; } 

//        public WordAnswer(string swedish, string english, string language = null)
//        {
//            Swedish = swedish;
//            English = english;
//            Language = language;
//            Timestamp = DateTime.Now; 
//        }
//    }
//}

namespace GlosApp.Models
{
    public class WordAnswer
    {
        public int Id { get; set; }
        public string Swedish { get; set; }
        public string English { get; set; }
        public string UserAnswer { get; set; }
        public string Language { get; set; }
        public DateTime Timestamp { get; set; }

        // Standardkonstruktor
        public WordAnswer()
        {
            Timestamp = DateTime.Now;
        }

        public WordAnswer(string swedish, string english, string language = null)
        {
            Swedish = swedish;
            English = english;
            Language = language;
            Timestamp = DateTime.Now;
        }
    }
}

