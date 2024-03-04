using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovePoint2 : Skill
{
    public override void DoSkill()
    {
        Managers.Game.MoveCountPlus((int)skillData.skillEffect);
        base.DoSkill();
    }
}