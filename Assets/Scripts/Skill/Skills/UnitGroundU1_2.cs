using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitGroundU1_2 : Skill
{
    public override void DoSkill()
    {
        //�𷡰����� ���ݼӵ� +15%
        �𷡰���.allAttackSpeedBonus += 0.15f;
        base.DoSkill();
    }
}
