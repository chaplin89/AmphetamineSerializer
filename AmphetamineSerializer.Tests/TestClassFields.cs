﻿using AmphetamineSerializer.Model.Attributes;
using System;
using System.Runtime.Serialization;


namespace AmphetamineSerializer.Tests
{
    [Serializable, DataContract]
    public class TestFieldTrivialTypes
    {
        [ASIndex(0), DataMember]  public uint            Test_Field0;
        [ASIndex(1), DataMember]  public int             Test_Field1;
        [ASIndex(2), DataMember]  public ushort          Test_Field2;
        [ASIndex(3), DataMember]  public short           Test_Field3;
        [ASIndex(4), DataMember]  public sbyte           Test_Field4;
        [ASIndex(5), DataMember]  public byte            Test_Field5;
        [ASIndex(6), DataMember]  public string          Test_Field6;
    }

    [Serializable, DataContract]
    public class TestField1DArray
    {
        [ASIndex(00), DataMember] public uint            Test_Field0;
        [ASIndex(01), DataMember] public int             Test_Field1;
        [ASIndex(02), DataMember] public ushort          Test_Field2;
        [ASIndex(03), DataMember] public short           Test_Field3;
        [ASIndex(04), DataMember] public sbyte           Test_Field4;
        [ASIndex(05), DataMember] public byte            Test_Field5;
        [ASIndex(06), DataMember] public string          Test_Field6;

        [ASIndex(07), DataMember] public uint    []      Test_Field7;
        [ASIndex(08), DataMember] public int     []      Test_Field8;
        [ASIndex(09), DataMember] public ushort  []      Test_Field9;
        [ASIndex(10), DataMember] public short   []      Test_Field10;
        [ASIndex(11), DataMember] public sbyte   []      Test_Field11;
        [ASIndex(12), DataMember] public byte    []      Test_Field12;
        [ASIndex(13), DataMember] public string  []      Test_Field13;
    }

    [Serializable, DataContract]
    public class TestFieldJaggedArray
    {
        [ASIndex(00), DataMember] public uint            Test_Field0;
        [ASIndex(01), DataMember] public int             Test_Field1;
        [ASIndex(02), DataMember] public ushort          Test_Field2;
        [ASIndex(03), DataMember] public short           Test_Field3;
        [ASIndex(04), DataMember] public sbyte           Test_Field4;
        [ASIndex(05), DataMember] public byte            Test_Field5;
        [ASIndex(06), DataMember] public string          Test_Field6;

        [ASIndex(07), DataMember] public uint    []      Test_Field7;
        [ASIndex(08), DataMember] public int     []      Test_Field8;
        [ASIndex(09), DataMember] public ushort  []      Test_Field9;
        [ASIndex(10), DataMember] public short   []      Test_Field10;
        [ASIndex(11), DataMember] public sbyte   []      Test_Field11;
        [ASIndex(12), DataMember] public byte    []      Test_Field12;
        [ASIndex(13), DataMember] public string  []      Test_Field13;
        
        [ASIndex(14), DataMember] public uint    [][]    Test_Field14;
        [ASIndex(15), DataMember] public int     [][]    Test_Field15;
        [ASIndex(16), DataMember] public ushort  [][]    Test_Field16;
        [ASIndex(17), DataMember] public short   [][]    Test_Field17;
        [ASIndex(18), DataMember] public sbyte   [][]    Test_Field18;
        [ASIndex(19), DataMember] public byte    [][]    Test_Field19;
        [ASIndex(20), DataMember] public string  [][]    Test_Field20;
    }

    [Serializable, DataContract]
    public class TestFieldFull
    {
        [ASIndex(00), DataMember] public uint            Test_Field0;
        [ASIndex(01), DataMember] public int             Test_Field1;
        [ASIndex(02), DataMember] public ushort          Test_Field2;
        [ASIndex(03), DataMember] public short           Test_Field3;
        [ASIndex(04), DataMember] public sbyte           Test_Field4;
        [ASIndex(05), DataMember] public byte            Test_Field5;
        [ASIndex(06), DataMember] public string          Test_Field6;

        [ASIndex(07), DataMember] public uint    []      Test_Field7;
        [ASIndex(08), DataMember] public int     []      Test_Field8;
        [ASIndex(09), DataMember] public ushort  []      Test_Field9;
        [ASIndex(10), DataMember] public short   []      Test_Field10;
        [ASIndex(11), DataMember] public sbyte   []      Test_Field11;
        [ASIndex(12), DataMember] public byte    []      Test_Field12;
        [ASIndex(13), DataMember] public string  []      Test_Field13;
        
        [ASIndex(14), DataMember] public uint    [][]    Test_Field14;
        [ASIndex(15), DataMember] public int     [][]    Test_Field15;
        [ASIndex(16), DataMember] public ushort  [][]    Test_Field16;
        [ASIndex(17), DataMember] public short   [][]    Test_Field17;
        [ASIndex(18), DataMember] public sbyte   [][]    Test_Field18;
        [ASIndex(19), DataMember] public byte    [][]    Test_Field19;
        [ASIndex(20), DataMember] public string  [][]    Test_Field20;

        [ASIndex(21), DataMember] public TestFieldJaggedArray Test_Field21;
        [ASIndex(22), DataMember] public TestFieldJaggedArray[]      Test_Field22;
        [ASIndex(23), DataMember] public TestFieldJaggedArray[][]    Test_Field23;
    }

    [Serializable, DataContract]
    public class TestFieldFullVersion
    {
        [ASIndex(00), DataMember] public int           Version;

        [ASIndex(02, Version = 100), DataMember] public float Test_100;
        [ASIndex(03, Version = 101), DataMember] public double Test_101;
        [ASIndex(04, Version = 102), DataMember] public FieldContained_102 Test_102;

        // [ASIndex(21)] public TestJaggedArray           Test_Field21;
        // [ASIndex(22)] public TestJaggedArray   []      Test_Field22;
        // [ASIndex(23)] public TestJaggedArray   [][]    Test_Field23;
    }

    [Serializable, DataContract]
    public class FieldContained_100
    {
        [ASIndex(01)] public int             Test_Field1;
        [ASIndex(02)] public ushort          Test_Field2;
        [ASIndex(03)] public short           Test_Field3;
        [ASIndex(04)] public sbyte           Test_Field4;
        [ASIndex(05)] public byte            Test_Field5;
        [ASIndex(06)] public string          Test_Field6;
    }
    
    [Serializable, DataContract]
    public class FieldContained_101
    {
        [ASIndex(01)] public uint    []      Test_Field7;
        [ASIndex(02)] public int     []      Test_Field8;
        [ASIndex(03)] public ushort  []      Test_Field9;
        [ASIndex(04)] public short   []      Test_Field10;
        [ASIndex(05)] public sbyte   []      Test_Field11;
        [ASIndex(06)] public byte    []      Test_Field12;
        [ASIndex(07)] public string  []      Test_Field13;
    }

    [Serializable, DataContract]
    public class FieldContained_102
    {
        [ASIndex(01)] public uint    [][]    Test_Field14;
        [ASIndex(02)] public int     [][]    Test_Field15;
        [ASIndex(03)] public ushort  [][]    Test_Field16;
        [ASIndex(04)] public short   [][]    Test_Field17;
        [ASIndex(05)] public sbyte   [][]    Test_Field18;
        [ASIndex(06)] public byte    [][]    Test_Field19;
        [ASIndex(07)] public string  [][]    Test_Field20;
    }
}