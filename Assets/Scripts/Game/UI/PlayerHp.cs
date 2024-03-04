using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHp : MonoBehaviour
{
    GameManager gm;
    Text text;
    [SerializeField] Image bar;

    void Start()
    {
        gm = Managers.Game;
        text = GetComponentInChildren<Text>();
    }

    void Update()
    {
        text.text = $"ü�� {gm.Hp.ToString()} / {gm.MaxHp.ToString()}";
        bar.fillAmount = gm.Hp / gm.MaxHp;
    }
}
