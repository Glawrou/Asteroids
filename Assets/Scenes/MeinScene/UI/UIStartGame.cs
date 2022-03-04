using UnityEngine;
using UnityEngine.UI;

public class UIStartGame : MonoBehaviour
{
    public UIMein uiMein;
    private void Start()
    {
        Time.timeScale = 0;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Time.timeScale = 1;
            uiMein.StartGame();
        }
    }
}
