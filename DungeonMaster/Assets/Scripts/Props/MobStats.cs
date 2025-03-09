using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobStats : MonoBehaviour
{
    public static bool sword;
    public static bool club;
    public static bool spear;
    public static bool bow;
    public static bool shield;

    //Drag N Drop script
    public GameObject weapon;
    public DragNDropWeapons dragScript;

    // Start is called before the first frame update
    void Start()
    {
        sword = false;
        club = false;
        spear = false;
        bow = false;
        shield = false;

        //get Drag N Drop script
        weapon = this.gameObject;
        dragScript = weapon.GetComponent<DragNDropWeapons>();
    }

    void Update()
    {
        if(dragScript.isLocked == true)
        {
            AttachWeapon();
        }

        if(dragScript.isLocked == false)
        {
            DetachWeapon();
        }
    }

    //set bool depending on weapon type when weapon attached
    public void AttachWeapon()
    {
        if(weapon.tag == "sword")
        {
            sword = true;
            Debug.Log("Sword!");
        }
        if (weapon.tag == "club")
        {
            club = true;
            Debug.Log("Club!");
        }
        if (weapon.tag == "spear")
        {
            spear = true;
            Debug.Log("Spear!");
        }
        if (weapon.tag == "bow")
        {
            bow = true;
            Debug.Log("Bow!");
        }
        if (weapon.tag == "shield")
        {
            shield = true;
            Debug.Log("Shield!");
        }
    }

    //set bool depending on weapon type when weapon detached
    public void DetachWeapon()
    {
        if(weapon.tag == "sword")
        {
            sword = false;
            Debug.Log("No sword!");
        }
        if (weapon.tag == "club")
        {
            club = false;
            Debug.Log("No club!");
        }
        if (weapon.tag == "spear")
        {
            spear = false;
            Debug.Log("No spear!");
        }
        if (weapon.tag == "bow")
        {
            bow = false;
            Debug.Log("No bow!");
        }
        if (weapon.tag == "shield")
        {
            shield = false;
            Debug.Log("No shield!");
        }
    }
}
