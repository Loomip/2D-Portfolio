using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MapManager : MonoBehaviour
{
    //캐릭터를 소환할 자리
    List<Vector2> characterSpawnPositions = new List<Vector2>()
    {
        new Vector2(-5, 35),
        new Vector2(-5, 25),
        new Vector2(-5, 15),
        new Vector2(-11, 30),
        new Vector2(-11, 20),
        new Vector2(-18, 35),
        new Vector2(-18, 25),
        new Vector2(-18, 15),
        new Vector2(-25, 30),
        new Vector2(-25, 20)
    };

    List<Vector2> enemySpawnPositions = new List<Vector2>()
    {
        new Vector2(5, 35),
        new Vector2(5, 25),
        new Vector2(5, 15),
        new Vector2(11, 30),
        new Vector2(11, 20),
        new Vector2(18, 35),
        new Vector2(18, 25),
        new Vector2(18, 15),
        new Vector2(25, 30),
        new Vector2(25, 20)
    };

}
