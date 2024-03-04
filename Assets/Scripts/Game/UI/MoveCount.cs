using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveCount : MonoBehaviour
{
    GameManager gm;
    Text text;

    // Start is called before the first frame update
    void Start()
    {
        gm = Managers.Game;
        text = GetComponentInChildren<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = gm.MoveCount.ToString();

        if(gm.gameStart == false)
        {
            transform.GetChild(1).gameObject.SetActive(true);
        }
        else
        {
            transform.GetChild(1).gameObject.SetActive(false);
        }
    }
}
