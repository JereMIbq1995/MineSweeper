namespace genie.cast {
    public class Cast {
        /*
            Private variables (Fields)
        */
        private Dictionary<string, List<Actor>> cast;
        
        /*
            Public methods
        */

        /***********************************************************
        * Constructor. Simply initialize the cast as a dictionary
        ************************************************************/
        public Cast() {
            this.cast = new Dictionary<string, List<Actor>>();
        }

        /***********************************************************
        * AddActor():
        * Add an actor to a group in the cast.
        * If the group is not found, create a new group with that name
        *   then put the actor in as the first element of that group
        ************************************************************/
        public void AddActor(string group, Actor actor) {
            if (!this.cast.ContainsKey(group)) {
                this.cast.Add(group, new List<Actor>());
            }
            if (!this.cast[group].Contains(actor)) {
                this.cast[group].Add(actor);
            }
        }

        /***********************************************************
        * GetActors():
        * Input: the group name as a string
        * Return:
        *   - A copy of that group (so that user can't add to the original)
        *   - Empty List of Actors if the group doesn't exist
        ************************************************************/
        public List<Actor> GetActors(string group) {
            if (this.cast.ContainsKey(group)) {
                return this.cast[group].ToList();
            }
            return new List<Actor>();
        }

        /***********************************************************
        * GetAllActors():
        * Return a list of all actors of all groups in the cast
        * Adding actors to this list will NOT affect the cast.
        ************************************************************/
        public List<Actor> GetAllActors() {
            List<Actor> result = new List<Actor>();
            foreach (List<Actor> group in this.cast.Values) {
                result.AddRange(group);
                // result.Concat(group);
            }
            return result;
        }

        /***********************************************************
        * GetFirstActor():
        * Input: The group name as a string
        * Output:
        *   - The first actor of the indicated group
        *   - NULL if group either doesn't exist or empty
        ************************************************************/
        public Actor? GetFirstActor(string group) {
            if (this.cast.ContainsKey(group) && this.cast[group].Count > 0) {
                return this.cast[group][0];
            }
            return null;
        }

        /***********************************************************
        * RemoveActor():
        * Input:
        *   - group: string. The name of the group
        *   - actor: Actor. The actor to be removed from the cast
        * Behavior:
        *   Remove the indicated actor from the cast.
        *   If the actor is null, or if group doesn't exist, do nothing.
        *   If the actor is not found in the given group, display a warning
        *        and do nothing to the cast
        ************************************************************/
        public void RemoveActor(string group, Actor? actor) {
            // If the actor received is null, just ignore it!
            if (this.cast.ContainsKey(group) && actor != null) {
                bool removeSuccess = this.cast[group].Remove(actor);
                if (!removeSuccess) {
                    Console.WriteLine("WARNING: Attempted to delete actor not found in the cast! Ignoring removal...");
                }
            }
        }

        /***********************************************************
        * PrintCast()
        * This function is purely for testing purposes.
        * It prints out all the groups and actors found in the cast
        *    and their width and height.
        ************************************************************/
        public void PrintCast() {
            foreach (KeyValuePair<string, List<Actor>> kV in this.cast) {
                Console.WriteLine($"\tGroup '{kV.Key}':");
                foreach (Actor actor in kV.Value) {
                    Console.WriteLine($"\t\t Actor with width-height: ({actor.GetWidth()}, {actor.GetHeight()})");
                }
            }
        }
    }
}