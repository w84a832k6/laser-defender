using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPosition : MonoBehaviour {
    
	void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, 1f);
    }
}
