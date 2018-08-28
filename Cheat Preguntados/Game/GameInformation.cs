using System.Collections.Generic;

namespace Cheat_Preguntados.Game
{
    public class GameInformation
    {
        public long id { get; set; }
        public Opponent opponent { get; set; }
        public string game_status { get; set; }
        public string language { get; set; }
        public string created { get; set; }
        public string last_turn { get; set; }
        public string type { get; set; }
        public string expiration_date { get; set; }
        public bool my_turn { get; set; }
        public string safeOpponentSelectionType { get; set; }
        public SpinsData spins_data { get; set; }
        public List<string> available_crowns { get; set; }
        public int my_player_number { get; set; }
        public int available_extra_shots { get; set; }
        public PlayerOne player_one { get; set; }
        public PlayerTwo player_two { get; set; }
        public int round_number { get; set; }
        public string sub_status { get; set; }
        public string previous_sub_status { get; set; }
        public Statistics statistics { get; set; }
        public bool is_random { get; set; }
        public int unread_messages { get; set; }
        public int status_version { get; set; }
        public MyLevelData my_level_data { get; set; }
        public string opponent_selection_type { get; set; }
        public bool normalType { get; set; }
        public bool duelGameType { get; set; }

        public class FacebookId
        {
            public string value { get; set; }
            public bool defined { get; set; }
        }

        public class LevelData
        {
            public int level { get; set; }
        }

        public class Opponent
        {
            public int id { get; set; }
            public int alerts_count { get; set; }
            public string username { get; set; }
            public string facebook_id { get; set; }
            public FacebookId facebookId { get; set; }
            public string facebook_name { get; set; }
            public bool fb_show_picture { get; set; }
            public bool fb_show_name { get; set; }
            public bool allow_og_posts { get; set; }
            public string photo_url { get; set; }
            public LevelData level_data { get; set; }
            public bool is_friend { get; set; }
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

        public class Question2
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
            public string facebook_id { get; set; }
            public string name { get; set; }
            public string username { get; set; }
            public string facebook_name { get; set; }
            public bool fb_show_picture { get; set; }
            public bool fb_show_name { get; set; }
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

        public class Question
        {
            public Question2 question { get; set; }
            public PowerupQuestion powerup_question { get; set; }
            public SecondChanceQuestion second_chance_question { get; set; }
        }

        public class Spin
        {
            public string type { get; set; }
            public bool second_chance_available { get; set; }
            public List<Question> questions { get; set; }
        }

        public class SpinsData
        {
            public List<Spin> spins { get; set; }
        }

        public class PlayerOne
        {
            public int charges { get; set; }
        }

        public class PlayerTwo
        {
            public int charges { get; set; }
        }

        public class CategoryQuestion
        {
            public string category { get; set; }
            public int correct { get; set; }
            public int incorrect { get; set; }
            public bool worst { get; set; }
        }

        public class PlayerOneStatistics
        {
            public List<CategoryQuestion> category_questions { get; set; }
            public int correct_answers { get; set; }
            public int incorrect_answers { get; set; }
            public int challenges_won { get; set; }
            public int questions_answered { get; set; }
            public int crowns_won { get; set; }
        }

        public class CategoryQuestion2
        {
            public string category { get; set; }
            public int correct { get; set; }
            public int incorrect { get; set; }
            public bool worst { get; set; }
        }

        public class PlayerTwoStatistics
        {
            public List<CategoryQuestion2> category_questions { get; set; }
            public int correct_answers { get; set; }
            public int incorrect_answers { get; set; }
            public int challenges_won { get; set; }
            public int questions_answered { get; set; }
            public int crowns_won { get; set; }
        }

        public class Statistics
        {
            public PlayerOneStatistics player_one_statistics { get; set; }
            public PlayerTwoStatistics player_two_statistics { get; set; }
        }

        public class MyLevelData
        {
            public int level { get; set; }
            public int points { get; set; }
            public int goal_points { get; set; }
            public int progress { get; set; }
            public bool level_up { get; set; }
        }
    }
}