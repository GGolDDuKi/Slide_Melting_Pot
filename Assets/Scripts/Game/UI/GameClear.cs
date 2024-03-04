using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameClear : MonoBehaviour
{
    public void GameSuccess()
    {
        int child = transform.childCount;
        for (int i = 0; i < child; i++)
        {
            transform.GetChild(i).gameObject.SetActive(true);
        }
    }
}
