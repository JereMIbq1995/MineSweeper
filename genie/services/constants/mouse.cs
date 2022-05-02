namespace genie.services {
    /* These constants define what integer each mouse button is known by the user should the
        key is supported.
        However, whether each mouse button is supported depends on the specific
        services that the user uses.
        For example, some of the mouse buttons defined here are supported by Raylib
        and some are not.
    */
    public static class Mouse {
        public const int LEFT = 0;     // index for Left mouse
        public const int MIDDLE = 1;    // index for Middle mouse
        public const int RIGHT = 2;     // index for Right mouse

        // If mouse has more than 3 buttons:
        // (there are only 2 more since Pygame only support 5)
        public const int EXTRA1 = 3;
        public const int EXTRA2 = 4;

        public const int SIDE = 5;
        public const int FORWARD = 6;
        public const int BACK = 7;
    }
}