using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawnerGK : MonoBehaviour
{

    [Header("GoalKeeper Mode")]
    public GameObject spawnAIKicker;
    public GameObject spawnPlayerGK;
    public GameObject spawnCamGK;
    public GameObject spawnBallGK;

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


    Transform spawnBallLocationGK;
    Transform spawnPlayerLocationGK;
    Transform spawnCamLocationGK;
    public Transform spawnGKLocation;
    int randomNum;
    // Start is called before the first frame update
    void Start()
    {
        if (SceneControll.isGoalKeeper)
        {
            ObjectSpawnerAsGoalKeeper();
        }
        ObjectSpawnerAsGoalKeeper();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ObjectSpawnerAsGoalKeeper()
    {
        randomNum = Random.Range(1, 5);
        if (randomNum == 1)
        {
            spawnBallLocationGK = spawnBallLocation1;
            spawnPlayerLocationGK = spawnPlayerLocation1;
            spawnCamLocationGK = spawnCamLocation1;
            Debug.Log("player random position 1");

        }
        else if (randomNum == 2)
        {
            spawnBallLocationGK = spawnBallLocation2;
            spawnPlayerLocationGK = spawnPlayerLocation2;
            spawnCamLocationGK = spawnCamLocation2;
            Debug.Log("player random position 2");

        }
        else if (randomNum == 3)
        {
            spawnBallLocationGK = spawnBallLocation3;
            spawnPlayerLocationGK = spawnPlayerLocation3;
            spawnCamLocationGK = spawnCamLocation3;
            Debug.Log("player random position 3");

        }
        else if (randomNum == 4)
        {
            spawnBallLocationGK = spawnBallLocation4;
            spawnPlayerLocationGK = spawnPlayerLocation4;
            spawnCamLocationGK = spawnCamLocation4;
            Debug.Log("player random position 4");

        }
        else if (randomNum == 5)
        {
            spawnBallLocationGK = spawnBallLocation5;
            spawnPlayerLocationGK = spawnPlayerLocation5;
            spawnCamLocationGK = spawnCamLocation5;
            Debug.Log("player random position 5");

        }

        GameManagerAsGK.spawnedBallGK = Instantiate(spawnBallGK, spawnBallLocationGK.position, spawnBallLocationGK.rotation);

        GameManagerAsGK.spawnedPlayerAIGK = Instantiate(spawnAIKicker, spawnPlayerLocationGK.position, spawnPlayerLocationGK.rotation);

        GameManagerAsGK.spawnedGK = Instantiate(spawnPlayerGK, spawnGKLocation.position, spawnGKLocation.rotation);
        GameManagerAsGK.spawnedCamGK = Instantiate(spawnCamGK, spawnCamLocationGK.position, spawnCamLocationGK.rotation);
        cameraClone = GameManagerAsGK.spawnedCamGK;
        spawnCamGK.transform.position = cameraClone.transform.position;
        spawnCamGK.transform.rotation = cameraClone.transform.rotation;

    }
}