using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitStormU1_2 : Skill
{
    public override void DoSkill()
    {
        //�ϴð������� ���ݼӵ� + 15%
        �ϴð�����.allAttackSpeedBonus += 0.15f;
        base.DoSkill();
    }
}
