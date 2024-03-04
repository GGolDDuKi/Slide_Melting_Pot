using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitWaterR1_3 : Skill
{
    public static bool unLock = false;

    public override void DoSkill()
    {
        //우무꾸미가 거품광선을 2번 발사합니다.
        unLock = true;
        base.DoSkill();
    }
}
