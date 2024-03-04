using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoolDown : MonoBehaviour
{
    public float CoolTime { get; set; } = 3;  //��ü ��Ÿ��
    public float CoolNow { get; set; } = 3;   //���� ��Ÿ��

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
