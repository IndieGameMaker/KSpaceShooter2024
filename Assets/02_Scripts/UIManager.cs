using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Button startButton;

    void Start()
    {
        startButton.onClick.AddListener(() => StartGame());

        // startButton.onClick.AddListener(() =>
        // {
        //     StartGame();
        // });

        // startButton.onClick.AddListener(delegate ()
        // {
        //     StartGame();
        //     Debug.Log("Start Button 클릭됨");
        // });
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Level01");
        SceneManager.LoadScene("Logic", LoadSceneMode.Additive);
    }

}
