using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 우무꾸미공격 : Projectile
{
    public override void Update()
    {
        gameObject.transform.position += Vector3.up * speed * Time.deltaTime;
    }

    public override void OnTriggerEnter2D(Collider2D collision)
    {
        if (UnitWaterR1_1.unLock == true)
        {
            int random = Random.Range(0, 10);
            if (random < 2)
            {
                collision.GetComponent<Enemy>().GetWet(0.5f, 3f);
            }
        }

        if (UnitWaterR1_4.unLock == true)
        {
            if (collision.GetComponent<Enemy>().cc == CCManager.CCType.Ignite)
            {
                int random = Random.Range(0, 100);
                if (random < 15)
                {
                    SteamExplosion(collision.GetComponent<Enemy>(), 2.0f, Dmg);
                }
            }
        }

        base.OnTriggerEnter2D(collision);
    }

    void SteamExplosion(Enemy target, float range, float damage)
    {
        Debug.Log("증기폭발!");
        Collider2D[] enemies = Physics2D.OverlapCircleAll(target.transform.position, range, LayerMask.GetMask("Enemy"));
        foreach(Collider2D enemy in enemies)
        {
            enemy.GetComponent<Enemy>().Hp -= (damage * 2.0f);
        }
    }
}
