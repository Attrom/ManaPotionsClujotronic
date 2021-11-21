using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clicker : MonoBehaviour
{

    public GameObject potionOptions;

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
                    potionOptions.SetActive(true);
                    Potion potion = hit.transform.GetComponent("Potion") as Potion;

                    PotionsManager.Instance.SelectAPotion(potion);
                }
            }
        }
    }
}
