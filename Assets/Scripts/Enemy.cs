using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject explosion;
    [SerializeField] Transform postDeathParent;
    [SerializeField] int pointsPerKill = 12;
    [SerializeField] int hitsToKill = 10;

    ScoreBoard scoreBoard;

	// Use this for initialization
	void Start () {
        AddBoxCollider();
        scoreBoard = FindObjectOfType<ScoreBoard>();
	}

    private void AddBoxCollider()
    {
        Collider boxCollider = gameObject.AddComponent<BoxCollider>();
        boxCollider.isTrigger = false;
    }

	private void OnParticleCollision(GameObject other)
    {
        ProcessHit();
        if(hitsToKill <= 1) 
        {
            KillEnemy();
        }
    }

    private void ProcessHit()
    {
        scoreBoard.AddPoints(pointsPerKill);
        hitsToKill--;
    }

    private void KillEnemy()
    {
        GameObject fx = Instantiate(explosion, gameObject.transform.position, Quaternion.identity);
        fx.transform.parent = postDeathParent;
        Destroy(gameObject);
	}
}
