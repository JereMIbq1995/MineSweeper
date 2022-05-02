using Raylib_cs;

using genie;
using genie.cast;
using genie.script;
using genie.test;
using genie.services;
using genie.services.raylib;

namespace MineSweeper
{
    public static class Program
    {
        public static void Test()
        {
            // MouseMap mouseMap = new MouseMap();
            // mouseMap.getRaylibMouse(-1);

            // CastScriptTest castScriptTest = new CastScriptTest();
            // castScriptTest.testCast();
            // castScriptTest.testScript();

            ServicesTest servicesTest = new ServicesTest();
            servicesTest.TestScreenService();

            // Director director = new Director();
            // director.DirectScene();
        }

        public static void Main(string[] args)
        {
            // A few game constants
            (int, int) W_SIZE = (700, 700);

            string SCREEN_TITLE = "Mine Sweeper";
            int FPS = 120;

            // Initiate all services
            RaylibKeyboardService keyboardService = new RaylibKeyboardService();
            RaylibPhysicsService physicsService = new RaylibPhysicsService();
            RaylibScreenService screenService = new RaylibScreenService(W_SIZE, SCREEN_TITLE, FPS);
            RaylibAudioService audioservice = new RaylibAudioService();
            RaylibMouseService mouseService = new RaylibMouseService();

            // Create the director
            Director director = new Director();

            // Create the cast
            Cast cast = new Cast();
            bool[,] mineGrid = new bool[7,7] {
                {false, false, false, true, false, false, false},
                {false, true, false, false, false, false, false},
                {false, true, false, true, false, true, false},
                {false, false, false, false, false, false, true},
                {false, false, false, false, false, false, true},
                {false, false, false, false, false, false, false},
                {false, true, false, true, false, false, false},
            };

            Board board = new Board((7,7), mineGrid, "", W_SIZE.Item1-50, W_SIZE.Item2-50, W_SIZE.Item1/2, W_SIZE.Item2/2);

            // Give actors to cast
            cast.AddActor("board", board);

            // Create the script
            Script script = new Script();

            // Add all input actions
            script.AddAction("input", new HandleQuitAction(1, screenService));
            script.AddAction("input", new InitializeBoardAction(1));
            script.AddAction("input", new HandleClickAction(1, mouseService, physicsService));

            // Add all update actions
            // script.AddAction("update", new HandleGameOverAction(1));

            // Add all output actions
            script.AddAction("output", new DrawActorsAction(1, screenService));
            script.AddAction("output", new UpdateScreenAction(2, screenService));

            // Yo, director, do your thing!
            director.DirectScene(cast, script);
        }
    }
}