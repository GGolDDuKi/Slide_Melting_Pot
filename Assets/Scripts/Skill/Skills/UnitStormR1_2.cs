using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitStormR1_2 : Skill
{
    public override void DoSkill()
    {
        //전구르미의 공격속도 +15%
        전구르미.allAttackSpeedBonus += 0.15f;
        base.DoSkill();
    }
}
