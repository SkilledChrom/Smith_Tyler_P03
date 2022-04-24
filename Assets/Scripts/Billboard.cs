using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    public GameObject player;

    void Update()
    {
        Vector3 targetPosition = new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z);

        transform.LookAt(targetPosition);
    }
}
