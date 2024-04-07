using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot : MonoBehaviour
{
    public GameObject monster;
    public GameObject EXcrate;
    public GameObject stuncrate;
    public GameObject eleccrate;
    private GameObject _currentarrow;
    public GameObject explodeArrow;
    public GameObject stunArrow;
    public GameObject eletricArrow;
    public int typeArrow;
    public float begintime=5;
    private int ExArrowAmount=10;
    private int stunArrowAmount=10;
    private int ElArrowAmount = 10;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        arrowChange();
        shooting();
       
    }
   
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag=="eplodecrate") 
        {
            ExArrowAmount += 10;
            Destroy(EXcrate);
        }
        if (other.gameObject.tag == "stuncrate")
        {
            stunArrowAmount += 10;
            Destroy(stuncrate);
        }
        if (other.gameObject.tag == "eletriccrate")
        {
            ElArrowAmount += 10;
            Destroy(eleccrate);
        }
        
    }
    public void arrowChange()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            typeArrow = 0;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            typeArrow = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            typeArrow = 2;
        }
    }
    public void shooting()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (typeArrow == 0 && ExArrowAmount > 0)
            {
               
                _currentarrow = Instantiate(explodeArrow, transform);
                _currentarrow.GetComponent<Rigidbody>().AddForce(Camera.main.transform.forward * 30f, ForceMode.Impulse);
                _currentarrow.transform.parent = null;
                Debug.Log("fire");
                if (transform.localPosition.x >= 15 && transform.localPosition.y >= 15 && transform.localPosition.z >= 15)
                {
                    Destroy(this.explodeArrow);
                    Debug.Log("destory");
                }
                --ExArrowAmount;
                
            }
            if (typeArrow == 1&&stunArrowAmount>0)
            {
                _currentarrow = Instantiate(stunArrow, transform);
                _currentarrow.GetComponent<Rigidbody>().AddForce(Camera.main.transform.forward * 30f, ForceMode.Impulse);
                _currentarrow.transform.parent = null;
                Debug.Log("fire1");
                if (transform.localPosition.x >= 15 && transform.localPosition.y >= 15 && transform.localPosition.z >= 15)
                {
                    Destroy(this.stunArrow);
                    Debug.Log("destory");
                }
                --stunArrowAmount;
            }
            if (typeArrow == 2 && ElArrowAmount > 0)
            {
                _currentarrow = Instantiate(eletricArrow, transform);
                _currentarrow.GetComponent<Rigidbody>().AddForce(Camera.main.transform.forward * 30f, ForceMode.Impulse);
                _currentarrow.transform.parent = null;
                Debug.Log("fire2");
                if (transform.localPosition.x >= 15&&transform.localPosition.y>=15&&transform.localPosition.z>=15)
                {
                    Destroy(this.eletricArrow);
                    Debug.Log("destory");
                }
                --ElArrowAmount;
            }
        }
    }
   
}
