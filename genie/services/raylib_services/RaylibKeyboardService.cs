using Raylib_cs;

namespace genie.services.raylib {
    /***************************************************************
    *   This class encapsulates most things you need to do to check
    *   for keyboard events.
    *   Note:
    *     KeyDown means whether you're holding the button - opposite of KeyUp.
    *     KeyPressed means whether you just pressed the button once - opposite of KeyReleased.
    ****************************************************************/
    class RaylibKeyboardService {
        //The keyboard service has a key map that maps
        // all genie key codes into Raylib key codes
        private KeysMap keysMap;

        /***************************************************************
        * Constructor
        ****************************************************************/
        public RaylibKeyboardService() {
            this.keysMap = new KeysMap();
        }

        /***************************************************************
        * Get a dictionary that map a set of keys to their states (Up or Down)
        * True = Down, False = Up
        ****************************************************************/
        public Dictionary<int, bool> GetKeysState(List<int> keys) {
            Dictionary <int, bool> keysState = new Dictionary<int, bool>();
            foreach (int key in keys) {
                keysState.Add(key, Raylib.IsKeyDown(this.keysMap.GetRaylibKey(key)));
            }
            return keysState;
        }

        /***************************************************************
        * Check to see if a key is pressed ONCE.
        * This function only returns True once when the key is pressed.
        * On the next frame, it will return false even if the key is still
        * held down
        ****************************************************************/
        public bool IsKeyPressed(int key) {
            return Raylib.IsKeyPressed(this.keysMap.GetRaylibKey(key));
        }

        /***************************************************************
        * Check to see if a key is released ONCE.
        * This function only returns True once when the key is released from
        * being held down.
        * On the next frame, it will return false even if the key is UP.
        * (This function is different from IsKeyUp())
        ****************************************************************/
        public bool IsKeyReleased(int key) {
            return Raylib.IsKeyReleased(this.keysMap.GetRaylibKey(key));
        }

        /***************************************************************
        * Check to see if a key is currently being held down.
        * Return True every frame if the key is held down at the time of
        * the check.
        ****************************************************************/
        public bool IsKeyDown(int key)
        {
            return Raylib.IsKeyDown(this.keysMap.GetRaylibKey(key));
        }

        /***************************************************************
        * This is just the opposite of IsKeyDown()
        ****************************************************************/
        public bool IsKeyUp(int key)
        {
            return Raylib.IsKeyUp(this.keysMap.GetRaylibKey(key));
        }
    }
}