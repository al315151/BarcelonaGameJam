﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public enum DesktopState
{
    Work, Home, Twiter
}

public class DesktopBehaviour : MonoBehaviour
{
    [Header("Containers Public References")]
    //References to put inside the right elements.
    public GameObject minimizedBar_GO;

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

    [Header("Games Related Variables")]
    public GameObject codeProgram_Reference_GO;
    public GameObject snakeProgram_Reference_GO;
    public GameObject RPSProgram_Reference_GO;
    public GameObject SpaceBattleProgram_Reference_GO;
    public GameObject MazeProgram_Reference_GO;
    public GameObject PongProgram_Reference_GO;

    public GameObject snakeProgramIcon_GO;
    public GameObject RPSProgramIcon_GO;
    public GameObject SpaceBattleProgramIcon_GO;
    public GameObject MazeIcon_GO;
    public GameObject PongIcon_Program_GO;

     bool snakeUnlocked;
     bool RPSUnlocked;
     bool spaceBattleUnlocked;
     bool MazeUnlocked;
     bool PongUnlocked;

    public GameObject snakeShop_Reference_GO;
    public GameObject RPSShop_Reference_GO;
    public GameObject SpaceBattleShop_Reference_GO;
    public GameObject MazeShop_Reference_GO;
    public GameObject PongShop_Reference_GO;

    public GameObject snakePirate_Reference_GO;
    public GameObject RPSPirate_Reference_GO;
    public GameObject SpaceBattlePirate_Reference_GO;
    public GameObject MazePirate_Reference_GO;
    public GameObject PongPirate_Reference_GO;


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
    public DesktopState currentState;

    [Header("Money Related Variables")]
    public Text moneyReference_Text;
    public GameObject moneyCanvas_GO;

    //ESTA VARIABLE VA DE 0 A 1.
    public float GameState;
    bool PiracyActivated;

    [Header("Desktop Management Variables")]
    public TwitProperties[] tweetPole_GO;

    [Header("Money Related Variables")]
    public Text FranEatButtonText;


    // Start is called before the first frame update
    void Start()
    {
        UnityStandardAssets.Characters.FirstPerson.FirstPersonController.canInput = true;
        SetDestopIconsAndPrograms();
        GameState = 0;
        DesktopGamesSetter();
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    // Update is called once per frame
    private void Update()
    {
        SetMoneyText();
    }


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
        SceneManager.LoadScene("Oficina");
    }

    public void UnlockGame(GameObject other)
    {
        if (other.name.Contains("Free"))
        {
            PiracyActivated = true;
            GameManager.instance.juegos_pirateados++;
        }        
        else { GameManager.instance.juegos_comprados++; }
        if (other.name.Contains("Snake") && GameManager.instance.money > 60f)
        {
            snakeUnlocked = true;
            GameManager.instance.money -= 60f;
        }
        if (other.name.Contains("RPS") && GameManager.instance.money > 60f)
        {
            RPSUnlocked = true;
            GameManager.instance.money -= 60f;
        }
        if (other.name.Contains("Maze") && GameManager.instance.money > 60f)
        {
            MazeUnlocked = true;
            GameManager.instance.money -= 60f;
        }
        if (other.name.Contains("Pong") && GameManager.instance.money > 60f)
        {
            PongUnlocked = true;
            GameManager.instance.money -= 60f;
        }
        if (other.name.Contains("SpaceBattle") && GameManager.instance.money > 60f)
        {
            spaceBattleUnlocked = true;
            GameManager.instance.money -= 60f;
        }
        DesktopGamesSetter();
    }

   public void DesktopGamesSetter()
    {
        if (snakeUnlocked)
        {
            snakePirate_Reference_GO.SetActive(false);
            snakeShop_Reference_GO.SetActive(false);
            snakeProgramIcon_GO.SetActive(true);
        }
        else
        {
            snakePirate_Reference_GO.SetActive(true);
            snakeShop_Reference_GO.SetActive(true);
            snakeProgramIcon_GO.SetActive(false);
        }

        if (MazeUnlocked)
        {
            MazePirate_Reference_GO.SetActive(false);
            MazeShop_Reference_GO.SetActive(false);
            MazeIcon_GO.SetActive(true);
        }
        else
        {
            MazePirate_Reference_GO.SetActive(true);
            MazeShop_Reference_GO.SetActive(true);
            MazeIcon_GO.SetActive(false);
        }

        if (RPSUnlocked)
        {
            RPSPirate_Reference_GO.SetActive(false);
            RPSShop_Reference_GO.SetActive(false);
            RPSProgramIcon_GO.SetActive(true);
        }
        else
        {
            RPSPirate_Reference_GO.SetActive(true);
            RPSShop_Reference_GO.SetActive(true);
            RPSProgramIcon_GO.SetActive(false);
        }

        if (spaceBattleUnlocked)
        {
            SpaceBattlePirate_Reference_GO.SetActive(false);
            SpaceBattleShop_Reference_GO.SetActive(false);
            SpaceBattleProgramIcon_GO.SetActive(true);
        }
        else
        {
            SpaceBattlePirate_Reference_GO.SetActive(true);
            SpaceBattleShop_Reference_GO.SetActive(true);
            SpaceBattleProgramIcon_GO.SetActive(false);
        }

        if (PongUnlocked)
        {
            PongPirate_Reference_GO.SetActive(false);
            PongShop_Reference_GO.SetActive(false);
            PongIcon_Program_GO.SetActive(true);
        }
        else
        {
            PongPirate_Reference_GO.SetActive(true);
            PongShop_Reference_GO.SetActive(true);
            PongIcon_Program_GO.SetActive(false);
        }

    }

    public void SetFoodWindowText(float numberOfDays)
    {
        FranEatButtonText.text = " Comprar comida (" + 30 + " euros)";
    }

    public void PurchaseFood()
    {
        GameManager.instance.money -= 30f;
    }

    public void PlayGame(GameObject other)
    {
        if (other.name.Contains("Snake"))
        {
            snakeProgram_Reference_GO.SetActive(true);
            RemoveAllMinimizedApps();
            snakeProgram_Reference_GO.GetComponent<DesktopWindowBehaviour>().ForceMaximizedWindow();
            SceneManager.LoadScene("SnakeMiniGame");
        }
        if (other.name.Contains("RPS"))
        {
            RPSProgram_Reference_GO.SetActive(true);
            RemoveAllMinimizedApps();
            RPSProgram_Reference_GO.GetComponent<DesktopWindowBehaviour>().ForceMaximizedWindow();
            SceneManager.LoadScene("Minigame1");
        }
        if (other.name.Contains("Maze"))
        {
            MazeProgram_Reference_GO.SetActive(true);
            RemoveAllMinimizedApps();
            MazeProgram_Reference_GO.GetComponent<DesktopWindowBehaviour>().ForceMaximizedWindow();
            SceneManager.LoadScene("Minigame3");
        }
        if (other.name.Contains("Pong"))
        {
            PongProgram_Reference_GO.SetActive(true);
            RemoveAllMinimizedApps();
            PongProgram_Reference_GO.GetComponent<DesktopWindowBehaviour>().ForceMaximizedWindow();
            SceneManager.LoadScene("Pong");
        }
        if (other.name.Contains("SpaceBattle"))
        {
            SpaceBattleProgram_Reference_GO.SetActive(true);
            RemoveAllMinimizedApps();
            SpaceBattleProgram_Reference_GO.GetComponent<DesktopWindowBehaviour>().ForceMaximizedWindow();
            SceneManager.LoadScene("Minigame2");
        }
    }


    public void SetDesktopState(DesktopState newState)
    {
        currentState = newState;
        SetDestopIconsAndPrograms();
    }

    public void SetMoneyText()
    {
        moneyReference_Text.text = "" + GameManager.instance.money;
    }


}
