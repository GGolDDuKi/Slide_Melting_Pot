using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeAndRound : MonoBehaviour
{
    Text text;
    GameManager gm;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponentInChildren<Text>();
        gm = Managers.Game;
    }

    // Update is called once per frame
    void Update()
    {
        gm.Timer += Time.deltaTime;

        text.text = gm.Timer.ToString("F0") + " / " + (gm.Round + 1).ToString() + "R";
        
    }
}
