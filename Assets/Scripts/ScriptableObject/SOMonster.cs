using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Monster Data", menuName = "Scriptable Object/Monster Data", order = int.MaxValue)]
public class SOMonster : ScriptableObject
{
    [SerializeField]
    private string _name;
    public string Name { get { return _name; } }

    [SerializeField]
    private int maxHp;
    public int MaxHp { get { return maxHp; } }

    [SerializeField]
    private int damage;
    public int Damage{ get { return damage; } }

    [SerializeField]
    private float speed;
    public float Speed{ get { return speed; } }
}
