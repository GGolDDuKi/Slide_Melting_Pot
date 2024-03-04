using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitWaterR1_4 : Skill
{
    public static bool unLock = false;

    public override void DoSkill()
    {
        //우무꾸미가 점화상태의 몬스터를 공격하면, 15% 확률로 적에게 증기 폭발이 발생하며, 대상과 주변 몬스터에게 200% 데미지를 줍니다.
        unLock = true;
        base.DoSkill();
    }
}
