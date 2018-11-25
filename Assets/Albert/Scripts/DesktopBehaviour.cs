﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum DesktopState
{
    Work, Home, Twiter
}

public class DesktopBehaviour : MonoBehaviour
{
    [Header("Containers Public References")]
    //References to put inside the right elements.
    public GameObject minimizedBar_GO;
    public GameObject gameFolder_GO;

    [Header("Container Elements Public References")]
    public GameObject[] minimizedElements_GO;
    public GameObject[] DesktopIcons_GO;

    [Header("Programs Public References")]
    //Reference to the programs.
    public DesktopWindowBehaviour twitterProgram_GO;
    public DesktopWindowBehaviour codeProgram_GO;
    public DesktopWindowBehaviour gameFolderProgram_GO;
    public DesktopWindowBehaviour vaperisProgram_GO;
    public DesktopWindowBehaviour vPotatoProgram_GO;
    public DesktopWindowBehaviour FranEatProgram_GO;

    [Header("Images Public References")]
    //Image public references
    public Sprite DownloadPageSprite;
    public Sprite GameFolderSprite;
    public Sprite ShopSprite;
    public Sprite twitterIconSprite;
    public Sprite[] twitterUserIconsSprites;
    public Sprite twitterBossIconSprite;
    public Sprite WorkBackground;
    public Sprite HomeBackground;

    [Header("PC's Canvas References")]
    public RectTransform workPC_GO;
    public GameObject homePC_GO;

    [Header("Desktop Management Variables")]
    public Image backgroundImage;
    public GameObject bottomBar;
    DesktopState currentState;

    [Header("Money Related Variables")]
    public Text moneyReference_Text;
    public GameObject moneyCanvas_GO;

    //ESTA VARIABLE VA DE 0 A 1.
    public float GameState;

    [Header("Desktop Management Variables")]
    public TwitProperties[] tweetPole_GO;
    

    // Start is called before the first frame update
    void Start()
    {
        currentState = DesktopState.Work;
        SetDestopIconsAndPrograms();
        GameState = 0;
    }

    // Update is called once per frame
 
    public void SetDestopIconsAndPrograms()
    {
        if (currentState == DesktopState.Home)
        {
            backgroundImage.sprite = HomeBackground;
            SpawnHomeIcons();
            bottomBar.SetActive(true);
            moneyCanvas_GO.SetActive(true);
        }
        else if (currentState == DesktopState.Work)
        {
            backgroundImage.sprite = WorkBackground;
            StartCodeProgram();
            bottomBar.SetActive(true);
            RemoveAllMinimizedApps();
            moneyCanvas_GO.SetActive(false);
        }
        else if (currentState == DesktopState.Twiter)
        {
            StartTwitterProgram();
            bottomBar.SetActive(false);
            RandomizeTweets();
            moneyCanvas_GO.SetActive(false);
        }
    }

    void SpawnHomeIcons()
    {
        for (int i = 0; i < DesktopIcons_GO.Length; i++)
        {
            DesktopIcons_GO[i].SetActive(true);
        }

        gameFolderProgram_GO.gameObject.SetActive(false);
        vaperisProgram_GO.gameObject.SetActive(false);
        vPotatoProgram_GO.gameObject.SetActive(false);
        FranEatProgram_GO.gameObject.SetActive(false);
        RemoveAllMinimizedApps();

    }

    void StartCodeProgram()
    {
        for (int i = 0; i < DesktopIcons_GO.Length; i++)
        {    DesktopIcons_GO[i].SetActive(false);      }
        RemoveAllMinimizedApps();
        codeProgram_GO.gameObject.SetActive(true);
        codeProgram_GO.ForceMaximizedWindow();
    }

    void StartTwitterProgram()
    {
        for (int i = 0; i < DesktopIcons_GO.Length; i++)
        { DesktopIcons_GO[i].SetActive(false); }
        twitterProgram_GO.gameObject.SetActive(true);
        twitterProgram_GO.ForceMaximizedWindow();
    }

    public void RemoveAllMinimizedApps()
    {
        for (int i = 0; i < minimizedElements_GO.Length; i++)
        { minimizedElements_GO[i].SetActive(false); }
    }

    public void AddToMinimizedApps(string window_name)
    {
       for (int i = 0; i < minimizedElements_GO.Length; i++)
        {
            if (minimizedElements_GO[i].name == gameFolderProgram_GO.name &&
                minimizedElements_GO[i].name == window_name)
            {
                minimizedElements_GO[i].SetActive(true);
                gameFolderProgram_GO.gameObject.SetActive(false);
                break;
            }
            else if (minimizedElements_GO[i].name == vaperisProgram_GO.name &&
                minimizedElements_GO[i].name == window_name)
            {
                minimizedElements_GO[i].SetActive(true);
                vaperisProgram_GO.gameObject.SetActive(false);
                break;
            }
            else if (minimizedElements_GO[i].name == vPotatoProgram_GO.name &&
                minimizedElements_GO[i].name == window_name)
            {
                minimizedElements_GO[i].SetActive(true);
                vPotatoProgram_GO.gameObject.SetActive(false);
                break;
            }
            else if (minimizedElements_GO[i].name == FranEatProgram_GO.name &&
                minimizedElements_GO[i].name == window_name)
            {
                minimizedElements_GO[i].SetActive(true);
                FranEatProgram_GO.gameObject.SetActive(false);
                break;
            }
        }

    }

    public void RemoveFromMinimized(GameObject other)
    {
        for (int i = 0; i < minimizedElements_GO.Length; i++)
        {
            if (minimizedElements_GO[i].name == gameFolderProgram_GO.name &&
                minimizedElements_GO[i].name ==other.name)
            {
                minimizedElements_GO[i].SetActive(false);
                gameFolderProgram_GO.gameObject.SetActive(true);
                break;
            }
            else if (minimizedElements_GO[i].name == vaperisProgram_GO.name &&
                minimizedElements_GO[i].name == other.name)
            {
                minimizedElements_GO[i].SetActive(false);
                vaperisProgram_GO.gameObject.SetActive(true);
                break;
            }
            else if (minimizedElements_GO[i].name == vPotatoProgram_GO.name &&
                minimizedElements_GO[i].name == other.name)
            {
                minimizedElements_GO[i].SetActive(false);
                vPotatoProgram_GO.gameObject.SetActive(true);
                break;
            }
            else if (minimizedElements_GO[i].name == FranEatProgram_GO.name &&
                minimizedElements_GO[i].name == other.name)
            {
                minimizedElements_GO[i].SetActive(false);
                FranEatProgram_GO.gameObject.SetActive(true);
                break;
            }
        }
    }


    public void RandomizeTweets()
    {
        int bossPosition = Random.Range(0, tweetPole_GO.Length);
        List<string> possibleBossPhrases = Database.bossPhrases[GameState];
        List<string> possiblePersonPhrases = Database.peoplePhrases[GameState];

        //Para que no se haga 
        int randomIconPosition = Random.Range(0, twitterUserIconsSprites.Length);
        int randomTextPosition = Random.Range(0, possiblePersonPhrases.Count);


        for (int i = 0; i < tweetPole_GO.Length; i++)
        {
            if (i == bossPosition)
            {
                tweetPole_GO[i].SetAuthorIconImage(twitterBossIconSprite);
                int randomPosition = Random.Range(0, possibleBossPhrases.Count);
                tweetPole_GO[i].SetAuthorNameText("Guillermo Wilson - CEO");
                tweetPole_GO[i].SetTwitText(possibleBossPhrases[randomPosition]);
            }
            else
            {
                tweetPole_GO[i].SetAuthorIconImage(twitterUserIconsSprites[randomIconPosition]);
                randomIconPosition = randomIconPosition + 1;
                if (randomIconPosition == twitterUserIconsSprites.Length) { randomIconPosition = 0; }

                tweetPole_GO[i].SetTwitText(possiblePersonPhrases[randomTextPosition]);
                randomTextPosition = randomTextPosition + 1;
                if (randomTextPosition == possiblePersonPhrases.Count) { randomTextPosition = 0; }

                tweetPole_GO[i].SetAuthorNameText(RandomNameGenerator());
            }


        }




    }

    public string RandomNameGenerator()
    {
        //https://stackoverflow.com/questions/14687658/random-name-generator-in-c-sharp

        string[] names_1 = {"Al" , "Jon", "Guil", "Alv", "Car", "Ad", "Ol", "Sab", "Br" };
        string[] names_2 = { "bert", "athan", "lem", "aro", "oline", "los", "rian", "ga", "rina", "" };

        string[] surnames_1 = { "furro", "taku", "Lop", "Gar", "Agui", "Cas", "asdf"  };
        string[] surnames_2 = { "o", "lord", "ez", "cia", "lar", "tell", "1982", "" };


        int index_1 = Random.Range(0, names_1.Length);
        int index_2 = Random.Range(0, names_2.Length);
        int index_3 = Random.Range(0, surnames_1.Length);
        int index_4 = Random.Range(0, surnames_2.Length);
               
        return names_1[index_1] + names_2[index_2] + " " + surnames_1[index_3] + surnames_2[index_4];

    }

    public void SetWindowedProperties(RectTransform other, RectTransform windowRect)
    {
        windowRect.pivot = other.pivot;
        windowRect.position = other.position;
        windowRect.rotation = other.rotation;
        windowRect.localPosition = other.localPosition;

        windowRect.rect.Set(other.rect.x, other.rect.y,
                            other.rect.width, other.rect.height);
        windowRect.anchorMax = other.anchorMax;
        windowRect.anchorMin = other.anchorMin;
        windowRect.offsetMax = other.offsetMax;
        windowRect.offsetMin = other.offsetMin;
    }

    public void CloseDesktop()
    {
        print("Cerramos el telon");
        this.gameObject.SetActive(false);
    }


}
