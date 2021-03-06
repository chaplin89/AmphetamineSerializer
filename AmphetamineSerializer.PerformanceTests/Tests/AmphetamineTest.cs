﻿using System.Diagnostics;
using System.IO;

namespace AmphetamineSerializer.PerformanceTests
{
    class AmphetamineTest<T> : PerformanceTestBase<T>
    {
        private Serializator<T> serializer;
        private BinaryWriter writer;

        public AmphetamineTest()
        {
            serializer = new Serializator<T>();
        }

        public override string Description => "Amphetamine";

        protected override double InternalDo(Stream stream, T graph)
        {
            writer = new BinaryWriter(stream);

            Stopwatch sw = new Stopwatch();
            sw.Start();
            serializer.Serialize(graph, writer);
            sw.Stop();
            return sw.Elapsed.TotalMilliseconds;
        }
    }
}
