/*
' /====================================================\
'| Developed Tony N. Hyde (www.k2host.co.uk)            |
'| Projected Started: 2021-09-08                        | 
'| Use: General                                         |
' \====================================================/
*/

using System;

using K2host.Sound.Interface;

namespace K2host.Sound.Classes
{

    public class OSoundParams : ISoundParams
    {

        /// <summary>
        /// The music volume
        /// </summary>
        public float VolumeMusic { get; set; }

        /// <summary>
        /// The voice volume
        /// </summary>
        public float VolumeVoice { get; set; }

        /// <summary>
        /// The effects volume
        /// </summary>
        public float VolumeEffects { get; set; }

        /// <summary>
        /// The global volume
        /// </summary>
        public float VolumeGlobal { get; set; }

        /// <summary>
        /// The mute for music
        /// </summary>
        public bool MuteMusic { get; set; }

        /// <summary>
        /// The mute for voice
        /// </summary>
        public bool MuteVoice { get; set; }

        /// <summary>
        /// The mute for effects
        /// </summary>
        public bool MuteEffects { get; set; }

        /// <summary>
        /// The mute for global
        /// </summary>
        public bool MuteGlobal { get; set; }

        /// <summary>
        /// The constuctor for the generating an instance.
        /// </summary>
        public OSoundParams()
        {


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

                }
            IsDisposed = true;
        }

        #endregion

    }

}
