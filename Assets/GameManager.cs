using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager current;

    public static int points { get; private set; } = 0;
    public static int spawnedCount { get; set; } = 0;

    public GameObject pauseMenu;

    public TextMeshProUGUI pointsText;

    public GameObject[] clickyObjects;
    private List<GameObject> spawnedObjects = new();

    public int spawnedCountLimit = 15;
    public float speedupRate = 0.1f;
    public float inicialSpawnTime = 3f;
    public float finalSpawnTime = 0.5f;
    private float spawnTime;

    public static void AddPoints(int value)
    {
        points += value;
        current.pointsText.text = "Score: " + points;
    }

    public void Awake()
    {
        current = this;
        Restart();
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            Restart();
        }
    }

    public void TogglePause()
    {
        Time.timeScale = pauseMenu.activeSelf ? 1 : 0;
        pauseMenu.SetActive(!pauseMenu.activeSelf);
    }

    public void MainTitle()
    {
        SceneManager.LoadScene(0);
    }

    public void Restart()
    {
        CancelInvoke();
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
        spawnTime = inicialSpawnTime;
        Invoke(nameof(SpawnRandomObject), spawnTime);
        points = 0;
        spawnedCount = 0;
        current.pointsText.text = "Score: 0";
    }

    public void GameOver()
    {
        if(points > PlayerPrefs.GetInt("high_score", 0))
        {
            PlayerPrefs.SetInt("high_score", points);
            current.pointsText.text = "Gameover! New Record! Score: " + points + "\n Press R to Restart";
        }
        else
        {
            current.pointsText.text = "Gameover! Score: " + points + "\n Press R to Restart";
        }

        for (int i = spawnedObjects.Count - 1; i >= 0; i--)
        {
            Destroy(spawnedObjects[i]);
        }
        spawnedObjects.Clear();
    }

    public void SpawnRandomObject()
    {
        if (spawnedCount > spawnedCountLimit)
        {
            GameOver();
            return;
        }
        GameObject prefab = clickyObjects[Random.Range(0, clickyObjects.Length)];

        Vector3 randomViewportPos = new(Random.value, Random.value, 0f);

        Vector2 spawnPos = Camera.main.ViewportToWorldPoint(new Vector3(randomViewportPos.x, randomViewportPos.y, 0));

        spawnedObjects.Add(Instantiate(prefab, spawnPos, Quaternion.identity));

        spawnedCount++;

        spawnTime -= ((spawnTime - finalSpawnTime) / inicialSpawnTime) * speedupRate;
        Invoke(nameof(SpawnRandomObject), spawnTime);
    }

}
