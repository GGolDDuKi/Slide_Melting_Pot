using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitGrassR1_4 : Skill
{
    public static bool unLock = false;

    public override void DoSkill()
    {
        //���þƸ��� ������ ���� 1������ �����մϴ�.
        unLock = true;
        base.DoSkill();
    }
}
