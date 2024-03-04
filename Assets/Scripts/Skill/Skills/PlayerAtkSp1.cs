using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAtkSp1 : Skill
{
    public override void DoSkill()
    {
        GameManager.attackSpeedBonus += skillData.skillEffect;
        base.DoSkill();
    }
}
