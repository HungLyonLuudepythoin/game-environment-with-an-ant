using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Analytics;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private float xLimit;
    [SerializeField] private float[] xPositions;


    [SerializeField] private Wave[] wave;
    private float currentTime;
    private bool isaddamount = false;
    List<float> remainingPosotions = new List<float>();
    private int waveIndex;
    float xPos = 0;
    int rand;

    // Start is called before the first frame update

    void Start()
    {
        currentTime = 0;
        remainingPosotions.AddRange(xPositions);
    }

    // Update is called once per frame
    void Update()
    {
        if (Player.instance.StartMoving == true && MenuManager.instance.gameOver == false)
        {
            currentTime -= Time.deltaTime;
            if (currentTime <= 0)
            {
                SelectWave();
            }
        }
    }

    void SpawnEnemy(float xPos)
    {
        int r = Random.Range(0, 4); // 4 types of enemies 
        string enemyName = "";
        if (r == 0) enemyName = "Apple";
        else if (r == 1) enemyName = "Bottle";
        else if (r == 2) enemyName = "Carton of milk";
        else enemyName = "Empty can";

        GameObject enemy = ObjectPooling.instance.GetPooledObject(enemyName);
        enemy.transform.position = new Vector3(xPos, transform.position.y, 0);
        enemy.SetActive(true);
    }
    void SelectWave()
    {
        remainingPosotions = new List<float>();
        remainingPosotions.AddRange(xPositions);

        waveIndex = Random.Range(0, wave.Length);

        currentTime = wave[waveIndex].delayTime;

        if (wave[waveIndex].spawnAmount == 1)
        {
            int a = Random.Range(0, 7); // 7 positions
            if (a == 0) xPos = -12;
            else if (a == 1) xPos = -8;
            else if (a == 2) xPos = -4;
            else if (a == 3) xPos = 0;
            else if (a == 4) xPos = 4;
            else if (a == 5) xPos = 8;
            else xPos = 12;
        }
        else if (wave[waveIndex].spawnAmount > 1)
        {

            rand = Random.Range(0, remainingPosotions.Count);
            xPos = remainingPosotions[rand];
            remainingPosotions.RemoveAt(rand);

        }
        if (MenuManager.instance.currentScore > 40 & MenuManager.instance.currentScore <= 100 && !isaddamount)
        {
            wave[waveIndex].spawnAmount++;
            isaddamount = true;
        }
        if (MenuManager.instance.currentScore > 100)
        {
            wave[waveIndex].spawnAmount = 7;
        }
        for (int i = 0; i < wave[waveIndex].spawnAmount; i++)
        {
            if (remainingPosotions.Count > 0)
            {
                SpawnEnemy(xPos);
                rand = Random.Range(0, remainingPosotions.Count);
                xPos = remainingPosotions[rand];
                remainingPosotions.RemoveAt(rand);

            }
            else
            {
                remainingPosotions.AddRange(xPositions);
            }

        }
    }
}

[System.Serializable]
public class Wave
{
    public float delayTime;
    public float spawnAmount;
}