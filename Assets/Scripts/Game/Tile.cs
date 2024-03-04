using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tile : ElementObject
{
    public void ChangeColor(Element element)
    {
        GetComponent<Image>().color = color[element];
    }

    public void ChangeElement()
    {
        element = Managers.Game.deckElement[Random.Range(0, Managers.Game.deckElement.Count)];
        ChangeColor(element);
    }

    public void ChangeElement(Element element)
    {
        this.element = element;
        ChangeColor(element);
    }
}
