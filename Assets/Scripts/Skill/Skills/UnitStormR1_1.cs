using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitStormR1_1 : Skill
{
    public static bool unLock = false;

    public override void DoSkill()
    {
        //전구르미의 공격이 20% 확률로 몬스터를 짧게 기절시키고 감전상태로 만듭니다.
        unLock = true;
        base.DoSkill();
    }
}
