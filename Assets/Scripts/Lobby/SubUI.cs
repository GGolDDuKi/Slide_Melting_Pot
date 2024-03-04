using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SubUI : MonoBehaviour
{
    Transform exit;

    void Start()
    {
        Init();
    }

    public void Exit()
    {
        foreach(Transform child in this.transform)
        {
            child.gameObject.SetActive(false);
        }
    }

    private void Init()
    {
        foreach (Transform child in this.transform)
        {
            if (child.name == "Exit")
                exit = child;
        }
        if (exit == null)
            return;
        else
            exit.GetComponent<Button>().onClick.AddListener(Exit);
    }
}
