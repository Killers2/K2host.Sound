/*
' /====================================================\
'| Developed Tony N. Hyde (www.k2host.co.uk)            |
'| Projected Started: 2021-09-08                        | 
'| Use: General                                         |
' \====================================================/
*/

using System;

namespace K2host.Sound.Interface
{

    /// <summary>
    /// This is used to help create the object class you define.
    /// </summary>
    public interface ISoundParams : IDisposable
    {
        
        /// <summary>
        /// The music volume
        /// </summary>
        float VolumeMusic { get; set; }

        /// <summary>
        /// The voice volume
        /// </summary>
        float VolumeVoice { get; set; }

        /// <summary>
        /// The effects volume
        /// </summary>
        float VolumeEffects { get; set; }

        /// <summary>
        /// The global volume
        /// </summary>
        float VolumeGlobal { get; set; }

        /// <summary>
        /// The mute for music
        /// </summary>
        bool MuteMusic { get; set; }

        /// <summary>
        /// The mute for voice
        /// </summary>
        bool MuteVoice { get; set; }

        /// <summary>
        /// The mute for effects
        /// </summary>
        bool MuteEffects { get; set; }

        /// <summary>
        /// The mute for global
        /// </summary>
        bool MuteGlobal { get; set; }

    }

}
