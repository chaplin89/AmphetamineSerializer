﻿using AmphetamineSerializer.Common;

namespace AmphetamineSerializer.Example
{
    public class DataDirectory
    {

        [ASIndex(0)]
        public uint VirtualAddress;
        [ASIndex(1)]
        public uint Size;
    }
}
