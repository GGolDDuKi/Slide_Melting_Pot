using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitGrassR1_1 : Skill
{
    public static bool unLock = false;

    public override void DoSkill()
    {
        //무궁아리가 몬스터에게 수많은 씨앗 미사일을 발사하여 총 500% 데미지를 입힙니다. 전부 발사하면, 3초 동안 힘을 모아 다시 발사할 수 있습니다.
        unLock = true;
        base.DoSkill();
    }
}
