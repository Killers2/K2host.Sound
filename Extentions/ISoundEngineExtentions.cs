/*
' /====================================================\
'| Developed Tony N. Hyde (www.k2host.co.uk)            |
'| Projected Started: 2021-09-08                        | 
'| Use: General                                         |
' \====================================================/
*/

using System;
using System.Linq;

using NAudio.Wave;
using NAudio.Wave.SampleProviders;

using K2host.Core;
using K2host.Sound.Classes;
using K2host.Sound.Enums;
using K2host.Sound.Interface;

namespace K2host.Sound.Extentions
{

    public static class ISoundEngineExtentions
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static ISoundEngine Load(this ISoundEngine e, ISoundParams parameters)
        {
            return e.SetupAudio(parameters);
        }
       
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static ISoundEngine SetupAudio(this ISoundEngine e, ISoundParams parameters)
        {

            e.SoundEffects.Values.ForEach(s => { 
            
                if (parameters.MuteGlobal)
                    s.Volume = 0.0f;
                else
                {
                    switch (s.SoundType)
                    {
                        case OSoundEffectCategory.Voice:
                            s.Volume = parameters.MuteVoice ? 0.0f : parameters.VolumeVoice;
                            break;
                        case OSoundEffectCategory.Effect:
                            s.Volume = parameters.MuteEffects ? 0.0f : parameters.VolumeEffects;
                            break;
                        case OSoundEffectCategory.Loop:
                            s.Volume = parameters.MuteMusic ? 0.0f : parameters.VolumeMusic;
                            break;
                    }
                }

            
            });

            return e;

        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        public static ISoundEngine Unload(this ISoundEngine e)
        {

            e.SoundEffects.Values.ForEach(s => {
                s.Dispose();
            });

            e.SoundEffects.Clear();

            return e;
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="names"></param>
        /// <param name="timegap"></param>
        public static void Play(this ISoundEngine e, string[] names, int timegap)
        {
            if (e.IsPlaying)
                return;

            e.MultiSoundNames = names;

            ISampleProvider[] buildList = Array.Empty<ISampleProvider>();

            e.MultiSoundNames.ForEach(name => {

                ISoundEffect s = e.Sound(name);

                if (s.Pitch > 0.0f && s.Pitch < 2.0f)
                    s.PitchProvider.PitchFactor = s.Pitch;

                s.OnPlayed += e.MultiSoundOnPlayed;

                buildList = buildList
                    .Append(s.Sound)
                    .Append(new OffsetSampleProvider(s.Sound) { 
                        DelayBy = TimeSpan.FromMilliseconds(timegap) 
                    })
                    .ToArray();

            });

            e.SoundInstance.Init(new ConcatenatingSampleProvider(buildList));
           
            e.SoundInstance.PlaybackStopped += (sender, args) => {
                e.MultiSoundNames.ForEach(name => {
                    var s = e.Sound(name);
                    s.OnPlayed?.Invoke(s);
                });
                e.MultiSoundNames.Dispose(out _);
                e.SoundInstance.Dispose();
                e.SoundInstance = new();
                e.IsPlaying = false;
            };

            e.SoundInstance.Volume = e.Sound(e.MultiSoundNames[0]).Volume;
            e.SoundInstance.Play();

            e.IsPlaying = true;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="multiplay"></param>
        public static void Play(this ISoundEngine e, ISoundMultiPlay[] multiplay)
        {
            if (e.IsPlaying)
                return;

            e.MultiSoundGaps = multiplay;

            ISampleProvider[] buildList = Array.Empty<ISampleProvider>();

            e.MultiSoundGaps.ForEach(item => {

                ISoundEffect s = e.Sound(item.Name);

                if (s.Pitch > 0.0f && s.Pitch < 2.0f)
                    s.PitchProvider.PitchFactor = item.Pitch;

                s.OnPlayed += e.MultiGapSoundOnPlayed;

                buildList = buildList
                    .Append(s.Sound)
                    .Append(new OffsetSampleProvider(s.Sound) {
                        LeadOut = TimeSpan.FromMilliseconds(item.Gap)
                    })
                    .ToArray();

            });

            e.SoundInstance.Init(new ConcatenatingSampleProvider(buildList));

            e.SoundInstance.PlaybackStopped += (sender, args) => {
                e.MultiSoundGaps.ForEach(g => {
                    var s = e.Sound(g.Name);
                    s.OnPlayed?.Invoke(s);
                    g.Dispose(); 
                });
                e.MultiSoundGaps.Dispose(out _);
                e.SoundInstance.Dispose();
                e.SoundInstance = new();
                e.IsPlaying = false;
            };

            e.SoundInstance.Volume = e.Sound(e.MultiSoundGaps[0].Name).Volume;
            e.SoundInstance.Play();

            e.IsPlaying = true;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="s"></param>
        public static void PlayStream(this ISoundEngine e, ISoundStream s)
        {
            if (e.IsPlaying)
                return;

            e.Play(s.Words);
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="context"></param>
        public static void PlayStream(this ISoundEngine e, string context)
        {
            if (e.IsPlaying)
                return;

            e.Play(new OSoundStream(e, context, 300, OSoundGapType.Frame).Words);

        }
      
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="index"></param>
        public static void PlaySentance(this ISoundEngine e, int index)
        {
            if (e.IsPlaying)
                return;

            e.PlayStream(e.SoundSentances.Values.ToArray()[index]);

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="uid"></param>
        public static void PlaySentance(this ISoundEngine e, string uid)
        {
            if (e.IsPlaying)
                return;

            if (e.SoundSentances.ContainsKey(uid))
                e.PlayStream(e.SoundSentances[uid]);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="s"></param>
        private static void MultiSoundOnPlayed(this ISoundEngine e, ISoundEffect s)
        {
            s.Sound.Position = 0;
            s.Sound.Seek(0, System.IO.SeekOrigin.Begin);
            s.OnPlayed -= e.MultiSoundOnPlayed;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="s"></param>
        private static void MultiGapSoundOnPlayed(this ISoundEngine e, ISoundEffect s)
        {
            s.Sound.Position = 0;
            s.Sound.Seek(0, System.IO.SeekOrigin.Begin);
            s.OnPlayed -= e.MultiGapSoundOnPlayed;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static ISoundEffect Sound(this ISoundEngine e, string name)
        {
            if (!e.SoundEffects.ContainsKey(name))
                return null;

            return e.SoundEffects[name];
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public static ISoundEffect Sound(this ISoundEngine e, int index)
        {

            if (index < 0 || index > e.SoundEffects.Count)
                return null;

            return e.SoundEffects.Values.ToArray()[index];

        }

    }

}