// using genie;
using genie.cast;

namespace genie.script {
    /********************************************************************************
    *    A thing that is done in an animation.
    *
    *    The responsibility of Action is to define the common methods for everything
    *    that can happen in an animation.Actions are classified as one of three
    *    types, INPUT, UPDATE, or OUTPUT. This allows a director to cue an action at
    *    the appropriate time. Action is an an abstract base class that must be
    *    subclassed for every concrete action of a specific animation or game.
    *
    * Attributes:
    *    priority: int, priority of the action lower means it's executed first.
    **********************************************************************************/
    public abstract class Action {
        public abstract class Callback {
            public abstract void OnNext(Cast cast, Script script);
            public abstract void OnStop();
        }

        private int priority;

        public Action(int priority) {
            this.priority = priority;
        }

        public int GetPriority() {
            return this.priority;
        }

        public void SetPriority(int priority) {
            this.priority = priority;
        }

        public abstract void execute(Cast cast, Script script, Clock clock, Callback callback);
    }
}