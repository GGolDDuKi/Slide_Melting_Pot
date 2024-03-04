using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] protected float speed = 5f;
    public GameObject attacker;
    public GameObject target;
    public int Dmg { get; set; }
    public Vector3 direction;

    public virtual void Start()
    {
        SetDestination();
    }

    public virtual void Update()
    {
        gameObject.transform.position = Vector3.MoveTowards(transform.position, direction, Time.deltaTime * speed * 30);
        if(transform.position == direction)
        {
            Destroy();
        }
    }

    public virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Enemy>())
        {
            collision.gameObject.GetComponent<Enemy>().Hp -= Dmg;
            if (Managers.Data.MissileData[attacker.GetComponent<Unit>().unitData.index].attackType == "None")
            {
                Destroy();
            }
        }
    }

    protected void SetDestination()
    {
        try
        {
            direction = target.transform.position;
        }
        catch (System.Exception e)
        {
            Debug.Log(e);
            Destroy();
        }
    }

    public void OnBecameInvisible()
    {
        Destroy();
    }

    public void Destroy()
    {
        //Managers.Resource.Destroy(gameObject);
        Destroy(gameObject);
    }
}
