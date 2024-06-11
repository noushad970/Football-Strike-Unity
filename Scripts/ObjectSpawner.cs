using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject SpawnBall; // The prefab to instantiate
    public GameObject SpawnPlayer;
    public GameObject SpawnGoalKeeperAI;
    

    public Transform spawnBallLocation1;
    public Transform spawnPlayerLocation1;

    public Transform spawnBallLocation2;
    public Transform spawnPlayerLocation2;

    public Transform spawnBallLocation3;
    public Transform spawnPlayerLocation3;

    public Transform spawnBallLocation4;
    public Transform spawnPlayerLocation4;

    public Transform spawnBallLocation5;
    public Transform spawnPlayerLocation5;


    public Transform spawnGKLocation;
    Transform spawnBallLocation;
    Transform spawnPlayerLocation;
    int randomNum;
    void Start()
    {

        
        objectSpawner();

        // Instantiate the object at the spawn location's position and rotation
    }
    public void objectSpawner()
    {
        randomNum = Random.Range(1, 5);
        if(randomNum==1)
        {
            spawnBallLocation= spawnBallLocation1;
            spawnPlayerLocation= spawnPlayerLocation1;
        }
        else if (randomNum == 2)
        {
            spawnBallLocation = spawnBallLocation2;
            spawnPlayerLocation = spawnPlayerLocation2;
        }
        else if (randomNum == 3)
        {
            spawnBallLocation = spawnBallLocation3;
            spawnPlayerLocation = spawnPlayerLocation3;
        }
        else if (randomNum == 4)
        {
            spawnBallLocation = spawnBallLocation4;
            spawnPlayerLocation = spawnPlayerLocation4;
        }
        else if (randomNum == 5)
        {
            spawnBallLocation = spawnBallLocation5;
            spawnPlayerLocation = spawnPlayerLocation5;
        }

        GameManager.spawnedBall = Instantiate(SpawnBall, spawnBallLocation.position, spawnBallLocation.rotation);

        GameManager.spawnedPlayer = Instantiate(SpawnPlayer, spawnPlayerLocation.position, spawnPlayerLocation.rotation);

        GameManager.spawnedGKAI = Instantiate(SpawnGoalKeeperAI, spawnGKLocation.position, spawnGKLocation.rotation);
    }
}
