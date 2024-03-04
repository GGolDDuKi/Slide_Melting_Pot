using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitFireR1_2 : Skill
{
    public override void DoSkill()
    {
        //소토박의 용암장판의 점화 데미지 +20%
        소토박.allDamageBonus += 0.2f;
        base.DoSkill();
    }
}
