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
            /* Separator from games*/
            for (int n = 1; n <= _variables.ConsoleWindowWidth; n++)
            {
                Write("-", "", Color.White, Color.Black);
            }
            WriteLine("");
            Write("█ Información de la partida - " + DateTime.Now, "", Color.Gold);

            if (!_gameInformation.duelGameType) // Classic mode
            {
                WriteLine("  -  Modo de juego Clásico", "", Color.Gold);
                if (_gameInformation.type == "CROWN") // category crown
                {
                    WriteLine("  Ha salido CORONA en la ruleta. Estas son las respuestas de cada categoría:", "", Color.White);
                    WriteLine("");
                    int num = 1;

                    /* Shows all questions and ansers */
                    foreach (var infor in Game.GameInformationClassicMode.CROWN.ListQuestionsFromTheCategories)
                    {
                        WriteLine($"  {num}. CATEGORÍA {infor.question.category}", "", Color.LightGoldenrodYellow);
                        WriteLine("     Pregunta: " + infor.question.text, "", Color.Cyan);
                        //WriteLine("     Respuestas: " + string.Join(", ", infor.question.answers), "", Color.Cyan);
                        Write("     Respuesta correcta: ", "", Color.Cyan);
                        WriteLine(infor.question.answers[infor.question.correct_answer], "", Color.GreenYellow);
                        WriteLine("");

                        if (_gameInformation.SecondChanceAvailable)
                        {
                            WriteLine("     [#] Pregunta de segunda oportunidad (en caso de haber fallado la anterior)", "", Color.White);
                            //WriteLine("     Categoría: " + infor.second_chance_question.category, "", Color.Cyan);
                            WriteLine("     Pregunta: " + infor.second_chance_question.text, "", Color.Cyan);
                            //WriteLine("     Respuestas: " + string.Join(", ", infor.second_chance_question.answers), "", Color.Cyan);
                            Write("     Respuesta correcta: ", "", Color.Cyan);
                            WriteLine(infor.second_chance_question.answers[infor.second_chance_question.correct_answer], "", Color.GreenYellow);
                            WriteLine("");
                        }
                        else
                            WriteLine("  [#] Has agotado la pregunta de segunda oportunidad.", "", Color.White);
                        num++;
                    }
                    Game.GameInformationClassicMode.CROWN.ListQuestionsFromTheCategories.Clear();
                }
                else // Type normal, you play one character only 
                {
                    WriteLine("  Categoría: " + _gameInformationClassicMode.category, "", Color.Cyan);
                    WriteLine("  Pregunta: " + _gameInformationClassicMode.text, "", Color.Cyan);
                    //WriteLine("  Respuestas: " + string.Join(", ", _gameInformationClassicMode.answers), "", Color.Cyan);
                    Write("  Respuesta correcta: ", "", Color.Cyan);
                    WriteLine(_gameInformationClassicMode.answers[_gameInformationClassicMode.correct_answer], "", Color.GreenYellow);
                    WriteLine("");

                    if (_gameInformation.SecondChanceAvailable)
                    {
                        WriteLine("  [#] Pregunta de segunda oportunidad (en caso de haber fallado la anterior)", "", Color.White);
                        WriteLine("  Categoría: " + _SecondChanceQuestion.category, "", Color.Cyan);
                        WriteLine("  Pregunta: " + _SecondChanceQuestion.text, "", Color.Cyan);
                        //WriteLine("  Respuestas: " + string.Join(", ", _SecondChanceQuestion.answers), "", Color.Cyan);
                        Write("  Respuesta correcta: ", "", Color.Cyan);
                        WriteLine(_SecondChanceQuestion.answers[_SecondChanceQuestion.correct_answer], "", Color.GreenYellow);
                        WriteLine("");
                    }
                    else
                        WriteLine("  [#] Has agotado la pregunta de segunda oportunidad.", "", Color.White);
                }
            }
            else if (_gameInformation.duelGameType) // Duel mode
            {

            }
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