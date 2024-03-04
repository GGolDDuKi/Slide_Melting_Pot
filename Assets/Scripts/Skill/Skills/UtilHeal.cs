using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UtilHeal : Skill
{
    public override void DoSkill()
    {
        Managers.Game.Hp += skillData.skillEffect;
        base.DoSkill();
    }
}
