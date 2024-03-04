using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UnitController : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    float MaxDistance = 15f;
    LayerMask layerMask;
    GameManager gm;
    TileManager tm;
    Tile tile;
    public Sprite mergeUnit;
    [SerializeField] List<GameObject> mergeUnits = new List<GameObject>();
    [SerializeField] bool sameElement;
    [SerializeField] bool canMerge;

    public bool clicking = false;
    Vector2 baseSize = Vector2.one;
    public float size = 1.5f;

    void Start()
    {
        if (mergeUnit = Resources.Load<Sprite>($"Images/Units/Level{GetComponent<Unit>().mergeLevel + 1}/{gameObject.name}")) { }
        else
        {
            mergeUnit = null;
        }
        layerMask = LayerMask.GetMask("Tile");
        gm = Managers.Game;
        tm = Managers.Tile;
    }

    void Update()
    {
        UnitClickAnimation();   
    }

    void UnitClickAnimation()
    {
        if (clicking == true && (Vector2)transform.localScale != Vector2.one * size)
        {
            transform.localScale = Vector2.Lerp(transform.localScale, Vector2.one * size, 0.01f);
        }
        else if (clicking == false && (Vector2)transform.localScale != baseSize)
        {
            transform.localScale = Vector2.Lerp(transform.localScale, baseSize, 0.01f);
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        mergeUnits.Add(this.gameObject);
        baseSize = transform.localScale;
        clicking = true;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (gm.MoveCount == 0 || gm.gameStart == true)
            return;

        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(eventData.position);
        worldPosition.z = 0;

        RaycastHit2D hit = Physics2D.Raycast(worldPosition, transform.forward, MaxDistance, layerMask);
        if (hit)
        {
            tile = hit.transform.gameObject.GetComponent<Tile>();
            //FreeMove��ų�� Ȱ��ȭ�� ���¶�� ���Ǿ��� ���� �̵�, �� �����̳� �������� �ִ� ������ �̵� �Ұ�

            if (GetComponent<Unit>().element == tile.element)
                sameElement = true;
            else
                sameElement = false;

            //���� �ֺ� 1ĭ, ���� �Ӽ��� Ÿ���̰�
            if (tm.CheckRoad(transform.parent.GetComponent<Tile>(), tile) && transform.parent != tile.transform)
            {
                //�ش� Ÿ�Ͽ� ������Ʈ�� ���ų�, �������� ���� ���
                if(tile.transform.childCount == 0 || (tile.transform.childCount > 0 && tile.transform.GetChild(0).GetComponent<Item>()))
                {
                    //�������̸� ������ �ߵ�
                    if(tile.transform.childCount > 0)
                    {   
                        tile.transform.GetChild(0).GetComponent<Item>().Effect();   //������ ȿ�� �ߵ�, ������Ʈ Ǯ��
                    }

                    transform.parent.GetComponent<Tile>().ChangeElement();
                    transform.parent = tile.transform;
                    GetComponent<RectTransform>().localPosition = Vector2.zero;
                    gm.MoveCountPlus(-1);
                    gm.ItemCount++;
                    if(gm.ItemCount >= 15)
                    {
                        gm.ItemSpawn();
                    }
                    gm.Exp++;
                    Pause.CheckExp();

                    //������ ���ְ� ����Ʈ�ѷ��� ������ ������ �Ӽ��� ������ �ش� �� ��Ÿ�� ������ ����
                    for (int i = 0; i < gm.deckTable.Length; i++)
                    {
                        if (gm.deckTable[i].unit.element == transform.GetComponent<Unit>().element)
                        {
                            gm.deckTable[i].Cool.CoolNow += 1;
                        }
                    }
                }
                //���� ���ְ� 1ĭ�Ÿ��̰�, �巡������ Ÿ�Ͽ� �ڽ��� �������
                else if (tm.TileDistance(transform.parent.GetComponent<Tile>(), tile) == 1 && tile.transform.childCount > 0)
                {
                    //�ش� �ڽİ� ���� ������ ���� �������� Ȯ���ϰ� ������ ���� ����Ʈ�� �߰�
                    if (transform.name == tile.transform.GetChild(0).name && GetComponent<Unit>().mergeLevel == tile.transform.GetChild(0).GetComponent<Unit>().mergeLevel)
                    {
                        if (!mergeUnits.Contains(tile.transform.GetChild(0).gameObject))
                        {
                            mergeUnits.Add(tile.transform.GetChild(0).gameObject);
                            tile.transform.GetChild(0).GetComponent<UnitController>().clicking = true;
                        }
                        else
                        {
                            canMerge = true;
                        }
                    }
                }
                else
                {
                    canMerge = false;
                }
            }
            
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if(mergeUnits.Count >= 2 && sameElement == true && canMerge == true && mergeUnit != null)
        {
            Debug.Log("����!");
            for(int i = mergeUnits.Count - 1; i > 0 ; i--)
            {
                Destroy(mergeUnits[i]);
                mergeUnits.RemoveAt(i);
            }
            mergeUnits[0].transform.parent = tile.transform;
            mergeUnits[0].transform.localPosition = Vector3.zero;
            mergeUnits[0].GetComponent<Unit>().mergeLevel++;
            mergeUnits[0].GetComponent<Image>().sprite = mergeUnit;
            if (mergeUnit = Resources.Load<Sprite>($"Images/Units/Level{GetComponent<Unit>().mergeLevel + 1}/{gameObject.name}")) { }
            else
            {
                mergeUnit = null;
            }
        }
        foreach(GameObject unit in mergeUnits)
        {
            unit.GetComponent<UnitController>().clicking = false;
        }
        mergeUnits.Clear();
        sameElement = false;
        canMerge = false;
    }
}
