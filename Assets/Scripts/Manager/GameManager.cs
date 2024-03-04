using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

//Game 씬에서 사용되는 필드들
public class GameManager : MonoBehaviour
{
    //게임 내 플레이어 최대/현재 체력
    public float MaxHp { get; } = 100;
    public float Hp { get; set; } = 100;

    //게임 내 플레이어 레벨, 최대/현재 경험치
    public int Level { get; set; } = 0;
    public float MaxExp { get; set; } = 10;
    public float Exp { get; set; } = 0;

    //게임이 일시정지 상태인지 확인
    public bool Pause { get; set; }

    //게임 속도 저장 변수
    public float GameSpeed { get; set; } = 1f;

    //유닛 이동 가능 횟수
    public int MoveCount { get; private set; } = 15;

    //아이템 소환까지 남은 유닛 이동 횟수
    public int ItemCount { get; set; } = 0;     //3번 이동하면 아이템 소환?

    //게임 내에서 흘러가는 타이머
    public float Timer { get; set; }

    //현재 라운드
    public int Round { get; set; } = 0;

    //현재 라운드에 남은 적 수
    public int RemainEnemy;
    public int[] enemyCount = { 20, 30, 40, 1 };

    //전투 페이즈로 넘어갔는지 아닌지
    public bool gameStart = false;

    //적 유닛 디버프 관련
    public float EnemySlow { get; set; }

    //유틸 관련
    public float ExpBonus { get; set; }

    public static float attackSpeedBonus;
    public static float damageBonus;

    public List<int> skillIndex = new List<int>();
    public List<Unit> usingUnit = new List<Unit>();
    public List<GameObject> fieldUnits = new List<GameObject>();
    public DeckController[] deckTable;
    public List<ElementObject.Element> deckElement = new List<ElementObject.Element>();
    GameObject[] Items;

    public Transform skillObjects;
    public Canvas darkField;

    public void Init()
    {
        for(int i = 1001; i < 1013; i++)
        {
            skillIndex.Add(i);
        }
        skillIndex.Remove(1008);
        skillIndex.Remove(1009);

        foreach (var unit in Managers.Card.usingCard)
        {
            Unit unitData = new Unit();
            unitData.unitData = unit.unitData;
            unitData.SetUnitData(unit.unitData);
            usingUnit.Add(unitData);
            skillIndex.Add(unitData.unitData.skill1);
            skillIndex.Add(unitData.unitData.skill2);
            skillIndex.Add(unitData.unitData.skill3);
            skillIndex.Add(unitData.unitData.skill4);
        }

        Items = Resources.LoadAll<GameObject>("Prefabs/Items");
        Reset();
        deckElement.Clear();
        skillObjects = GameObject.Find("SkillObjects").transform;
        darkField = GameObject.Find("DarkField").GetComponent<Canvas>();
        deckTable = GameObject.Find("DeckTable").GetComponentsInChildren<DeckController>();
        for(int i = 0; i < deckTable.Length; i++)
        {
            deckTable[i].Init();
            deckTable[i].unit = usingUnit[i];
            deckTable[i].obj = Resources.Load<GameObject>($"Prefabs/Units/{deckTable[i].unit.unitData.unitName}");
            deckTable[i].transform.GetChild(1).GetComponent<Image>().sprite = Resources.Load<Sprite>($"Images/Units/Level0/{usingUnit[i].unitData.unitName}");
            deckTable[i].Cool.GetComponent<Image>().color = deckTable[i].unit.color[deckTable[i].unit.element];
            deckElement.Add(deckTable[i].unit.element);
        }
    }

    public void Reset()
    {
        Hp = MaxHp;
        Level = 0;
        Exp = 0;
        GameSpeed = 1f;
        MoveCount = 15;
        Round = 0;
        gameStart = false;
        Pause = false;
        Timer = 0;
        Managers.Tile.Clear();
        ItemCount = 0;
        fieldUnits.Clear();
        RemainEnemy = enemyCount[Round];
        ResetSkillBonus();
    }

    public void RoundReset()
    {
        Managers.Tile.LayerReset();
        gameStart = false;
        Round++;
        MoveCount += 15;
        RemainEnemy = enemyCount[Round];
    }

    public void ResetSkillBonus()
    {
        attackSpeedBonus = 0;
        damageBonus = 0;
        foreach(var unit in Managers.Data.UnitData.Values)
        {
            Type type = Type.GetType(unit.unitName);
            FieldInfo field1 = type.GetField("allAttackSpeedBonus");
            FieldInfo field2 = type.GetField("allDamageBonus");
            field1.SetValue(type, 0);
            field2.SetValue(type, 0);
            Debug.Log("필드를 0으로 초기화하였습니다.");
        }
        foreach(var skill in Managers.Skill.SkillDictionary.Values)
        {
            Type type = Type.GetType(skill.skillData.skillName);
            FieldInfo field1 = type.GetField("unLock");
            if(field1 != null)
            {
                field1.SetValue(type, false);
            }
            Debug.Log("스킬을 리셋했습니다.");
        }
    }

    public void ItemSpawn()
    {
        int rows = Managers.Tile.Tiles.GetLength(0);
        int cols = Managers.Tile.Tiles.GetLength(1);
        int row = UnityEngine.Random.Range(0, rows);
        int col = UnityEngine.Random.Range(0, cols);
        if(Managers.Tile.Tiles[row, col].transform.childCount > 0)
        {
            ItemSpawn();
        }
        else
        {
            GameObject item = Managers.Resource.Instantiate(Items[UnityEngine.Random.Range(0, Items.Length)], Managers.Tile.Tiles[row, col].transform);
            item.GetComponent<RectTransform>().anchoredPosition = Vector3.zero;
            item.GetComponent<RectTransform>().localScale = Vector3.one;
            ItemCount = 0;
        }
    }

    public void MoveCountPlus(int count)
    {
        MoveCount += count;
    }
}
