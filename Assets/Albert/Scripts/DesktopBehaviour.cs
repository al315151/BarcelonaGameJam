using System.Collections;
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
    public GameObject twitterFeed_GO;
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
    public Sprite WorkBackground;
    public Sprite HomeBackground;

    [Header("PC's Canvas References")]
    public GameObject workPC_GO;
    public GameObject homePC_GO;

    [Header("Desktop Management Variables")]
    public Image backgroundImage;
    public GameObject bottomBar;
    DesktopState currentState;
   
    // Start is called before the first frame update
    void Start()
    {
        currentState = DesktopState.Twiter;
        SetDestopIconsAndPrograms();
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    public void SetDestopIconsAndPrograms()
    {
        if (currentState == DesktopState.Home)
        {
            backgroundImage.sprite = HomeBackground;
            SpawnHomeIcons();
            bottomBar.SetActive(true);
            backgroundImage.sprite = HomeBackground;
        }
        else if (currentState == DesktopState.Work)
        {
            backgroundImage.sprite = WorkBackground;
            StartCodeProgram();
            bottomBar.SetActive(false);
        }
        else if (currentState == DesktopState.Twiter)
        {
            StartTwitterProgram();
            bottomBar.SetActive(false);
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
    }

    void StartCodeProgram()
    {
        for (int i = 0; i < DesktopIcons_GO.Length; i++)
        {    DesktopIcons_GO[i].SetActive(false);      }
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



}
