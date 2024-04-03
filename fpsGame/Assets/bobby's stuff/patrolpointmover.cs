using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class patrolpointmover : MonoBehaviour
{
    public int pointSelector;
    private int _speed=50;
    public GameObject point1;
    public GameObject point2;
    public GameObject point3;
    public GameObject point4;
    public GameObject pointmover;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        patrolspot(pointSelector);
    }

    private void patrolspot(int pointSelector)
    {
       
        if (pointSelector == 1)
        {
            Vector3 direction = point1.transform.position - pointmover.transform.position;
            direction.Normalize();
            pointmover.transform.position += direction * _speed * Time.deltaTime;
        }
        if (pointSelector == 2)
        {
            Vector3 direction = point2.transform.position - pointmover.transform.position;
            direction.Normalize();
            pointmover.transform.position += direction * _speed * Time.deltaTime;
        }
        if (pointSelector == 3)
        {
            Vector3 direction = point3.transform.position - pointmover.transform.position;
            direction.Normalize();
            pointmover.transform.position += direction * _speed * Time.deltaTime;
        }
        if (pointSelector == 4)
        {
            Vector3 direction = point4.transform.position - pointmover.transform.position;
            direction.Normalize();
            pointmover.transform.position += direction * _speed * Time.deltaTime;
        }
    }

    public void OnTriggerStay(Collider other)
    {
        
        if (other.tag == "patrolpoint")
        {
            Debug.Log("random");
            int selector = Random.Range(1, 5);
            if (selector == 1)
            {
                patrolspot(1);
            }
            if (selector == 2)
            {
                patrolspot(2);
            }
            if (selector == 3)
            {
                patrolspot(3);
            }
            if (selector == 4)
            {
                patrolspot(4);
            }
        }

    }
}
