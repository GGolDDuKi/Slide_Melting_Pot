using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitWaterR1_4 : Skill
{
    public static bool unLock = false;

    public override void DoSkill()
    {
        //�칫�ٹ̰� ��ȭ������ ���͸� �����ϸ�, 15% Ȯ���� ������ ���� ������ �߻��ϸ�, ���� �ֺ� ���Ϳ��� 200% �������� �ݴϴ�.
        unLock = true;
        base.DoSkill();
    }
}
