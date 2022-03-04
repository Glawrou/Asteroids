using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIGameOver : MonoBehaviour
{
    public UIMein uiMein;
    public Text scoreText;

    private int score = 0;

    private void Update()
    {
        score = uiMein.GetScore();
        scoreText.text = "" + score;

        if (Input.GetKeyDown(KeyCode.Space)) SceneManager.LoadScene("Mein");

    }
}
