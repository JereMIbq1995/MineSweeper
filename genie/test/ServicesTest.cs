using Raylib_cs;
using System.Numerics;
using genie.cast;

namespace genie.services.raylib
{
    public class ServicesTest {
        
        RaylibKeyboardService keyboardService;
        RaylibMouseService mouseService;
        RaylibScreenService screenService;
        // RaylibAudioService audioService;
        // RaylibPhysicsService physicsService;

        public ServicesTest() {
            // Nothing for now
            this.keyboardService = new RaylibKeyboardService();
            this.mouseService = new RaylibMouseService();
            this.screenService = new RaylibScreenService((1280, 720), "Services Test", 60);
        }

        /**********************************************************************
        * This function test the detection of keys 
        *   - LEFT, RIGHT, UP, and DOWN.
        *   - A, D, W, S
        *   - and J, L, I, K
        * The first keys group tests the function GetKeysStates()
        * The second keys group tests the functions IsKeysPressed() and IsKeysReleased()
        * The third keys group tests the functions IsKeysDown() and IsKeysUp()
        ***********************************************************************/
        public void TestKeyboardService() {

            while (!screenService.IsQuit()) {
                
                //Testing get keys states:
                List<int> keys = new List<int>();
                keys.Add(Keys.LEFT);
                keys.Add(Keys.RIGHT);
                keys.Add(Keys.UP);
                keys.Add(Keys.DOWN);

                Dictionary<int, bool> keysState = keyboardService.GetKeysState(keys);

                if (keysState[Keys.LEFT]) {
                    Console.WriteLine("LEFT is down!");
                }
                if (keysState[Keys.RIGHT]) {
                    Console.WriteLine("RIGHT is down!");
                }
                if (keysState[Keys.UP]) {
                    Console.WriteLine("UP is down!");
                }
                if (keysState[Keys.DOWN]) {
                    Console.WriteLine("DOWN is down!");
                }

                //Testing IsKeyPressed(), IsKeyReleased()
                if (keyboardService.IsKeyPressed(Keys.A)) {
                    Console.WriteLine("A is pressed!");
                }
                if (keyboardService.IsKeyPressed(Keys.D)) {
                    Console.WriteLine("D is pressed!");
                }
                if (keyboardService.IsKeyPressed(Keys.W)) {
                    Console.WriteLine("W is pressed!");
                }
                if (keyboardService.IsKeyPressed(Keys.S)) {
                    Console.WriteLine("S is pressed!");
                }

                if (keyboardService.IsKeyReleased(Keys.A) || keyboardService.IsKeyReleased(Keys.D) 
                    || keyboardService.IsKeyReleased(Keys.W) || keyboardService.IsKeyReleased(Keys.S)) {
                        Console.WriteLine("Something key was just released!");
                }

                //Testing IsKeyDown(), IsKeyUp()
                // Comment this part out to see clearer result of previous tests
                if (keyboardService.IsKeyDown(Keys.J))
                {
                    Console.WriteLine("J is down!");
                }
                if (keyboardService.IsKeyDown(Keys.L))
                {
                    Console.WriteLine("L is down!");
                }
                if (keyboardService.IsKeyDown(Keys.I))
                {
                    Console.WriteLine("I is down!");
                }
                if (keyboardService.IsKeyDown(Keys.K))
                {
                    Console.WriteLine("K is down!");
                }

                if (keyboardService.IsKeyUp(Keys.J) && keyboardService.IsKeyUp(Keys.L)
                    && keyboardService.IsKeyUp(Keys.I) && keyboardService.IsKeyUp(Keys.K))
                {
                    Console.WriteLine("J, L, I, K are all up!");
                }

                //All the drawing stuff...
                Raylib.BeginDrawing();
                Raylib.ClearBackground(Raylib_cs.Color.SKYBLUE);
                Raylib.DrawFPS(10, 10);
                Raylib.DrawText("Press UP, DOWN, LEFT, or RIGHT and watch the console!", 100, 360, 30, Raylib_cs.Color.RED);
                Raylib.DrawText("Press W, S, A, or D and watch the console!", 100, 400, 30, Raylib_cs.Color.RED);
                Raylib.DrawText("Press I, K, J, or L and watch the console!", 100, 440, 30, Raylib_cs.Color.RED);
                Raylib.EndDrawing();
            }
            Raylib.CloseWindow();
        }

        /**********************************************************************
        * This function test the detection of the mouse buttons:
        * LEFT, RIGHT and Scrolling
        ***********************************************************************/
        public void TestMouseService()
        {
            int smallDotYCoor = 200;

            while (!screenService.IsQuit())
            {

                //Testing IsMousePressed(), IsMouseReleased():
                if (mouseService.IsButtonPressed(Mouse.LEFT)) {
                    Console.WriteLine("LEFT mouse pressed!");
                }
                if (mouseService.IsButtonPressed(Mouse.RIGHT)) {
                    Console.WriteLine("RIGHT mouse pressed!");
                }
                if (mouseService.IsButtonPressed(Mouse.MIDDLE)) {
                    Console.WriteLine("MIDDLE mouse pressed!");
                }
                if (mouseService.IsButtonReleased(Mouse.LEFT)) {
                    Console.WriteLine("LEFT mouse released!");
                }
                if (mouseService.IsButtonReleased(Mouse.RIGHT)) {
                    Console.WriteLine("RIGHT mouse released!");
                }
                if (mouseService.IsButtonReleased(Mouse.MIDDLE)) {
                    Console.WriteLine("MIDDLE mouse released!");
                }

                // Test GetMouseWheelMove()
                float mouseWheelMove = mouseService.GetMouseWheelMove();
                smallDotYCoor -= (int)mouseWheelMove*2;

                //Test IsMouseDown(), IsMouseUp():
                bool leftDown = mouseService.IsButtonDown(Mouse.LEFT);
                bool rightDown = mouseService.IsButtonDown(Mouse.RIGHT);
                bool middleDown = mouseService.IsButtonDown(Mouse.MIDDLE);
                bool leftUp = mouseService.IsButtonUp(Mouse.LEFT);
                bool rightUp = mouseService.IsButtonUp(Mouse.RIGHT);
                bool middleUp = mouseService.IsButtonUp(Mouse.MIDDLE);

                // Test HasMouseMoved() and GetCurrentCoordinates()
                if (mouseService.HasMouseMoved()) {
                    Console.WriteLine("Mouse is moving...");
                    Vector2 mouseCoordinates = mouseService.GetCurrentCoordinates();
                    Console.WriteLine($"Coordinates: ({mouseCoordinates.X}, {mouseCoordinates.Y})");
                }

                //All the drawing stuff...
                Raylib.BeginDrawing();
                
                Raylib.ClearBackground(Raylib_cs.Color.SKYBLUE);
                Raylib.DrawFPS(10, 10);
                if (leftDown) {
                    Raylib.DrawCircle(100, 100, 80, Raylib_cs.Color.RED);
                }
                if (leftUp) {
                    Raylib.DrawCircle(100, 100, 80, Raylib_cs.Color.GRAY);
                }
                if (middleDown) {
                    Raylib.DrawCircle(200, 100, 80, Raylib_cs.Color.BLUE);
                }
                if (middleUp) {
                    Raylib.DrawCircle(200, 100, 80, Raylib_cs.Color.GRAY);
                }
                if (rightDown) {
                    Raylib.DrawCircle(300, 100, 80, Raylib_cs.Color.RED);
                }
                if (rightUp) {
                    Raylib.DrawCircle(300, 100, 80, Raylib_cs.Color.GRAY);
                }

                Raylib.DrawCircle(600, smallDotYCoor, 20, Raylib_cs.Color.RED);
                // if (mouseWheelMove > 0) {
                //     Raylib.DrawCircle(600, 100, 20, Raylib.RED);
                // }
                // else if (mouseWheelMove < 0) {
                //     Raylib.DrawCircle(600, 200, 20, Raylib.RED);
                // }
                // else {
                //     Raylib.DrawCircle(600, 150, 20, Raylib.RED);
                // }
                Raylib.DrawText("CLICK anywhere on the screen with LEFT, RIGHT, and MIDDLE mouses", 100, 360, 30, Raylib_cs.Color.RED);
                Raylib.DrawText("The gray dots above will change color when the respective mouse is HELD.", 100, 400, 30, Raylib_cs.Color.RED);
                Raylib.DrawText("Scroll to pull the small RED dot UP or DOWN", 100, 440, 30, Raylib_cs.Color.RED);
                Raylib.DrawText("Watch the console for Pressed and Released detection", 100, 480, 30, Raylib_cs.Color.RED);
                Raylib.DrawText("Watch the console for mouse Movement detection", 100, 520, 30, Raylib_cs.Color.RED);
                Raylib.EndDrawing();
            }
            Raylib.CloseWindow();
        }

        /**********************************************************************
        * This function test the detection of the mouse buttons:
        * LEFT, RIGHT and Scrolling
        ***********************************************************************/
        public void TestScreenService() {
            
            Cast cast = new Cast();
            Actor ship = new Actor("genie/test/testAssets/spaceship_red.png", 70, 50, 640, 360, 0, 0, 180);
            cast.AddActor("ship", ship);

            while (!screenService.IsQuit()) {
                screenService.BeginDrawing();
                screenService.FillScreen(Color.CYAN);

                // Draw text
                // screenService.DrawText("Hello World non centered!", (640, 360), "", 30, Color.BLACK, true, false);
                // screenService.DrawText("Hello World centered!", (640, 500), "", 30, Color.BLACK, true, true);

                // Draw Rectangle
                screenService.DrawRectangle((640, 100), 50, 50, Color.RED, 5, (float) 0.5);

                // Draw Circles (and their sectors)
                screenService.DrawCircle((640, 360), 100, Color.GREEN, 0, true, false, true, false);
                screenService.DrawCircle((440, 360), 100, Color.BLACK, 0, false, true, false, true);
                screenService.DrawCircle((840, 360), 100, Color.GRAY, 0, false, false, true, true);
                screenService.DrawCircle((1040, 360), 100, Color.YELLOW, 1, true, true, false, false);
                screenService.DrawCircle((240, 360), 100, Color.MAGENTA, 1, true, false, false, true);
                screenService.DrawCircle((640, 560), 100, Color.BLUE, 1, false, true, true, false);
                screenService.DrawCircle((840, 560), 100, Color.WHITE, 5, true, true, true, true);
                screenService.DrawCircle((440, 560), 100, Color.RED, 1, true, false, true, false);

                // Drawing all actors in the cast
                screenService.DrawActors(cast.GetAllActors());

                screenService.UpdateScreen();
            }
            screenService.CloseWindow();
        }
    }
}