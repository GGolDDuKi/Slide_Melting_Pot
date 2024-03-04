using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ElementObject : MonoBehaviour
{
    public enum Element
    {
        Fire,
        Water,
        Grass,
        Storm,
        Ground
    }

    public Dictionary<Element, Color> color = new Dictionary<Element, Color>()
    {
        { Element.Fire, Color.red },
        { Element.Water, Color.blue },
        { Element.Grass, Color.green },
        { Element.Storm, Color.yellow },
        { Element.Ground, new Color(173/255f, 99/255f, 71/255f) }
    };

    public Element element;
}
