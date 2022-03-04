using UnityEngine;
using UnityEngine.UI;

public class UIMein : MonoBehaviour
{
    public StarshipController starshipController;
    public Text scoreText;
    public Text lifeText;

    [Header("UI Groups")]
    public GameObject uiGamplay;
    public GameObject uiMein;
    public GameObject uiGameOver;
    public GameObject uiStartGame;

    private int score = 0;

    void Update()
    {
        scoreText.text = "" + score;
        if(starshipController != null)lifeText.text = "" + starshipController.GetLife();

        if (Input.GetKeyDown(KeyCode.F1)) activeUI(uiGamplay);
    }

    public void GameOver()
    {
        activeUI(uiGameOver, true);
        activeUI(uiStartGame, false);
        activeUI(uiMein, false);
        activeUI(uiGamplay, false);
    }

    public void StartGame()
    {
        activeUI(uiGameOver, false);
        activeUI(uiStartGame, false);
        activeUI(uiMein, true);
        activeUI(uiGamplay, true);
    }

    private void activeUI(GameObject Ui)
    {
        if (Ui.activeSelf == true)
            Ui.SetActive(false);
        else if (Ui.activeSelf == false)
            Ui.SetActive(true);
    }

    private void activeUI(GameObject Ui, bool b)
    {
            Ui.SetActive(b);
    }

    public int GetScore()
    {
        return score;
    }
    public void AddScore(int s)
    {
        score += s;
    }
}
