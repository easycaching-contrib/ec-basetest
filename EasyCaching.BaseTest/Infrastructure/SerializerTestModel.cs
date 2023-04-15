using MemoryPack;
using ProtoBuf;

namespace EasyCaching.BaseTest.Infrastructure;

[Serializable]
[ProtoContract]
[MemoryPackable]
public partial class SerializerTestModel
{
    [ProtoMember(1)]
    public string Prop { get; set; }
}
