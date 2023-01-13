using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5; 
    public Rigidbody playerRB; 
    public GameObject focalPoint; 
    public bool hasPowerup = false; 
    public float powerupStrengh = 15;
    public GameObject powerupIndicator; 
    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("FocalPoint");
    }

    // Update is called once per frame
    void Update()
    {
        float verticalInput = Input.GetAxis("Vertical");
        playerRB.AddForce(focalPoint.transform.forward * verticalInput * speed);
        powerupIndicator.transform.position = transform.position + new Vector3(0, -0.5f, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Powerup"))
        {
            hasPowerup = true;
            Destroy(other.gameObject); 
            StartCoroutine(powerupCountdownRoutine());
            powerupIndicator.gameObject.SetActive(true);    
        }
    }

    private IEnumerator powerupCountdownRoutine(){
        yield return new WaitForSeconds(7);
        hasPowerup = false;
        powerupIndicator.gameObject.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy") && hasPowerup){
            Rigidbody enemyRB = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 expell = collision.gameObject.transform.position - transform.position;
            enemyRB.AddForce(expell * powerupStrengh, ForceMode.Impulse);
            Debug.Log("Has collided with " + collision.gameObject.name + "and hasPowerup = " + hasPowerup);
        }

    }

 
}
