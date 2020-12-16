using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallsInitializer : MonoBehaviour
{
    public GameObject BouncingWallPrefab;
    public GameObject DefeatWallPrefab;

    public static float LeftSide { get; private set; }
    public static float RightSide { get; private set; }

    void Start()
    {
        Vector3 minPoint = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0));
        Vector3 maxPoint = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        LeftSide = minPoint.x;
        RightSide = maxPoint.x;
        GameObject topWall = Instantiate(DefeatWallPrefab);
        topWall.transform.position = new Vector3(0, maxPoint.y + 0.5f, 0);
        topWall.transform.localScale = new Vector3(maxPoint.x - minPoint.x, 0.01f, 1);
        GameObject bottomWall = Instantiate(DefeatWallPrefab);
        bottomWall.transform.position = new Vector3(0, minPoint.y - 0.5f, 0);
        bottomWall.transform.localScale = new Vector3(maxPoint.x - minPoint.x, 0.01f, 1);
        GameObject leftWall = Instantiate(BouncingWallPrefab);
        leftWall.transform.position = new Vector3(minPoint.x, 0, 0);
        leftWall.transform.localScale = new Vector3(0.01f, maxPoint.y - minPoint.y + 1, 1);
        GameObject rightWall = Instantiate(BouncingWallPrefab);
        rightWall.transform.position = new Vector3(maxPoint.x, 0, 0);
        rightWall.transform.localScale = new Vector3(0.01f, maxPoint.y - minPoint.y + 1, 1);
    }
}
