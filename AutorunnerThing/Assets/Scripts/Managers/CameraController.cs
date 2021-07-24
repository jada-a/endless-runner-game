using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public PlayerController player;
    private Vector3 lastPlayerPosition;
    private float distanceToMove;
    public float step;
    private float stepStorage;


    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerController>();
        lastPlayerPosition = player.transform.position;
        stepStorage = step;

    }

    // Update is called once per frame
    void Update()
    {
        //distanceToMove = player.transform.position.x - lastPlayerPosition.x;
       //transform.position = new Vector3(transform.position.x + distanceToMove, transform.position.y, transform.position.z);

        //lastPlayerPosition = player.transform.position;

        Vector3 cameraPosition = transform.position;

        cameraPosition.x += step;
        transform.position = cameraPosition;
    }

    public void StopCamera()
    {
        step = 0;
    }

    public void StartCamera()
    {
        step = stepStorage;
    }


}
