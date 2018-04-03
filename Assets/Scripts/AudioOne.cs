using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioOne : MonoBehaviour {

	private void Awake()
	{
        int numPlayers = FindObjectsOfType<AudioOne>().Length;
        if (numPlayers > 1) {
            Destroy(gameObject);
        } 
        else 
        {
            DontDestroyOnLoad(gameObject);
        }
	}

}
