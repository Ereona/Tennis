using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventReceiverFieldSetter : FieldSetter
{
    public EventSender Sender;

    protected override void UpdateValue()
    {
        object value = GetValue();
        if (value is IEventReceiver)
        {
            Sender.SetReceiver((IEventReceiver)value);
        }
        else if (value == null)
        {
            Sender.SetReceiver(null);
        }
    }
}
