using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    public int[] roundLevel;

    private void Start()
    {
        roundLevel[0] = 12;
        roundLevel[1] = 10;
        roundLevel[2] = 12;
    }
}
