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
    public interface ISoundStream : IDisposable
    {

        /// <summary>
        /// The parent engine that drives the sounds
        /// </summary>
        ISoundEngine Parent { get; set; }

        /// <summary>
        /// The multi play items for this stream
        /// </summary>
        ISoundMultiPlay[] Words { get; set; }

    }

}
