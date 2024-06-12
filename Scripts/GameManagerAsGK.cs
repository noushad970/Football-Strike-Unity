using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameManagerAsGK : MonoBehaviour
{
    //goalkeeper

    public static GameObject spawnedBallGK;
    public static GameObject spawnedPlayerAIGK;
    public static GameObject spawnedGK;
    public static GameObject spawnedCamGK;
    public Button shootAgainButton;
    public Button MainMenuButton;
    public ObjectSpawnerGK spawnGKmode;
    // Start is called before the first frame update
    void Start()
    {
        shootAgainButton.onClick.AddListener(resetsKicker);
        MainMenuButton.onClick.AddListener(mainMenu);
    }
    void mainMenu()
    {
        resetsKicker();
        BallScript.shootplayer = 0;
        SceneControll.isGoalKeeper = false;
        SceneControll.isPenaltyKicker= false;
        SceneManager.LoadScene("Menu");
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    void resetsKicker()
    {
        DeleteSpawnedObjectGK();
        StartCoroutine(waitSec());
        BallScript.shootplayer = 0;
        spawnGKmode.ObjectSpawnerAsGoalKeeper();
    }
    IEnumerator waitSec()
    {
        yield return new WaitForSeconds(.5f);
    }
    public void DeleteSpawnedObjectGK()
    {
        Destroy(spawnedBallGK);
        Destroy(spawnedPlayerAIGK);
        Destroy(spawnedGK);
        Destroy(spawnedCamGK);

    }
}
