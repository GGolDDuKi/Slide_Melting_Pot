using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUpItem : Item
{
    public override void Effect()
    {
        Pause.LevelUp();
        Managers.Resource.Destroy(gameObject);
    }
}
