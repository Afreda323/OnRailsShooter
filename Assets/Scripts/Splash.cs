using UnityEngine;
using UnityEngine.SceneManagement;

public class Splash : MonoBehaviour
{
    [SerializeField] float splashTime = 2f;


    // Use this for initialization
    void Start()
    {
        Invoke("GoToGame", splashTime);
    }

    void GoToGame()
    {
        SceneManager.LoadScene(1);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
