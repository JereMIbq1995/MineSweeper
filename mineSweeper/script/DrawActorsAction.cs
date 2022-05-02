using genie;
using genie.cast;
using genie.script;
using genie.services;
using genie.services.raylib;

namespace MineSweeper {
    class DrawActorsAction : genie.script.Action {
        
        private RaylibScreenService screenService;

        public DrawActorsAction(int priority, RaylibScreenService screenService) : base(priority) {
            this.screenService = screenService;
        }

        public override void execute(Cast cast, Script script, Clock clock, Callback callback) {

            // First, fill the screen with white every frame, get ready to draw more stuff
            this.screenService.FillScreen(Color.WHITE);

            // Draw all actors as rectangles for now.
            foreach (Actor actor in cast.GetAllActors()) {
                bool isBoard = actor is Board;
                // Color actorColor = actor is Board ? Color.BLUE : Color.BLACK;
                if (isBoard) {
                    this.screenService.DrawRectangle(actor.GetPosition(), actor.GetWidth(), actor.GetHeight(), Color.BLUE, 2);
                }
                else if (actor is Square) {
                    Square square = (Square)actor;
                    this.screenService.DrawActor(actor);
                    if (square.IsRevealed()) {
                        this.screenService.DrawText(square.GetDisplaySymbol(), actor.GetPosition(), "", 30, null, true, true);
                    }
                }
                else {
                    this.screenService.DrawActor(actor);
                }
            }

            // this.screenService.DrawActors(cast.GetAllActors());
        }
    }
}