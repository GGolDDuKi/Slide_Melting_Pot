using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitGroundN1_2 : Skill
{
    public override void DoSkill()
    {
        //가시도치의 데미지 +15%
        가시도치.allDamageBonus += 0.15f;
        base.DoSkill();
    }
}
