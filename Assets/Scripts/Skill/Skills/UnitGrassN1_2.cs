using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitGrassN1_2 : Skill
{
    public override void DoSkill()
    {
        //��ī������ ���ݼӵ� + 15%
        ��ī����.allAttackSpeedBonus += 0.15f;
        base.DoSkill();
    }
}
