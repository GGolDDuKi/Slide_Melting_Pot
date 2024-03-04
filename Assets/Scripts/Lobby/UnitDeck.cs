using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitDeck : MonoBehaviour
{
    public void SetUnitImage()
    {
        for(int i = 0; i < 4 ; i++)
        {
            if (i < Managers.Card.usingCard.Count)
            {
                transform.GetChild(i).GetChild(0).GetComponent<Image>().sprite = Managers.Card.usingCard[i].GetComponent<Card>().unitSprite;
            }
            else
            {
                transform.GetChild(i).GetChild(0).GetComponent<Image>().sprite = null;
            }
        }
    }
}
