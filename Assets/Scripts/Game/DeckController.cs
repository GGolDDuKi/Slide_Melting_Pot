using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DeckController : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    float MaxDistance = 15f;
    LayerMask layerMask;

    public GameObject obj;
    //public DragUnit UnitUI { get; set; }
    public Unit unit;
    public CoolDown Cool { get; set; }

    Vector2 basePosition;
    GameManager gm;
    TileManager tm;
    public bool zeroCool;

    public void Init()
    {
        MaxDistance = 15f;
        tm = Managers.Tile;
        gm = Managers.Game;
        layerMask = LayerMask.GetMask("Tile");
        //UnitUI = transform.GetChild(1).GetComponent<DragUnit>();
        Cool = transform.GetChild(0).GetComponent<CoolDown>();
    }

    void Update()
    {
        if (GetComponentInChildren<CoolDown>().CoolNow >= GetComponentInChildren<CoolDown>().CoolTime && zeroCool == false)
            zeroCool = true;
        else if (GetComponentInChildren<CoolDown>().CoolNow < GetComponentInChildren<CoolDown>().CoolTime && zeroCool == true)
            zeroCool = false;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (!zeroCool)
            return;

        basePosition = transform.GetChild(1).transform.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (!zeroCool)
            return;

        transform.GetChild(1).transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (!zeroCool)
            return;

        Tile tile;
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(eventData.position);
        worldPosition.z = 0;

        RaycastHit2D hit = Physics2D.Raycast(worldPosition, transform.GetChild(1).transform.forward, MaxDistance, layerMask);
        if (hit)
        {
            Debug.Log("EndDrag");
            tile = hit.transform.gameObject.GetComponent<Tile>();
            //주변에 유닛과 동일한 속성의 타일이 있고, 소환하려는 타일에 유닛이나 아이템이 없으면 소환
            if(tm.CheckAroundTile(tile, obj.GetComponent<Unit>().element) && tile.transform.childCount == 0)
            {
                GameObject newUnit = Instantiate<GameObject>(obj, tile.transform);
                newUnit.name = unit.unitData.unitName;
                newUnit.GetComponent<Unit>().SetUnitData(unit.unitData);
                newUnit.GetComponent<Image>().sprite = Resources.Load<Sprite>($"Images/Units/Level0/{unit.unitData.unitName}");
                tile.element = newUnit.GetComponent<Unit>().element;
                tile.ChangeColor(tile.element);
                Cool.CoolNow = 0;
                Debug.Log("유닛 소환");
                gm.fieldUnits.Add(newUnit);
            }
            else
            {
                Debug.Log("소환 실패");
            }
        }
        transform.GetChild(1).transform.position = basePosition;
    }
}
