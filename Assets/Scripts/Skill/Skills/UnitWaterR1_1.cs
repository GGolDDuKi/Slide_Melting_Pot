using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitWaterR1_1 : Skill
{
    public static bool unLock = false;

    public override void DoSkill()
    {
        //�칫�ٹ��� ��ǰ������ 20% Ȯ���� ������ ���·� ����� 3�� ���� 50% �������� ����ϴ�.
        unLock = true;
        base.DoSkill();
    }
}
