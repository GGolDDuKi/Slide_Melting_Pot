using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitStormR1_3 : Skill
{
    public static bool unLock = false;

    public override void DoSkill()
    {
        //전구르미의 공격이 최대 3개의 전기를 발사합니다.
        unLock = true;
        base.DoSkill();
    }
}
