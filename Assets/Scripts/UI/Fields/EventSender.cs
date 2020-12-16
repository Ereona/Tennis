using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventSender : MonoBehaviour
{
    public string EventName;
    IEventReceiver Receiver;

    public void SendEvent()
    {
        SendEvent(null);
    }

    public void SendEvent(object parameter)
    {
        if (Receiver != null)
        {
            Receiver.ReceiveEvent(EventName, parameter);
        }
    }

    public void SetReceiver(IEventReceiver receiver)
    {
        Receiver = receiver;
    }
}
