using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 전구르미공격 : Projectile
{
    public int spreadCount;

    public override void Start()
    {
        base.Start();
        if(UnitStormR1_4.unLock == true)
        {
            spreadCount = 1;
        }
        else
        {
            spreadCount = 0;
        }
    }

    public override void OnTriggerEnter2D(Collider2D collision)
    {
        if (UnitStormR1_1.unLock == true)
        {
            int random = Random.Range(0, 10);
            if (random < 2)
            {
                collision.GetComponent<Enemy>().GetShock(1f);
            }
        }

        if (UnitStormR1_4.unLock == true)
        {
            if (collision.GetComponent<Enemy>().cc == CCManager.CCType.Wet || collision.GetComponent<Enemy>().cc == CCManager.CCType.Freeze)
            {
                collision.GetComponent<Enemy>().Hp -= (Dmg * 2);
                if(spreadCount > 0)
                {
                    Spread(collision.gameObject, Dmg * 2);
                }
                else
                {
                    Destroy();
                }
            }
            else
            {
                base.OnTriggerEnter2D(collision);
            }
        }
        else
        {
            base.OnTriggerEnter2D(collision);
        }
    }

    void Spread(GameObject target, float damage)
    {
        Enemy[] enemies = GameObject.Find("SceneEnemies").GetComponentsInChildren<Enemy>();
        if(enemies.Length == 0)
        {
            Destroy();
        }
        Enemy newTarget = new Enemy();
        float distance = 100f;
        foreach(Enemy enemy in enemies)
        {
            if(enemy != target)
            {
                if(distance > (enemy.transform.position - target.transform.position).magnitude)
                {
                    newTarget = enemy;
                    distance = (enemy.transform.position - target.transform.position).magnitude;
                }
            }
        }
        target = newTarget.gameObject;
        SetDestination();
        spreadCount--;
    }
}
