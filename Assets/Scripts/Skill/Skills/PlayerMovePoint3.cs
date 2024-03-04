using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovePoint3 : Skill
{
    public override void DoSkill()
    {
        Managers.Game.MoveCountPlus((int)skillData.skillEffect);
        base.DoSkill();
    }
}
