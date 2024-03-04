using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCManager : MonoBehaviour
{
    public enum CCType : uint
    {
        Normal    = 0x00000000,
        Ignite    = 0x00000001,   //점화
        UnIgnite  = 0xFFFFFFFE,
        Burn      = 0x00000002,   //화상
        UnBurn    = 0xFFFFFFFD,
        Wet       = 0x00000004,   //축축함
        UnWet     = 0xFFFFFFFB,
        Freeze    = 0x00000008,   //빙결
        UnFreeze  = 0xFFFFFFF7,
        Vine      = 0x00000010,   //덩쿨
        UnVine    = 0xFFFFFFEF,
        Poison    = 0x00000020,   //중독
        UnPoison  = 0xFFFFFFDF,
        Shock     = 0x00000040,   //감전
        UnShock   = 0xFFFFFFBF,
        Wind      = 0x00000080,   //난기류
        UnWind    = 0xFFFFFF7F,
        Spoil     = 0x00000100,   //부패
        UnSpoil   = 0xFFFFFEFF,
        Petrify   = 0x00000200,    //석화
        UnPetrify = 0xFFFFFDFF
    }
}
