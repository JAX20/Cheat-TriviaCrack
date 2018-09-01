namespace Cheat_Preguntados.Game
{
    public class OpponentProfile : Core
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
        public LevelData2 level_data { get; set; }
        public bool is_friend { get; set; }

        public class LevelData2
        {
            public int level { get; set; }
        }

        public class FacebookId
        {
            public string value { get; set; }
            public bool defined { get; set; }
        }
    }
}