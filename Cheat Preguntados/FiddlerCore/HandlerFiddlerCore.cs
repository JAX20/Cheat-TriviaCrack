using System.Text;
using Fiddler;
using Cheat_Preguntados.Game;
using System.Drawing;
using Console = Colorful.Console;
using System.Collections.Generic;
using System;
using System.Web.Script.Serialization;

namespace Cheat_Preguntados.FiddlerCore
{
    public class HandlerFiddlerCore : Core
    {
        public void Start()
        {
            _consoleOutput.WriteLine("Iniciando proxy...", "Cheat");
            FiddlerApplication.AfterSessionComplete += FiddlerApplication_AfterSessionComplete; // Create event AfterSessionComplete. This event fires when a session has been completed
            FiddlerApplication.Startup(8888, FiddlerCoreStartupFlags.Default); // Start FiddlerCore listening on the specified port
            _consoleOutput.WriteLine("Instalando certificado SSL...", "Cheat");
            Certificate.Install(); // Create certificate for use in HTTPS interception
        }

        private void FiddlerApplication_AfterSessionComplete(Session oSession)
        {
            try
            {
                /*
                 * Example query urls
                 * Details of the game and opponent: https://api.preguntados.com/api/users/IDOWNER/games/IDGAME
                 * Details of the owner: https://api.preguntados.com/api/users/IDOWNER/
                 * https://api.preguntados.com/api/social-login // Full profile
                 * https://api.preguntados.com/api/users/IDOWNER/dashboard
                 */
                string FullUrl = oSession.fullUrl;
                string[] FullUrlParameters = FullUrl.Split('/');
                if (FullUrl.StartsWith("https://api.preguntados.com/api/") & _variables.ImStarted)
                {
                    if (FullUrl.Contains("users") & FullUrl.Contains("games")) // Get details of the opponent and information of the game (questions, correct answer ...) and others details
                    {
                        Dictionary<object, object> gameData = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<object, object>>(Encoding.UTF8.GetString(oSession.ResponseBody));

                        /* Type of game: classic or duel*/
                        _gameInformation.duelGameType = bool.Parse(gameData["duelGameType"].ToString());

                        if (_gameInformation.duelGameType) // Duel mode
                        {

                        }
                        else // Classic mode
                        {
                            //_gameInformation = Newtonsoft.Json.JsonConvert.DeserializeObject<GameInformation>(Encoding.UTF8.GetString(oSession.ResponseBody));
                            //_gameInformation.questionClassicMode.category = gameData["category"].ToString();

                            //object a = new JavaScriptSerializer().Deserialize(gameData["spins_data"].ToString(), typeof(object));

                            Dictionary<string, object> sData = new JavaScriptSerializer().Deserialize<Dictionary<string, object>>(gameData["spins_data"].ToString());
                            string getSpins = Newtonsoft.Json.JsonConvert.SerializeObject(sData["spins"], Newtonsoft.Json.Formatting.Indented);

                            /* JSON ARRAY; Contain type (crown, normal or duel game), questions, answers, powerup_question and second_chande_question */
                            var JSONArray = Newtonsoft.Json.JsonConvert.DeserializeObject<List<object>>(getSpins.ToString());
                            if (JSONArray.Count >= 1)
                            {
                                foreach (var i in JSONArray)
                                {
                                    var js = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, object>>(i.ToString());
                                    _gameInformation.type = js["type"].ToString();
                                    _gameInformation.SecondChanceAvailable = bool.Parse(js["second_chance_available"].ToString());
                                    if (_gameInformation.type == "CROWN")
                                    {
                                        var AllQuestionsAndAnswers = Newtonsoft.Json.JsonConvert.DeserializeObject<List<object>>(js["questions"].ToString());
                                        foreach (var temp in AllQuestionsAndAnswers)
                                            GameInformationClassicMode.CROWN.ListQuestionsFromTheCategories.Add(Newtonsoft.Json.JsonConvert.DeserializeObject<GameInformationClassicMode.CROWN>(temp.ToString()));
                                        _consoleOutput.ShowInformationGame();
                                        return;
                                    }
                                    else if (_gameInformation.type == "NORMAL")
                                    {
                                        /* Remove characters not necessary */
                                        getSpins = getSpins.Substring(1, getSpins.Length - 2);

                                        var spinsToObject = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, object>>(getSpins.ToString());

                                        //_gameInformation.SecondChanceAvailable = bool.Parse(spinsToObject["second_chance_available"].ToString());

                                        /* Gets JSON string with the question, powerup_question and second_chande_question from variable spinsToObject */
                                        string getQuestion_PowerupQuestion_SecondQuestion = spinsToObject["questions"].ToString();
                                        /* Remove characters not necessary */
                                        getQuestion_PowerupQuestion_SecondQuestion = getQuestion_PowerupQuestion_SecondQuestion.Substring(1, getQuestion_PowerupQuestion_SecondQuestion.Length - 2);
                                        /* Converto to Object the variable getQuestionsArray */
                                        var questionsArrayToObject = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, object>>(getQuestion_PowerupQuestion_SecondQuestion.ToString());


                                        //var questions = Newtonsoft.Json.JsonConvert.DeserializeObject<test>(a2.ToString());

                                        /* Gets JSON string with only the question and a Array with the answers, the category, the correct answer ... */
                                        string getQuestion = questionsArrayToObject["question"].ToString();
                                        /* Create a instance a the class GameInformationClassicMode for after to have acceso. 
                                         * Also stores the content the variable  getQuestionsArray in the class GameInformationClassicMode.*/
                                        _gameInformationClassicMode = Newtonsoft.Json.JsonConvert.DeserializeObject<GameInformationClassicMode>(getQuestion.ToString());

                                        /* Gets JSON string for second chance question. It contain question and a Array with the answers, the category, the correct answer ... */
                                        string getSecondChanceQuestion = questionsArrayToObject["second_chance_question"].ToString();
                                        /* Create a instance a the class SecondChanceQuestion for after to have access. 
                                         * Also stores the content the variable  getSecondChanceQuestion in the class SecondChanceQuestion.*/
                                        if (_gameInformation.SecondChanceAvailable)
                                            _SecondChanceQuestion = Newtonsoft.Json.JsonConvert.DeserializeObject<GameInformationClassicMode.SecondChanceQuestion>(getSecondChanceQuestion.ToString());

                                        //object value = "";
                                        //var result = sData.TryGetValue("type", out value);
                                        //var categor = sData[0];
                                        //_gameInformation.questionClassicMode.category = a[0];
                                    }
                                }
                                _consoleOutput.ShowInformationGame();
                            }
                        }
                    }
                    if (FullUrlParameters[4] == "social-login") // Login data
                    {
                        Dictionary<object, object> loginData = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<object, object>>(Encoding.UTF8.GetString(oSession.ResponseBody));

                        /* User profile*/
                        _ownerProfile.userProfile.id = int.Parse((loginData["id"].ToString()));
                        _ownerProfile.userProfile.username = loginData["username"].ToString();
                        _ownerProfile.userProfile.gender = loginData["gender"].ToString();

                        /* Facebook profile*/
                        _ownerProfile.facebookProfile.id = loginData["facebook_id"].ToString();
                        _ownerProfile.facebookProfile.name = loginData["facebook_name"].ToString();

                        /* Remaining (they are not necessary): online_status, session, description, zip_codes, fb_show_picture, allow_og_post, twitter_name, fb_show_name, has_pass, phone, photo_url and email */

                        /* Shows on the console*/
                        _consoleOutput.ShowDetailsOwner();
                    }
                    if (FullUrlParameters[6] == "dashboard?app_config_version=0") // Dashboard data from the game
                    {
                        Dictionary<object, object> dashboardData = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<object, object>>(Encoding.UTF8.GetString(oSession.ResponseBody));

                        /* User profile*/
                        _ownerProfile.userProfile.coins = int.Parse(dashboardData["coins"].ToString());
                        _ownerProfile.userProfile.country = dashboardData["country"].ToString();
                        _variables.Language = dashboardData["country"].ToString();
                        _ownerProfile.lives.quantity = int.Parse(dashboardData["quantity"].ToString());
                        _ownerProfile.lives.max = int.Parse(dashboardData["max"].ToString());
                        _ownerProfile.lives.unlimited = bool.Parse(dashboardData["unlimited"].ToString());

                        /* Inbox */
                        _ownerProfile.inbox.total = int.Parse(dashboardData["total"].ToString());
                        _ownerProfile.inbox.news = int.Parse(dashboardData["news"].ToString());
                        _ownerProfile.inbox.unread_conversations = int.Parse(dashboardData["unread_conversations"].ToString());

                        /* LevelData */
                        _ownerProfile.level_data.level = int.Parse(dashboardData["level"].ToString());
                        _ownerProfile.level_data.points = int.Parse(dashboardData["points"].ToString());
                        _ownerProfile.level_data.goal_points = int.Parse(dashboardData["goal_points"].ToString());
                        _ownerProfile.level_data.progress = int.Parse(dashboardData["progress"].ToString());
                        _ownerProfile.level_data.level_up = bool.Parse(dashboardData["level_up"].ToString());
                    }
                }
            }
            catch (Exception e)
            {

            }
        }

        public void Stop()
        {
            _consoleOutput.WriteLine("Stopping proxy...", "Cheat");
            FiddlerApplication.Shutdown(); // Stop proxy
            //Certificate.Uninstall(); // Removes Fiddler generated certificates.
        }
    }
}