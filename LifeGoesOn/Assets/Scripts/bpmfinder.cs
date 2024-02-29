using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bpmfinder : MonoBehaviour
{
    public KeyCode key;
    private GameObject player;
    public GameObject prefab;
    private float prev = 0f;
    private float avg = 0f;
    private int total = 0;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(key)) {
            Instantiate(prefab).transform.position = player.transform.position;
        }

    }
}
