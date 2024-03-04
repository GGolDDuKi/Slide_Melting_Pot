using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System;

[Serializable]
public class UnitData
{
    public int index;
    public string unitName;
    public string element;
    public string rarity;
    public float attackSpeed;
    public int damage;
    public string rangeType;
    public int rangeLevel;
    public string unitInfo;
    public int cardLv;
    public float mergeDamage;
    public int skill1;
    public int skill2;
    public int skill3;
    public int skill4;
}

[Serializable]
public class MissileData
{
    public int index;
    public string unitName;
    public float sizeX;
    public float sizeY;
    public string attackType;
    public float speed;
}

[Serializable]
public class SkillData
{
    public int index;
    public string skillClass;
    public string skillName;
    public string skillUser;
    public string skillInfo;
    public float skillEffect;
    public string rarity;
    public int overlap;
}

[Serializable]
public class EnemyData
{
    public int index;
    public string name;
    public float hp;
    public float damage;
    public float speed;
    public float sizeX;
    public float sizeY;
}

public class DataManager : MonoBehaviour
{
    //¿Ø¥÷ µ•¿Ã≈Õ∏¶ µÒº≈≥ ∏Æ
    private Dictionary<int, UnitData> unitData = new Dictionary<int, UnitData>();
    public Dictionary<int, UnitData> UnitData { get { return unitData; } }

    //¿Ø¥÷ ≈ıªÁ√º µ•¿Ã≈Õ µÒº≈≥ ∏Æ
    private Dictionary<int, MissileData> missileData = new Dictionary<int, MissileData>();
    public Dictionary<int, MissileData> MissileData { get { return missileData; } }

    //Ω∫≈≥ µ•¿Ã≈Õ µÒº≈≥ ∏Æ
    private Dictionary<int, SkillData> skillData = new Dictionary<int, SkillData>();
    public Dictionary<int, SkillData> SkillData { get { return skillData; } }

    //∏ÛΩ∫≈Õ µ•¿Ã≈Õ µÒº≈≥ ∏Æ
    private Dictionary<int, EnemyData> enemyData = new Dictionary<int, EnemyData>();
    public Dictionary<int, EnemyData> EnemyData { get { return enemyData; } }

    public void Init()
    {
        GetData();
    }

    public void GetData()
    {
        //¿Ø¥÷ µ•¿Ã≈Õ ¿–æÓø¿±‚
        unitData = JsonToUnity.ParsingUnitData("Json/UnitData");
        missileData = JsonToUnity.ParsingMissileData("Json/MissileData");
        skillData = JsonToUnity.ParsingSkillData("Json/SkillData");
    }
}

public class JsonToUnity
{
    public static TextAsset JsonFile;

    public static Dictionary<int, UnitData> ParsingUnitData(string path)
    {
        JsonFile = Resources.Load<TextAsset>(path);
        Dictionary<int, UnitData> DataDictionary = new Dictionary<int, UnitData>();
        DataDictionary = JsonConvert.DeserializeObject<Dictionary<int, UnitData>>(JsonFile.text);
        foreach (var data in DataDictionary)
        {
            data.Value.index = data.Key;
        }
        return DataDictionary;
    }

    public static Dictionary<int, MissileData> ParsingMissileData(string path)
    {
        JsonFile = Resources.Load<TextAsset>(path);
        Dictionary<int, MissileData> DataDictionary = new Dictionary<int, MissileData>();
        DataDictionary = JsonConvert.DeserializeObject<Dictionary<int, MissileData>>(JsonFile.text);
        foreach (var data in DataDictionary)
        {
            data.Value.index = data.Key;
        }
        return DataDictionary;
    }

    public static Dictionary<int, SkillData> ParsingSkillData(string path)
    {
        JsonFile = Resources.Load<TextAsset>(path);
        Dictionary<int, SkillData> DataDictionary = new Dictionary<int, SkillData>();
        DataDictionary = JsonConvert.DeserializeObject<Dictionary<int, SkillData>>(JsonFile.text);
        foreach (var data in DataDictionary)
        {
            data.Value.index = data.Key;
        }
        return DataDictionary;
    }

    public static Dictionary<int, EnemyData> ParsingEnemyData(string path)
    {
        JsonFile = Resources.Load<TextAsset>(path);
        Dictionary<int, EnemyData> DataDictionary = new Dictionary<int, EnemyData>();
        DataDictionary = JsonConvert.DeserializeObject<Dictionary<int, EnemyData>>(JsonFile.text);
        foreach (var data in DataDictionary)
        {
            data.Value.index = data.Key;
        }
        return DataDictionary;
    }
}
