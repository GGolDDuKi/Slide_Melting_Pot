using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 불고미 : Unit
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
            attack.GetComponent<Projectile>().attacker = gameObject;
            attack.GetComponent<Projectile>().target = target;
            attack.GetComponent<Projectile>().Dmg = Damage;
            if (UnitFireN1_4.unLock == true)
            {
                StartCoroutine(DoubleAttack());
            }
            canAttack = false;
            StartCoroutine(AttackDelay());
        }
    }

    IEnumerator DoubleAttack()
    {
        yield return new WaitForSeconds(0.2f);
        Debug.Log("한번 더 공격!");
        GameObject newAttack = Managers.Resource.Instantiate($"Effects/{unitData.unitName}", effect);
        newAttack.transform.position = transform.position;
        newAttack.GetComponent<Projectile>().attacker = gameObject;
        newAttack.GetComponent<Projectile>().target = target;
        newAttack.GetComponent<Projectile>().Dmg = Damage;
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
