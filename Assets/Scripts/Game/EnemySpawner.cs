using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private float timer;
    Transform enemies;
    private bool spawnOn = true;   //true면 몬스터 소환 가능
    GameObject[] monsters;
    GameObject boss;

    private void Start()
    {
        enemies = GameObject.Find("SceneEnemies").transform;
        monsters = Resources.LoadAll<GameObject>("Prefabs/Enemies/Normal");
        boss = Resources.Load<GameObject>("Prefabs/Enemies/Boss/Boss");
    }

    private void Update()
    {
        if(Managers.Game.gameStart == true && Managers.Game.RemainEnemy > 0 && spawnOn == true && Managers.Game.Round < 3)
        {
            GameObject enemy = Managers.Resource.Instantiate(monsters[Random.Range(0, monsters.Length)], enemies);
            enemy.transform.position = this.transform.GetChild(Random.Range(0, transform.childCount)).position;
            Managers.Game.RemainEnemy--;
            spawnOn = false;
            StartCoroutine(SpawnDelay());
        }
        else if(Managers.Game.gameStart == true && Managers.Game.RemainEnemy > 0 && spawnOn == true && Managers.Game.Round >= 3)
        {
            GameObject enemy = Managers.Resource.Instantiate(boss, enemies);
            enemy.transform.localPosition = Vector3.zero;
            Managers.Game.RemainEnemy--;
            spawnOn = false;
            StartCoroutine(SpawnDelay());
        }
    }

    IEnumerator SpawnDelay()
    {
        yield return new WaitForSeconds(timer);
        spawnOn = true;
    }
}