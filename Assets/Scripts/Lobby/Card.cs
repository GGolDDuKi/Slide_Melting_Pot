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

    //ī�� �ִ�/���� ����
    public int MaxCardCount { get; private set; } = 10;
    public int CardCount { get; private set; } = 0;

    //ī�� �����ߴ��� Ȯ��
    public bool selecting = false;

    //ī�忡 �� ���� �ε���
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

    //ī�带 �⺻ ���·� �ʱ�ȭ
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

    //ī�� ���� ���¿��� ���� ��ư�� ������ ���� ���� UI ON
    public void ClickInfo()
    {
        for(int i = 0; i < subUI.transform.childCount; i++)
        {
            subUI.transform.GetChild(i).gameObject.SetActive(true);
        }
        //���� �̸� ǥ��
        subUI.transform.GetChild(1).GetChild(1).GetComponent<Text>().text = unitData.unitName;
        //���� �̹��� ǥ��
        subUI.transform.GetChild(1).GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetComponent<Image>().sprite = unitSprite;
        subUI.transform.GetChild(1).GetChild(0).GetChild(0).GetChild(1).GetChild(0).GetComponent<Text>().text = "0";
        subUI.transform.GetChild(1).GetChild(0).GetChild(0).GetChild(2).GetChild(0).GetComponent<Text>().text = $"{CardCount.ToString()} / {MaxCardCount.ToString()}";
        subUI.transform.GetChild(1).GetChild(0).GetChild(2).GetComponent<Text>().text = $"�Ӽ� : {unitData.element}";
        subUI.transform.GetChild(1).GetChild(0).GetChild(3).GetComponent<Text>().text = $"{unitData.unitInfo}";
        subUI.transform.GetChild(1).GetChild(0).GetChild(4).GetChild(2).GetComponent<Text>().text = $"{unitData.rangeLevel.ToString()}";
        subUI.transform.GetChild(1).GetChild(0).GetChild(5).GetChild(2).GetComponent<Text>().text = $"{unitData.damage.ToString()}";
        subUI.transform.GetChild(1).GetChild(0).GetChild(6).GetChild(2).GetComponent<Text>().text = $"{unitData.attackSpeed.ToString()}";

    }

    //ī�� ���� ���¿��� ��� ��ư�� ������ ������ ���� ������ �̵�
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

    //ī�� ������ �����Ǹ� ȣ��
    public void ClickReset()
    {
        selecting = false;
        ButtonChange();
    }

    public void ChangeState()
    {
        if (usingState == Using.UnUse)
        {
            cardCount.GetComponentInChildren<Text>().text = "���";
            cardCount.GetComponent<Button>().enabled = true;
        }
        else if (usingState == Using.Use)
        {
            cardCount.GetComponentInChildren<Text>().text = "����";
            cardCount.GetComponent<Button>().enabled = true;
        }
    }

    public void ButtonChange()
    {
        if(selecting == true)
        {
            unitLevel.GetComponentInChildren<Text>().text = "����";
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
