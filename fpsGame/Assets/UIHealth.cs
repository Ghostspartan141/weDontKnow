using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIHealth : MonoBehaviour
{
    public Image healthBar;
    public float healthAmount = 100f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //resets the level
        if (healthAmount<=0)
        {
            Application.LoadLevel(Application.loadedLevel);
        }
    }
    //takes damage
    public void TakeDamage(float Damage)
    {
        healthAmount -= Damage;
        healthBar.fillAmount = healthAmount / 100f;
    }
    // takes heal
    public void TakeHeal(float Heal)
    {
        healthAmount += Heal;
        healthBar.fillAmount = Mathf.Clamp(Heal, 0, 100);
        healthBar.fillAmount = healthAmount / 100f;
    }
    // checks collison
    public void OnTriggerStay(Collider other)
    {
        if(other.tag =="enemy")
        {
            TakeDamage(1);
        }
        if (other.tag == "healthpad")
        {
            TakeHeal(1);
        }
    }
}

