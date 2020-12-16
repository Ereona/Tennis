using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEventReceiver
{
    void ReceiveEvent(string name, object parameter);
}
