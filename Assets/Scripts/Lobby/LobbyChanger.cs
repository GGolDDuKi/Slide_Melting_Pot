using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyChanger : MonoBehaviour
{
    RectTransform rt;
    Vector2 shop = new Vector2(1080, 0);
    Vector2 lobby = new Vector2(0, 0);
    Vector2 uM = new Vector2(-1080, 0);
    [SerializeField] private float speed;

    public enum State
    {
        Lobby,
        Shop,
        UnitManage
    }

    private State state;
    private Dictionary<State, Vector2> uiPos = new Dictionary<State, Vector2>();
    private Vector2 movePos;

    void Start()
    {
        state = State.Lobby;
        rt = GetComponent<RectTransform>();
        uiPos.Add(State.Lobby, lobby);
        uiPos.Add(State.Shop, shop);
        uiPos.Add(State.UnitManage, uM);
    }

    private void Update()
    {
        ChangeUI();
    }

    public void SelectShop()
    {
        state = State.Shop;
    }

    public void SelectLobby()
    {
        state = State.Lobby;
    }

    public void SelectUM()
    {
        state = State.UnitManage;
    }

    void ChangeUI()
    {
        uiPos.TryGetValue(state, out movePos);
        if(rt.anchoredPosition != movePos)
        {
            rt.anchoredPosition = Vector2.Lerp(rt.anchoredPosition, movePos, speed);
        }
    }
}
