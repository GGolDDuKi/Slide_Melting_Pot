using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentDeck : MonoBehaviour
{
    public static void AddCard(Card card)
    {
        GameObject deck = GameObject.Find("Units");

        if(Managers.Card.usingCard.Count < 4)
        {
            card.transform.parent = deck.transform;
            card.GetComponent<RectTransform>().anchorMin = new Vector2(0.5f, 0.5f);
            card.GetComponent<RectTransform>().anchorMax = new Vector2(0.5f, 0.5f);
            card.GetComponent<RectTransform>().localPosition = Vector3.zero;
            Managers.Card.usingCard.Add(card);
            Managers.Card.unUsingCard.Remove(card);
            card.usingState = Card.Using.Use;
            card.selecting = false;
            card.ButtonChange();
            GameObject.Find("UnitDeck").GetComponent<UnitDeck>().SetUnitImage();
            //GameObject.Find("Cards").GetComponent<UnitList>().CardSort();
        }
    }

    public static void UnUseCard(Card card)
    {
        GameObject deck = GameObject.Find("Cards");
        card.transform.parent = deck.transform;
        card.GetComponent<RectTransform>().anchorMin = new Vector2(0.5f, 0.5f);
        card.GetComponent<RectTransform>().anchorMax = new Vector2(0.5f, 0.5f);
        card.GetComponent<RectTransform>().localPosition = Vector3.zero;

        Managers.Card.unUsingCard.Add(card);
        Managers.Card.usingCard.Remove(card);
        card.usingState = Card.Using.UnUse;
        card.selecting = false;
        card.ButtonChange();
        GameObject.Find("UnitDeck").GetComponent<UnitDeck>().SetUnitImage();
        //deck.GetComponent<UnitList>().CardSort();
    }
}
