using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    private bool isInPlay = false;
    private Rigidbody physics;
    private float startSpeed = 300;
    private Transform paddleParent;

    private void Awake()
    {
        physics = gameObject.GetComponent<Rigidbody>();
        paddleParent = transform.parent;
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        if (IsOkToLaunch())
        {
            Launch();
        }
    }

    public void Reset()
    {
        gameObject.SetActive(true);
        isInPlay = false;
        physics.isKinematic = true;
        transform.parent = paddleParent;
        transform.position = new Vector3(0f, 01f, 0f);

    }

    private bool IsOkToLaunch()
    {
        if (isInPlay == false && Input.GetButtonDown("Fire1"))
            return true;
        return false;
    }

    private void Launch()
    {
        isInPlay = true;
        transform.parent = null;
        physics.isKinematic = false;
        physics.AddForce(new Vector3(startSpeed, startSpeed, 0f));
    }
}
