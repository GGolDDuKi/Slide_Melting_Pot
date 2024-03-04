using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    GameManager gm;
    SceneManagerEx sm;
    TileManager tm;

    [SerializeField] private static GameObject skillUpgrade;
    [SerializeField] private GameObject onPause;
    [SerializeField] private GameObject gameOver;
    [SerializeField] private GameObject gameClear;
    [SerializeField] private GameObject spawners;
    [SerializeField] private GameObject map;
    [SerializeField] private GameObject tileRepos;
    [SerializeField] private GameObject effects;
    
    Transform enemies;

    // Start is called before the first frame update
    void Start()
    {
        map.SetActive(false);
        map.SetActive(true);
        gm = Managers.Game;
        sm = Managers.Scene;
        tm = Managers.Tile;
        enemies = GameObject.Find("SceneEnemies").transform;
        skillUpgrade = GameObject.Find("SkillUpgrade");
    }

    private void Update()
    {
        GameOver();
        GameClear();
        GameStart();
    }

    public void OnPause()
    {
        TimeStop();
        int child = onPause.transform.childCount;
        for (int i = 0; i < child; i++)
        {
            onPause.transform.GetChild(i).gameObject.SetActive(true);
        }
    }

    public void Play()
    {
        int child = onPause.transform.childCount;
        for (int i = 0; i < child; i++)
        {
            onPause.transform.GetChild(i).gameObject.SetActive(false);
        }
        TimePlay();
    }

    public void Home()
    {
        //Game 씬에 있는 오브젝트, GameManager에서 관리 중인 데이터 리셋해야 됨
        tm.Clear();
        gm.Reset();
        sm.LoadScene("Lobby");
    }

    public static void TimeStop()
    {
        if (Managers.Game.Pause == false)
        {
            Managers.Game.Pause = true;
            Time.timeScale = 0f;
        }
    }

    public static void TimePlay()
    {
        if (Managers.Game.Pause == true)
        {
            Managers.Game.Pause = false;
            Time.timeScale = Managers.Game.GameSpeed;
        }
    }

    void GameOver()
    {
        if(gm.Hp <= 0)
        {
            TimeStop();
            gameOver.GetComponent<GameOver>().GameFail();
            gm.Reset();
            tm.Clear();
        }
    }

    void GameClear()
    {
        if (gm.RemainEnemy <= 0 && gm.Hp > 0 && enemies.childCount <= 0 && Managers.Game.Round >= 3)
        {
            TimeStop();
            gameClear.GetComponent<GameClear>().GameSuccess();
            gm.Reset();
            tm.Clear();
        }
        else if(gm.RemainEnemy <= 0 && gm.Hp > 0 && enemies.childCount <= 0 && Managers.Game.Round < 3)
        {
            gm.RoundReset();
        }
        tileRepos.SetActive(true);
    }

    void GameStart()
    {
        if(gm.MoveCount <= 0 && gm.gameStart == false)
        {
            gm.gameStart = true;
            tileRepos.SetActive(false);
            Managers.Tile.ChangeLayersUT();
            Time.timeScale = gm.GameSpeed;
        }
    }

    public static void CheckExp()
    {
        if(Managers.Game.Exp >= Managers.Game.MaxExp)
        {
            LevelUp();
            Managers.Game.Exp = 0;
        }
    }

    public static void LevelUp()
    {
        TimeStop();
        Managers.Game.Level++;
        SkillUpgrade();
    }

    static void SkillUpgrade()
    {
        int child = skillUpgrade.transform.childCount;
        for (int i = 0; i < child; i++)
        {
            skillUpgrade.transform.GetChild(i).gameObject.SetActive(true);
        }
        skillUpgrade.GetComponent<SkillUpgrade>().ChangeSkills();
    }
}
