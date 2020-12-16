using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallInitializer : BallInitializerBase
{
    public float MinVelocity;
    public float MaxVelocity;
    public float MinSize;
    public float MaxSize;

    protected override void CreateBall()
    {
        if (BallInstance != null)
        {
            Destroy(BallInstance);
        }
        BallInstance = Instantiate(BallPrefab);
        float size = Random.Range(MinSize, MaxSize);
        BallInstance.transform.localScale = new Vector3(size, size, 1);
        Rigidbody2D rb = BallInstance.GetComponent<Rigidbody2D>();
        Vector2 direction = Random.insideUnitCircle.normalized;
        if (Mathf.Abs(direction.y) < Mathf.Abs(direction.x))
        {
            direction = Vector2.Perpendicular(direction);
        }
        float velocity = Random.Range(MinVelocity, MaxVelocity);
        rb.velocity = direction * velocity;
        SkinObject selectedSkin = SkinsController.Instance.GetSelectedSkin();
        if (selectedSkin != null)
        {
            SpriteRenderer renderer = BallInstance.GetComponent<SpriteRenderer>();
            renderer.color = selectedSkin.Colour;
        }
    }
}
