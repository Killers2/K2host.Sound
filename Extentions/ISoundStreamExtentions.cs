/*
' /====================================================\
'| Developed Tony N. Hyde (www.k2host.co.uk)            |
'| Projected Started: 2021-09-08                        | 
'| Use: General                                         |
' \====================================================/
*/

using System;
using System.Collections.Generic;
using System.Linq;

using K2host.Core;
using K2host.Sound.Classes;
using K2host.Sound.Interface;

using gl = K2host.Core.OHelpers;

namespace K2host.Sound.Extentions
{

    public static class ISoundStreamExtentions
    {
        
        /// <summary>
        /// This initiates the <see cref="ISoundStream"/> instance based on the input text and time frame.
        /// </summary>
        /// <param name="e"></param>
        /// <param name="text"></param>
        /// <param name="timeFrame"></param>
        public static void CreateByFrame(this ISoundStream e, string text, int timeFrame)
        {

            IEnumerable<ISoundMultiPlay> multiplays = Array.Empty<ISoundMultiPlay>();

            text
                .Split((char)32)
                .ForEach(word => { 
            
                    string name = word;

                    if (name.Contains(","))
                        name = name.Remove(name.IndexOf(","));

                    ISoundEffect s = e.Parent.Sound(name);
                    
                    if (s != null)
                    {

                        ISoundMultiPlay p = new OSoundMultiPlay() { 
                            Name    = name, 
                            Gap     = timeFrame 
                        };
                        
                        gl.GetPercent(timeFrame, s.Duration.Milliseconds, out int result);
                       
                        p.Gap = result;

                        if (word.Contains(","))
                            p.Gap += (250 - p.Gap);

                        multiplays = multiplays.Append(p);

                    }            

                });

            e.Words = multiplays.ToArray();

        }

        /// <summary>
        /// This initiates the <see cref="ISoundStream"/> instance based on the input text and time gap.
        /// </summary>
        /// <param name="e"></param>
        /// <param name="text"></param>
        /// <param name="timeGap"></param>
        public static void CreateByGap(this ISoundStream e, string text, int timeGap)
        {

            IEnumerable<ISoundMultiPlay> multiplays = Array.Empty<ISoundMultiPlay>();

            text
                .Split((char)32)
                .ForEach(word => {

                    int delay = timeGap;
                    string name = word;

                    if (name.Contains(","))
                    {
                        name = name.Remove(name.IndexOf(","));
                        delay += (250 - delay);
                    }

                    ISoundEffect s = e.Parent.Sound(name);

                    if (s != null)
                        multiplays = multiplays.Append(new OSoundMultiPlay()
                        {
                            Name    = name,
                            Gap     = delay
                        });

                });

            e.Words = multiplays.ToArray();

        }

    }

}