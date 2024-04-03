using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponBase : ScriptableObject
{
    public abstract void Use(WeaponUser user,Vector3 forward);
    
}
