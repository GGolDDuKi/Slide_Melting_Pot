using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDestinations : MonoBehaviour
{
    private static Vector2[] s_enemyDestination = {
        new Vector2(2.5f, 1),
        new Vector2(-2.5f, 1),
        new Vector2(0, 3.5f)
    };
    public static Vector2[] EnemyDestination { get { return s_enemyDestination; } }
}
