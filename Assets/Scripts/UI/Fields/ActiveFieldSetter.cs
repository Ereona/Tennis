using UnityEngine;
using System.Collections;

public class ActiveFieldSetter : FieldSetter
{
    public GameObject Obj;

    protected override void UpdateValue()
    {
        object value = GetValue();
        if (value is bool)
        {
            Obj.SetActive((bool)value);
        }
    }
}
