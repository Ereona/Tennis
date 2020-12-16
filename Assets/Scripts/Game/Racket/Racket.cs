using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Racket : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            ScoresCounter.Score++;
        }
    }

    public void MoveRacket(float translation)
    {
        float newXPos = transform.position.x + translation;
        float clamped = Mathf.Clamp(newXPos, WallsInitializer.LeftSide, WallsInitializer.RightSide);
        transform.position = new Vector3(clamped, transform.position.y, transform.position.z);
        GlobalEvents.RaiseOnRacketPositionChanged(this);
    }
}
