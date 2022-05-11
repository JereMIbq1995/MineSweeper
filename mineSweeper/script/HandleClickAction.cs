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
        private (int, int) W_SIZE;

        public HandleClickAction(int priority, RaylibMouseService mouseService, RaylibPhysicsService physicsService, (int,int) W_SIZE) :
        base(priority) {
            this.mouseService = mouseService;
            this.physicsService = physicsService;
            this.board = null;
            this.isLost = false;
            this.W_SIZE = W_SIZE;
        }

        override public void execute(Cast cast, Script script, Clock clock, Callback callback)
        {
            if (this.board == null) {
                this.board = (Board?)(cast.GetFirstActor("board"));
            }

            if (this.mouseService.IsButtonPressed(Mouse.LEFT) && board != null && !this.isLost && !board.IsSwept()) {
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
                    Actor lostMessage = new Actor("./mineSweeper/assets/Lost.png", 370, 66, W_SIZE.Item1/2, W_SIZE.Item2/2);
                    cast.AddActor("lostMessage", lostMessage);
                }
            }
        }
    }
}