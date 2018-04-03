using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
                         
public class Player : MonoBehaviour {

    [Header("General")]
    [SerializeField] float xRange = 5f;
    [SerializeField] float yRange = 3f;
    [Tooltip("Meters per second")] [SerializeField] float xSpeed = 4f;
    [Tooltip("Meters per second")] [SerializeField] float ySpeed = 4f;
    [SerializeField] GameObject[] cannons;


    [Header("Player Position and Rotate")]
    [SerializeField] float pitchRotateControl = -5f;
    [SerializeField] float pitchRotateFactor = -15f;
    [SerializeField] float yawRotateFactor = 5f;
    [SerializeField] float rollRotateFactor = -15f;

    float yThrow;
    float xThrow;
    bool hasControl = true;
    ScoreBoard scoreBoard;

	// Use this for initialization
	void Start () {
        scoreBoard = FindObjectOfType<ScoreBoard>();
        InvokeRepeating("UpScoreInTime", 0, 1);
	}

    private void UpScoreInTime () {
        scoreBoard.AddPoints(10);
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (hasControl) 
        {
            HandleDirections();
            HandleRotate();
            HandleFiring();
        }
    }

    private void HandleRotate () {
        float pitchRotate = transform.localPosition.y * pitchRotateControl + yThrow * pitchRotateFactor;
        float yawRotate = transform.localPosition.x * yawRotateFactor;
        float rollRotate = xThrow * rollRotateFactor;

        transform.localRotation = Quaternion.Euler(pitchRotate, yawRotate, rollRotate);
    }

    private void HandleDirections () 
    {
        yThrow = CrossPlatformInputManager.GetAxis("Vertical");
        float yOffset = yThrow * ySpeed * Time.deltaTime;
        float rawYOffset = transform.localPosition.y + yOffset;

        float clampedY = Mathf.Clamp(rawYOffset, -yRange, yRange);


        xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        float xOffset = xThrow * xSpeed * Time.deltaTime;
        float rawXOffset = transform.localPosition.x + xOffset;

        float clampedX = Mathf.Clamp(rawXOffset, -xRange, xRange);

        transform.localPosition = new Vector3(
            clampedX, clampedY, transform.localPosition.z
        );
    }

    void OnDeath ()
    {
        hasControl = false;
    }

    private void HandleFiring () 
    {
        if (CrossPlatformInputManager.GetButton("Fire"))
        {
            ToggleEmission(true);
        }
        else 
        {
            ToggleEmission(false);
        }
    }

    private void ToggleEmission (bool isActive) {
        foreach (GameObject cannon in cannons) 
        {
            var particles = cannon.GetComponent<ParticleSystem>().emission;
            particles.enabled = isActive;
        }
    }
}
