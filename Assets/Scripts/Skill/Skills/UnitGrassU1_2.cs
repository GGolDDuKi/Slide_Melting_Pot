using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitGrassU1_2 : Skill
{
    public override void DoSkill()
    {
        //�Ḯ�ƽ��� ���ݼӵ� +15%
        �Ḯ�ƽ�.allAttackSpeedBonus += 0.15f;
        base.DoSkill();
    }
}
