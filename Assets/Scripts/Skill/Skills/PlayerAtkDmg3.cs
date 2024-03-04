using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAtkDmg3 : Skill
{
    public override void DoSkill()
    {
        GameManager.damageBonus += skillData.skillEffect;
        base.DoSkill();
    }
}
