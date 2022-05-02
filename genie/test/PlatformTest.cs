using Raylib_cs;
using System.Numerics;
using genie.cast;

namespace genie.services.raylib
{
    public class PlatformTest
    {

        RaylibKeyboardService keyboardService;
        RaylibMouseService mouseService;
        RaylibScreenService screenService;
        // RaylibAudioService audioService;
        RaylibPhysicsService physicsService;

        private List<int> keysOfInterest;

        private int heroMovementVel;

        public PlatformTest()
        {
            // Nothing for now
            this.keyboardService = new RaylibKeyboardService();
            this.mouseService = new RaylibMouseService();
            this.screenService = new RaylibScreenService((1280, 800), "Services Test", 60);
            this.physicsService = new RaylibPhysicsService();

            this.keysOfInterest = new List<int>();
            this.keysOfInterest.Add(Keys.LEFT);
            this.keysOfInterest.Add(Keys.RIGHT);
            this.keysOfInterest.Add(Keys.SPACE);

            this.heroMovementVel = 4;
        }

        private void HandleHeroMovementAction(Cast cast) {
            // Grab the hero from the cast
            Actor? hero = cast.GetFirstActor("hero");

            // Only move if hero is not null
            if (hero != null)
            {
                // Get the keysState from the keyboardService
                Dictionary<int, bool> keysState = keyboardService.GetKeysState(this.keysOfInterest);

                // Change the velocity to the appropriate value and let MoveActorsAction handle the
                // actual movement
                if (keysState[Keys.LEFT])
                {
                    // this.hero.SetVx(-this.heroMovementVel);
                    foreach (Actor actor in cast.GetAllActors())
                    {
                        if (actor != hero)
                        {
                            actor.SetVx(this.heroMovementVel);
                        }


                    }
                }
                if (keysState[Keys.RIGHT])
                {
                    // this.hero.SetVx(-this.heroMovementVel);
                    foreach (Actor actor in cast.GetAllActors())
                    {
                        if (actor != hero)
                        {
                            actor.SetVx(-this.heroMovementVel);
                        }
                    }
                }
                if (keysState[Keys.SPACE])
                {
                    hero.SetVy(-14);
                }

                // If none of the LEFT or RIGHT keys are down, x-velocity is 0
                if (!(keysState[Keys.LEFT] || keysState[Keys.RIGHT]))
                {
                    foreach (Actor actor in cast.GetAllActors())
                    {
                        if (actor != hero)
                        {
                            actor.SetVx(0);
                        }
                    }
                }
            }
        }

        private void ApplyGravity(Cast cast) {
            Actor? hero = cast.GetFirstActor("hero");
            if (hero != null) {
                hero.SetVy(hero.GetVy() + (float).7);
            }
        }

        private void MoveActorsAction(Cast cast)
        {
            List<Actor> allActors = cast.GetAllActors();
            this.physicsService.MoveActors(allActors);
            this.physicsService.RotateActors(allActors);
        }

        private void HandleHeroPlatformsCollisions(Cast cast) {
            // Grab the hero from the cast
            Actor? hero = cast.GetFirstActor("hero");
            List<Actor> platforms = cast.GetActors("platform");

            // Only move if hero is not null
            if (hero != null)
            {
                foreach (Actor platform in platforms)
                {
                    if (this.physicsService.CheckCollision(hero, platform))
                    {

                        if (this.physicsService.IsAbove(hero, platform))
                        {
                            hero.SetY(platform.GetTopLeft().Item2 - hero.GetHeight() / 2);
                            hero.SetVy(0);
                        }
                        if (this.physicsService.IsLeftOf(hero, platform))
                        {
                            hero.SetX(platform.GetTopLeft().Item1 - hero.GetWidth() / 2);
                            hero.SetVx(0);
                        }
                        if (this.physicsService.IsRightOf(hero, platform))
                        {
                            hero.SetX(platform.GetTopRight().Item1 + hero.GetWidth() / 2);
                            hero.SetVx(0);
                        }
                        if (this.physicsService.IsBelow(hero, platform))
                        {
                            hero.SetY(platform.GetBottomLeft().Item2 + hero.GetHeight() / 2);
                            hero.SetVy(0);
                        }
                    }
                }
            }
        }

        private void DrawActorsAction(Cast cast) {
            this.screenService.FillScreen(Color.WHITE);
            foreach (Actor actor in cast.GetActors("platform"))
            {
                Color actorColor = Color.BLACK;
                this.screenService.DrawRectangle(actor.GetPosition(), actor.GetWidth(), actor.GetHeight(), actorColor, 5);
            }

            Actor? hero = cast.GetFirstActor("hero");
            if (hero != null) {
                this.screenService.DrawRectangle(hero.GetPosition(), hero.GetWidth(), hero.GetHeight(), Color.BLUE, 5);
            }
        }

        public void TestPlayerPlatformCollisions() {

            (int, int) L_SIZE = (8000, 2000);
            (int, int) W_SIZE = (1000, 800);

            // Create the cast
            Cast cast = new Cast();

            // Add all actors to the cast
            cast.AddActor("hero", new Actor("genie/test/testAssets/spaceship_red.png", 50, 70, 640, 360, 0, 0, 180));
            cast.AddActor("platform", new Actor("", L_SIZE.Item1, (100), //path, width, height
                                                    L_SIZE.Item1 / 2, W_SIZE.Item2,   // x and y
                                                    0, 0));  // vx and vy
            cast.AddActor("platform", new Actor("", 100, 300, 700, 700));
            cast.AddActor("platform", new Actor("", 200, 100, 1000, 700));
            cast.AddActor("platform", new Actor("", 200, 50, 1400, 600));

            while (!screenService.IsQuit())
            {
                // input
                HandleHeroMovementAction(cast);
                
                // update
                ApplyGravity(cast);
                MoveActorsAction(cast);
                HandleHeroPlatformsCollisions(cast);

                // output
                DrawActorsAction(cast);
                this.screenService.UpdateScreen();
            }
            screenService.CloseWindow();
        }
    }

}