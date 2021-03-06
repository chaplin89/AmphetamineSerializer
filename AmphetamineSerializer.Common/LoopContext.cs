﻿using AmphetamineSerializer.Common.Element;
using AmphetamineSerializer.Interfaces;
using Sigil;

namespace AmphetamineSerializer.Common
{
    /// <summary>
    /// Manage a context for a loop
    /// </summary>
    public class LoopContext
    {
        public LoopContext(LocalElement index)
        {
            Index = index;
        }

        /// <summary>
        /// This is the index.
        /// </summary>
        public LocalElement Index { get; set; }
        
        /// <summary>
        /// Size of the array.
        /// </summary>
        public IElement Size { get; set; }

        /// <summary>
        /// Label that point to the end of the loop,
        /// where the out of bound condition is checked.
        /// </summary>
        public Label CheckOutOfBound { get; set; }

        /// <summary>
        /// Label that point at the body of the loop.
        /// </summary>
        public Label Body { get; set; }
    }
}
