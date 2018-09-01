namespace Cheat_Preguntados.Game
{
    public class GameInformation
    {
        public long id { get; set; }
        public string game_status { get; set; }
        public string language { get; set; }
        public string type { get; set; }
        public bool normalType { get; set; }
        public bool duelGameType { get; set; }
        public bool SecondChanceAvailable { get; set; }
        //public QuestionClassicMode questionClassicMode { get; set; }


        public GameInformation()
        {
            //questionClassicMode = new QuestionClassicMode();
        }
    }
}