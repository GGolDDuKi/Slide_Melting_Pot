using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitStormR1_4 : Skill
{
    public static bool unLock = false;

    public override void DoSkill()
    {
        //���������� ������ ������ Ȥ�� ���� ������ ���Ϳ��� ������ +200% �������� �ָ�, �ֺ� ���Ϳ��� �ѹ��� ���ĵ˴ϴ�.
        unLock = true;
        base.DoSkill();
    }
}
