using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitWaterU1_2 : Skill
{
    public override void DoSkill()
    {
        //�Ϻα��� ���ݼӵ� + 15%
        �Ϻα�.allAttackSpeedBonus += 0.15f;
        base.DoSkill();
    }
}
