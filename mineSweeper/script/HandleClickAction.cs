using genie.cast;
using genie.script;
using genie.services;
using genie.services.raylib;
using genie;

namespace MineSweeper
{
    class HandleClickAction : genie.script.Action
    {
        private RaylibMouseService mouseService;
        private RaylibPhysicsService physicsService;
        private Board? board;
        private bool isLost;

        public HandleClickAction(int priority, RaylibMouseService mouseService, RaylibPhysicsService physicsService) :
        base(priority) {
            this.mouseService = mouseService;
            this.physicsService = physicsService;
            this.board = null;
            this.isLost = false;
        }

        override public void execute(Cast cast, Script script, Clock clock, Callback callback)
        {
            if (this.board == null) {
                this.board = (Board?)(cast.GetFirstActor("board"));
            }

            if (this.mouseService.IsButtonPressed(Mouse.LEFT) && board != null && !this.isLost) {
                List<Actor> squares = cast.GetActors("squares");
                System.Numerics.Vector2 mouseCoordinates = mouseService.GetCurrentCoordinates();
                (float, float) mouseCoorTuple = (mouseCoordinates.X, mouseCoordinates.Y);
                
                foreach (Square square in squares) {
                    if (this.physicsService.CheckCollisionPoint(square, mouseCoorTuple)) {
                        (int row, int col) boardCoor = square.GetBoardCoordinates();
                        this.isLost = board.Click(boardCoor.row, boardCoor.col);
                        break;
                    }
                }

                if (this.isLost) {
                    board.RevealAllMines();
                }
            }
        }
    }
}