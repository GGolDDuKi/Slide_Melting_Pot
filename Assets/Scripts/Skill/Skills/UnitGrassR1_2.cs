using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitGrassR1_2 : Skill
{
    public override void DoSkill()
    {
        //���þƸ��� ���ݼӵ� +15%
        ���þƸ�.allAttackSpeedBonus += 0.15f;
        base.DoSkill();
    }
}
