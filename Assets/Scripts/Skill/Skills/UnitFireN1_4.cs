using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitFireN1_4 : Skill
{
    public static bool unLock = false;

    public override void DoSkill()
    {
        //�Ұ���� ���� Ƚ�� + 1
        unLock = true;
        base.DoSkill();
    }
}
