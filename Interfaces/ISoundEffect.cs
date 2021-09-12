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

namespace K2host.Sound.Interface
{

    /// <summary>
    /// This is used to help create the object class you define.
    /// </summary>
    public interface ISoundEffect : IDisposable
    {

        /// <summary>
        /// The sound effect object dirived from NAudio
        /// </summary>
        AudioFileReader Sound { get; }

        /// <summary>
        /// The pitch sample provider created based on the sound.
        /// </summary>
        SmbPitchShiftingSampleProvider PitchProvider { get; }

        /// <summary>
        /// The callback for played sounds
        /// </summary>
        OnPlayedEventHandler OnPlayed { get; set; }

        /// <summary>
        /// The sound effect type category
        /// </summary>
        OSoundEffectCategory SoundType { get; set; }

        /// <summary>
        /// Determins its enabled state
        /// </summary>
        bool SoundEnabled { get; set; }

        /// <summary>
        /// The volume for this sound
        /// </summary>
        float Volume { get; set; }

        /// <summary>
        /// The playback pan
        /// </summary>
        float Pan { get; set; }

        /// <summary>
        /// The playback pitch        
        /// Pitch Factor (0.5f = octave down, 1.0f = normal, 2.0f = octave up)
        /// </summary>
        float Pitch { get; set; }

        /// <summary>
        /// The sound duration
        /// </summary>
        TimeSpan Duration { get; }

        /// <summary>
        /// The name of the sound
        /// </summary>
        string Name { get; set; }

    }

}
