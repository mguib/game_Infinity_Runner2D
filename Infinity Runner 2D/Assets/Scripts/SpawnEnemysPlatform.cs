using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemysPlatform : MonoBehaviour
{

    public GameObject enemyPrefab;

    private GameObject currentEnemy;

    public List<Transform> points = new List<Transform>();

    // Start is called before the first frame update
    void Start()
    {
        CreatEnemy();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CreatEnemy()
    {
        int pos = Random.Range(0, points.Count);
        GameObject e = Instantiate(enemyPrefab, points[pos].position, points[pos].rotation);
        currentEnemy = e;
        
    }

    public void SpawnEnemies()
    {
        //Aqui é chegado se o Inimigo foi destruido
        if (currentEnemy != null)
        {
            CreatEnemy();
        }
    }
}
