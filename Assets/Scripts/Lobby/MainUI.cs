using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainUI : MonoBehaviour
{
    public GameObject subUI;

    private void Start()
    {
        subUI = GameObject.Find($"{gameObject.name}Image");
        gameObject.GetComponent<Button>().onClick.AddListener(OnClicked);
    }

    public void OnClicked()
    {
        foreach(Transform child in subUI.transform)
        {
            child.gameObject.SetActive(true);
        }
    }
}
