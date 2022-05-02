using Raylib_cs;
using genie.cast;

namespace genie.services.raylib {
    /***************************************************************
    *   This class helps you:
    *       - check for collision
    *       - move or rotate actors given a list of actors
    *       - Check whether an actor is left, right, top, or
                bottom of another actor.
    ****************************************************************/
    class RaylibPhysicsService {
        
        //Doesn't need any field for now

        // Constructor
        public RaylibPhysicsService() {
            //Empty for now
        }

        /***************************************************************
        * Turns an actor into a Rectangle for the purpose of collision checking
        ****************************************************************/
        private Rectangle GetRectangle(Actor actor) {
            (float x, float y) topLeft = actor.GetTopLeft();
            return new Rectangle(topLeft.x, topLeft.y, actor.GetWidth(), actor.GetHeight());
        }

        /***************************************************************
        *   Rotate all actors using the rotate method of each actor
        ****************************************************************/
        public void RotateActors(List<Actor> actors) {
            foreach (Actor actor in actors) {
                actor.Rotate();
            }
        }

        /***************************************************************
        *   Move all actors using the MoveWithVelocity() method of each actor
        ****************************************************************/
        public void MoveActors(List<Actor> actors) {
            foreach (Actor actor in actors) {
                actor.MoveWithVelocity();
            }
        }

        /***************************************************************
        *   Check for collision between 2 actors.
        ****************************************************************/
        public bool CheckCollision(Actor actor1, Actor actor2) {
            return Raylib.CheckCollisionRecs(this.GetRectangle(actor1), this.GetRectangle(actor2));
        }

        /***************************************************************
        *   Check for collision between an actor and a point (float 2-tuple)
        ****************************************************************/
        public bool CheckCollisionPoint(Actor actor, (float x, float y) point) {
            return Raylib.CheckCollisionPointRec(new System.Numerics.Vector2(point.x, point.y), this.GetRectangle(actor));
        }

        /***************************************************************
        *   Check for collision between an actor (target) and a list of actors
        *   Return value:
        *       - The first actor in the list that collides with target
        *       - NULL if there is no collision between target and any of the
        *         actors in the actors list.
        ****************************************************************/
        public Actor? CheckCollisionList(Actor target, List<Actor> actors) {
            foreach (Actor actor in actors) {
                if (Raylib.CheckCollisionRecs(this.GetRectangle(actor), this.GetRectangle(target))) {
                    return actor;
                }
            }
            return null;
        }

        /***************************************************************
        *   Check to see if an actor (target) collides with ALL of the
        *   actors in a list of actors.
        ****************************************************************/
        public bool CheckCollisionAll(Actor target, List<Actor> actors) {
            foreach (Actor actor in actors) {
                if (!Raylib.CheckCollisionRecs(this.GetRectangle(actor), this.GetRectangle(target))) {
                    return false;
                }
            }
            return true;
        }

        /***************************************************************
        *   Is actor1 above actor2?
        ****************************************************************/
        public bool IsAbove(Actor actor1, Actor actor2) {
            return (actor1.GetPreviousY() <= (actor2.GetPreviousTopLeft().Item2 - actor1.GetHeight() / 2));
        }

        /***************************************************************
        *   Is actor1 below actor2?
        ****************************************************************/
        public bool IsBelow(Actor actor1, Actor actor2)
        {
            return (actor1.GetPreviousY() >= (actor2.GetPreviousBottomLeft().Item2 + actor1.GetHeight() / 2));
        }

        /***************************************************************
        *   Is actor1 left of actor2?
        ****************************************************************/
        public bool IsLeftOf(Actor actor1, Actor actor2) {
            return (actor1.GetPreviousX() <= (actor2.GetPreviousTopLeft().Item1 - actor1.GetWidth() / 2));
        }

        /***************************************************************
        *   Is actor1 right of actor2?
        ****************************************************************/
        public bool IsRightOf(Actor actor1, Actor actor2) {
            return (actor1.GetPreviousX() >= (actor2.GetPreviousBottomRight().Item1 + actor1.GetWidth() / 2));
        }

    }
}