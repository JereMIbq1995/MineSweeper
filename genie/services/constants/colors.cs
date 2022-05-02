namespace genie.services {
    /*
        This class defines a few commonly used colors,
        as well as the Color class that has the Red, Green,
        Blue, and Alpha (transparency) attributes.
    */
    public class Color {
        public static Color BLACK = new Color(0,0,0,255);
        public static Color GRAY = new Color(127, 127, 127, 255);
        public static Color WHITE = new Color(255, 255, 255, 255);
        public static Color RED = new Color(255, 0, 0, 255);
        public static Color GREEN = new Color(0, 255, 0, 255);
        public static Color BLUE = new Color(0, 0, 255, 255);
        public static Color YELLOW = new Color(255, 255, 0, 255);
        public static Color CYAN = new Color(0, 255, 255, 255);
        public static Color MAGENTA = new Color(255, 0, 255, 255);

        public int r { get; set; }
        public int g { get; set; }
        public int b { get; set; }
        public int a { get; set; }

        public Color (int r, int g, int b, int a) {
            this.r = r;
            this.g = g;
            this.b = b;
            this.a = a;
        }
    }
}