using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    public CanvasGroup gameOverCanvasGroup;
    public GameObject pausedCanvasGroup;

    bool paused;

    // Use this for initialization
    void Start () {
        gameOverCanvasGroup.alpha = 0;
        UnpauseGame();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.P) && !paused)
        {
            print("det");
            PauseGame();
        }
        else if (Input.GetKeyDown(KeyCode.P) && paused)
        {
            print("det2");
            UnpauseGame();
        }
    }

    public IEnumerator EndOfGame()
    {
        //SceneManager.LoadSceneAsync(1);
        float t = 0;
        while (t < 1)
        {
            gameOverCanvasGroup.alpha = t;
            t += Time.deltaTime * 0.4f;
            yield return null;
        }
    }
    public void ChangeScene(int sceneNo)
    {
        SceneManager.LoadScene(sceneNo);
    }


    public void PauseGame()
    {
        paused = true;
        pausedCanvasGroup.SetActive(true);
        Time.timeScale = 0;
    }

    public void UnpauseGame()
    {
        Time.timeScale = 1;
        paused = false;
        pausedCanvasGroup.SetActive(false);

    }

}
