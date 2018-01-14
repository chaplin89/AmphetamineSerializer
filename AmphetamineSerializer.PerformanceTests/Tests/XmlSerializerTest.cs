﻿using System.Diagnostics;
using System.IO;
using System.Xml.Serialization;

namespace AmphetamineSerializer.PerformanceTests
{
    class XmlSerializerTest<T> : PerformanceTestBase<T>
    {
        private XmlSerializer serializer;

        public XmlSerializerTest()
        {
            serializer = new XmlSerializer(typeof(T));
        }

        public override string Description => "XmlSerializer";

        public override double Do(Stream stream)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            serializer.Serialize(stream, graph);
            sw.Stop();
            return sw.Elapsed.TotalMilliseconds;
        }
    }
}
