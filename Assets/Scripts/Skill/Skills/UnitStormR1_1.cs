using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitStormR1_1 : Skill
{
    public static bool unLock = false;

    public override void DoSkill()
    {
        //���������� ������ 20% Ȯ���� ���͸� ª�� ������Ű�� �������·� ����ϴ�.
        unLock = true;
        base.DoSkill();
    }
}
