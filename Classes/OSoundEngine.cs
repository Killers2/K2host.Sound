/*
' /====================================================\
'| Developed Tony N. Hyde (www.k2host.co.uk)            |
'| Projected Started: 2021-09-08                        | 
'| Use: General                                         |
' \====================================================/
*/

using System;
using System.Collections.Generic;

using NAudio.Wave;

using K2host.Sound.Interface;

namespace K2host.Sound.Classes
{

    public class OSoundEngine : ISoundEngine
    {

        /// <summary>
        /// The full path to the audio files
        /// </summary>
        public string AudioPath { get; set; }

        /// <summary>
        /// The collection of sound effects items
        /// </summary>
        public Dictionary<string, ISoundEffect> SoundEffects { get; }

        /// <summary>
        /// The collection of sound stream items
        /// </summary>       
        public Dictionary<string, ISoundStream> SoundSentances { get; }

        /// <summary>
        /// The multi sound names list
        /// </summary>
        public string[] MultiSoundNames { get; set; }

        /// <summary>
        /// The multi sound gaps play list
        /// </summary>
        public ISoundMultiPlay[] MultiSoundGaps { get; set; }

        /// <summary>
        /// The playing state of the engine.
        /// </summary>
        public bool IsPlaying { get; set; }

        /// <summary>
        /// The sound effect instance object dirived from NAudio
        /// </summary>
        public WaveOutEvent SoundInstance { get; set; }

        /// <summary>
        /// The playback state
        /// </summary>
        public PlaybackState State { get { return SoundInstance.PlaybackState; } }

        /// <summary>
        /// The constuctor for the generating an instance.
        /// </summary>
        public OSoundEngine()
        {
            SoundEffects    = new Dictionary<string, ISoundEffect>();
            SoundSentances  = new Dictionary<string, ISoundStream>();
            SoundInstance   = new();
        }

        #region Deconstuctor

        private bool IsDisposed = false;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!IsDisposed)
                if (disposing)
                {
                    SoundInstance?.Dispose();
                }
            IsDisposed = true;
        }

        #endregion

    }

}