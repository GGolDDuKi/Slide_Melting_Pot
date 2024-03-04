using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public void GameFail()
    {
        int child = transform.childCount;
        for(int i = 0; i < child; i++)
        {
            transform.GetChild(i).gameObject.SetActive(true);
        }
    }
}
