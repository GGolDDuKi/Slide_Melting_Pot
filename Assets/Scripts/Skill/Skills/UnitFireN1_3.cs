using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitFireN1_3 : Skill
{
    public static bool unLock = false;

    public override void DoSkill()
    {
        //불고미가 난기류 상태인 몬스터를 공격하면 N초 동안 공격속도 +200%
        unLock = true;
        base.DoSkill();
    }
}
