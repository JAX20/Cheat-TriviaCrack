﻿using Cheat_Preguntados.FiddlerCore;
using Cheat_Preguntados.Game;
using System;
using System.Drawing;
using System.Runtime.InteropServices;
using Console = Colorful.Console;

namespace Cheat_Preguntados
{
    public class Core
    {
        /*
         * Create instances of the class to use later
         */
        public static OwnerProfile _ownerProfile;
        public static GameInformation _gameInformation;
        public static GameInformationClassicMode _gameInformationClassicMode;
        public static GameInformationClassicMode.SecondChanceQuestion _SecondChanceQuestion;
        public static Variables _variables;
        public static HandlerFiddlerCore _handlerFiddlerCore;
        public static ConsoleOutput _consoleOutput;

        static void Main(string[] args)
        {
            try
            {    /*  #Instances
                 * Create an instance to the class.
                 *   Create the instances that are in the constructor
                 */
                _ownerProfile = new OwnerProfile();
                _gameInformation = new GameInformation();
                _gameInformationClassicMode = new GameInformationClassicMode();
                _SecondChanceQuestion = new GameInformationClassicMode.SecondChanceQuestion();
                _variables = new Variables();
                _handlerFiddlerCore = new HandlerFiddlerCore();
                _consoleOutput = new ConsoleOutput();
                /* #EndInstances*/

                handler = new ConsoleEventDelegate(ConsoleEventCallback); //Instance for the method ConsoleEventCallback
                SetConsoleCtrlHandler(handler, true); // Call to the API SetConsoleCtrlHandler
                _consoleOutput.ConsoleWelcome();
                _handlerFiddlerCore.Start(); // Start the proxy, install the certificate and the event for sessions capture
                _consoleOutput.WriteLine("Inicie ahora sesión en FaceBook si aún no lo hizo y luego entre en alguna partida que sea modo Clásico. \nEsperando...", "Cheat");
                _variables.ImStarted = true;
                _consoleOutput.WriteLine("");
                while (true) { System.Threading.Thread.Sleep(1800000); } // Prevent the application from closing
            }
            catch (Exception e)
            {
                _consoleOutput.WriteError(e);
                _handlerFiddlerCore.Stop();
                Certificate.Uninstall();
                _consoleOutput.WriteLine("\n\nThe application will close after pressing a key");
                Console.ReadKey();
            }
        }

        #region Console Application Exit 
        static ConsoleEventDelegate handler;
        private delegate bool ConsoleEventDelegate(int eventType);
        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern void SetConsoleCtrlHandler(ConsoleEventDelegate callback, bool add); // SetConsoleCtrlHandler is a function from kernel32.dll
        static bool ConsoleEventCallback(int eventType)
        {
            if (eventType == 2) // Close windows console
                _handlerFiddlerCore.Stop();
            return false;
        }
        #endregion
    }
}