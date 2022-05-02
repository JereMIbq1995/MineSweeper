using genie.cast;
using genie.script;
using genie.services;
using genie.services.raylib;
using genie;

namespace MineSweeper
{
    class HandleFlagAction : genie.script.Action
    {
        private RaylibMouseService mouseService;
        private RaylibPhysicsService physicsService;
        private Board? board;

        public HandleFlagAction(int priority, RaylibMouseService mouseService, RaylibPhysicsService physicsService) :
        base(priority)
        {
            this.mouseService = mouseService;
            this.physicsService = physicsService;
            this.board = null;
        }

        override public void execute(Cast cast, Script script, Clock clock, Callback callback)
        {
            if (this.board == null)
            {
                this.board = (Board?)(cast.GetFirstActor("board"));
            }

            if (this.mouseService.IsButtonPressed(Mouse.RIGHT) && board != null)
            {
                Console.WriteLine("Mouse Right clicked!");
                List<Actor> squares = cast.GetActors("squares");
                List<Actor> flags = cast.GetActors("flags");
                System.Numerics.Vector2 mouseCoordinates = mouseService.GetCurrentCoordinates();
                (float, float) mouseCoorTuple = (mouseCoordinates.X, mouseCoordinates.Y);

                bool placingFlag = true;
                foreach (Actor flag in flags) {
                    if (this.physicsService.CheckCollisionPoint(flag, mouseCoorTuple)) {
                        cast.RemoveActor("flags", flag);
                        placingFlag = false;
                        break;
                    }
                }

                if (placingFlag) {
                    foreach (Square square in squares)
                    {
                        if (this.physicsService.CheckCollisionPoint(square, mouseCoorTuple))
                        {
                            Actor flag = new Actor("mineSweeper/assets/flag.png", square.GetWidth(), square.GetHeight(), square.GetX(), square.GetY());
                            cast.AddActor("flags", flag);
                            break;
                        }
                    }
                }
            }
        }
    }
}