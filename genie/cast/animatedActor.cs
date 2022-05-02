namespace genie.cast {
    class AnimatedActor : Actor {
        
        // Private member variables
        private List<string> paths;
        private float animationSpeed;
        private bool isAnimating;
        private bool eventTriggered;
        private float currentFrame;

        // Constructor
        public AnimatedActor(List<string> paths, int width, int height,
                            int animationFPS = 10, int gameFPS = 60,
                            bool eventTriggered = true,
                            float x = 0, float y = 0, float vx = 0, float vy = 0,
                            float rotation = 0, float rotationVel = 0,
                            bool flipped = false) : 
        base(paths[0], width, height, x, y, vx, vy, rotation, rotationVel, flipped)
        {
            this.paths = paths;
            this.animationSpeed = (float)animationFPS / (float)gameFPS;
            this.isAnimating = eventTriggered ? false : true;
            this.eventTriggered = eventTriggered;
            this.currentFrame = 0;
        }

        public List<string> GetPaths() {
            return this.paths;
        }

        public void SetPaths(List<string> paths) {
            this.paths = paths;
        }

        public string GetCurrentPath() {
            return this.paths[(int)(this.currentFrame)];
        }

        public float GetAnimationSpeed() {
            return this.animationSpeed;
        }

        public void SetAnimationSpeed(float animationSpeed) {
            this.animationSpeed = animationSpeed;
        }

        public bool IsAnimating() {
            return this.isAnimating;
        }

        public void SetAnimating(bool animating) {
            this.isAnimating = animating;
        }

        public void SetNextFrame() {
            if (this.isAnimating) {
                this.currentFrame += this.animationSpeed;

                if ((int)this.currentFrame >= this.paths.Count) {
                    this.currentFrame = 0;
                    if (this.eventTriggered) {
                        this.isAnimating = false;
                    }
                }

                base.SetPath(this.paths[(int)this.currentFrame]);
            }
        }
    }
}