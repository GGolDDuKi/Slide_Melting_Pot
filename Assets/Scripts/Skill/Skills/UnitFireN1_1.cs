using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitFireN1_1 : Skill
{
    public static bool unLock = false;

    public override void DoSkill()
    {
        //�Ұ���� ������ ���͸� �����ϸ� 5�� ���� 20% ��ŭ �������� ������ ��ȭ ���·� ����ϴ�.
        unLock = true;
        base.DoSkill();
    }
}
