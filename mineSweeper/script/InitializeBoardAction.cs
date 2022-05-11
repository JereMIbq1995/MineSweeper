using genie.cast;
using genie.script;
using genie;

namespace MineSweeper {
    class InitializeBoardAction : genie.script.Action {
        
        private string path;
        private (int, int) w_size;
        private (int, int) boardDimension;
        private int numSquares;
        private float percentMines;         // percentMines: How many percent of the number of squares are mines?

        public InitializeBoardAction(int priority, (int, int) w_size, (int, int) boardDimension, float percentMines, string path = "") :
        base(priority) {
            this.w_size = w_size;
            this.boardDimension = boardDimension;
            this.percentMines = percentMines;
            this.numSquares = this.boardDimension.Item1 * this.boardDimension.Item2;
            this.path = path;
        }

        // Return a random set of indices from 0 to <numSquares>, exclusively,
        // where the mines are. The number of indices in this set is the number
        // of mines
        private HashSet<int> GetMinesIndicesSet() {
            int numMines = (int)(this.percentMines * numSquares);
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

        // Generate a random 2D List of booleans which specify where the mines are.
        // True if there's a mine at the specified coordinate, False otherwise.
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

        // Execute...
        override public void execute(Cast cast, Script script, Clock clock, Callback callback) {

            // Generate the mineGrid
            List<List<bool>> mineGrid = GenerateMineGrid();

            // Create the board with the given mineGrid
            Board board = new Board(this.boardDimension, mineGrid, "", this.w_size.Item1 - 50, this.w_size.Item2 - 50, this.w_size.Item1 / 2, this.w_size.Item2 / 2);

            // Give board to the cast
            cast.AddActor("board", board);

            // Put all the Square objects contained in the board in the cast
            foreach (List<Square> row in board.GetSquares()) {
                foreach (Square square in row) {
                    cast.AddActor("squares", square);
                }
            }

            // This action should only happen once at the beginning of the game
            script.RemoveAction("input", this);
        }
    }
}