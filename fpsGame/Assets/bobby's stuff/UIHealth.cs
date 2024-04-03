using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIHealth : MonoBehaviour
{
    public Image healthBar;
    public Image sheildbar;
    public float healthAmount = 100f;
    public float sheildpower=0f;
    public GameObject sheildpickup;
    public GameObject healthPickup;

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
        if (sheildpower > 0)
        {
            sheildpower -= Damage;
            sheildbar.fillAmount = sheildpower / 100f;
        }
        else
        {
            healthAmount -= Damage;
            healthBar.fillAmount = healthAmount / 100f;
        }
    }
    // takes heal
    public void TakeHeal(float Heal)
    {
        healthAmount += Heal;
        if (healthAmount>=100)
        {
            sheildpower = healthAmount - 100;
            sheildbar.fillAmount = sheildpower / 100f;
            healthAmount = 100f;
            Destroy(healthPickup);
        }
        
        healthBar.fillAmount = Mathf.Clamp(Heal, 0, 100);
        healthBar.fillAmount = healthAmount / 100f;
        Destroy(healthPickup);
    }
    public void sheildhealth(float Heal)
    {
        sheildpower += Heal;
        if (sheildpower>100)
        {
            sheildpower = 100f;
        }
        
        sheildbar.fillAmount = Mathf.Clamp(Heal, 0, 100);
        sheildbar.fillAmount = sheildpower / 100f;
        Destroy(sheildpickup);
    }
    // checks collison
    public void OnTriggerStay(Collider other)
    {
        if(other.tag =="enemy")
        {
            TakeDamage(1);
        }
        if (other.tag == "healthkit")
        {
            TakeHeal(50);
        }
        if(other.tag=="sheildpickup")
        {
            sheildhealth(100);
        }
       
    }
}

