using genie.cast;
using genie.services;

namespace MineSweeper {
    class Square : Actor {
        
        private bool revealed;
        private (int, int) boardCoordinate;
        private string displaySymbol;
        private Color displaySymbolColor;

        public Square(string path, int width, int height, (int, int) boardCoordinate,
                    string displaySymbol = "",
                    float x = 0, float y = 0,
                    float vx = 0, float vy = 0,
                    float rotation = 0, float rotationVel = 0,
                    bool flipped = false) : 
        base(path, width, height, x, y, vx, vy, rotation, rotationVel, flipped) {
            this.displaySymbol = displaySymbol;
            this.revealed = false;
            this.boardCoordinate = boardCoordinate;
            this.displaySymbolColor = Color.BLACK;
        }

        public string GetDisplaySymbol() {
            return this.displaySymbol;
        }

        public void SetDisplaySymbol(string displaySymbol) {
            this.displaySymbol = displaySymbol;
        }

        public void Reveal(bool mine = false) {
            if (mine) {
                this.SetPath("mineSweeper/assets/square-mine.png");
            }
            else {
                this.SetPath("mineSweeper/assets/square-clicked.png");
            }
            this.revealed = true;
        }

        public bool IsRevealed() {
            return this.revealed;
        }

        public Color GetDisplayedSymbolColor() {
            return this.displaySymbolColor;
        }

        public void SetDisplaySymbol(Color color) {
            this.displaySymbolColor = color;
        }

        public (int, int) GetBoardCoordinates() {
            return this.boardCoordinate;
        }
    }
}