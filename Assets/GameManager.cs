using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public AudioClip[] clipsAudio;
    private AudioSource source;

    //Control variables
    public int day;
    public float money;
    public int juegos_comprados;
    public int juegos_pirateados;

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
        UnityStandardAssets.Characters.FirstPerson.FirstPersonController.canInput = true;
        GameObject.Find("AnimacionCambioDiaCanvas").GetComponent<Animator>().SetTrigger("LaunchDayAnim");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlayAudio(int i)
    {
        source.clip = clipsAudio[i];
        source.loop = false;
        source.Play();
    }
    
    
}
