using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 재카로프 : Unit
{
    public static float allAttackSpeedBonus;
    public float AttackSpeed { get { return 1.0f / unitData.attackSpeed * (1 + allAttackSpeedBonus + attackSpeedBonus + GameManager.attackSpeedBonus); } }

    public static float allDamageBonus;
    public int Damage
    {
        get
        {
            if (mergeLevel > 0)
            {
                return (int)((unitData.damage * (unitData.mergeDamage * mergeLevel)) * (1 + allDamageBonus + damageBonus + GameManager.damageBonus));
            }
            else
            {
                return (int)((unitData.damage) * (1 + allDamageBonus + damageBonus + GameManager.damageBonus));
            }
        }
    }

    private void Update()
    {
        if (Time.timeScale != 0f)
        {
            FindTarget();
            if (canAttack == true)
            {
                Attack();
            }
        }
    }

    public override void Attack()
    {
        if (target != null)
        {
            GameObject attack = Managers.Resource.Instantiate($"Effects/{unitData.unitName}", effect);
            attack.transform.position = transform.position;
            attack.GetComponent<Projectile>().target = target;
            attack.GetComponent<Projectile>().Dmg = Damage;
            canAttack = false;
            StartCoroutine(AttackDelay());
        }
    }

    public override IEnumerator AttackDelay()
    {
        yield return new WaitForSeconds(AttackSpeed);
        canAttack = true;
    }

    public static void Reset()
    {
        allAttackSpeedBonus = 0.0f;
        allDamageBonus = 0.0f;
    }
}
