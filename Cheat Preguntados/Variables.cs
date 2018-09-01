using System.Drawing;

namespace Cheat_Preguntados
{
    public class Variables : Core
    {
        public readonly string VersionApplication = "2.0";
        public readonly bool VersionBeta = false;
        public readonly Color DefaultForegroundColor = Color.Salmon;
        public readonly Color DefaultBackgroundColor = Color.Black;
        public readonly int ConsoleWindowWidth = 109;
        public readonly int ConsoleWindowHeight = 30;

        public bool ImStarted = false;

        private string _language;
        public string Language
        {
            get { return _language; }
            set { _language = value; }
        }
        
        private bool _detectedTheDetailsFromOwner = false;

        public bool DetectedTheDetailsFromOwner
        {
            get { return _detectedTheDetailsFromOwner; }
            set { _detectedTheDetailsFromOwner = value; }
        }

        private bool _detectedTheDetailsFromGame = false;

        public bool DetectedTheDetailsFromGame
        {
            get { return _detectedTheDetailsFromGame; }
            set { _detectedTheDetailsFromGame = value; }
        }
    }
}