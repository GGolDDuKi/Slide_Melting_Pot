using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitWaterR1_2 : Skill
{
    public override void DoSkill()
    {
        //우무꾸미의 공격속도 +10%
        우무꾸미.allAttackSpeedBonus += 0.1f;
        base.DoSkill();
    }
}
