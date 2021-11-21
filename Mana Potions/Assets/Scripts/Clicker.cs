using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clicker : MonoBehaviour
{

    public GameObject potionOptions;

    public AudioSource openMenu;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            LayerMask mask = LayerMask.GetMask("Potions");

            if (Physics.Raycast(ray, out hit, 100.0f, mask))
            {
                if (hit.transform != null)
                {
                    Invoke("OpenMenu", 0.5f);
                    Potion potion = hit.transform.GetComponent("Potion") as Potion;
                    GameObject potionGameObject = hit.transform.gameObject;
                    
                    PotionsManager.Instance.SetCurrentPotionObject(potionGameObject);
                    PotionsManager.Instance.SelectAPotion(potion);
                }
            }
        }
    }


    private void OpenMenu()
    {
        potionOptions.SetActive(true);
        openMenu.Play();
    }
}
