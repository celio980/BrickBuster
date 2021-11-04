using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{

    public void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }

}
