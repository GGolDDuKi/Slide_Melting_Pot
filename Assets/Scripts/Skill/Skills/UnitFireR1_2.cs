using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitFireR1_2 : Skill
{
    public override void DoSkill()
    {
        //������� ��������� ��ȭ ������ +20%
        �����.allDamageBonus += 0.2f;
        base.DoSkill();
    }
}
