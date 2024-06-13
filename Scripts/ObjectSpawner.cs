using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [Header("Kicker Mode")]
    public GameObject SpawnBall; // The prefab to instantiate
    public GameObject SpawnPlayer;
    public GameObject SpawnGoalKeeperAI;
    public GameObject spawnCamera;
    private GameObject cameraClone;

    public Transform spawnBallLocation1;
    public Transform spawnPlayerLocation1;
    public Transform spawnCamLocation1;

    public Transform spawnBallLocation2;
    public Transform spawnPlayerLocation2;
    public Transform spawnCamLocation2;

    public Transform spawnBallLocation3;
    public Transform spawnPlayerLocation3;
    public Transform spawnCamLocation3;

    public Transform spawnBallLocation4;
    public Transform spawnPlayerLocation4;
    public Transform spawnCamLocation4;

    public Transform spawnBallLocation5;
    public Transform spawnPlayerLocation5;
    public Transform spawnCamLocation5;



    public Transform spawnGKLocation;
    Transform spawnBallLocation;
    Transform spawnPlayerLocation;
    Transform spawnCamLocation;
    public static Transform ballLocation;

    int randomNum;
    void Start()
    {

        if(SceneControll.isPenaltyKicker)
        {
            objectSpawnerAsKicker();

        }

        // Instantiate the object at the spawn location's position and rotation
    }
    public void objectSpawnerAsKicker()
    {
        randomNum = Random.Range(1, 5);
        if(randomNum==1)
        {
            spawnBallLocation= spawnBallLocation1;
            spawnPlayerLocation= spawnPlayerLocation1;
            spawnCamLocation= spawnCamLocation1;
            Debug.Log("player random position 1");
            
        }
        else if (randomNum == 2)
        {
            spawnBallLocation = spawnBallLocation2;
            spawnPlayerLocation = spawnPlayerLocation2;
            spawnCamLocation= spawnCamLocation2;
            Debug.Log("player random position 2");

        }
        else if (randomNum == 3)
        {
            spawnBallLocation = spawnBallLocation3;
            spawnPlayerLocation = spawnPlayerLocation3;
            spawnCamLocation= spawnCamLocation3;
            Debug.Log("player random position 3");

        }
        else if (randomNum == 4)
        {
            spawnBallLocation = spawnBallLocation4;
            spawnPlayerLocation = spawnPlayerLocation4;
            spawnCamLocation= spawnCamLocation4;
            Debug.Log("player random position 4");

        }
        else if (randomNum == 5)
        {
            spawnBallLocation = spawnBallLocation5;
            spawnPlayerLocation = spawnPlayerLocation5;
                spawnCamLocation = spawnCamLocation5;
            Debug.Log("player random position 5");

        }
        ballLocation= spawnBallLocation;    
        GameManager.spawnedBall = Instantiate(SpawnBall, spawnBallLocation.position, spawnBallLocation.rotation);
        
        GameManager.spawnedPlayer = Instantiate(SpawnPlayer, spawnPlayerLocation.position, spawnPlayerLocation.rotation);
        
        GameManager.spawnedGKAI = Instantiate(SpawnGoalKeeperAI, spawnGKLocation.position, spawnGKLocation.rotation);
        GameManager.spawnedCam= Instantiate(spawnCamera,spawnCamLocation.position, spawnCamLocation.rotation);
        cameraClone = GameManager.spawnedCam;
        spawnCamera.transform.position = cameraClone.transform.position;
        spawnCamera.transform.rotation = cameraClone.transform.rotation;
    }
    
}
