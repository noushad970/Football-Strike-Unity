using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneControll : MonoBehaviour
{
    public Button GoalKeeperButton;
    public Button PenaltyKickButton;

    void Start()
    {
        // Assign the onClick listeners for the buttons
        GoalKeeperButton.onClick.AddListener(GoalKeeper);
        PenaltyKickButton.onClick.AddListener(PenaltyKicker);
    }

    void GoalKeeper()
    {
        SceneManager.LoadScene("FootballStrikeGoalKeeper");
    }

    void PenaltyKicker()
    {
        SceneManager.LoadScene("FootballStrikePenaltyKicker");
    }
}
