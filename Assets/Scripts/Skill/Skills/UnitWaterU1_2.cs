using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitWaterU1_2 : Skill
{
    public override void DoSkill()
    {
        //하부기이 공격속도 + 15%
        하부기.allAttackSpeedBonus += 0.15f;
        base.DoSkill();
    }
}
