namespace genie.script
{
    public class Script
    {
        /*
            Private variables (Fields)
        */
        private Dictionary<string, List<Action>> script;
        private string[] validGroupNames = { "input", "update", "output" };

        /*
            Public methods
        */

        /***********************************************************
        * Constructor. Simply initialize the script as a dictionary
        ************************************************************/
        public Script()
        {
            this.script = new Dictionary<string, List<Action>>();

            foreach (string groupName in this.validGroupNames) {
                this.script.Add(groupName, new List<Action>());
            }
        }

        /***********************************************************
        * AddAction():
        * Add an action to a group in the script.
        * If the group is not found, create a new group with that name
        *   then put the action in as the first element of that group
        ************************************************************/
        public void AddAction(string group, Action action)
        {
            if (!this.validGroupNames.Contains(group)) {
                throw new Exception($"Script.AddAction(): group must be one of {this.validGroupNames.ToString()}");
            }

            // Make sure not to add the same action twice (cuz that'll be real weird)
            if (!this.script[group].Contains(action))
            {
                this.script[group].Add(action);
            }
        }

        /***********************************************************
        * GetActions():
        * Input: the group name as a string
        * Return:
        *   - A copy of that group (so that user can't add to the original)
        *   - NULL if the group doesn't exist
        ************************************************************/
        public List<Action> GetActions(string group)
        {
            if (!this.validGroupNames.Contains(group))
            {
                throw new Exception($"Script.GetActions(): group must be one of {this.validGroupNames.ToString()}");
            }

            return this.script[group].ToList();
        }

        /***********************************************************
        * RemoveAction():
        * Input:
        *   - group: string. The name of the group
        *   - action: Action. The action to be removed from the script
        * Behavior:
        *   Remove the indicated action from the script.
        *   If the action is null, or if group doesn't exist, do nothing.
        *   If the action is not found in the given group, display a warning
        *        and do nothing to the script
        ************************************************************/
        public void RemoveAction(string group, Action? action)
        {
            if (!this.validGroupNames.Contains(group))
            {
                throw new Exception($"Script.RemoveAction(): group must be one of {this.validGroupNames.ToString()}");
            }

            // If the action received is null, just ignore it!
            if (action != null)
            {
                bool removeSuccess = this.script[group].Remove(action);
                if (!removeSuccess)
                {
                    Console.WriteLine("WARNING: Attempted to delete action not found in the script! Ignoring removal...");
                }
            }
        }

        /***********************************************************
        * PrintScript()
        * This function is purely for testing purposes.
        * It prints out all the groups and actions found in the script
        *    and their width and height.
        ************************************************************/
        public void PrintScript()
        {
            foreach (KeyValuePair<string, List<Action>> kV in this.script)
            {
                Console.WriteLine($"\tGroup '{kV.Key}': {kV.Value.Count} actions found!");
                foreach (Action action in kV.Value)
                {
                    Console.WriteLine($"\t\t{action}");
                }
            }
        }
    }
}