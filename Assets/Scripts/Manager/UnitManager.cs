using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitManager : MonoBehaviour
{
    //UnitData를 Unit으로 변경하여 모든 유닛을 저장한 리스트
    private Dictionary<int, Unit> unitData = new Dictionary<int, Unit>();
    public Dictionary<int, Unit> UnitData { get { return unitData; } }

    public void Init()
    {
        SetUnitList();
    }

    void SetUnitList()
    {
        foreach (UnitData unit in Managers.Data.UnitData.Values)
        {
            Type type = Type.GetType(unit.unitName);
            Unit newUnit= (Unit)Activator.CreateInstance(type);
            newUnit.unitData = unit;
            unitData.Add(newUnit.unitData.index, newUnit);
        }
    }
}
