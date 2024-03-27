using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WeaponUser : MonoBehaviour
{
    [SerializeField] private WeaponBase _curWeapon;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
        { 
            Ray ray=Camera.main.ScreenPointToRay(Input.mousePosition);
            _curWeapon?.Use(this, ray.direction);
        }
    }
}
