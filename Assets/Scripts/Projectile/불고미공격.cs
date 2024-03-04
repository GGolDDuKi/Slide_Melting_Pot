using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 불고미공격 : Projectile
{
    public override void OnTriggerEnter2D(Collider2D collision)
    {
        if(UnitFireN1_1.unLock == true)
        {
            int random = Random.Range(0, 10);
            if (random < 2)
            {
                target.GetComponent<Enemy>().GetIgnite(Dmg, 5f);
            }
        }

        if(UnitFireN1_3.unLock == true)
        {
            if (collision.GetComponent<Enemy>().cc == CCManager.CCType.Wind)
            {
                StartCoroutine(AttackSpeedBonus(attacker.GetComponent<Unit>(), 2.0f, 5f));
            }
        }

        base.OnTriggerEnter2D(collision);
    }

    IEnumerator AttackSpeedBonus(Unit unit, float percent, float time)
    {
        Debug.Log("난기류 공격으로 공격속도 증가!");
        unit.attackSpeedBonus = percent;
        yield return new WaitForSeconds(time);
        unit.attackSpeedBonus = 0f;
    }
}
