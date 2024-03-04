using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCManager : MonoBehaviour
{
    public enum CCType : uint
    {
        Normal    = 0x00000000,
        Ignite    = 0x00000001,   //��ȭ
        UnIgnite  = 0xFFFFFFFE,
        Burn      = 0x00000002,   //ȭ��
        UnBurn    = 0xFFFFFFFD,
        Wet       = 0x00000004,   //������
        UnWet     = 0xFFFFFFFB,
        Freeze    = 0x00000008,   //����
        UnFreeze  = 0xFFFFFFF7,
        Vine      = 0x00000010,   //����
        UnVine    = 0xFFFFFFEF,
        Poison    = 0x00000020,   //�ߵ�
        UnPoison  = 0xFFFFFFDF,
        Shock     = 0x00000040,   //����
        UnShock   = 0xFFFFFFBF,
        Wind      = 0x00000080,   //�����
        UnWind    = 0xFFFFFF7F,
        Spoil     = 0x00000100,   //����
        UnSpoil   = 0xFFFFFEFF,
        Petrify   = 0x00000200,    //��ȭ
        UnPetrify = 0xFFFFFDFF
    }
}
