using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    Canvas canvas;

    // Start is called before the first frame update
    void Start()
    {
        canvas = GetComponent<Canvas>();
        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0f;
            canvas.enabled = true;
        }
    }

    public void Resume ()
    {
        Time.timeScale = 1f;
        canvas.enabled = false;
    }

    public void QuitToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
