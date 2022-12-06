using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HandgunUseAttacks : MonoBehaviour
{
    public int handgunAmmoAmount = 10;
    // public int machinegunAmmoAmount = 10;
    // public int shotgunAmmoAmount = 10;
    public float meleeRepeatDelay = 0.25f;
    public GameObject projectile;
    public GameObject punchMesh;
    public Text ammoPanel;

    private bool punchActive;

    private void Start()
    {
        //Update text to display the player ammo.
        UpdateText();
        //Hide the hand when we start the game and have ammo.
        punchMesh.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (handgunAmmoAmount > 0)
            {
                handgunAmmoAmount--;
                UpdateText();
                var clone = Instantiate(projectile, gameObject.transform.position, gameObject.transform.rotation);
                //Destroy after 2 seconds to stop clutter.
                Destroy(clone, 5.0f);
            }
            // else if (machinegunAmmoAmount > 0 && (gameObject.tag == "Machinegun"))
            // {
            //     machinegunAmmoAmount--;
            //     UpdateText();
            //     var clone = Instantiate(projectile, gameObject.transform.position, gameObject.transform.rotation);
            //     //Destroy after 2 seconds to stop clutter.
            //     Destroy(clone, 5.0f);
            // }
            // else if (shotgunAmmoAmount > 0 && (gameObject.tag == "Shotgun"))
            // {
            //     shotgunAmmoAmount--;
            //     UpdateText();
            //     var clone = Instantiate(projectile, gameObject.transform.position, gameObject.transform.rotation);
            //     //Destroy after 2 seconds to stop clutter.
            //     Destroy(clone, 5.0f);
            // }
            else
            {
                //MeleeAttackMode
                if (!punchActive)
                {
                    punchActive = true;
                    StartCoroutine(MeleeAttack());
                }
            }
        }
    }

    void ApplyHandgunAmmo(int ammo)
    {
        handgunAmmoAmount += ammo;
        UpdateText();
    }

    void UpdateText()
    {
        //Check the ammo panel exists.
        if (ammoPanel != null)
        {
            //Sets the text on our panel.
            ammoPanel.text = handgunAmmoAmount.ToString();
        }
    }

    void checkScript(){
        if (this.enabled)
            this.enabled=false;
        else
            this.enabled=true;
       
        print (this.enabled);
    }

    //Coroutine for MeleeAttack
    IEnumerator MeleeAttack()
    {
        punchMesh.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        punchMesh.SetActive(false);
        yield return new WaitForSeconds(meleeRepeatDelay);
        punchActive = false;
        yield return null;
    }
}
