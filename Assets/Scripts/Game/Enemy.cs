using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public CCManager.CCType cc = CCManager.CCType.Normal;

    [SerializeField] private float baseSpeed;
    [SerializeField] private float speed;
    [SerializeField] private int dmg;
    [SerializeField] private float maxHp;
    [SerializeField] private float hp;
    public float Hp { get { return hp; } set { hp = value; } }
    GameManager gm;
    Transform effect;

    private void Start()
    {
        gm = Managers.Game;
        effect = GameObject.Find("SceneEffects").transform;
        cc = CCManager.CCType.Normal;
    }

    void Update()
    {
        transform.position += Vector3.down * Time.deltaTime * speed;
        if(Hp <= 0)
        {
            Destroy();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "HitLine")
        {
            Destroy();
            gm.Hp -= Random.Range(5, 9);
            if(gm.Hp < 0)
            {
                gm.Hp = 0;
            }
        }
    }

    private void Destroy()
    {
        if(effect.childCount > 0)
        {
            foreach (Transform child in effect)
            {
                if (child.GetComponent<Projectile>().target == this.gameObject && Managers.Data.MissileData[child.GetComponent<Projectile>().attacker.GetComponent<Unit>().unitData.index].attackType == "None")
                {
                    child.GetComponent<Projectile>().target = null;
                    Managers.Resource.Destroy(child.gameObject);
                }
            }
        }
        Hp = maxHp;
        cc = CCManager.CCType.Normal;
        speed = baseSpeed;
        Managers.Resource.Destroy(gameObject);
    }

    //상태이상
    public void GetIgnite(int damage, float time)
    {
        cc |= CCManager.CCType.Ignite;
        StartCoroutine(Igniting(damage, time));
    }

    IEnumerator Igniting(int damage, float time)
    {
        for (int i = 0; i < (int)time; i++)
        {
            Hp -= (float)damage * 0.2f;
            Debug.Log($"점화 데미지 {((float)damage * 0.2f).ToString()}");
            yield return new WaitForSeconds(1f);
        }
        cc &= CCManager.CCType.UnIgnite;
    }

    public void GetWet(float percent, float time)
    {
        cc |= CCManager.CCType.Wet;
        StartCoroutine(Wetting(percent, time));
    }

    IEnumerator Wetting(float percent, float time)
    {
        float baseSpeed = speed;
        speed *= percent;
        yield return new WaitForSeconds(time);
        speed = baseSpeed;
        cc &= CCManager.CCType.UnWet;
    }

    public void GetShock(float time)
    {
        cc |= CCManager.CCType.Shock;
        StartCoroutine(Shocking(time));
    }

    IEnumerator Shocking(float time)
    {
        float baseSpeed = speed;
        speed = 0;
        yield return new WaitForSeconds(time);
        speed = baseSpeed;
        cc &= CCManager.CCType.UnShock;
    }
}
