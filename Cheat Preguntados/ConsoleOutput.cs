using System;
using System.Collections.Generic;
using System.Drawing;
using Console = Colorful.Console;

namespace Cheat_Preguntados
{
    public class ConsoleOutput : Core
    {
        public void ConsoleWelcome()
        {
            Console.Title = "Cheat for Preguntados - apps.facebook.com/triviacrack";
            Console.SetWindowSize(_variables.ConsoleWindowWidth, _variables.ConsoleWindowHeight);
            /*if (_ownerProfile != null)
                WriteLine($"Bienvenido/a {_ownerProfile.username }", "", ConsoleColor.White);*/
            //System.Console.SetWindowSize(89, 30);
            List<string> Lines = new List<string>();
            Lines.Add("");
            Lines.Add(@"   _____ _                _   _____                            _            _          ");
            Lines.Add(@"  / ____| |              | | |  __ \                          | |          | |          ");
            Lines.Add(@" | |    | |__   ___  __ _| |_| |__) _ __ ___  __ _ _   _ _ __ | |_ __ _  __| | ___  ___ ");
            Lines.Add(@" | |    |  _ \ / _ \/ _  | __|  ___|  __/ _ \/ _  | | | |  _ \| __/ _  |/ _  |/ _ \/ __|");
            Lines.Add(@" | |____| | | |  __| (_| | |_| |   | | |  __| (_| | |_| | | | | || (_| | (_| | (_) \__ \");
            Lines.Add(@"  \_____|_| |_|\___|\____|\__|_|   |_|  \___|\___ |\____|_| |_|\__\____|\____|\___/|___/");
            Lines.Add(@"                                              __/ |                                     ");
            Lines.Add(@"                                             |___/                                      ");
            foreach (string Line in Lines)
            {
                int Spacing = Console.WindowWidth - Line.Length - 1;
                string Ln = Line;

                for (int s = 0; s < Spacing; s++)
                    Ln += ' ';
                WriteLine(Ln, "", Color.White);
            }
            Color colorCustom = (Color)new ColorConverter().ConvertFromString("#1D97C");
            Write("\n\tAutor JAX", "", colorCustom);
            Write("   |   ", "", Color.White);
            Write($"Versión de desarrollo {_variables.VersionApplication} ", "", colorCustom); Console.Write(Convert.ToString(_variables.VersionBeta ? "Beta" : ""), Color.Red);
            Write("   |   ", "", Color.White);
            Write("github.com/JAX20/", "", colorCustom);
            Console.WriteLine("\n");
        }

        public void ShowDetailsOwner()
        {
            WriteLine(((Equals(_ownerProfile.userProfile.gender, "male") ? "Bienvenido " : "Bienvenida ") + _ownerProfile.facebookProfile.name), "Cheat", Color.White);
            //WriteLine("Cantidad de monedas: " + _ownerProfile.userProfile.coins);
            WriteLine("");
        }

        public void ShowInformationGame()
        {
            int correct_answer = _gameInformation.spins_data.spins[0].questions[0].question.correct_answer;
            for (int n = 1; n <= _variables.ConsoleWindowWidth; n++)
            {
                Write("-", "", Color.White, Color.Black);
            }
            WriteLine("");
            WriteLine("█ Información de la partida - " + DateTime.Now, "", Color.Gold);
            WriteLine("  Categoría: " + _gameInformation.spins_data.spins[0].questions[0].question.category, "", Color.Cyan);
            WriteLine("  Pregunta: " + _gameInformation.spins_data.spins[0].questions[0].question.text, "", Color.Cyan);
            WriteLine("  Respuestas: " + string.Join(", ", _gameInformation.spins_data.spins[0].questions[0].question.answers), "", Color.Cyan);
            Write("  Respuesta correcta: ", "", Color.Cyan);
            WriteLine(_gameInformation.spins_data.spins[0].questions[0].question.answers[correct_answer], "", Color.GreenYellow);
        }

        public void Write(string body, string head = "", Color? foregroundColor = null, Color? backgroundColor = null)
        {
            Console.ForegroundColor = foregroundColor ?? _variables.DefaultForegroundColor;
            Console.BackgroundColor = backgroundColor ?? _variables.DefaultBackgroundColor;

            if (head != string.Empty)
                Console.Write($"[{head}] ");
            Console.Write($"{body}");
        }
        public void WriteLine(string body, string head = "", Color? foregroundColor = null, Color? backgroundColor = null)
        {
            Console.ForegroundColor = foregroundColor ?? _variables.DefaultForegroundColor;
            Console.BackgroundColor = backgroundColor ?? _variables.DefaultBackgroundColor;

            if (head != string.Empty)
                Console.Write($"[{head}] ");
            Console.WriteLine($"{body}");
        }

        public void WriteError(string error)
        {
            WriteLine(error, "Error", Color.Red);
        }
        public void WriteError(Exception error)
        {
            WriteLine("Information error: " + error.Message + Environment.NewLine + error.StackTrace, "Error", Color.Red);
        }
    }
}