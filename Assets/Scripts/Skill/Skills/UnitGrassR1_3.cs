using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitGrassR1_3 : Skill
{
    public static bool unLock = false;

    public override void DoSkill()
    {
        //���þƸ��� ���� ������ ���Ϳ��� �ִ� ������ +200%
        unLock = true;
        base.DoSkill();
    }
}
