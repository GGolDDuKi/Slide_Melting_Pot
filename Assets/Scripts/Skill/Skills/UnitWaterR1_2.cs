using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitWaterR1_2 : Skill
{
    public override void DoSkill()
    {
        //�칫�ٹ��� ���ݼӵ� +10%
        �칫�ٹ�.allAttackSpeedBonus += 0.1f;
        base.DoSkill();
    }
}
