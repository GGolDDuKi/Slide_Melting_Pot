using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitGroundU1_2 : Skill
{
    public override void DoSkill()
    {
        //모래강쥐의 공격속도 +15%
        모래강쥐.allAttackSpeedBonus += 0.15f;
        base.DoSkill();
    }
}
