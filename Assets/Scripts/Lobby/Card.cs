using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    public enum Using
    {
        Use,
        UnUse
    }

    public Using usingState;

    //카드 최대/현재 개수
    public int MaxCardCount { get; private set; } = 10;
    public int CardCount { get; private set; } = 0;

    //카드 선택했는지 확인
    public bool selecting = false;

    //카드에 들어갈 유닛 인덱스
    public UnitData unitData;
    public Sprite unitSprite;

    [SerializeField] GameObject subUI;
    [SerializeField] Image unitImage;
    [SerializeField] GameObject unitLevel;
    [SerializeField] GameObject cardCount;

    private void Start()
    {
        subUI = GameObject.Find("UnitInformation");
    }

    //카드를 기본 상태로 초기화
    public void InitCard(UnitData unitData)
    {
        this.unitData = unitData;
        unitSprite = Resources.Load<Sprite>($"Images/Units/Level0/{unitData.unitName}");
        if (unitImage.sprite != unitSprite)
        {
            unitImage.sprite = unitSprite;
        }
        if(unitLevel.GetComponentInChildren<Text>().text != "0"/*Managers.Data.UnitList[index].UnitLevel.ToString()*/)
        {
            unitLevel.GetComponentInChildren<Text>().text = "0"/*Managers.Data.UnitList[index].UnitLevel.ToString()*/;
        }
        cardCount.GetComponentInChildren<Text>().text = CardCount.ToString() + " / " + MaxCardCount.ToString();
    }

    public void ClickCard()
    {
        if(selecting == false)
        {
            selecting = true;
            ButtonChange();
        }
        else
        {
            selecting = false;
            ButtonChange();
        }
    }

    //카드 선택 상태에서 정보 버튼을 누르면 유닛 정보 UI ON
    public void ClickInfo()
    {
        for(int i = 0; i < subUI.transform.childCount; i++)
        {
            subUI.transform.GetChild(i).gameObject.SetActive(true);
        }
        //유닛 이름 표시
        subUI.transform.GetChild(1).GetChild(1).GetComponent<Text>().text = unitData.unitName;
        //유닛 이미지 표시
        subUI.transform.GetChild(1).GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetComponent<Image>().sprite = unitSprite;
        subUI.transform.GetChild(1).GetChild(0).GetChild(0).GetChild(1).GetChild(0).GetComponent<Text>().text = "0";
        subUI.transform.GetChild(1).GetChild(0).GetChild(0).GetChild(2).GetChild(0).GetComponent<Text>().text = $"{CardCount.ToString()} / {MaxCardCount.ToString()}";
        subUI.transform.GetChild(1).GetChild(0).GetChild(2).GetComponent<Text>().text = $"속성 : {unitData.element}";
        subUI.transform.GetChild(1).GetChild(0).GetChild(3).GetComponent<Text>().text = $"{unitData.unitInfo}";
        subUI.transform.GetChild(1).GetChild(0).GetChild(4).GetChild(2).GetComponent<Text>().text = $"{unitData.rangeLevel.ToString()}";
        subUI.transform.GetChild(1).GetChild(0).GetChild(5).GetChild(2).GetComponent<Text>().text = $"{unitData.damage.ToString()}";
        subUI.transform.GetChild(1).GetChild(0).GetChild(6).GetChild(2).GetComponent<Text>().text = $"{unitData.attackSpeed.ToString()}";

    }

    //카드 선택 상태에서 사용 버튼을 누르면 유닛이 현재 덱으로 이동
    public void ClickUse()
    {
        if (usingState == Using.UnUse)
        {
            CurrentDeck.AddCard(GetComponent<Card>());
        }
        else if (usingState == Using.Use)
        {
            CurrentDeck.UnUseCard(GetComponent<Card>());
        }
    }

    //카드 선택이 해제되면 호출
    public void ClickReset()
    {
        selecting = false;
        ButtonChange();
    }

    public void ChangeState()
    {
        if (usingState == Using.UnUse)
        {
            cardCount.GetComponentInChildren<Text>().text = "사용";
            cardCount.GetComponent<Button>().enabled = true;
        }
        else if (usingState == Using.Use)
        {
            cardCount.GetComponentInChildren<Text>().text = "해제";
            cardCount.GetComponent<Button>().enabled = true;
        }
    }

    public void ButtonChange()
    {
        if(selecting == true)
        {
            unitLevel.GetComponentInChildren<Text>().text = "정보";
            unitLevel.GetComponent<Button>().enabled = true;
            ChangeState();
        }
        else
        {
            unitLevel.GetComponentInChildren<Text>().text = "0"/*Managers.Data.UnitList[index].UnitLevel.ToString()*/;
            unitLevel.GetComponent<Button>().enabled = false;
            cardCount.GetComponentInChildren<Text>().text = CardCount.ToString() + " / " + MaxCardCount.ToString();
            cardCount.GetComponent<Button>().enabled = false;
        }
    }
}
