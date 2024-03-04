using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitStormR1_4 : Skill
{
    public static bool unLock = false;

    public override void DoSkill()
    {
        //전구르미의 공격이 축축함 혹은 빙결 상태인 몬스터에게 맞으면 +200% 데미지를 주며, 주변 몬스터에게 한번만 전파됩니다.
        unLock = true;
        base.DoSkill();
    }
}
