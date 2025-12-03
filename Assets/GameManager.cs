using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public Rigidbody carRB;

    public GameObject[] obstacles;
    public GameObject coin;

    public GameObject mainMenu;
    public GameObject loseScreen;
    public GameObject winScreen;
    GameObject statics;

    public static int level = 1;
    int frequency;

    public int points;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    void Start()
    {
        statics = GameObject.Find("Statics");
        PlaceObstacles();
        PlaceCoins();
    }

    void PlaceObstacles()
    {
        if (level == 1)
        {
            frequency = 50;
        }
        else if (level == 2)
        {
            frequency = 30;
        }
        else if (level == 3)
        {
            frequency = 10;
        }

        for (int i = 0; i < 2000; i += frequency)
        {
            Vector3 random = new Vector3(Random.Range(-4.5f, 4.5f), 0.5f, RandomRoadZ());
            GameObject obs = Instantiate(obstacles[Random.Range(0, obstacles.Length)], random, Quaternion.identity);
            obs.transform.localEulerAngles = new Vector3(0, 90, 0);
            obs.transform.SetParent(statics.transform);
        }
    }

    Vector3 RandomRoadCoordinate()
    {
        Vector3 random = new Vector3(Random.Range(-4.5f, 4.5f), 1f, Random.Range (1 , 1000));
        return random;
    }

    void PlaceCoins()
    {
        for (int i = 0; i < 1000; i += 20)
        {
            GameObject coins = Instantiate(coin, RandomRoadCoordinate(), Quaternion.identity);
            coins.transform.localEulerAngles = new Vector3(0, 90, 90);
            coins.transform.SetParent(statics.transform);
        }
    }

    float RandomRoadZ()
    {
        return Random.Range(0f, 1000f);
    }

    void Update()
    {
        CheckLose();
        CheckLevelOutOfArray();
    }

    void CheckLevelOutOfArray()
    {
        if (level > 3) level = 1;
    }

    void CheckLose()
    {
        if (!mainMenu.activeInHierarchy && !winScreen.activeInHierarchy && !loseScreen.activeInHierarchy)
        {
            if ((int)carRB.velocity.magnitude == 0)
            {
                StartCoroutine(ThreeSecondsOfStayStillCheck());
            }
            else if ((int)carRB.gameObject.transform.position.y < -3)
            {
                loseScreen.SetActive(true);
            }
        }
    }

    IEnumerator ThreeSecondsOfStayStillCheck()
    {
        yield return new WaitForSeconds(3);
        if ((int)carRB.velocity.magnitude == 0)
        {
            loseScreen.SetActive(true);
        }
    }
}
