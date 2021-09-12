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

    public class OSoundMultiPlay : ISoundMultiPlay
    {

        /// <summary>
        /// The multi play name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The gap between plays
        /// </summary>
        public int Gap { get; set; }

        /// <summary>
        /// the pitch of the multi play
        /// </summary>
        public float Pitch { get; set; }

        /// <summary>
        /// The constuctor for the generating an instance.
        /// </summary>
        public OSoundMultiPlay()
        {
            Name    = string.Empty;
            Gap     = 0;
            Pitch   = 1.0f;
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
