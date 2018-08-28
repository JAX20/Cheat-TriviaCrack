using System.Text;
using Fiddler;
using Cheat_Preguntados.Game;
using System.Drawing;
using Console = Colorful.Console;
using System.Collections.Generic;
using System;

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
                    #region Not Working
                    if (FullUrl.Contains("users") & !FullUrl.Contains("games")) // Get profile from owner. Not working
                    {
                        //PathAndQuery = "/api/users/IDOWNER/assets/web"

                        if (_ownerProfile == null & oSession.PathAndQuery.Split('/').Length == 4)
                        {
                            if (oSession.ResponseBody.Length > 5)
                            {
                                OwnerProfile profile = Newtonsoft.Json.JsonConvert.DeserializeObject<OwnerProfile>(Encoding.Default.GetString(oSession.ResponseBody));
                                _ownerProfile = profile;
                                _variables.DetectedTheDetailsFromOwner = true;
                            }
                        }
                    }
                    #endregion

                    if (FullUrl.Contains("users") & FullUrl.Contains("games")) // Get details of the opponent and information of the game (questions, correct answer ...) and others details
                    {
                        _gameInformation = Newtonsoft.Json.JsonConvert.DeserializeObject<GameInformation>(Encoding.UTF8.GetString(oSession.ResponseBody));
                        _consoleOutput.ShowInformationGame();
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