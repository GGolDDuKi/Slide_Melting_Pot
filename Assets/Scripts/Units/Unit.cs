using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class Unit : ElementObject
{
    enum Rarity
    {
        Normal,
        Rare,
        Unique
    }
    Rarity rarity;
    public int mergeLevel;
    [SerializeField] protected bool canAttack = true;
    [SerializeField] protected string attackEffect;
    [SerializeField] public GameObject target; //���� ����� ���������� �ǽð� ����
    public Skill[] Skills { get; set; } = new Skill[4]; //���ֺ��� ��ų 5����
    public List<GameObject> EnemiesInRange;   //���� ���� ���� �ִ� ��� ���� ����Ʈ
    public int UnitLevel { get; set; }

    public float attackSpeedBonus;
    public float damageBonus;

    public UnitData unitData;
    public MissileData missileData;
    public List<SkillData> skillData = new List<SkillData>();

    protected Transform effect;

    //id�� DataManager���� ���� �����Ϳ� Resources���� ���� �̹��� �� �����͵��� �ҷ����� �Լ�
    public void SetUnitData(UnitData unitData)
    {
        this.unitData = unitData;
        missileData = Managers.Data.MissileData[unitData.index];
        skillData.Add(Managers.Data.SkillData[unitData.skill1]);
        skillData.Add(Managers.Data.SkillData[unitData.skill2]);
        skillData.Add(Managers.Data.SkillData[unitData.skill3]);
        skillData.Add(Managers.Data.SkillData[unitData.skill4]);
        //�Ӽ��̶� ��� string to enum
        element = (Element)Enum.Parse(typeof(Element), unitData.element);
        rarity = (Rarity)Enum.Parse(typeof(Rarity), unitData.rarity);
    }

    private void Start()
    {
        effect = GameObject.Find("SceneEffects").transform;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Enemy") && !EnemiesInRange.Contains(collision.gameObject))
        {
            EnemiesInRange.Add(collision.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Enemy") && EnemiesInRange.Contains(collision.gameObject))
        {
            EnemiesInRange.Remove(collision.gameObject);
        }
    }

    protected void FindTarget()
    {
        if(EnemiesInRange.Count > 0)
        {
            float distance = 100;
            GameObject obj = null;

            foreach (GameObject enemy in EnemiesInRange)
            {
                if (distance > Vector3.Distance(transform.position, enemy.transform.position))
                {
                    distance = Vector3.Distance(transform.position, enemy.transform.position);
                    obj = enemy;
                }
            }
            target = obj;
        }
        else
        {
            if(target != null)
            {
                target = null;
            }
        }
    }

    public virtual void Attack()
    {
        if(target != null)
        {
            GameObject attack = Instantiate<GameObject>(Resources.Load<GameObject>($"Prefabs/Effects/{unitData.unitName}"));
            attack.transform.parent = effect.transform;
            canAttack = false;
            attack.transform.position = transform.position;
            attack.GetComponent<Projectile>().attacker = gameObject;
            attack.GetComponent<Projectile>().target = target;
            attack.GetComponent<Projectile>().Dmg = unitData.damage;
            StartCoroutine(AttackDelay());
        }
    }

    public virtual IEnumerator AttackDelay()
    {
        yield return new WaitForSeconds(unitData.attackSpeed);
        canAttack = true;
    }
}
