using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UtilSlow : Skill
{
    public override void DoSkill()
    {
        Managers.Game.EnemySlow += skillData.skillEffect;
        base.DoSkill();
    }
}
