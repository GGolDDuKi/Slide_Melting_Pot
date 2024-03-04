using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 전구르미 : Unit
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
            GameObject attack = Instantiate<GameObject>(Resources.Load<GameObject>($"Prefabs/Effects/{unitData.unitName}"));
            attack.transform.parent = effect.transform;
            attack.transform.position = transform.position;
            attack.GetComponent<Projectile>().attacker = gameObject;
            attack.GetComponent<Projectile>().target = target;
            attack.GetComponent<Projectile>().Dmg = Damage;
            if (UnitStormR1_3.unLock == true)
            {
                StartCoroutine(TrippleAttack());
            }
            canAttack = false;
            StartCoroutine(AttackDelay());
        }
    }

    IEnumerator TrippleAttack()
    {
        yield return new WaitForSeconds(0.2f);
        Debug.Log("한번 더 공격!");
        GameObject newAttack1 = Instantiate<GameObject>(Resources.Load<GameObject>($"Prefabs/Effects/{unitData.unitName}"));
        newAttack1.transform.parent = effect.transform;
        newAttack1.transform.position = transform.position;
        newAttack1.GetComponent<Projectile>().attacker = gameObject;
        newAttack1.GetComponent<Projectile>().target = target;
        newAttack1.GetComponent<Projectile>().Dmg = Damage;
        yield return new WaitForSeconds(0.2f);
        Debug.Log("한번 더 공격!");
        GameObject newAttack2 = Instantiate<GameObject>(Resources.Load<GameObject>($"Prefabs/Effects/{unitData.unitName}"));
        newAttack2.transform.parent = effect.transform;
        newAttack2.transform.position = transform.position;
        newAttack2.GetComponent<Projectile>().attacker = gameObject;
        newAttack2.GetComponent<Projectile>().target = target;
        newAttack2.GetComponent<Projectile>().Dmg = Damage;
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
