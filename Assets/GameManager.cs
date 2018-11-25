using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    //Control variables
    int day;
    float money;
    int juegos_comprados;
    int juegos_pirateados;

    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);

        GameObject.Find("AnimacionCambioDiaCanvas").GetComponentInChildren<Text>().text = "Dia " + instance.day;
        instance.day++;
        UnityStandardAssets.Characters.FirstPerson.FirstPersonController.canInput = false;
        GameObject.Find("AnimacionCambioDiaCanvas").GetComponent<Animator>().SetTrigger("LaunchDayAnim");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
            SceneManager.LoadScene("Casa");
    }

    
}
