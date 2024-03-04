using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStartNow : MonoBehaviour
{
    GameManager gm;
    [SerializeField] private GameObject spawners;

    private void Start()
    {
        gm = Managers.Game;
    }

    public void StartNow()
    {
        if(gm.gameStart == false)
        {
            gm.gameStart = true;
            GameObject.Find("TileReposition").SetActive(false);
            Managers.Tile.ChangeLayersUT();
        }
    }
}
