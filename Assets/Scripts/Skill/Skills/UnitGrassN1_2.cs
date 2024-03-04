using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitGrassN1_2 : Skill
{
    public override void DoSkill()
    {
        //재카로프의 공격속도 + 15%
        재카로프.allAttackSpeedBonus += 0.15f;
        base.DoSkill();
    }
}
