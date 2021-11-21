using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drink : MonoBehaviour
{

    public AudioSource drink;
    
    public void DrinkSound()
    {
        drink.Play();
    }
}
