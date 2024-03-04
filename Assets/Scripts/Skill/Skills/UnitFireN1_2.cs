using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitFireN1_2 : Skill
{
    public override void DoSkill()
    {
        //불고미의 데미지 +15%
        불고미.allDamageBonus += 0.15f;
        base.DoSkill();
    }
}
