using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitFireN1_3 : Skill
{
    public static bool unLock = false;

    public override void DoSkill()
    {
        //�Ұ�̰� ����� ������ ���͸� �����ϸ� N�� ���� ���ݼӵ� +200%
        unLock = true;
        base.DoSkill();
    }
}
