using genie.cast;
using genie.script;
using genie;

namespace MineSweeper {
    class InitializeBoardAction : genie.script.Action {
        
        private string path;
        private (int, int) w_size;
        private (int, int) boardDimension;

        public InitializeBoardAction(int priority, (int, int) w_size, (int, int) boardDimension, string path = "") :
        base(priority) {
            this.w_size = w_size;
            this.boardDimension = boardDimension;
            this.path = path;
        }

        private HashSet<int> GetMinesIndicesSet() {
            int numSquares = boardDimension.Item1 * boardDimension.Item2;
            int numMines = (int) (0.15 * numSquares); //about 20% of squares are mines
            int numMineGenerated = 0;

            HashSet<int> mineIndices = new HashSet<int>();
            Random rnd = new Random();

            while (numMineGenerated != numMines) {
                int num = rnd.Next(0, numSquares);
                if (!mineIndices.Contains(num)) {
                    mineIndices.Add(num);
                    numMineGenerated++;
                }
            }

            return mineIndices;
        }

        private List<List<bool>> GenerateMineGrid() {
            List<List<bool>> mineGrid = new List<List<bool>>();

            for (int i = 0; i < boardDimension.Item1; i++) {
                mineGrid.Add(new List<bool>());
                for (int j = 0; j < boardDimension.Item2; j++) {
                    mineGrid[i].Add(false);
                }
            }

            HashSet<int> mineIndices = GetMinesIndicesSet();

            foreach (int mineIndex in mineIndices) {
                int row = (int) (mineIndex / boardDimension.Item2);
                int col = mineIndex % boardDimension.Item2;
                mineGrid[row][col] = true;
            }

            return mineGrid;
        }

        override public void execute(Cast cast, Script script, Clock clock, Callback callback) {
            List<List<bool>> mineGrid = GenerateMineGrid();

            Board board = new Board(this.boardDimension, mineGrid, "", this.w_size.Item1 - 50, this.w_size.Item2 - 50, this.w_size.Item1 / 2, this.w_size.Item2 / 2);

            // Give actors to cast
            cast.AddActor("board", board);

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