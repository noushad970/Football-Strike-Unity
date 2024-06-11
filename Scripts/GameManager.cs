using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{


    public Button shootAgainButton;
    public Button lowShotButton;
    public Button loftedShotButton;
    public static GameObject spawnedBall;
    public static GameObject spawnedPlayer;
    public static GameObject spawnedGKAI;
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
        shootAgainButton.onClick.AddListener(resets);
        lowShotButton.onClick.AddListener(SetLowShot);
        loftedShotButton.onClick.AddListener(SetLoftedShot);

    }
    void SetLowShot()
    {
        isLowShot = true;

        // isCurlShot = false;
        BallScript.maxForceMultiplier = 25f;
        BallScript.minForceMultiplier = 13f;
        Debug.Log("Low shot selected");
    }

    void SetLoftedShot()
    {

        BallScript.maxForceMultiplier = 20f;
        BallScript.minForceMultiplier = 10f;
        isLowShot = false;
        // isCurlShot = false;
        Debug.Log("Lofted shot selected");
    }

    void resets()
    {
        DeleteSpawnedObject();
        StartCoroutine(waitSec());
        BallScript.shootplayer = 0;
        spawner.objectSpawner();
    }
    IEnumerator waitSec()
    {
        yield return new WaitForSeconds(.5f);
    }
    public void DeleteSpawnedObject()
    {
        Destroy(spawnedBall);
        Destroy(spawnedPlayer);
        Destroy(spawnedGKAI);
    }





}


