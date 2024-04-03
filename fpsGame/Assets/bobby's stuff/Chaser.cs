using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Chaser : MonoBehaviour
{
    public GameObject _target;
    public GameObject AI;
    public GameObject patrolPoint;
    private float _speed = 1f;
    private float _decetionRange = 10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(AI.transform.position, _target.transform.position) < _decetionRange)
        {
            Vector3 direction = _target.transform.position - AI.transform.position;
            direction.Normalize();
            AI.transform.position += direction * _speed*2 * Time.deltaTime;
           
        }
        if (Vector3.Distance(AI.transform.position, _target.transform.position) > _decetionRange)
        {
            Vector3 direction = patrolPoint.transform.position - AI.transform.position;
            direction.Normalize();
            AI.transform.position += direction * _speed *3* Time.deltaTime;
            
        }
    }
}
