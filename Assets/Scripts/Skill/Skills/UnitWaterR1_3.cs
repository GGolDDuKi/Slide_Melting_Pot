using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitWaterR1_3 : Skill
{
    public static bool unLock = false;

    public override void DoSkill()
    {
        //�칫�ٹ̰� ��ǰ������ 2�� �߻��մϴ�.
        unLock = true;
        base.DoSkill();
    }
}
