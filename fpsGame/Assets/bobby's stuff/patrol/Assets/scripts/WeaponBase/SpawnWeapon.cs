
using UnityEngine;

namespace weapon
{
    [CreateAssetMenu(menuName ="weapon/Spawn")]
    public class SpawnWeapon : WeaponBase
    {
        [SerializeField] private GameObject _prefabToSpawn;

        public override void Use(WeaponUser user, Vector3 forward)
        {
            Instantiate(_prefabToSpawn,user.transform.position,Quaternion.Euler(forward));
        }
    }
}
