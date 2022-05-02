namespace genie {
    /***************************************************************************
    *   The animation clock.
    *    
    *    The responsibility of Clock is to keep track of time in both the real
    *    world and the animation world.See https://gameprogrammingpatterns.com/ for 
    *    a good explanation of how this works.
    *
    *    Attributes:
    *        _lag (float): The amount of time the animation is behind the real world.
    *        _last (float): The previously marked time in the real world.
    *        _frames (float): A running total of frames.
    *        _seconds (float): A running total of seconds.
    *        _updates (float): A running total of updates.
    ***************************************************************************/
    public class Clock {

        // Private member variables
        private float TIME_STEP = (float) (1.0 / 60.0);
        private float lag;
        private DateTime previous;
        private float frames;
        private float seconds;
        private float updates;
        
        // stats need some more thoughts...
        // private Dictionary<string, string> stats;

        // Constructor
        public Clock() {
            this.lag = 0;
            this.previous = DateTime.Now;
            this.frames = 0;
            this.seconds = 0;
            this.updates = 0;
        }

        /***********************************************************
        * Catches animation time up by one fixed time step.
        * This method should be called once at the end of each frame's update phase.
        ***********************************************************/
        public void CatchUp() {
            this.lag -= this.TIME_STEP;
            this.updates += 1;
        }

        public void GetStats() {

        }

        /************************************************************
        *    Whether or not the animation time is lagging behind that of the real
        *    world.
        *
        *    Returns:
        *        bool: True if lag is greater than the fixed time step; false if 
        *        otherwise.
        *************************************************************/
        public bool IsLagging() {
            return this.lag >= this.TIME_STEP;
        }

        /************************************************************
        * Marks the real world time so that we are able to measure lag. This 
        * should be called once at the beginning of each frame.
        *************************************************************/
        public void Tick() {
            DateTime current = DateTime.Now;
            TimeSpan elapsed = current - this.previous;
            this.previous = current;
            this.lag += (float) elapsed.TotalSeconds;
            this.frames += 1;
        }
    }
}