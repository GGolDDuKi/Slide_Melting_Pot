using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitGroundN1_2 : Skill
{
    public override void DoSkill()
    {
        //���õ�ġ�� ������ +15%
        ���õ�ġ.allDamageBonus += 0.15f;
        base.DoSkill();
    }
}
