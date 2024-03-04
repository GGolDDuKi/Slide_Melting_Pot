using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitFireN1_4 : Skill
{
    public static bool unLock = false;

    public override void DoSkill()
    {
        //불고미의 공격 횟수 + 1
        unLock = true;
        base.DoSkill();
    }
}
