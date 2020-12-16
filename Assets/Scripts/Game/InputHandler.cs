using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputHandler : MonoBehaviour
{
    private bool overUI = false;

    void Update()
    {
        if (IsPointerOverUI())
        {
            return;
        }
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                GlobalEvents.RaiseOnTouchDown(touch.position);
            }
            else if (touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary)
            {
                GlobalEvents.RaiseOnTouch(touch.position);
            }
            else
            {
                GlobalEvents.RaiseOnTouchUp(touch.position);
            }
        }
#if UNITY_EDITOR
        if (Input.GetMouseButtonDown(0))
        {
            GlobalEvents.RaiseOnTouchDown(Input.mousePosition);
        }
        if (Input.GetMouseButton(0))
        {
            GlobalEvents.RaiseOnTouch(Input.mousePosition);
        }
        if (Input.GetMouseButtonUp(0))
        {
            GlobalEvents.RaiseOnTouchUp(Input.mousePosition);
        }
#endif
    }

    public bool IsPointerOverUI()
    {
        // check mouse
        if (EventSystem.current.IsPointerOverGameObject())
            return true;

        //check touch
        if (Input.touchCount > 0)
        {
            Touch touch = Input.touches[0];
            if (touch.phase == TouchPhase.Began || touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary)
            {
                overUI = EventSystem.current.IsPointerOverGameObject(touch.fingerId);
                return overUI;
            }
            else
            {
                return overUI;
            }

        }

        return false;
    }
}
