using genie;
using genie.cast;
using genie.script;
using genie.services;
using genie.services.raylib;

namespace MineSweeper
{
    class HandleQuitAction : genie.script.Action
    {

        private RaylibScreenService screenService;

        public HandleQuitAction(int priority, RaylibScreenService screenService) : base(priority)
        {
            this.screenService = screenService;
        }

        public override void execute(Cast cast, Script script, Clock clock, Callback callback)
        {
            // If the X (close) button on the top right of game window is clicked, stop the game 
            if (this.screenService.IsQuit()) {
                callback.OnStop();
            }
        }
    }
}