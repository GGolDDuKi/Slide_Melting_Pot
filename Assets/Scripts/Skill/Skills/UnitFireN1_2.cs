using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitFireN1_2 : Skill
{
    public override void DoSkill()
    {
        //�Ұ���� ������ +15%
        �Ұ��.allDamageBonus += 0.15f;
        base.DoSkill();
    }
}
