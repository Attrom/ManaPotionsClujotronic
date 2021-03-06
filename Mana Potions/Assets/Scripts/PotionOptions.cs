using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionOptions : MonoBehaviour
{
    public static PotionOptions Instance { get; private set; }


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

}
