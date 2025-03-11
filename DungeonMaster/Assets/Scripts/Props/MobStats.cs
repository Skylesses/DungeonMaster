using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobStats : MonoBehaviour
{
    //enemy types
    public static bool skeleton;
    public static bool spearSkeleton;
    public static bool spearShieldSkeleton;
    public static bool swordSkeleton;
    public static bool swordShieldSkeleton;
    public static bool goblin;
    public static bool swordGoblin;
    public static bool clubGoblin;
    public static bool bandit;
    public static bool swordBandit;
    public static bool daggerBandit;
    public static bool zombie;   
    public static bool wyrmling;
    public static bool spider;
    public static bool ogre;

    public static bool sword;
    public static bool club;
    public static bool spear;
    public static bool bow;
    public static bool shield;

    //Drag N Drop script
    public GameObject dropSpot;
    public Transform dragObj;
    public Transform dummy;
    //public DragNDropWeapons dragScript;

    // Start is called before the first frame update
    void Start()
    {
        skeleton = false;
        spearSkeleton = false;
        spearShieldSkeleton = false;
        swordSkeleton = false;
        swordShieldSkeleton = false;
        goblin = false;
        swordGoblin = false;
        clubGoblin = false;
        bandit = false;
        swordBandit = false;
        daggerBandit = false;
        zombie = false;
        wyrmling = false;
        spider = false;
        ogre = false;

        sword = false;
        club = false;
        spear = false;
        bow = false;
        shield = false;

        //get Drag N Drop script
        dropSpot = this.gameObject;
        //dragScript = weapon.GetComponent<DragNDropWeapons>();
    }

    void Update()
    {
        if(dragObj == dummy && dropSpot.transform.childCount > 0)
        {
            dragObj = dropSpot.transform.GetChild(0);
            AttachWeapon();
        }
        if(dragObj != dummy && dropSpot.transform.childCount == 0)
        {
            
            DetachWeapon();
        }
    }

    //set bool depending on weapon type when weapon attached
    public void AttachWeapon()
    {
        if(dragObj.tag == "sword")
        {
            sword = true;
            Debug.Log("Sword!");
        }
        if (dragObj.tag == "club")
        {
            club = true;
            Debug.Log("Club!");
        }
        if (dragObj.tag == "spear")
        {
            spear = true;
            Debug.Log("Spear!");
        }
        if (dragObj.tag == "bow")
        {
            bow = true;
            Debug.Log("Bow!");
        }
        if (dragObj.tag == "shield")
        {
            shield = true;
            Debug.Log("Shield!");
        }
    }

    //set bool depending on weapon type when weapon detached
    public void DetachWeapon()
    {
        if(dragObj.tag == "sword")
        {
            sword = false;
            Debug.Log("No sword!");
            dragObj = dummy;
        }
        if (dragObj.tag == "club")
        {
            club = false;
            Debug.Log("No club!");
            dragObj = dummy;
        }
        if (dragObj.tag == "spear")
        {
            spear = false;
            Debug.Log("No spear!");
            dragObj = dummy;
        }
        if (dragObj.tag == "bow")
        {
            bow = false;
            Debug.Log("No bow!");
            dragObj = dummy;
        }
        if (dragObj.tag == "shield")
        {
            shield = false;
            Debug.Log("No shield!");
            dragObj = dummy;
        }
    }
}
