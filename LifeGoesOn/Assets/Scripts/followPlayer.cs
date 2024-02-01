using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followPlayer : MonoBehaviour
{
    public Transform player;
    private Vector3 offset = new(3, 1, -5);

    // Update is called once per frame
    void Update() {
        transform.position = player.position + offset;
    }
}
