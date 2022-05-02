using genie.cast;
using genie.script;

namespace genie {

    /*************************************************************
    * These 2 exceptions are designed to skip the rest of the game loop
    * and move on to the next iteration or stop the game completely.
    * Note that StopGame means that:
    *    The game loop is exited immediately, skipping all following actions.
    * This means that the game window will close immediately as well.
    **************************************************************/
    class ChangeSceneException : Exception {
        
        public ChangeSceneException(string? message) : base(message) {
            // Other stuff that might need to be done.
        }
    }

    class StopGameException : Exception {
        public StopGameException(string? message) : base(message) {
            // Other stuff that might need to be done
        }
    }

    /*************************************************************
    * The director class:
    *   - Holds the cast and the script.
    *   - DirectScene runs the game loop by running:
    *         + All input actions
    *         + All update actions
    *         + All output actions
    *   ...every iteration of the loop
    **************************************************************/
    public class Director : script.Action.Callback {

        // Private member variables
        private bool isDirecting;    //Is the game still going?
        private Cast cast;           // The current cast of the game
        private Script script;       // The current script of the game
        private Clock clock;         // Clock. Holds statistics about time, framerate and other things...

        // Constructor
        public Director() {
            this.isDirecting = true;
            this.cast = new Cast();
            this.script = new Script();
            this.clock = new Clock();
        }

        /**********************************************************
        * Start the game given a cast and a script...
        ***********************************************************/
        public void DirectScene(Cast cast, Script script) {
            
            this.cast = cast;
            this.script = script;
            this.isDirecting = true;

            while (isDirecting) {
                try {
                    DoInputs();
                    DoUpdates();
                    DoOutputs();
                }
                
                // Skip the rest of the actions if
                //  - The game must be exited right the way
                //  - or The cast and script are completely changed (change scene)
                catch (ChangeSceneException e) { Console.WriteLine(e.Message); }
                catch (StopGameException e) { Console.WriteLine(e.Message); }
            }
        }

        /**********************************************************
        * Stop the game loop when called
        ***********************************************************/
        public override void OnStop()
        {
            this.isDirecting = false;
            throw new StopGameException("Game is stopped.");
        }

        /**********************************************************
        * This is used when the cast and the script need to be completely
        * replaced and the game switches to a different scene.
        * For example, this can be used to move from 1 level of the game
        * to another.
        ***********************************************************/
        public override void OnNext(Cast cast, Script script) {
            this.cast = cast;
            this.script = script;
            throw new ChangeSceneException("Changing scene with a new CAST and a new SCRIPT...");
        }

        /**********************************************************
        * Go through all INPUT actions and execute each one
        ***********************************************************/
        private void DoInputs() {
            this.clock.Tick();
            foreach (script.Action action in this.script.GetActions("input")) {
                action.execute(this.cast, this.script, this.clock, this);
            }
        }

        /**********************************************************
        * Go through all UPDATE actions and execute each one
        ***********************************************************/
        private void DoUpdates() {
            while (this.clock.IsLagging()) {
                foreach (script.Action action in this.script.GetActions("update")) {
                    action.execute(this.cast, this.script, this.clock, this);
                }
                this.clock.CatchUp();
            }
        }

        /**********************************************************
        * Go through all OUTPUT actions and execute each one
        ***********************************************************/
        private void DoOutputs() {
            foreach (script.Action action in this.script.GetActions("output")) {
                action.execute(this.cast, this.script, this.clock, this);
            }
        }
    }
}