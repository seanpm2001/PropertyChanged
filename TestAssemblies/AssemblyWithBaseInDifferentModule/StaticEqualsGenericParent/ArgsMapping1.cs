﻿using System.ComponentModel;
using System.Runtime.CompilerServices;
using AssemblyWithBase.StaticEqualsGenericParent;

namespace AssemblyWithBaseInDifferentModule.StaticEqualsGenericParent;

public class ArgsMapping1 :
    INotifyPropertyChanged    {
    string property1;
    public string Property1
    {
        get => property1;
        set
        {
            property1 = value;
            Property2 = new();
        }
    }

    public ClassWithTwoBaseClasses1 Property2 { get; set; }

    public event PropertyChangedEventHandler PropertyChanged;
    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new(propertyName));
    }
}