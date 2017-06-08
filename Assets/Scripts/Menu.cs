using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour {
    private Canvas gameOverCanvas;
    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void loadMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
