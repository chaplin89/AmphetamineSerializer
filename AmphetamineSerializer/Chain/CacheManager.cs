﻿using AmphetamineSerializer.Interfaces;
using AmphetamineSerializer.Common;
using System;
using System.Collections.Generic;
using AmphetamineSerializer.Common.Chain;

namespace AmphetamineSerializer.Chain
{
    public class CacheManager : IChainElement
    {
        readonly Dictionary<Type, RequestHandler> managedRequests;

        public CacheManager()
        {
            managedRequests = new Dictionary<Type, RequestHandler>()
            {
                { typeof(SerializationBuildRequest), HandleSerializationBuild }
            };
        }

        public Dictionary<Type, RequestHandler> ManagedRequestes { get { return managedRequests; } }

        public string Name { get { return "CacheManager"; } }

        public IResponse HandleSerializationBuild(IRequest request)
        {
            return null;
        }
    }
}
