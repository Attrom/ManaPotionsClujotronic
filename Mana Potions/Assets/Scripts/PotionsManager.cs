using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionsManager : MonoBehaviour
{

    public static PotionsManager Instance { get; private set; }

    public GameObject potionPrefab;
    public GameObject potionPrefab2;
    public GameObject potionPrefab3;

    private int currentNumberOfPotions = 5;
    private List<Potion> currentPotions;
    private bool[] slotsAvailabilty = new bool[25];

    public AudioSource mix;
    public AudioSource goodPotion;
    public AudioSource badPotion;
    public AudioSource burp1;
    public AudioSource burp2;

    private Potion selectedPotion;
    private GameObject selectedPotionGameObject;

    private Potion combineQueue = null;



    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            for (int i = 0; i < 5; i++)
            {
                slotsAvailabilty[i] = false;
            }
            for (int i = 5; i < 24; i++)
            {
                slotsAvailabilty[i] = true;
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SelectAPotion(Potion pot)
    {
        this.selectedPotion = pot;
    }

    public void Drink()
    {
        Invoke("GetEffects", 3);
    }

    private void GetEffects()
    {
        EffectsManager.Instance.AddEffect(this.selectedPotion.GetEffect().effectName);

        if (this.selectedPotion.GetEffect().greenComponent == Effect.Side.Good)
        {
            goodPotion.Play();
        }
        else
        {
            badPotion.Play();
        }
        Invoke("Burp", 2);

    }

    private void Burp()
    {
        int i = Random.Range(0, 2);
        if( i == 0)
        {
            burp1.Play();
        }
        else
        {
            burp2.Play();
        }
    }

    public void SetCurrentPotionObject(GameObject gameObject)
    {
        this.selectedPotionGameObject = gameObject;
    }

    public void CombinePotion()
    {

        if(combineQueue == null)
        {
            combineQueue = this.selectedPotion;
        } 
        else
        {
            int slot = GetFirstAvailableSlot();
            if ( slot >= 0)
            {
                //play mixing animation and sound
                mix.Play();


                Vector3 position = new Vector3(slot % 8 * 0.75f - 1.25f  - 0.1032f + 1.404f - 2.551f, 0.18f - 1.411f  - 0.098f + 3.009f, - (slot / 8 * 0.75f) - 2.055f + 4.552618f + 0.251f);
                int i = Random.Range(0,3);
                GameObject newPotion;
                if (i == 0)
                {
                    newPotion = Instantiate(potionPrefab, position, Quaternion.identity, gameObject.transform) as GameObject;
                }
                else if(i == 1)
                { 
                    newPotion = Instantiate(potionPrefab2, position, Quaternion.identity, gameObject.transform) as GameObject;
                }
                else
                {
                    newPotion = Instantiate(potionPrefab3, position, Quaternion.identity, gameObject.transform) as GameObject;
                }
                newPotion.GetComponent<Potion>().Init(CombineColors(combineQueue.GetColor(), this.selectedPotion.GetColor()));
                newPotion.GetComponent<Potion>().slot = slot;

                slotsAvailabilty[slot] = false;
                combineQueue = null;
            }
        }
    }

    public void ThrowPotion()
    {
        this.slotsAvailabilty[this.selectedPotion.slot] = true;
        this.selectedPotionGameObject.GetComponent<AudioSource>().Play();
        Destroy(this.selectedPotionGameObject,1.4f);
    }

    private int GetFirstAvailableSlot()
    {
        for (int i = 0; i < 25 ; i++)
        {
            if (this.slotsAvailabilty[i])
            {
                return i;
            }
        }
        return -1;
    }

    private Color CombineColors(Color first, Color second)
    {

        float r = (first.r + second.r) / 2;
        float g = (first.g + second.g) / 2;
        float b = (first.b + second.b) / 2;

        return new Color(r, g, b);
    }

}
