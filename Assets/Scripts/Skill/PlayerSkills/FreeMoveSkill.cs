//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.EventSystems;
//using UnityEngine.UI;

//public class FreeMoveSkill : Skill, IPointerClickHandler
//{
//    void Awake()
//    {
//        FreeMoveSkill fms = new FreeMoveSkill();
//        Managers.Skill.SkillList.Add(fms);
//        Debug.Log("fms ��ų����Ʈ�� �߰�");
//    }

//    public Text text;

//    public override void DoSkill()
//    {
//        GameObject skill = Instantiate(Resources.Load<GameObject>("Prefabs/Skills/PlayerSkills/FreeMoveSkill"));
//    }

//    Unit unit;
//    Tile tile;

//    float MaxDistance = 15f;
//    LayerMask layerMask;

//    public void Start()
//    {
//        foreach(GameObject unit in Managers.Game.fieldUnits)
//        {
//            unit.GetComponent<Collider2D>().enabled = false;
//        }
//        transform.parent = Managers.Game.skillObjects;
//        transform.localPosition = Vector2.zero;

//        Time.timeScale = 0f;
//        Managers.Tile.ChangeLayersUT();
//        text.text = "�̵���ų ������ �����ϼ���.";
//    }

//    public void OnPointerClick(PointerEventData eventData)
//    {
//        if (unit == null)
//        {
//            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(eventData.position);
//            worldPosition.z = 0;
//            layerMask = LayerMask.GetMask("Tile");
//            RaycastHit2D hit = Physics2D.Raycast(worldPosition, transform.forward, MaxDistance, layerMask);
//            if (hit.transform.GetComponentInChildren<Unit>())
//            {
//                Debug.Log("������ �����߽��ϴ�.");
//                unit = hit.transform.GetComponentInChildren<Unit>();
//                Managers.Tile.ChangeLayersTU();
//                text.text = "�̵��ϰ� ���� �� Ÿ���� �����ϼ���.";
//                text.fontSize = 50;
//            }
//        }
//        else if (tile == null)
//        {
//            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(eventData.position);
//            worldPosition.z = 0;
//            layerMask = LayerMask.GetMask("Tile");
//            RaycastHit2D hit = Physics2D.Raycast(worldPosition, transform.forward, MaxDistance, layerMask);
//            if (hit)
//            {
//                if (hit.transform.childCount <= 0)
//                {
//                    Debug.Log("Ÿ���� �����߽��ϴ�.");
//                    tile = hit.transform.GetComponent<Tile>();
//                }
//            }
//            tile.ChangeElement(unit.element);
//            unit.transform.parent = tile.transform;
//            unit.transform.localPosition = Vector2.zero;
//            Managers.Tile.LayerReset();
//            Time.timeScale = Managers.Game.GameSpeed;
//            foreach (GameObject unit in Managers.Game.fieldUnits)
//            {
//                unit.GetComponent<Collider2D>().enabled = true;
//            }
//            Destroy(this.gameObject);
//        }
//    }
//}
