using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoolDown : MonoBehaviour
{
    public float CoolTime { get; set; } = 3;  //전체 쿨타임
    public float CoolNow { get; set; } = 3;   //현재 쿨타임

    GameManager gm;
    Image image;

    private void Start()
    {
        image = GetComponent<Image>();
        gm = Managers.Game;
    }

    private void Update()
    {
        image.fillAmount = CoolNow / CoolTime;
    }
}
