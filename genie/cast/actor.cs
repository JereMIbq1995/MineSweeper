namespace genie.cast {
    /***********************************************************
    * Actor:
    *    A thing that participates in an animation. Anything that either MOVES, can be DRAWN
    *    on the screen, or BOTH is an actor.
    *    For the purpose of collision checking, all actors are represented with the shape of a RECTANGLE.
    *    
    *    Attributes:
    *        _path : The file path of the image of the actor. Should be a path to a .png file
    *        _width : Width of the actor. Used to scale the image AND to determine the hit box
    *        _height : Height of the actor. Used to scale the image AND to determine the hit box
    *        
    *        _x : the x coordinate of the center of the rectangle
    *        _y : the y coordinate of the position
    *        
    *        _vx : the horizontal velocity
    *        _vy : the vertical velocity
    *        
    *        _rotation : How many degrees you want to rotate the image, with 0 being the original position.
    *        _rotational_vel : Rotational velocity. How many degrees you want the actor to rotate each frame.
    *                            When this value is set, the actor will be constantly rotating.
    *        
    *        _mirrored : Do you want the image of the actor to be mirrored?
    *
    *        Note: A lot of the animations, scaling, image transformations,... will be handled for you
    *                when an actor is passed to draw_actors() in the screen service. All you need
    *                to do is setting these values correctly here.
    ************************************************************/
    public class Actor {

        // Private member variables (Fields)
        private string path;
        private int width;
        private int height;
        
        private float x;
        private float y;
        private float vx;
        private float vy;

        private float rotation;
        private float rotationVel;

        private bool flipped;

        // These are used by physics service. Users probably don't need this.
        private float previousX;
        private float previousY;


        // Public methods:

        // Constructor
        public Actor(string path, int width, int height,
                    float x = 0, float y = 0,
                    float vx = 0, float vy = 0,
                    float rotation = 0, float rotationVel = 0,
                    bool flipped = false) {
            this.path = path;

            this.width = width;
            this.height = height;

            this.x = x;
            this.y = y;

            this.vx = vx;
            this.vy = vy;

            this.rotation = rotation;
            this.rotationVel = rotationVel;

            this.flipped = flipped;

            this.previousX = x;
            this.previousY = y;
        }
        
        
        // Set/Get methods for path
        public string GetPath() {
            return this.path;
        }

        public void SetPath(string path) {
            this.path = path;
        }

        
        // Set/Get methods for width and height
        public int GetWidth() {
            return this.width;
        }

        public void SetWidth(int width) {
            this.width = width;
        }

        public int GetHeight() {
            return this.height;
        }

        public void SetHeight(int height) {
            this.height = height;
        }

        // Actor
        public (float x, float y) GetPosition() {
            return (this.x, this.y);
        }

        // Set/Get methods for x and y
        public float GetX() {
            return this.x;
        }

        public void SetX(float x) {
            this.x = x;
        }

        public float GetY() {
            return this.y;
        }

        public void SetY(float y) {
            this.y = y;
        }

        // GetPrevious data (coordinates and corners of previous frame)
        public float GetPreviousX()
        {
            return this.previousX;
        }

        public float GetPreviousY()
        {
            return this.previousY;
        }

        public (float, float) GetPreviousTopLeft()
        {
            return (this.previousX - this.width / 2, this.previousY - height / 2);
        }

        public (float, float) GetPreviousTopRight()
        {
            return (this.previousX + this.width / 2, this.previousY - height / 2);
        }

        public (float, float) GetPreviousBottomLeft()
        {
            return (this.previousX - this.width / 2, this.previousY + height / 2);
        }

        public (float, float) GetPreviousBottomRight()
        {
            return (this.previousX + this.width / 2, this.previousY + height / 2);
        }

        // Set/Get methods for vx and vy
        public float GetVx() {
            return this.vx;
        }

        public void SetVx(float vx) {
            this.vx = vx;
        }

        public float GetVy() {
            return this.vy;
        }

        public void SetVy(float vy) {
            this.vy = vy;
        }

        // Getters for top-left corner of the rectangle
        public (float, float) GetTopLeft() {
            return (this.x - this.width/2, this.y - this.height/2);
        }
        
        public (float, float) GetTopRight()
        {
            return (this.x + this.width / 2, this.y - this.height / 2);
        }

        public (float, float) GetBottomLeft()
        {
            return (this.x - this.width / 2, this.y + this.height / 2);
        }

        public (float, float) GetBottomRight()
        {
            return (this.x + this.width / 2, this.y + this.height / 2);
        }

        // Set/Get methods for rotation and rotation_vel
        public float GetRotation() {
            return this.rotation;
        }

        public void SetRotation(float rotation) {
            this.rotation = rotation;
        }

        public float GetRotationVel() {
            return this.rotationVel;
        }

        public void SetRotationVel(float rotationVel) {
            this.rotationVel = rotationVel;
        }

        // Set/Get methods for flipped
        public bool GetFlipped() {
            return this.flipped;
        }

        public void SetFlipped(bool flipped) {
            this.flipped = flipped;
        }

        // Move functions:
        public void MoveWithVelocity() {
            this.previousX = this.x;
            this.previousY = this.y;
            this.x += this.vx;
            this.y += this.vy;
        }

        public void Rotate() {
            this.rotation += this.rotationVel;
        }
    }
}