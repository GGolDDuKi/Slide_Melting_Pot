using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitStormR1_3 : Skill
{
    public static bool unLock = false;

    public override void DoSkill()
    {
        //���������� ������ �ִ� 3���� ���⸦ �߻��մϴ�.
        unLock = true;
        base.DoSkill();
    }
}
