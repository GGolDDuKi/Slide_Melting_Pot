using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitGrassU1_2 : Skill
{
    public override void DoSkill()
    {
        //멜리아스의 공격속도 +15%
        멜리아스.allAttackSpeedBonus += 0.15f;
        base.DoSkill();
    }
}
