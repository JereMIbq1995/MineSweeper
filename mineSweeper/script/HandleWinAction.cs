using genie.cast;
using genie.script;
using genie.services;
using genie.services.raylib;
using genie;

namespace MineSweeper
{
    class HandleWinAction : genie.script.Action
    {
        private (int, int) W_SIZE;

        public HandleWinAction(int priority, (int, int) W_SIZE) : //, RaylibMouseService mouseService, RaylibPhysicsService physicsService, (int, int) W_SIZE) :
        base(priority)
        {
            this.W_SIZE = W_SIZE;
        }

        override public void execute(Cast cast, Script script, Clock clock, Callback callback)
        {
            Board? board = (Board?)(cast.GetFirstActor("board"));
            if (board != null) {                
                if (board.IsSwept()) {
                    Actor winMessage = new Actor("./mineSweeper/assets/Win.png", 370, 66, W_SIZE.Item1 / 2, W_SIZE.Item2 / 2);
                    cast.AddActor("winMessage", winMessage);
                }
            }
        }
    }
}