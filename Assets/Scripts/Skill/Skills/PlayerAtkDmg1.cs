using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAtkDmg1 : Skill
{
    public override void DoSkill()
    {
        GameManager.damageBonus += skillData.skillEffect;
        base.DoSkill();
    }
}
