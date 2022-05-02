using genie.cast;

namespace genie.test {
    public class CastScriptTest {
        
        public void testCast() {
            Cast cast = new Cast();

            // Test AddActor
            Actor actor1 = new Actor("", 1, 0);
            Actor actor2 = new Actor("", 2, 0);
            Actor actor3 = new Actor("", 3, 0);
            Actor actor4 = new Actor("", 4, 0);

            cast.AddActor("player", actor1);
            cast.AddActor("asteroids", actor2);
            cast.AddActor("asteroids", actor3);
            cast.AddActor("mothership", actor4);

            Console.WriteLine("After adding first 4 actors: ");
            cast.PrintCast();

            // Test GetFirstActor:
            Actor? firstOfAsteroids = cast.GetFirstActor("asteroids");
            Console.WriteLine("Trying to get the first actor of 'asteroids': ");
            if (firstOfAsteroids == null)
            {
                Console.WriteLine("Something went HORIBLY WRONG!");
            }
            else
            {
                Console.WriteLine($"First actor of asteroids: ({firstOfAsteroids.GetWidth()}, {firstOfAsteroids.GetHeight()})");
            }
            cast.PrintCast();

            // Test GetActors:
            Console.WriteLine("Trying to get all 'asteroids'");
            List<Actor>? allAsteroids = cast.GetActors("asteroids");
            if (allAsteroids == null)
            {
                Console.WriteLine("Something went HORIBLY WRONG!");
            }
            else
            {
                foreach (Actor actor in allAsteroids)
                {
                    Console.WriteLine($"Asteroid with width-height: ({actor.GetWidth()}, {actor.GetHeight()})");
                }
            }
            cast.PrintCast();

            // Try to add something to the asteroid list just received above (this should NOT add to the cast dictionary inside cast):
            Console.WriteLine("Trying to add (5, 0) to the asteroids list received from the cast simply by using .Add(). Will it appear in the Cast?");
            if (allAsteroids != null)
            {
                allAsteroids.Add(new Actor("", 5, 0));
            }
            cast.PrintCast();

            // Test GetAllActors:
            Console.WriteLine("Trying to get all 'asteroids'");
            List<Actor>? allActors = cast.GetAllActors();
            if (allActors == null)
            {
                Console.WriteLine("Something went HORIBLY WRONG!");
            }
            else
            {
                Console.WriteLine($"Result: {allActors.Count} actors returned");
                foreach (Actor actor in allActors)
                {
                    Console.WriteLine($"Asteroid with width-height: ({actor.GetWidth()}, {actor.GetHeight()})");
                }
            }
            cast.PrintCast();

            // Add another actor to the list received from GetAllActors. Let's make sure it doesn't alter the cast:
            if (allActors != null)
            {
                Console.WriteLine("Trying to add (5,0) to allActors. Let's make sure it doesn't alter the cast.");
                allActors.Add(new Actor("", 5, 0));
            }
            cast.PrintCast();

            // Test RemoveActor:
            Console.WriteLine("Attempting to remove firstOfAsteroids: ");
            cast.RemoveActor("asteroids", firstOfAsteroids);
            cast.PrintCast();

            // Let's try to remove something that doesn't exist
            Console.WriteLine("Attempting to remove actor5 which is not in the cast: ");
            Actor actor5 = new Actor("", 5, 0);
            cast.RemoveActor("asteroids", actor5);
            cast.PrintCast();
        }
    }
}