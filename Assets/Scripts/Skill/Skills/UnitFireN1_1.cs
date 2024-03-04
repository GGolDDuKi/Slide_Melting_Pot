using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitFireN1_1 : Skill
{
    public static bool unLock = false;

    public override void DoSkill()
    {
        //불고미의 공격이 몬스터를 적중하면 5초 동안 20% 만큼 데미지를 입히는 점화 상태로 만듭니다.
        unLock = true;
        base.DoSkill();
    }
}
