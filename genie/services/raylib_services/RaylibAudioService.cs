using Raylib_cs;

namespace genie.services.raylib {
    /************************************************************************
    *    Everything that has to do with sound.
    *    At least the things you need. Feel free to add more functionalities
    *    to this class if you wish to.
    *************************************************************************/
    class RaylibAudioService {
        
        // Private member variable(s)
        private Dictionary<string, Sound> soundCache;
        
        // Constructor
        public RaylibAudioService() {
            Raylib.InitAudioDevice();
            this.soundCache = new Dictionary<string, Sound>();
        }

        /*********************************************************************
        *    This private method loads the sound into memory
        *    Why is it private? Well, because you probably don't need
        *    to worry about what it does :)
        *********************************************************************/
        private Sound LoadSound(string path) {
            Sound sound = Raylib.LoadSound(path);
            this.soundCache[path] = sound;
            return sound;
        }

        /********************************************************************
        *    Play the sound given the path to the sound file and the volume
        *    Input:
        *       - path: string, path to the sound file
        *       - volume: float, goes from 0 to 1. If you go over 1, it's
                            treated as 1. If you go below 0, it's treated as 0.
        *********************************************************************/
        public void PlaySound(string path, float volume = 1) {
            try {

                //Determine whether to pull from the cache or load new
                Sound sound = !this.soundCache.ContainsKey(path) ? this.LoadSound(path) : this.soundCache[path];
                
                // Set the volume
                Raylib.SetSoundVolume(sound, volume);

                // Play!
                Raylib.PlaySound(sound);

            }
            catch (Exception e) {
                // In case path is not found...
                Console.WriteLine(e.Message);
            }
        }
    }
}