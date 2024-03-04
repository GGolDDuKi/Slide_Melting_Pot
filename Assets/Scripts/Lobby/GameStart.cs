using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStart : MonoBehaviour
{
    SceneManagerEx sm;

    private void Start()
    {
        sm = Managers.Scene;
    }

    public void OnGameStart()
    {
        sm.LoadScene("Game");
    }
}
