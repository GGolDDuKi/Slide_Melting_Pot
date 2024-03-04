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
//        Debug.Log("fms 스킬리스트에 추가");
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
//        text.text = "이동시킬 유닛을 선택하세요.";
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
//                Debug.Log("유닛을 선택했습니다.");
//                unit = hit.transform.GetComponentInChildren<Unit>();
//                Managers.Tile.ChangeLayersTU();
//                text.text = "이동하고 싶은 빈 타일을 선택하세요.";
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
//                    Debug.Log("타일을 선택했습니다.");
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
