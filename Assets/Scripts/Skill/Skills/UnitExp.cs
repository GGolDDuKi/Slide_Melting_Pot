using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UtilExp : Skill
{
    public override void DoSkill()
    {
        Managers.Game.ExpBonus += skillData.skillEffect;
        base.DoSkill();
    }
}
