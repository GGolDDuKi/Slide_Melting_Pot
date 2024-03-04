using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCountUpItem : Item
{
    public override void Effect()
    {
        Managers.Game.MoveCountPlus(5);
        Managers.Resource.Destroy(gameObject);
    }
}