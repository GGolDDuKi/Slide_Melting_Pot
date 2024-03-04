using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitGrassR1_2 : Skill
{
    public override void DoSkill()
    {
        //무궁아리의 공격속도 +15%
        무궁아리.allAttackSpeedBonus += 0.15f;
        base.DoSkill();
    }
}
