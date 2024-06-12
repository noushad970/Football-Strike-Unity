using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{


    public Button shootAgainButton;
    public Button lowShotButton;
    public Button loftedShotButton;
    //kicker
    public static GameObject spawnedBall;
    public static GameObject spawnedPlayer;
    public static GameObject spawnedGKAI;
    public static GameObject spawnedCam;

    
    //public Button curlShotButton;
    public static bool isLowShot = true;
    public ObjectSpawner spawner;
    //public AIGoalKeeper AIGK;

    private void Update()
    {
        if(BallScript.shootplayer>0)
        {
            shootAgainButton.enabled = true;
        }
        else
        {
            shootAgainButton.enabled=false;
        }
    }
    void Start()
    {


        // Assign button click listeners
        //AIGK.GetComponent<AIGoalKeeper>();
        shootAgainButton.enabled = false;
        shootAgainButton.onClick.AddListener(resetsKicker);
        lowShotButton.onClick.AddListener(SetLowShot);
        loftedShotButton.onClick.AddListener(SetLoftedShot);

    }
    void SetLowShot()
    {
        isLowShot = true;

        // isCurlShot = false;
        BallScript.maxForceMultiplier = 30f;
        BallScript.minForceMultiplier = 15f;
        Debug.Log("Low shot selected");
    }

    void SetLoftedShot()
    {

        BallScript.maxForceMultiplier = 20f;
        BallScript.minForceMultiplier = 13f;
        isLowShot = false;
        // isCurlShot = false;
        Debug.Log("Lofted shot selected");
    }

    void resetsKicker()
    {
        DeleteSpawnedObjectKicker();
        StartCoroutine(waitSec());
        BallScript.shootplayer = 0;
        spawner.objectSpawnerAsKicker();
    }
    IEnumerator waitSec()
    {
        yield return new WaitForSeconds(.5f);
    }
    public void DeleteSpawnedObjectKicker()
    {
        Destroy(spawnedBall);
        Destroy(spawnedPlayer);
        Destroy(spawnedGKAI);
        Destroy(spawnedCam);

    }
    





}


