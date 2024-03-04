using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitWaterR1_1 : Skill
{
    public static bool unLock = false;

    public override void DoSkill()
    {
        //우무꾸미의 거품광선이 20% 확률로 축축함 상태로 만들고 3초 동안 50% 느려지게 만듭니다.
        unLock = true;
        base.DoSkill();
    }
}
