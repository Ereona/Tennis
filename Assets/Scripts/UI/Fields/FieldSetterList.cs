using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class FieldSetterList : MonoBehaviour
{
    public GameObject FieldSettersParent;
    private FieldSetter[] FieldSetters;

    private bool _inited = false;

    private void Init()
    {
        if (_inited)
        {
            return;
        }
        _inited = true;
        FieldSetters = FieldSettersParent.GetComponentsInChildren<FieldSetter>();
    }

    public void SetSourceObject(IFieldList source)
    {
        _source = source;
        UpdateValues();
    }

    public void UpdateValues()
    {
        if (_source != null)
        {
            SetFieldValues(_source.GetFieldValues());
        }
    }

    private void SetFieldValues(Dictionary<string, object> values)
    {
        Init();
        foreach (FieldSetter setter in FieldSetters)
        {
            object value;
            if (values.TryGetValue(setter.FieldName, out value))
            {
                setter.SetFieldValue(value);
            }
        }
    }

    private IFieldList _source;
}
