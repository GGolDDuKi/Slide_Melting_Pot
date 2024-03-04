using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLevel : MonoBehaviour
{
    GameManager gm;
    Text text;
    [SerializeField] Image bar;
    [SerializeField] Pause pause;

    void Start()
    {
        gm = Managers.Game;
        text = GetComponentInChildren<Text>();
    }

    void Update()
    {
        text.text = $"°æÇèÄ¡ {gm.Exp.ToString()} / {gm.MaxExp.ToString()}";
        bar.fillAmount = gm.Exp / gm.MaxExp;
    }
}
