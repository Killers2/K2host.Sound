/*
' /====================================================\
'| Developed Tony N. Hyde (www.k2host.co.uk)            |
'| Projected Started: 2021-09-08                        | 
'| Use: General                                         |
' \====================================================/
*/

using System;

using K2host.Sound.Enums;
using K2host.Sound.Extentions;
using K2host.Sound.Interface;

namespace K2host.Sound.Classes
{

    public class OSoundStream : ISoundStream
    {

        
        /// <summary>
        /// The parent engine that drives the sounds
        /// </summary>
        public ISoundEngine Parent { get; set; }

        /// <summary>
        /// The multi play items for this stream
        /// </summary>
        public ISoundMultiPlay[] Words { get; set; }

        /// <summary>
        /// The constuctor for the generating an instance.
        /// </summary>
        public OSoundStream()
        {


        }
       
        /// <summary>
        /// The constuctor for the generating an instance.
        /// </summary>
        public OSoundStream(ISoundEngine engine, string text, int timeSpan, OSoundGapType e)
        {

            Parent = engine;

            switch (e)
            {
                case OSoundGapType.Gaps:
                    this.CreateByGap(text, timeSpan);
                    break;
                case OSoundGapType.Frame:
                    this.CreateByFrame(text, timeSpan);
                    break;
            }
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
