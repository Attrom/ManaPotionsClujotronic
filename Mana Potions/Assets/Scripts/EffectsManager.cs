using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EffectsManager : MonoBehaviour
{
    public static EffectsManager Instance { get; private set; }

    public Text effectsList;

    public Light light;

    public Camera mainCamera;

    private List<Effect.Effects> currentEffects = new List<Effect.Effects>();

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

    //Use this function when the player wants to drink a potion to determine if he already tried that one, and if so he sais "Oh, not again..." and refuses to drink it
    public bool HasEffect(Effect.Effects effect)
    {
        if (currentEffects.Contains(effect))
        {
            return true;
        }
        return false;
    }

    /// <summary>
    /// When drinking add the curent potion Effect to the list of current Effects
    /// </summary>
    /// <param name="effect"></param>
    public void AddEffect(Effect.Effects effect)
    {
        currentEffects.Add(effect);
        Debug.Log(effect);
        effectsList.text += '\n';
        effectsList.text += effect;

        PerformEffect(effect);

    }

    private void PerformEffect(Effect.Effects effect)
    {
        if(effect == Effect.Effects.EternalYouthLife)
        {
            GameManager.Instance.Win();
        }

        else if(effect == Effect.Effects.Zombify)
        {
            GameManager.Instance.Lose();
        }

        else if (effect == Effect.Effects.ShortLife || effect == Effect.Effects.OldView)
        {
            GameManager.Instance.GetOld();            
        }


        else
        {
            int random = Random.Range(0, 3);
            if(random == 0)
            {
                mainCamera.fieldOfView -= 1;
            }
            if(random == 1)
            {
                light.intensity -= 0.05f;
            }

        }


    }

}
