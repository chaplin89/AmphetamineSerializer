﻿using AmphetamineSerializer.Chain;
using AmphetamineSerializer.Common;
using AmphetamineSerializer.Interfaces;
using AmphetamineSerializer.Model;
using AmphetamineSerializer.Model.Attributes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace AmphetamineSerializer.Helpers
{
    public class StreamDeserializationCtx : BuilderBase
    {
        /// <summary>
        /// Map every trivial type with its handler inside BinaryWriter or BinaryReader.
        /// </summary>
        static private readonly Dictionary<Type, MethodInfo> typeHandlerMap = new Dictionary<Type, MethodInfo>()
        {
            {typeof(byte),                   typeof(BinaryWriter).GetMethod("Write", new Type[] {typeof(byte),   })},
            {typeof(sbyte),                  typeof(BinaryWriter).GetMethod("Write", new Type[] {typeof(sbyte),  })},
            {typeof(uint),                   typeof(BinaryWriter).GetMethod("Write", new Type[] {typeof(uint),   })},
            {typeof(int),                    typeof(BinaryWriter).GetMethod("Write", new Type[] {typeof(int),    })},
            {typeof(ushort),                 typeof(BinaryWriter).GetMethod("Write", new Type[] {typeof(ushort), })},
            {typeof(short),                  typeof(BinaryWriter).GetMethod("Write", new Type[] {typeof(short),  })},
            {typeof(double),                 typeof(BinaryWriter).GetMethod("Write", new Type[] {typeof(double), })},
            {typeof(float),                  typeof(BinaryWriter).GetMethod("Write", new Type[] {typeof(float),  })},
            {typeof(byte[]),                 typeof(BinaryWriter).GetMethod("Write", new Type[] {typeof(byte[]), })},
            {typeof(ulong),                  typeof(BinaryWriter).GetMethod("Write", new Type[] {typeof(ulong),  })},
            {typeof(long),                   typeof(BinaryWriter).GetMethod("Write", new Type[] {typeof(long),   })},
            {typeof(char),                   typeof(BinaryWriter).GetMethod("Write", new Type[] {typeof(char),   })},

            {typeof(byte).MakeByRefType(),   typeof(BinaryReader).GetMethod("ReadByte")},
            {typeof(sbyte).MakeByRefType(),  typeof(BinaryReader).GetMethod("ReadSByte")},
            {typeof(uint).MakeByRefType(),   typeof(BinaryReader).GetMethod("ReadUInt32")},
            {typeof(int).MakeByRefType(),    typeof(BinaryReader).GetMethod("ReadInt32")},
            {typeof(ushort).MakeByRefType(), typeof(BinaryReader).GetMethod("ReadUInt16")},
            {typeof(short).MakeByRefType(),  typeof(BinaryReader).GetMethod("ReadInt16")},
            {typeof(double).MakeByRefType(), typeof(BinaryReader).GetMethod("ReadDouble")},
            {typeof(float).MakeByRefType(),  typeof(BinaryReader).GetMethod("ReadSingle")},
            {typeof(byte[]).MakeByRefType(), typeof(BinaryReader).GetMethod("ReadBytes")},
            {typeof(ulong).MakeByRefType(),  typeof(BinaryReader).GetMethod("ReadUInt64")},
            {typeof(long).MakeByRefType(),   typeof(BinaryReader).GetMethod("ReadInt64")},
            {typeof(char).MakeByRefType(),   typeof(BinaryReader).GetMethod("ReadChar")},
        };
        
        static StreamDeserializationCtx()
        {
            // Not all methods were found
            Debug.Assert(!typeHandlerMap.Where(x => x.Value == null).Any());
        }

        public StreamDeserializationCtx(FoundryContext ctx) : base(ctx)
        {
        }

        protected override ElementBuildResponse InternalMake()
        {
            if (ctx.Element?.LoadedType == null)
                return null;

            if (typeHandlerMap.ContainsKey(ctx.Element.LoadedType))
                HandlePrimitive(ctx);
            else if (ctx.Element.LoadedType == typeof(string))
                HandleString(ctx);
            else
                return null;

            method = new ElementBuildResponse() { Status = BuildedFunctionStatus.ContextModified };
            return method;
        }
        
        public void HandleString(FoundryContext ctx)
        {
            if (ctx.IsDeserializing)
                DecodeString(ctx);
            else
                EncodeString(ctx);
        }


        /// <summary>
        /// Rough C# translation:
        /// Encoding.ASCII.GetString(reader.ReadBytes(reader.ReadInt32()));
        /// 
        /// One day this will support multiple encoding depending on attributes.
        /// </summary>
        /// <param name="ctx"></param>
        public void DecodeString(FoundryContext ctx)
        {
            var valueToLoad = new GenericElement(((g, _) =>
            {
                // Put the decoded string in the stack.
                g.Call(typeof(Encoding).GetProperty("ASCII").GetMethod);
                g.LoadArgument(1);
                g.LoadArgument(1);
                g.CallVirtual(typeHandlerMap[typeof(int).MakeByRefType()]);
                g.CallVirtual(typeHandlerMap[typeof(byte[]).MakeByRefType()]);
                g.CallVirtual(typeof(Encoding).GetMethod("GetString", new Type[] { typeof(byte[]) }));
            }), null);

            ctx.Element.Store(ctx.G, valueToLoad, TypeOfContent.Value);
        }

        public ElementBuildResponse EncodeString(FoundryContext ctx)
        {
            // Rough C# translation:
            // writer.Write(Encoding.ASCII.GetByteCount(Load()));
            // writer.Write(Encoding.ASCII.GetBytes(Load());

            // Write lenght
            ctx.G.LoadArgument(1);
            ctx.G.Call(typeof(Encoding).GetProperty("ASCII").GetMethod);
            ctx.Element.Load(ctx.G, TypeOfContent.Value);
            ctx.G.CallVirtual(typeof(Encoding).GetMethod("GetByteCount", new Type[] { typeof(string) }));
            ctx.G.CallVirtual(typeHandlerMap[typeof(int)]);

            // Write string
            ctx.G.LoadArgument(1);
            ctx.G.Call(typeof(Encoding).GetProperty("ASCII").GetMethod);
            ctx.Element.Load(ctx.G, TypeOfContent.Value);
            ctx.G.CallVirtual(typeof(Encoding).GetMethod("GetBytes", new Type[] { typeof(string) }));
            ctx.G.CallVirtual(typeHandlerMap[typeof(byte[])]);
            return new ElementBuildResponse() { Status = BuildedFunctionStatus.ContextModified };
        }

        public void HandlePrimitive(FoundryContext ctx)
        {
            if (ctx.IsDeserializing)
            {
                //Read from stream
                var readFromStream = new GenericElement(((g, _) =>
                {
                    ctx.G.LoadArgument(1);
                    g.CallVirtual(typeHandlerMap[ctx.Element.LoadedType.MakeByRefType()]);
                }), null);

                ctx.Element.Store(ctx.G, readFromStream, TypeOfContent.Value);
            }
            else
            {
                //Write into stream
                ctx.G.LoadArgument(1);
                ctx.Element.Load(ctx.G, TypeOfContent.Value);
                ctx.G.CallVirtual(typeHandlerMap[ctx.Element.LoadedType]);
            }
        }
    }
}
