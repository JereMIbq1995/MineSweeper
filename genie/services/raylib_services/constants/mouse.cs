using Raylib_cs;

namespace genie.services.raylib
{
    /*
        This class maps the Genie Mouse values to the Raylib mouse values
    */
    public class MouseMap
    {

        // hold the mapping of genie mouse button to raylib mouse button
        private Dictionary<int, MouseButton> mouseMap;

        /*
            Constructor:
            Put all the mapping of supported genie keys to raylib keys inside keysMap
        */
        public MouseMap()
        {
            this.mouseMap = new Dictionary<int, MouseButton>();

            mouseMap.Add(Mouse.LEFT, MouseButton.MOUSE_LEFT_BUTTON);
            mouseMap.Add(Mouse.MIDDLE, MouseButton.MOUSE_MIDDLE_BUTTON);
            mouseMap.Add(Mouse.RIGHT, MouseButton.MOUSE_RIGHT_BUTTON);

            // mouseMap.Add(Mouse.EXTRA1, MouseButton.MOUSE_BUTTON_EXTRA);

            // mouseMap.Add(Mouse.SIDE, MouseButton.MOUSE_BUTTON_SIDE);
            // mouseMap.Add(Mouse.FORWARD,MouseButton.MOUSE_BUTTON_FORWARD);
            // mouseMap.Add(Mouse.BACK, MouseButton.MOUSE_BUTTON_BACK);
        }

        /*
            Attempt to return the raylib version of the mouse button,
            given the genie version
        */
        public MouseButton GetRaylibMouse(int genieMouseButton)
        {
            try
            {
                return this.mouseMap[genieMouseButton];
            }
            catch (KeyNotFoundException e)
            {
                if (e.Source != null)
                    Console.WriteLine("KeyNotFoundException source: {0}", e.Source);
                throw new KeyNotFoundException($"Genie mouse button {genieMouseButton} is not a valid mouse button");
            }
        }
    }
}