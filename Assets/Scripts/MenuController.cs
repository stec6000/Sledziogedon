using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour {

    public Canvas mainCanvas;

	void Start () {
	}
	
	void Update () {
	
	}

    public void ChangeScene()
    {
        PlayerPrefs.SetFloat("High", 60);
        Application.LoadLevel("Player");
    }

    public void loadScene(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void realoadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void setActiveCanvas(string name)
    {
        foreach (GameObject canvas in GameObject.FindGameObjectsWithTag("MenuCanvas"))
        {
            canvas.GetComponent<Canvas>().enabled = false;
        }
        GameObject.Find(name).GetComponent<Canvas>().enabled = true;
    }
}
