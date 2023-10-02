using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    /*Por si se quisiera que el fondo se moviera con el pj
    public Transform bg;
    public Transform terrain;
    private float lastXPos;
    */
    // Start is called before the first frame update
    void Start()
    {
        //lastXPos = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        /*
        float amountToMoveX = transform.position.x - lastXPos;
        bg.position = bg.position + new Vector3(amountToMoveX * .2f, 0f, 0f);
        terrain.position = terrain.position + new Vector3(amountToMoveX * .5f, 0f, 0f);
        lastXPos = transform.position.x;*/
    }
}
