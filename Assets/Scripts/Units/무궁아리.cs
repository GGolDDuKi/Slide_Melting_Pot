using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 무궁아리 : Unit
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

    bool canSkill = true;

    private void Update()
    {
        if (Time.timeScale != 0f)
        {
            FindTarget();
            if (canAttack == true)
            {
                Attack();
            }
            if(canSkill == true)
            {
                AttackSkill();
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
            canAttack = false;
            StartCoroutine(AttackDelay());
        }
    }

    public override IEnumerator AttackDelay()
    {
        yield return new WaitForSeconds(AttackSpeed);
        canAttack = true;
    }

    public void AttackSkill()
    {
        if (target != null && UnitGrassR1_1.unLock == true)
        {
            try
            {
                StartCoroutine(Skill());
            }
            catch(System.Exception e)
            {
                Debug.Log(e);
            }
        }
    }

    IEnumerator Skill()
    {
        canSkill = false;
        for(int i =  0; i < 5; i++)
        {
            GameObject attack = Managers.Resource.Instantiate($"Effects/{unitData.unitName}", effect);
            attack.transform.position = transform.position;
            attack.GetComponent<Projectile>().attacker = gameObject;
            FindTarget();
            attack.GetComponent<Projectile>().target = target;
            attack.GetComponent<Projectile>().Dmg = Damage;
            yield return new WaitForSeconds(0.1f);
        }
        StartCoroutine(SkillDelay());
    }

    IEnumerator SkillDelay()
    {
        yield return new WaitForSeconds(3f);
        canSkill = true;
    }

    public static void Reset()
    {
        allAttackSpeedBonus = 0.0f;
        allDamageBonus = 0.0f;
    }
}
