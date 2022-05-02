using genie.cast;

namespace MineSweeper
{
    class Board : Actor
    {
        private (int, int) dimension;
        private bool[,] mineGrid;
        private List<List<Square>> squares;

        public Board((int, int) dimension, bool[,] mineGrid,
                    string path, int width, int height,
                    float x = 0, float y = 0,
                    float vx = 0, float vy = 0,
                    float rotation = 0, float rotationVel = 0,
                    bool flipped = false) :
        base(path, width, height, x, y, vx, vy, rotation, rotationVel, flipped)
        {
            this.dimension = dimension;
            this.mineGrid = mineGrid;
            this.squares = new List<List<Square>>();

            this.PopulateBoard();
        }

        private void PopulateBoard() {
            int width = this.GetWidth() / this.dimension.Item2;
            int height = this.GetHeight() / this.dimension.Item1;
            (float, float) topLeft = this.GetTopLeft();

            for (int i = 0; i < dimension.Item1; i++) {
                squares.Add(new List<Square>());
                for (int j = 0; j < dimension.Item2; j++) {
                    float x = topLeft.Item1 + width/2 + j*width;
                    float y = topLeft.Item2 + height/2 + i*height;
                    squares[i].Add(new Square("mineSweeper/assets/square-hidden.png", width, height, (i, j), "", x, y));
                }
            }
        }

        public bool IsMine(int r, int c) {
            return mineGrid[r, c];
        }

        public List<List<Square>> GetSquares() {
            return this.squares;
        }

        public (int, int) GetDimension() {
            return this.dimension;
        }
        
        private void ExploreSquare(int row, int col) {
            (int x, int y)[] neighbors = new (int x, int y)[8] {
                (row-1,col-1), (row-1, col), (row-1, col+1),
                (row, col-1), (row, col+1),
                (row+1,col-1), (row+1, col), (row+1, col+1)
            };

            // If indexes are invalid, OR if it's a bomb, OR if the square is already revealed, then return.
            if (row < 0 || col < 0 || row >= dimension.Item1 || col >= dimension.Item2 || mineGrid[row, col] || squares[row][col].IsRevealed()) {
                return;
            }
            
            // First, reveal the square being explored
            squares[row][col].Reveal();

            // Count the number of mines among the neighbors
            int numMines = 0;
            foreach ((int x, int y) neighbor in neighbors)
            {
                if (neighbor.x >= 0 && neighbor.y >= 0 && neighbor.x < dimension.Item1 && neighbor.y < dimension.Item2) {
                    numMines += mineGrid[neighbor.x, neighbor.y] ? 1 : 0;
                }
            }

            // If the number of mines around the current square is > 0,
            // reveal the square, but do not explore the neighbor
            if (numMines > 0) {
                squares[row][col].SetDisplaySymbol(numMines.ToString());
            }
            // If the number of mines around the current square is 0,
            // Then explore all of its neighbor
            else {
                foreach ((int x, int y) neighbor in neighbors) {
                    ExploreSquare(neighbor.x, neighbor.y);
                }
            }
        }

        public void RevealAllMines() {
            for (int r = 0; r < dimension.Item1; r++) {
                for (int c = 0; c < dimension.Item2; c++) {
                    if (mineGrid[r,c]) {
                        squares[r][c].Reveal(true);
                    }
                }
            }
        }

        // Return True if hit a bomb, False otherwise
        public bool Click(int row, int col) {
            if (mineGrid[row, col]) {
                squares[row][col].Reveal(true);
                return true;
            }
            else {
                ExploreSquare(row, col);
                return false;
            }
        }
    }
}