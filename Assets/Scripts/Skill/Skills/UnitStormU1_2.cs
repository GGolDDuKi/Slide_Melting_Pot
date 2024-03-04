using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitStormU1_2 : Skill
{
    public override void DoSkill()
    {
        //하늘가오리의 공격속도 + 15%
        하늘가오리.allAttackSpeedBonus += 0.15f;
        base.DoSkill();
    }
}
