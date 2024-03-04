using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SystemManager : MonoBehaviour
{
    //�÷��̾� �ڿ�
    public int Gold { get; private set; }
    public int Gem { get; private set; }
    public int Energy { get; private set; }

    //���� ���� ��� ����(�Ƹ� ī��� ����ɵ�?)
    public Unit[] allUnits;

    //�÷��̾ ������ ī�� 4���� ����
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
