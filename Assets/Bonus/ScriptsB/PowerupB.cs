using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupB : MonoBehaviour
{
    public float distanceToCover = 0.1f; 
    public float speed = 4;
    public Vector3 startingPosition;
    public float rotationSpeed = 2; 
    // Start is called before the first frame update
    void Start()
    {
        startingPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movement = startingPosition;
        movement.y += distanceToCover * Mathf.Sin(Time.time * speed);
        transform.position = movement; 
        transform.Rotate ( Vector3.up * ( rotationSpeed * Time.deltaTime ) );
    }

}
