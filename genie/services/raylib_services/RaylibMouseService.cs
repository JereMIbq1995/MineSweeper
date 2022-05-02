using Raylib_cs;
using System.Numerics;

namespace genie.services.raylib {
    /***************************************************************
    *   This class encapsulates most things you need to do to check
    *   for Mouse events.
    *   Note:
    *     ButtonDown means whether you're holding the button - opposite of ButtonUp.
    *     ButtonPressed means whether you just pressed the button once - opposite of ButtonReleased.
    ****************************************************************/
    class RaylibMouseService {

        // Private member variable
        private MouseMap mouseMap;      // Maps genie mouse buttons to Raylib mouse buttons
        private Vector2 mousePosition;  // Current position of the mouse

        /*************************************************************************
        * Constructor
        **************************************************************************/
        public RaylibMouseService() {
            this.mouseMap = new MouseMap();
            this.mousePosition = Raylib.GetMousePosition();
        }

        /*************************************************************************
        * Check to see if the button is currently DOWN
        **************************************************************************/
        public bool IsButtonDown(int button) {
            return Raylib.IsMouseButtonDown(this.mouseMap.GetRaylibMouse(button));
        }

        /*************************************************************************
        * Check to see if the button is currently UP
        **************************************************************************/
        public bool IsButtonUp(int button) {
            return Raylib.IsMouseButtonUp(this.mouseMap.GetRaylibMouse(button));
        }

        /*************************************************************************
        * Check to see if the button was PRESSED once
        * If the mouse button is held down, this function only return True for
        *    1 frame. For all frames after that, this function will return False
        *    eventhough the button is still held down.
        **************************************************************************/
        public bool IsButtonPressed(int button) {
            return Raylib.IsMouseButtonPressed(this.mouseMap.GetRaylibMouse(button));
        }

        /*************************************************************************
        * Check to see if the button was RELEASED once
        * If the mouse button was just released from being pressed, this function
        *    only return True for 1 frame. For all frames after that, this function 
        *    will return False eventhough the button is currently UP.
        *    This makes this function different from IsButtonUp().
        **************************************************************************/
        public bool IsButtonReleased(int button) {
            return Raylib.IsMouseButtonReleased(this.mouseMap.GetRaylibMouse(button));
        }

        /*************************************************************************
        * Check to see if the mouse has just moved from the last frame
        **************************************************************************/
        public bool HasMouseMoved() {
            Vector2 currentPosition = Raylib.GetMousePosition();
            bool hasMoved = (currentPosition.X - this.mousePosition.X != 0) || (currentPosition.Y - this.mousePosition.Y != 0);
            this.mousePosition = currentPosition;
            return hasMoved;
        }

        /*************************************************************************
        * Check to see if the Mouse Wheel was moved during the current frame:
        * Return values:
        *      - Positive if mouse wheel was moved up
        *      - 0 if mouse wheel was not moved
        *      - Negative if mouse wheel was moved down
        **************************************************************************/
        public float GetMouseWheelMove() {
            return Raylib.GetMouseWheelMove();
        }

        /*************************************************************************
        * Return the current coordinates of the mouse inside Raylib screen.
        * The return value's datatype is System.Numerics.Vector2
        **************************************************************************/
        public Vector2 GetCurrentCoordinates() {
            return Raylib.GetMousePosition();
        }

    }
}