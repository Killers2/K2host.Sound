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
    public interface ISoundMultiPlay : IDisposable
    {

        /// <summary>
        /// The multi play name
        /// </summary>
        string Name { get; set; }
        
        /// <summary>
        /// The gap between plays
        /// </summary>
        int Gap { get; set; }
        
        /// <summary>
        /// the pitch of the multi play
        /// </summary>
        float Pitch { get; set; }

    }

}
