using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ColorFieldSetter : FieldSetter
{
    public Graphic TargetImage;

    protected override void UpdateValue()
    {
        object value = GetValue();
        if (value is Color)
        {
            Color colorValue = (Color)value;
            TargetImage.color = colorValue;
        }
    }
}
