using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSpeed : MonoBehaviour
{
    Text text;
    GameManager gm;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponentInChildren<Text>();
        gm = Managers.Game;
        text.text = "X " + gm.GameSpeed.ToString() + "배속";
    }

    public void SpeedControl()
    {
        if (gm.GameSpeed == 1f)
        {
            gm.GameSpeed = 2f;
            Time.timeScale = gm.GameSpeed;
        }
        else if (gm.GameSpeed == 2f)
        {
            gm.GameSpeed = 4f;
            Time.timeScale = gm.GameSpeed;
        }
        else
        {
            gm.GameSpeed = 1f;
            Time.timeScale = gm.GameSpeed;
        }
        text.text = "X " + gm.GameSpeed.ToString() + "배속";
    }
}
