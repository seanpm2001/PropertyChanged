﻿#if NETFRAMEWORK
using ICSharpCode.Decompiler.Metadata;
using PropertyChanged;
using PropertyChanging;

namespace SmokeTest;
[UsesVerify]
public sealed class CombinedChangingAndChangedWeaverTests : IDisposable
{
    PEFile _file = new(typeof(Testee).Assembly.Location);

    static CombinedChangingAndChangedWeaverTests()
    {
        VerifyICSharpCodeDecompiler.Initialize();
    }

    PropertyToDisassemble GetProperty(string propertyName)
    {
        return new PropertyToDisassemble(_file, "SmokeTest.Testee", propertyName, PropertyParts.Setter);
    }

    [Fact]
    public async Task ReferenceTypeProperty()
    {
        await Verify(GetProperty("Property1")).UniqueForAssemblyConfiguration();
    }

    [Fact]
    public async Task ValueTypeProperty()
    {
        await Verify(GetProperty("Property2")).UniqueForAssemblyConfiguration();
    }

    [Fact]
    public async Task NullableValueTypeProperty()
    {
        await Verify(GetProperty("Property3")).UniqueForAssemblyConfiguration();
    }

    public void Dispose()
    {
        _file.Dispose();
    }
}

[ImplementPropertyChanging]
[AddINotifyPropertyChangedInterface]
public class Testee
{
    public string Property1 { get; set; }

    public int Property2 { get; set; }

    public int? Property3 { get; set; }
}

#endif

