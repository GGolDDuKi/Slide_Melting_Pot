using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 무궁아리공격 : Projectile
{
    int passCount;

    public override void Start()
    {
        base.Start();
        if(UnitGrassR1_4.unLock == true)
        {
            passCount = 1;
        }
        else
        {
            passCount = 0;
        }
    }

    public override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Enemy>())
        {
            if(UnitGrassR1_3.unLock == true)
            {
                if (collision.gameObject.GetComponent<Enemy>().cc == CCManager.CCType.Shock)
                {
                    collision.gameObject.GetComponent<Enemy>().Hp -= (Dmg * 2);
                }
            }
        }

        if (passCount > 0)
        {
            passCount--;
        }
        else if (Managers.Data.MissileData[attacker.GetComponent<Unit>().unitData.index].attackType == "None")
        {
            Destroy();
        }
    }
}
