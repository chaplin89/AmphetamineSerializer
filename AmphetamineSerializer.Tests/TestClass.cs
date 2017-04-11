﻿using AmphetamineSerializer.Common.Attributes;
using System;

namespace AmphetamineSerializer.Tests
{
        [Serializable]
    public class TestTrivialTypes
    {
        [ASIndex(0)]  public uint            Test1_Field0;
        [ASIndex(1)]  public int             Test1_Field1;
        [ASIndex(2)]  public ushort          Test1_Field2;
        [ASIndex(3)]  public short           Test1_Field3;
        [ASIndex(4)]  public sbyte           Test1_Field4;
        [ASIndex(5)]  public byte            Test1_Field5;
        [ASIndex(6)]  public string          Test1_Field6;
    }

    [Serializable]
    public class Test1DArray
    {
        [ASIndex(0)]  public uint            Test1_Field0;
        [ASIndex(1)]  public int             Test1_Field1;
        [ASIndex(2)]  public ushort          Test1_Field2;
        [ASIndex(3)]  public short           Test1_Field3;
        [ASIndex(4)]  public sbyte           Test1_Field4;
        [ASIndex(5)]  public byte            Test1_Field5;
        [ASIndex(6)]  public string          Test1_Field6;
                      
        [ASIndex(7)]  public uint    []      Test1_Field7;
        [ASIndex(8)]  public int     []      Test1_Field8;
        [ASIndex(9)]  public ushort  []      Test1_Field9;
        [ASIndex(10)] public short   []      Test1_Field10;
        [ASIndex(11)] public sbyte   []      Test1_Field11;
        [ASIndex(12)] public byte    []      Test1_Field12;
        [ASIndex(13)] public string  []      Test1_Field13;
    }

    [Serializable]
    public class TestJaggedArray
    {
        [ASIndex(0)]  public uint            Test1_Field0;
        [ASIndex(1)]  public int             Test1_Field1;
        [ASIndex(2)]  public ushort          Test1_Field2;
        [ASIndex(3)]  public short           Test1_Field3;
        [ASIndex(4)]  public sbyte           Test1_Field4;
        [ASIndex(5)]  public byte            Test1_Field5;
        [ASIndex(6)]  public string          Test1_Field6;
                      
        [ASIndex(7)]  public uint    []      Test1_Field7;
        [ASIndex(8)]  public int     []      Test1_Field8;
        [ASIndex(9)]  public ushort  []      Test1_Field9;
        [ASIndex(10)] public short   []      Test1_Field10;
        [ASIndex(11)] public sbyte   []      Test1_Field11;
        [ASIndex(12)] public byte    []      Test1_Field12;
        [ASIndex(13)] public string  []      Test1_Field13;
        
        [ASIndex(14)] public uint    [][]    Test1_Field14;
        [ASIndex(15)] public int     [][]    Test1_Field15;
        [ASIndex(16)] public ushort  [][]    Test1_Field16;
        [ASIndex(17)] public short   [][]    Test1_Field17;
        [ASIndex(18)] public sbyte   [][]    Test1_Field18;
        [ASIndex(19)] public byte    [][]    Test1_Field19;
        [ASIndex(20)] public string  [][]    Test1_Field20;
    }

    [Serializable]
    public class TestFull
    {
        [ASIndex(0)]  public uint            Test_Field0;
        [ASIndex(1)]  public int             Test_Field1;
        [ASIndex(2)]  public ushort          Test_Field2;
        [ASIndex(3)]  public short           Test_Field3;
        [ASIndex(4)]  public sbyte           Test_Field4;
        [ASIndex(5)]  public byte            Test_Field5;
        [ASIndex(6)]  public string          Test_Field6;
                      
        [ASIndex(7)]  public uint    []      Test_Field7;
        [ASIndex(8)]  public int     []      Test_Field8;
        [ASIndex(9)]  public ushort  []      Test_Field9;
        [ASIndex(10)] public short   []      Test_Field10;
        [ASIndex(11)] public sbyte   []      Test_Field11;
        [ASIndex(12)] public byte    []      Test_Field12;
        [ASIndex(13)] public string  []      Test_Field13;
        
        [ASIndex(14)] public uint    [][]    Test_Field14;
        [ASIndex(15)] public int     [][]    Test_Field15;
        [ASIndex(16)] public ushort  [][]    Test_Field16;
        [ASIndex(17)] public short   [][]    Test_Field17;
        [ASIndex(18)] public sbyte   [][]    Test_Field18;
        [ASIndex(19)] public byte    [][]    Test_Field19;
        [ASIndex(20)] public string  [][]    Test_Field20;

        [ASIndex(21)] public TestJaggedArray           Test_Field21;
        [ASIndex(22)] public TestJaggedArray   []      Test_Field22;
        [ASIndex(23)] public TestJaggedArray   [][]    Test_Field23;
    }
}                                                  
                                                   