using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitList : MonoBehaviour
{
    public List<Card> unitList = new List<Card>();
    DataManager dm;

    public void Start()
    {
        dm = Managers.Data;
        InitCards();
    }

    public void InitCards()
    {
        Managers.Card.allCard.Clear();
        Managers.Card.unUsingCard.Clear();
        Managers.Card.usingCard.Clear();
        int unitCount = dm.UnitData.Count;
        
        //만들어져있는 카드가 전체 유닛 수보다 적으면 적은만큼 만들어 unitList에 넣기
        if(Managers.Card.allCard.Count < unitCount)
        {
            int lack = unitCount - unitList.Count;
            for(int i = 0; i < lack; i++)
            {
                Card card = Instantiate<Card>(Resources.Load<Card>("Prefabs/Cards/Card"));
                card.name = "Card";
                card.transform.parent = this.transform;
                unitList.Add(card);
                Managers.Card.allCard.Add(card);
                Managers.Card.unUsingCard.Add(card);
                card.usingState = Card.Using.UnUse;
                card.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
            }
        }
        
        for(int i = 0; i < unitList.Count; i++)
        {
            unitList[i].InitCard(dm.UnitData[i]);
        }

        //발표용 유닛들 설정
        foreach (var card in unitList)
        {
            if (card.unitData.unitName == "불고미" || card.unitData.unitName == "우무꾸미" || card.unitData.unitName == "무궁아리" || card.unitData.unitName == "전구르미")
            {
                CurrentDeck.AddCard(card);
            }
        }
    }

    //public void CardSort()
    //{
    //    List<Card> sortedCards = new List<Card>();
    //    List<Card> unSortedCards = new List<Card>();
    //    unSortedCards.AddRange(transform.GetComponentsInChildren<Card>());
    //    Card card = null;

    //    for(int i = 0; i < unSortedCards.Count; i++)
    //    {
    //        card = unSortedCards[i];
    //        for(int j = i + 1; j < unSortedCards.Count; j++)
    //        {
    //            if(card.unitData.index > unSortedCards[j].unitData.index)
    //            {
    //                card = unSortedCards[j];
    //            }
    //        }
    //        sortedCards.Add(card);
    //    }

    //    transform.DetachChildren();

    //    foreach(var sortedCard in sortedCards)
    //    {
    //        sortedCard.transform.SetParent(transform);
    //    }
    //}
}
