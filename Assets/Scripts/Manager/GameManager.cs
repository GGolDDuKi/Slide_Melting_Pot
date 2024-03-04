using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

//Game ������ ���Ǵ� �ʵ��
public class GameManager : MonoBehaviour
{
    //���� �� �÷��̾� �ִ�/���� ü��
    public float MaxHp { get; } = 100;
    public float Hp { get; set; } = 100;

    //���� �� �÷��̾� ����, �ִ�/���� ����ġ
    public int Level { get; set; } = 0;
    public float MaxExp { get; set; } = 10;
    public float Exp { get; set; } = 0;

    //������ �Ͻ����� �������� Ȯ��
    public bool Pause { get; set; }

    //���� �ӵ� ���� ����
    public float GameSpeed { get; set; } = 1f;

    //���� �̵� ���� Ƚ��
    public int MoveCount { get; private set; } = 15;

    //������ ��ȯ���� ���� ���� �̵� Ƚ��
    public int ItemCount { get; set; } = 0;     //3�� �̵��ϸ� ������ ��ȯ?

    //���� ������ �귯���� Ÿ�̸�
    public float Timer { get; set; }

    //���� ����
    public int Round { get; set; } = 0;

    //���� ���忡 ���� �� ��
    public int RemainEnemy;
    public int[] enemyCount = { 20, 30, 40, 1 };

    //���� ������� �Ѿ���� �ƴ���
    public bool gameStart = false;

    //�� ���� ����� ����
    public float EnemySlow { get; set; }

    //��ƿ ����
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
            Debug.Log("�ʵ带 0���� �ʱ�ȭ�Ͽ����ϴ�.");
        }
        foreach(var skill in Managers.Skill.SkillDictionary.Values)
        {
            Type type = Type.GetType(skill.skillData.skillName);
            FieldInfo field1 = type.GetField("unLock");
            if(field1 != null)
            {
                field1.SetValue(type, false);
            }
            Debug.Log("��ų�� �����߽��ϴ�.");
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
