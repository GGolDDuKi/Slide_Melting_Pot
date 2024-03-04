using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitGrassR1_4 : Skill
{
    public static bool unLock = false;

    public override void DoSkill()
    {
        //무궁아리의 공격이 몬스터 1마리를 관통합니다.
        unLock = true;
        base.DoSkill();
    }
}
