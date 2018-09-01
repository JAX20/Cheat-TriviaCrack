using System.Collections.Generic;

namespace Cheat_Preguntados.Game
{
    public class GameInformationClassicMode
    {
        public int id { get; set; }
        public string category { get; set; }
        public string text { get; set; }
        public List<string> answers { get; set; }
        public int correct_answer { get; set; }
        public string media_type { get; set; }
        public Author author { get; set; }
        public class Author
        {
            public int id { get; set; }
            public string name { get; set; }
            public string username { get; set; }
            public bool fb_show_picture { get; set; }
            public bool fb_show_name { get; set; }
        }

        public class CROWN
        {
            public static List<CROWN> ListQuestionsFromTheCategories = new List<CROWN>();
            public Question question { get; set; }
            public PowerupQuestion powerup_question { get; set; }
            public SecondChanceQuestion second_chance_question { get; set; }

            public CROWN()
            {
                question = new Question();
                powerup_question = new PowerupQuestion();
                second_chance_question = new SecondChanceQuestion();
            }
            public class SecondChanceQuestion
            {
                public int id { get; set; }
                public string category { get; set; }
                public string text { get; set; }
                public List<string> answers { get; set; }
                public int correct_answer { get; set; }
                public string media_type { get; set; }
                public Author3 author { get; set; }
            }
            public class Author
            {
                public int id { get; set; }
                public string facebook_id { get; set; }
                public string name { get; set; }
                public string username { get; set; }
                public string facebook_name { get; set; }
                public bool fb_show_picture { get; set; }
                public bool fb_show_name { get; set; }
            }

            public class Question
            {
                public int id { get; set; }
                public string category { get; set; }
                public string text { get; set; }
                public List<string> answers { get; set; }
                public int correct_answer { get; set; }
                public string media_type { get; set; }
                public Author author { get; set; }
            }

            public class Author2
            {
                public int id { get; set; }
                public string name { get; set; }
                public string username { get; set; }
                public bool fb_show_picture { get; set; }
                public bool fb_show_name { get; set; }
            }

            public class PowerupQuestion
            {
                public int id { get; set; }
                public string category { get; set; }
                public string text { get; set; }
                public List<string> answers { get; set; }
                public int correct_answer { get; set; }
                public string media_type { get; set; }
                public Author2 author { get; set; }
            }

            public class Author3
            {
                public int id { get; set; }
                public string name { get; set; }
                public string username { get; set; }
                public bool fb_show_picture { get; set; }
                public bool fb_show_name { get; set; }
            }
        }

        public class SecondChanceQuestion
        {
            public int id { get; set; }
            public string category { get; set; }
            public string text { get; set; }
            public List<string> answers { get; set; }
            public int correct_answer { get; set; }
            public string media_type { get; set; }
            public Author author { get; set; }
            public class Author
            {
                public int id { get; set; }
                public string facebook_id { get; set; }
                public string name { get; set; }
                public string username { get; set; }
                public string facebook_name { get; set; }
                public bool fb_show_picture { get; set; }
                public bool fb_show_name { get; set; }
            }
        }
    }
}
