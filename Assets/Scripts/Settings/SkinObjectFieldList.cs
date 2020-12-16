using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkinObjectFieldList : IFieldList, IEventReceiver, ISelectableItem
{
    public event Action<SkinObjectFieldList> onButtonClick;

    public SkinObjectFieldList(SkinObject source)
    {
        SourceObject = source;
    }

    public SkinObject SourceObject { get; private set; }

    public bool IsSelected 
    { 
        get; 
        set; 
    }

    public Dictionary<string, object> GetFieldValues()
    {
        Dictionary<string, object> values = new Dictionary<string, object>();
        values.Add("Color", SourceObject.Colour);
        values.Add("IsSelected", IsSelected);
        values.Add("EventReceiver", this);
        return values;
    }

    public void ReceiveEvent(string name, object parameter)
    {
        if (name == "ButtonClick")
        {
            onButtonClick?.Invoke(this);
        }
    }
}
