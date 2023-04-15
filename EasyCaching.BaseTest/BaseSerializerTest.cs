﻿using EasyCaching.BaseTest.Infrastructure;
using EasyCaching.Core.Serialization;

namespace EasyCaching.BaseTest;

public abstract class BaseSerializerTest
{
    protected IEasyCachingSerializer _serializer;

    [Fact]
    public void Serialize_Object_Should_Succeed()
    {
        var res = _serializer.Serialize(new SerializerTestModel { Prop = "abc" });

        Assert.NotEmpty(res);
    }

    [Fact]
    public void Deserialize_Object_Should_Succeed()
    {
        var bytes = _serializer.Serialize(new SerializerTestModel { Prop = "abc" });

        var res = _serializer.Deserialize<SerializerTestModel>(bytes);

        Assert.Equal("abc", res.Prop);
    }

    [Fact]
    public void SerializeObject_should_Succeed()
    {
        object obj = new SerializerTestModel { Prop = "abc" };

        var bytes = _serializer.SerializeObject(obj);

        Assert.NotEmpty(bytes);
    }

    [Fact]
    public virtual void DeserializeObject_should_Succeed()
    {
        object obj = new SerializerTestModel { Prop = "abc" };

        var bytes = _serializer.SerializeObject(obj);

        var desObj = _serializer.DeserializeObject(bytes) as SerializerTestModel;

        Assert.Equal("abc", desObj.Prop);
    }


    [Theory]
    [InlineData("N2L7KXa084WvelONYjkJ_traBMCCvy_UKmpUUzlrQ0EA2yNp3Iz6eSUrRG0bhaR_viswd50vDuPkY5nG43d1gbm-olT2KRMxOsVE08RfeD9lvK9lMguNG9kpIkKGZEjIf8Jv2m9fFhf8bnNa-yQH3g")]
    [InlineData("123abc")]
    public void Serialize_String_Should_Succeed(string str)
    {
        var res = _serializer.Serialize(str);

        Assert.NotEmpty(res);
    }

    [Theory]
    [InlineData("N2L7KXa084WvelONYjkJ_traBMCCvy_UKmpUUzlrQ0EA2yNp3Iz6eSUrRG0bhaR_viswd50vDuPkY5nG43d1gbm-olT2KRMxOsVE08RfeD9lvK9lMguNG9kpIkKGZEjIf8Jv2m9fFhf8bnNa-yQH3g")]
    [InlineData("123abc")]
    public void Deserialize_String_Should_Succeed(string str)
    {
        var bytes = _serializer.Serialize(str);

        var res = _serializer.Deserialize<string>(bytes);

        Assert.Equal(str, res);
    }

}

