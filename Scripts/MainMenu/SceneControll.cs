using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneControll : MonoBehaviour
{
    public Button GoalKeeperButton;
    public Button PenaltyKickButton;
    public static bool isPenaltyKicker=false;
    public static bool isGoalKeeper=false;

    void Start()
    {
        // Assign the onClick listeners for the buttons
        GoalKeeperButton.onClick.AddListener(GoalKeeper);
        PenaltyKickButton.onClick.AddListener(PenaltyKicker);
    }

    void GoalKeeper()
    {
        isGoalKeeper = true;
        isPenaltyKicker = false;
        SceneManager.LoadScene("FootballStrikeGoalKeeper");
    }

    void PenaltyKicker()
    {
        isPenaltyKicker = true;
        isGoalKeeper=false;
        SceneManager.LoadScene("FootballStrikePenaltyKicker");
    }
}
