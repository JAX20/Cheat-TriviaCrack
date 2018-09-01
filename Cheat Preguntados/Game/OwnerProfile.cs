namespace Cheat_Preguntados.Game
{
    public class OwnerProfile : Core
    {
        public UserProfile userProfile { get; set; }
        public FacebookProfile facebookProfile { get; set; }
        public Lives lives { get; set; }
        public LevelData level_data { get; set; }
        public Inbox inbox { get; set; }

        public OwnerProfile()
        {
            userProfile = new UserProfile();
            facebookProfile = new FacebookProfile();
            lives = new Lives();
            level_data = new LevelData();
            inbox = new Inbox();
        }

        public class UserProfile
        {
            public int id { get; set; }
            public string username { get; set; }
            public string gender { get; set; }
            public int alerts_count { get; set; }
            public int coins { get; set; }
            public string photo_url { get; set; }
            public int extra_shots { get; set; }
            public string country { get; set; }
        }
        public class FacebookProfile
        {
            public string name { get; set; }
            public bool show_picture { get; set; }
            public bool show_name { get; set; }
            public string id { get; set; }
            public string value { get; set; }
            public bool defined { get; set; }
        }

        public class Lives
        {
            public int quantity { get; set; }
            public int max { get; set; }
            public bool unlimited { get; set; }
        }

        public class LevelData
        {
            public int level { get; set; }
            public int points { get; set; }
            public int goal_points { get; set; }
            public int progress { get; set; }
            public bool level_up { get; set; }
        }
        public class Inbox
        {
            public int total { get; set; }
            public int news { get; set; }
            public int unread_conversations { get; set; }
        }
    }
}