using genie.cast;
using genie.script;
using genie;

namespace MineSweeper {
    class InitializeBoardAction : genie.script.Action {
        
        private string path;

        public InitializeBoardAction(int priority, string path = "") :
        base(priority) {
            this.path = path;
        }

        private void ReadBoard(string path) {

        }

        override public void execute(Cast cast, Script script, Clock clock, Callback callback) {
            Board? board = (Board?)(cast.GetFirstActor("board"));

            if (board != null) {
                (int r, int c) dimension = board.GetDimension();
                Console.WriteLine(dimension);
                List<List<Square>> squares = board.GetSquares();

                for(int i = 0; i < dimension.r; i++) {
                    for (int j = 0; j < dimension.c; j++) {
                        cast.AddActor("squares", squares[i][j]);
                    }
                }
            }

            script.RemoveAction("input", this);
        }
    }
}