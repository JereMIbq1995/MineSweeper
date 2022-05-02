using Raylib_cs;

namespace genie.services.raylib {
    /*
        This class maps the Genie Keys to the Raylib Keys
    */
    public class KeysMap {

        // hold the mapping of genie key to raylib key
        private Dictionary<int, KeyboardKey> keysMap;
        
        /*
            Constructor:
            Put all the mapping of supported genie keys to raylib keys inside keysMap
        */
        public KeysMap() {
            this.keysMap = new Dictionary<int, KeyboardKey>();

            keysMap.Add(Keys.BACKSPACE, KeyboardKey.KEY_BACKSPACE);
            keysMap.Add(Keys.TAB, KeyboardKey.KEY_TAB);
            // keysMap.Add(Keys.CLEAR, KeyboardKey.);
            keysMap.Add(Keys.RETURN, KeyboardKey.KEY_ENTER);
            keysMap.Add(Keys.PAUSE, KeyboardKey.KEY_PAUSE);
            keysMap.Add(Keys.ESCAPE, KeyboardKey.KEY_ESCAPE);
            keysMap.Add(Keys.SPACE, KeyboardKey.KEY_SPACE);
            // keysMap.Add(Keys.EXCLAIM, KeyboardKey.);
            // keysMap.Add(Keys.DBL_QUOTE, KeyboardKey.);
            // keysMap.Add(Keys.HASH, KeyboardKey.);
            // keysMap.Add(Keys.DOLLAR, KeyboardKey.);
            // keysMap.Add(Keys.AMPERSAND, KeyboardKey.);
            keysMap.Add(Keys.QUOTE, KeyboardKey.KEY_APOSTROPHE);
            // keysMap.Add(Keys.LEFTPAREN, KeyboardKey.);
            // keysMap.Add(Keys.RIGHTPAREN, KeyboardKey.);
            // keysMap.Add(Keys.ASTERISK, KeyboardKey.);
            // keysMap.Add(Keys.PLUS, KeyboardKey.);
            keysMap.Add(Keys.COMMA, KeyboardKey.KEY_COMMA);
            keysMap.Add(Keys.MINUS, KeyboardKey.KEY_MINUS);
            keysMap.Add(Keys.PERIOD, KeyboardKey.KEY_PERIOD);
            keysMap.Add(Keys.SLASH, KeyboardKey.KEY_SLASH);
            keysMap.Add(Keys.K_0, KeyboardKey.KEY_ZERO);
            keysMap.Add(Keys.K_1, KeyboardKey.KEY_ONE);
            keysMap.Add(Keys.K_2, KeyboardKey.KEY_TWO);
            keysMap.Add(Keys.K_3, KeyboardKey.KEY_THREE);
            keysMap.Add(Keys.K_4, KeyboardKey.KEY_FOUR);
            keysMap.Add(Keys.K_5, KeyboardKey.KEY_FIVE);
            keysMap.Add(Keys.K_6, KeyboardKey.KEY_SIX);
            keysMap.Add(Keys.K_7, KeyboardKey.KEY_SEVEN);
            keysMap.Add(Keys.K_8, KeyboardKey.KEY_EIGHT);
            keysMap.Add(Keys.K_9, KeyboardKey.KEY_NINE);
            // keysMap.Add(Keys.COLON, KeyboardKey.);
            keysMap.Add(Keys.SEMICOLON, KeyboardKey.KEY_SEMICOLON);
            // keysMap.Add(Keys.LESS, KeyboardKey.);
            keysMap.Add(Keys.EQUAL, KeyboardKey.KEY_EQUAL);
            // keysMap.Add(Keys.GREATER, KeyboardKey.);
            // keysMap.Add(Keys.QUESTION, KeyboardKey.);
            // keysMap.Add(Keys.AT, KeyboardKey.);
            keysMap.Add(Keys.LEFT_BRACKET, KeyboardKey.KEY_LEFT_BRACKET);
            keysMap.Add(Keys.BACKSLASH, KeyboardKey.KEY_BACKSLASH);
            keysMap.Add(Keys.RIGHTBRACKET, KeyboardKey.KEY_RIGHT_BRACKET);
            // keysMap.Add(Keys.CARET, KeyboardKey.);
            // keysMap.Add(Keys.UNDERSCORE, KeyboardKey.);
            keysMap.Add(Keys.BACKQUOTE, KeyboardKey.KEY_GRAVE);
            keysMap.Add(Keys.A, KeyboardKey.KEY_A);
            keysMap.Add(Keys.B, KeyboardKey.KEY_B);
            keysMap.Add(Keys.C, KeyboardKey.KEY_C);
            keysMap.Add(Keys.D, KeyboardKey.KEY_D);
            keysMap.Add(Keys.E, KeyboardKey.KEY_E);
            keysMap.Add(Keys.F, KeyboardKey.KEY_F);
            keysMap.Add(Keys.G, KeyboardKey.KEY_G);
            keysMap.Add(Keys.H, KeyboardKey.KEY_H);
            keysMap.Add(Keys.I, KeyboardKey.KEY_I);
            keysMap.Add(Keys.J, KeyboardKey.KEY_J);
            keysMap.Add(Keys.K, KeyboardKey.KEY_K);
            keysMap.Add(Keys.L, KeyboardKey.KEY_L);
            keysMap.Add(Keys.M, KeyboardKey.KEY_M);
            keysMap.Add(Keys.N, KeyboardKey.KEY_N);
            keysMap.Add(Keys.O, KeyboardKey.KEY_O);
            keysMap.Add(Keys.P, KeyboardKey.KEY_P);
            keysMap.Add(Keys.Q, KeyboardKey.KEY_Q);
            keysMap.Add(Keys.R, KeyboardKey.KEY_R);
            keysMap.Add(Keys.S, KeyboardKey.KEY_S);
            keysMap.Add(Keys.T, KeyboardKey.KEY_T);
            keysMap.Add(Keys.U, KeyboardKey.KEY_U);
            keysMap.Add(Keys.V, KeyboardKey.KEY_V);
            keysMap.Add(Keys.W, KeyboardKey.KEY_W);
            keysMap.Add(Keys.X, KeyboardKey.KEY_X);
            keysMap.Add(Keys.Y, KeyboardKey.KEY_Y);
            keysMap.Add(Keys.Z, KeyboardKey.KEY_Z);
            keysMap.Add(Keys.DELETE, KeyboardKey.KEY_DELETE);
            keysMap.Add(Keys.KP0, KeyboardKey.KEY_KP_0);
            keysMap.Add(Keys.KP1, KeyboardKey.KEY_KP_1);
            keysMap.Add(Keys.KP2, KeyboardKey.KEY_KP_2);
            keysMap.Add(Keys.KP3, KeyboardKey.KEY_KP_3);
            keysMap.Add(Keys.KP4, KeyboardKey.KEY_KP_4);
            keysMap.Add(Keys.KP5, KeyboardKey.KEY_KP_5);
            keysMap.Add(Keys.KP6, KeyboardKey.KEY_KP_6);
            keysMap.Add(Keys.KP7, KeyboardKey.KEY_KP_7);
            keysMap.Add(Keys.KP8, KeyboardKey.KEY_KP_8);
            keysMap.Add(Keys.KP9, KeyboardKey.KEY_KP_9);
            keysMap.Add(Keys.KP_PERIOD, KeyboardKey.KEY_KP_DECIMAL);
            keysMap.Add(Keys.KP_DIVIDE, KeyboardKey.KEY_KP_DIVIDE);
            keysMap.Add(Keys.KP_MULTIPLY, KeyboardKey.KEY_KP_MULTIPLY);
            keysMap.Add(Keys.KP_MINUS, KeyboardKey.KEY_KP_SUBTRACT);
            keysMap.Add(Keys.KP_PLUS, KeyboardKey.KEY_KP_ADD);
            keysMap.Add(Keys.KP_ENTER, KeyboardKey.KEY_KP_ENTER);
            keysMap.Add(Keys.KP_EQUAL, KeyboardKey.KEY_KP_EQUAL);
            keysMap.Add(Keys.UP, KeyboardKey.KEY_UP);
            keysMap.Add(Keys.DOWN, KeyboardKey.KEY_DOWN);
            keysMap.Add(Keys.LEFT, KeyboardKey.KEY_LEFT);
            keysMap.Add(Keys.RIGHT, KeyboardKey.KEY_RIGHT);
            keysMap.Add(Keys.INSERT, KeyboardKey.KEY_INSERT);
            keysMap.Add(Keys.HOME, KeyboardKey.KEY_HOME);
            keysMap.Add(Keys.END, KeyboardKey.KEY_END);
            keysMap.Add(Keys.PAGEUP, KeyboardKey.KEY_PAGE_UP);
            keysMap.Add(Keys.PAGEDOWN, KeyboardKey.KEY_PAGE_DOWN);
            keysMap.Add(Keys.F1, KeyboardKey.KEY_F1);
            keysMap.Add(Keys.F2, KeyboardKey.KEY_F2);
            keysMap.Add(Keys.F3, KeyboardKey.KEY_F3);
            keysMap.Add(Keys.F4, KeyboardKey.KEY_F4);
            keysMap.Add(Keys.F5, KeyboardKey.KEY_F5);
            keysMap.Add(Keys.F6, KeyboardKey.KEY_F6);
            keysMap.Add(Keys.F7, KeyboardKey.KEY_F7);
            keysMap.Add(Keys.F8, KeyboardKey.KEY_F8);
            keysMap.Add(Keys.F9, KeyboardKey.KEY_F9);
            keysMap.Add(Keys.F10, KeyboardKey.KEY_F10);
            keysMap.Add(Keys.F11, KeyboardKey.KEY_F11);
            keysMap.Add(Keys.F12, KeyboardKey.KEY_F12);
            // keysMap.Add(Keys.F13, KeyboardKey.);
            // keysMap.Add(Keys.F14, KeyboardKey.);
            // keysMap.Add(Keys.F15, KeyboardKey.);
            keysMap.Add(Keys.NUMLOCK, KeyboardKey.KEY_NUM_LOCK);
            keysMap.Add(Keys.CAPSLOCK, KeyboardKey.KEY_CAPS_LOCK);
            keysMap.Add(Keys.SCROLLOCK, KeyboardKey.KEY_SCROLL_LOCK);
            keysMap.Add(Keys.RSHIFT, KeyboardKey.KEY_RIGHT_SHIFT);
            keysMap.Add(Keys.LSHIFT, KeyboardKey.KEY_LEFT_SHIFT);
            keysMap.Add(Keys.RCTRL, KeyboardKey.KEY_RIGHT_CONTROL);
            keysMap.Add(Keys.LCTRL, KeyboardKey.KEY_LEFT_CONTROL);
            keysMap.Add(Keys.RALT, KeyboardKey.KEY_RIGHT_ALT);
            keysMap.Add(Keys.LALT, KeyboardKey.KEY_LEFT_ALT);
            // keysMap.Add(Keys.RMETA, KeyboardKey.);
            // keysMap.Add(Keys.LMETA, KeyboardKey.);
            keysMap.Add(Keys.LSUPER, KeyboardKey.KEY_LEFT_SUPER);
            keysMap.Add(Keys.RSUPER, KeyboardKey.KEY_RIGHT_SUPER);
            // keysMap.Add(Keys.MODE, KeyboardKey.);
            // keysMap.Add(Keys.HELP, KeyboardKey.);
            keysMap.Add(Keys.PRINT, KeyboardKey.KEY_PRINT_SCREEN);
            // keysMap.Add(Keys.SYSREQ, KeyboardKey.);
            // keysMap.Add(Keys.BREAK, KeyboardKey.);
            keysMap.Add(Keys.MENU, KeyboardKey.KEY_MENU);
            // keysMap.Add(Keys.POWER, KeyboardKey.);
            // keysMap.Add(Keys.EURO, KeyboardKey.);
            keysMap.Add(Keys.KB_MENU, KeyboardKey.KEY_KB_MENU);
            keysMap.Add(Keys.VOLUME_UP, KeyboardKey.KEY_VOLUME_UP);
            keysMap.Add(Keys.VOLUME_DOWN, KeyboardKey.KEY_VOLUME_DOWN);
        }

        public KeyboardKey GetRaylibKey(int genieKey) {
            try {
                return this.keysMap[genieKey];
            }
            catch (KeyNotFoundException e) {
                if (e.Source != null)
                    Console.WriteLine("KeyNotFoundException source: {0}", e.Source);
                throw new KeyNotFoundException($"Genie key {genieKey} is not a valid key");
            }
        }
    }
}