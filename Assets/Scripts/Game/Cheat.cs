using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cheat : MonoBehaviour
{
    GameManager gm;

    private void Start()
    {
        gm = Managers.Game;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            gm.Hp = 0;
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            gm.RemainEnemy = 0;
        }
    }
}
