using UnityEngine;
using UnityEngine.SceneManagement;

public class ZombieManager : MonoBehaviour
{
    public GameObject zombiePrefab; // Zombie prefab
    public Transform playerTransform; // Oyuncunun transformu
    public int maxZombiesOnScreen = 10; // Ekranda maksimum zombi say�s�
    public int totalZombiesToSpawn = 100; // Toplam spawn edilecek zombi say�s�
    public float spawnRadiusMin = 10f; // Minimum spawn mesafesi
    public float spawnRadiusMax = 30f; // Maksimum spawn mesafesi
    public float spawnInterval = 2f; // Zombi spawn aral���
    public string gameOverSceneName = "TheEnd";

    private int zombiesSpawned = 1;
    private int zombiesKilled = 1;

    private void Start()
    {
        maxZombiesOnScreen = PlayerPrefs.GetInt("MaxZombies", 10); // Varsay�lan de�er 10
        totalZombiesToSpawn = PlayerPrefs.GetInt("TotalZombies", 100); // Varsay�lan de�er 100

        InvokeRepeating("SpawnZombie", 0f, spawnInterval);
    }

    private void SpawnZombie()
    {
        if (zombiesSpawned < totalZombiesToSpawn && GameObject.FindGameObjectsWithTag("zombie").Length < maxZombiesOnScreen)
        {
            Vector3 spawnPos = RandomPositionAroundPlayer();
            GameObject zombie = Instantiate(zombiePrefab, spawnPos, Quaternion.LookRotation(playerTransform.position - spawnPos));
            zombiesSpawned++;

            // Zombiye bir script ekleyin veya var olan bir scripte bir fonksiyon ekleyin
            //zombie.GetComponent<ZombieAttack>().OnDeath += ZombieKilled;
        }
        if (zombiesSpawned >= totalZombiesToSpawn)
        {
            CancelInvoke("SpawnZombie");
            Debug.Log("T�m zombiler �ld�r�ld�. B�l�m tamamland�!");
            SceneManager.LoadScene(gameOverSceneName);
        }
    }

    private Vector3 RandomPositionAroundPlayer()
    {
        Vector3 randomDirection = Random.insideUnitSphere * Random.Range(spawnRadiusMin, spawnRadiusMax);
        randomDirection += playerTransform.position;
        randomDirection.y = 0; // Y eksenini sabit tut
        return randomDirection;
    }

    private void ZombieKilled()
    {
        zombiesKilled++;

        if (zombiesKilled >= totalZombiesToSpawn)
        {
            SceneManager.LoadScene(gameOverSceneName);
            CancelInvoke("SpawnZombie");
            Debug.Log("T�m zombiler �ld�r�ld�. B�l�m tamamland�!");
        }
    }
}
