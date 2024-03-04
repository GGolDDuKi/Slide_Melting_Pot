using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitGrassR1_3 : Skill
{
    public static bool unLock = false;

    public override void DoSkill()
    {
        //무궁아리가 감전 상태인 몬스터에게 주는 데미지 +200%
        unLock = true;
        base.DoSkill();
    }
}
