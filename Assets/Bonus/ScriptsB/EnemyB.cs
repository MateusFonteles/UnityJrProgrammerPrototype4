using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyB : MonoBehaviour
{
    public Rigidbody enemyRB; 
    public GameObject player;
    public float speed = 3;
    private float limit = -30;
    public Texture[] texturesArray; 
    private Renderer _renderer; 

    // Start is called before the first frame update
    void Start()
    {
        enemyRB = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");   
        _renderer = GetComponent<Renderer>();
        int textureIndex = Random.Range(0, texturesArray.Length);
        _renderer.material.mainTexture = texturesArray[textureIndex];
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 lookDirection = (player.transform.position - transform.position).normalized; 
        enemyRB.AddForce(lookDirection * speed);
        
                if (transform.position.y < limit)
        {
            Destroy(gameObject);
        }
        
    }
}
