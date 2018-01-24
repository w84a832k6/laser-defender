using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    public GameObject enemyPrefab;
    public float width = 10f;
    public float height = 5f;
    public float speed = 5f;

    private bool movingRight = true;
    private float xmax;
    private float xmin;

    // Use this for initialization
    void Start () {
        float distanceToCamera = transform.position.z - Camera.main.transform.position.z;
        Vector3 leftEdge = Camera.main.ViewportToWorldPoint(new Vector3(0f, 0f, distanceToCamera));
        Vector3 rightEdge = Camera.main.ViewportToWorldPoint(new Vector3(1f, 0f, distanceToCamera));
        xmax = rightEdge.x;
        xmin = leftEdge.x;

        foreach (Transform child in transform)
        {
            GameObject enemy = Instantiate(enemyPrefab, child.transform.position, Quaternion.identity);
            enemy.transform.parent = child;
        }
    }

    public void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, new Vector3(width, height));
    }
	
	// Update is called once per frame
	void Update () {
        if(movingRight)
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }
        else
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }

        float rightEdgeOfFormation = transform.position.x + (0.5f * width);
        float leftEdgeOfFormation = transform.position.x - (0.5f * width);
        if(leftEdgeOfFormation < xmin)
        {
            movingRight = true;
        }
        else if(rightEdgeOfFormation > xmax)
        {
            movingRight = false;
        }
	}
}
