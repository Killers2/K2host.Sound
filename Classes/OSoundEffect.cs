/*
' /====================================================\
'| Developed Tony N. Hyde (www.k2host.co.uk)            |
'| Projected Started: 2021-09-08                        | 
'| Use: General                                         |
' \====================================================/
*/

using System;

using NAudio.Wave;
using NAudio.Wave.SampleProviders;

using K2host.Sound.Delegates;
using K2host.Sound.Enums;
using K2host.Sound.Interface;

namespace K2host.Sound.Classes
{

    public class OSoundEffect : ISoundEffect
    {

        /// <summary>
        /// The sound effect object dirived from NAudio
        /// </summary>
        public AudioFileReader Sound { get; }

        /// <summary>
        /// The pitch sample provider created based on the sound.
        /// </summary>
        public SmbPitchShiftingSampleProvider PitchProvider { get; }

        /// <summary>
        /// The callback for played sounds
        /// </summary>
        public OnPlayedEventHandler OnPlayed { get; set; }

        /// <summary>
        /// The sound effect type category
        /// </summary>
        public OSoundEffectCategory SoundType { get; set; }

        /// <summary>
        /// Determins its enabled state
        /// </summary>
        public bool SoundEnabled { get; set; }

        /// <summary>
        /// The volume for this sound
        /// </summary>
        public float Volume { get; set; }

        /// <summary>
        /// The playback pan
        /// </summary>
        public float Pan { get; set; }

        /// <summary>
        /// The playback pitch
        /// Pitch Factor (0.5f = octave down, 1.0f = normal, 2.0f = octave up)
        /// </summary>
        public float Pitch { get; set; }

        /// <summary>
        /// The sound duration
        /// </summary>
        public TimeSpan Duration { get { return Sound.TotalTime; } }

        /// <summary>
        /// The name of the sound
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The constuctor for the generating an instance.
        /// </summary>
        public OSoundEffect()
        {
            SoundType       = OSoundEffectCategory.Effect;
            SoundEnabled    = true;
        }

        /// <summary>
        /// The constuctor for the generating an instance.
        /// </summary>
        public OSoundEffect(string asset, string name, OSoundEffectCategory type)
            : this()
        {

            Name            = name;
            SoundType       = type;
            Sound           = new AudioFileReader(asset);
            Pan             = 0f;
            Pitch           = 1.0f;
            Volume          = 0.9f;
            SoundEnabled    = true;
            PitchProvider   = new SmbPitchShiftingSampleProvider(Sound) { PitchFactor = 1.0f };

            //NOTE: https://stackoverflow.com/questions/28792548/how-can-i-play-byte-array-of-audio-raw-data-using-naudio

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
                    Sound?.Dispose();
                }
            IsDisposed = true;
        }

        #endregion

    }

}