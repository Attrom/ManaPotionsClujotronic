using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public GameObject photo;

    public GameObject win;
    public GameObject lose;

    public Material young;
    public Material normal;
    public Material old;

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

    public void Win()
    {
        photo.GetComponent<Renderer>().material = young;

        win.SetActive(true);
    }

    public void Lose()
    {
        lose.SetActive(false);
    }

    public void GetOld()
    {
        photo.GetComponent<Renderer>().material = old;
    }
}
