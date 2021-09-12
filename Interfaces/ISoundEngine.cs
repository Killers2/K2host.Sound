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

namespace K2host.Sound.Interface
{

    /// <summary>
    /// This is used to help create the object class you define.
    /// </summary>
    public interface ISoundEngine : IDisposable
    {

        /// <summary>
        /// The full path to the audio files
        /// </summary>
        string AudioPath { get; set; }
        
        /// <summary>
        /// The collection of sound effects items
        /// </summary>
        Dictionary<string, ISoundEffect> SoundEffects { get; }
        
        /// <summary>
        /// The collection of sound stream items
        /// </summary>       
        Dictionary<string, ISoundStream> SoundSentances { get; }
       
        /// <summary>
        /// The multi sound names list
        /// </summary>
        string[] MultiSoundNames { get; set; }

        /// <summary>
        /// The multi sound gaps play list
        /// </summary>
        ISoundMultiPlay[] MultiSoundGaps { get; set; }
        
        /// <summary>
        /// The playing state of the engine.
        /// </summary>
        bool IsPlaying { get; set; }

        /// <summary>
        /// The sound effect instance object dirived from NAudio
        /// </summary>
        WaveOutEvent SoundInstance { get; set; }
       
        /// <summary>
        /// The playback state
        /// </summary>
        PlaybackState State { get; }

    }

}
