using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace weapon
{
    [CreateAssetMenu(menuName = "weapon/scan")]
    public class HitScanWeapon : WeaponBase
    {
        public override void Use(WeaponUser user, Vector3 forward)
        {
            RaycastHit hit;
            if (Physics.Raycast(user.transform.position, forward, out hit))
            {
                Debug.Log(hit.transform.name);
            }

        }
    }
}
