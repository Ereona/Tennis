using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WebBallInitializer : BallInitializerBase
{
    protected override void CreateBall()
    {
        BallInstance = Instantiate(BallPrefab);
        // получение характеристик мяча с сервера и применение их к созданному экземпляру
        // также этот класс может корректировать положение мяча в зависимости от данных с сервера
    }
}
