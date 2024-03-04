using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomTilePosition : MonoBehaviour
{
    TileManager tm;

    private void Start()
    {
        tm = Managers.Tile;
    }

    public void OnClicked()
    {
        tm.TileReposition();
    }
}
