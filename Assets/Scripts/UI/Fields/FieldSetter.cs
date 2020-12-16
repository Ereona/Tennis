using UnityEngine;
using System.Collections;

public class FieldSetter : MonoBehaviour 
{
    public string FieldName;
    private object Value;

    public void SetFieldValue(object value)
    {
        Value = value;
        UpdateValue();
    }

    protected virtual void UpdateValue()
    { }

    protected object GetValue()
    {
        return Value;
    }
}
