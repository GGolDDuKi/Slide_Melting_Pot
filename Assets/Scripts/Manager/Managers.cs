using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//게임 내에 시스템 요소 등과 관련된 단일 요소 관리
[System.Serializable]
public class Managers : MonoBehaviour
{
    static Managers s_instance;
    public static Managers Instance { get { Init(); return s_instance; } }

    GameManager _game = new GameManager();
    public static GameManager Game { get { return Instance._game; } }

    DataManager _data = new DataManager();
    public static DataManager Data { get { return Instance._data; } }

    CCManager _cc = new CCManager();
    public static CCManager CC { get { return Instance._cc; } }

    CardManager _card = new CardManager();
    public static CardManager Card { get { return Instance._card; } }

    SkillManager _skill = new SkillManager();
    public static SkillManager Skill { get { return Instance._skill; } }

    PlayerManager _player = new PlayerManager();
    public static PlayerManager Player { get { return Instance._player; } }

    StageManager _stage = new StageManager();
    public static StageManager Stage { get { return Instance._stage; } }

    PoolManager _pool = new PoolManager();
    public static PoolManager Pool { get { return Instance._pool; } }

    ResourceManager _resource = new ResourceManager();
    public static ResourceManager Resource { get { return Instance._resource; } }

    TileManager _tile = new TileManager();
    public static TileManager Tile { get { return Instance._tile; } }

    SceneManagerEx _scene = new SceneManagerEx();
    public static SceneManagerEx Scene { get { return Instance._scene; } }

    SystemManager _system = new SystemManager();
    public static SystemManager System { get { return Instance._system; } }

    private void Start()
    {
        Init();
    }

    static void Init()
    {
        if(s_instance == null)
        {
            GameObject go = GameObject.Find("@Managers");
            if(go == null)
            {
                go = new GameObject { name = "@Managers" };
                go.AddComponent<Managers>();
            }
            DontDestroyOnLoad(go);
            s_instance = go.GetComponent<Managers>();

            s_instance._data.Init();
            s_instance._system.Init();
            s_instance._pool.Init();
            s_instance._skill.Init();
            //s_instance._player.Init();
        }
    }

    public static void Clear()
    {
        Pool.Clear();
    }
}
