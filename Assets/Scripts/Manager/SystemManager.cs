using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SystemManager : MonoBehaviour
{
    //플레이어 자원
    public int Gold { get; private set; }
    public int Gem { get; private set; }
    public int Energy { get; private set; }

    //게임 내의 모든 유닛(아마 카드로 변경될듯?)
    public Unit[] allUnits;

    //플레이어가 선택한 카드 4개의 유닛
    public GameObject[] PlayerUnits { get; set; } = new GameObject[4];

    public void Init()
    {
        allUnits = Resources.LoadAll<Unit>("Prefabs/Units/Level0");
        PlayerUnits[0] = Resources.Load<GameObject>("Prefabs/Units/Level0/Bear");
        PlayerUnits[1] = Resources.Load<GameObject>("Prefabs/Units/Level0/Hedgehog");
        PlayerUnits[2] = Resources.Load<GameObject>("Prefabs/Units/Level0/Octopus");
        PlayerUnits[3] = Resources.Load<GameObject>("Prefabs/Units/Level0/Flower");
    }
}
