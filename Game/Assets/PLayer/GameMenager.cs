using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMenager : MonoBehaviour
{
    public GameObject GameOver, Live0, Live1, Live2, Live3;
    public static int Health;
    public float curHealth;

    // Start is called before the first frame update
    void Start()
    {
        Health = 4;
        curHealth = Health;
        Live0.gameObject.SetActive(true);
        Live1.gameObject.SetActive(true);
        Live2.gameObject.SetActive(true);
        Live3.gameObject.SetActive(true);
        GameOver.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        switch (Health)
        {
            case 4:
                Live0.gameObject.SetActive(true);
                Live1.gameObject.SetActive(true);
                Live2.gameObject.SetActive(true);
                Live3.gameObject.SetActive(true);
                break;
            case 3:
                Live0.gameObject.SetActive(true);
                Live1.gameObject.SetActive(true);
                Live2.gameObject.SetActive(true);
                Live3.gameObject.SetActive(false);
                break;
            case 2:
                Live0.gameObject.SetActive(true);
                Live1.gameObject.SetActive(true);
                Live2.gameObject.SetActive(false);
                Live3.gameObject.SetActive(false);
                break;
            default:
                Live0.gameObject.SetActive(false);
                Live1.gameObject.SetActive(false);
                Live2.gameObject.SetActive(false);
                Live3.gameObject.SetActive(false);
                GameOver.gameObject.SetActive(true);
                Time.timeScale = 0;
                break;

        }
    }
}
