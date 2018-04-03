using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour {

    [SerializeField] float reloadDelay = 1f;
    [SerializeField] GameObject deathParticles;

    private void OnTriggerEnter(Collider other)
    {
        deathParticles.SetActive(true);
        StartDeath();
        Invoke("ReloadScene", reloadDelay);
    }

    private void StartDeath ()
    {
        SendMessage("OnDeath");
    }

    private void ReloadScene () {
        SceneManager.LoadScene(1);
    }
}
