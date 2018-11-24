using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum DesktopState
{
    Work, Home
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

    [Header("Programs Public References")]
    //Reference to the programs.
    public DesktopWindowBehaviour twitterProgram_GO;
    public DesktopWindowBehaviour gameFolderProgram_GO;
    public DesktopWindowBehaviour codeProgram_GO;
    public DesktopWindowBehaviour shopProgram_GO;

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
    DesktopState currentState;
    RectTransform aux_rect;


    // Start is called before the first frame update
    void Start()
    {
        currentState = DesktopState.Home;

    }

    // Update is called once per frame
    void Update()
    {
      
    }

    public void SetWorldSpaceCanvas(RectTransform canvasPosition)
    {
        if (currentState == DesktopState.Home)
        {
            backgroundImage.sprite = HomeBackground;
            SpawnHomeIcons();
        }
        else
        {
            backgroundImage.sprite = WorkBackground;
            SpawnWorkIcons();
        }


    }

    void SpawnHomeIcons()
    {

    }

    void SpawnWorkIcons()
    {

    }

    public void AddToMinimizedApps(string name)
    {
       for (int i = 0; i < minimizedElements_GO.Length; i++)
        {
            if (minimizedElements_GO[i].name == gameFolderProgram_GO.name)
            {
                minimizedElements_GO[i].SetActive(true);
                gameFolderProgram_GO.gameObject.SetActive(false);
                break;
            }
            else if (minimizedElements_GO[i].name == shopProgram_GO.name)
            {
                minimizedElements_GO[i].SetActive(true);
                shopProgram_GO.gameObject.SetActive(false);
                break;
            }
            else if (minimizedElements_GO[i].name == codeProgram_GO.name)
            {
                minimizedElements_GO[i].SetActive(true);
                codeProgram_GO.gameObject.SetActive(false);
                break;
            }
            else if (minimizedElements_GO[i].name == twitterProgram_GO.name)
            {
                minimizedElements_GO[i].SetActive(true);
                twitterProgram_GO.gameObject.SetActive(false);
                break;
            }
        }

    }

    public void RemoveFromMinimized(GameObject other)
    {
        for (int i = 0; i < minimizedElements_GO.Length; i++)
        {
            if (minimizedElements_GO[i].name == gameFolderProgram_GO.name)
            {
                minimizedElements_GO[i].SetActive(false);
                gameFolderProgram_GO.gameObject.SetActive(true);
                break;
            }
            else if (minimizedElements_GO[i].name == shopProgram_GO.name)
            {
                minimizedElements_GO[i].SetActive(false);
                shopProgram_GO.gameObject.SetActive(true);
                break;
            }
            else if (minimizedElements_GO[i].name == codeProgram_GO.name)
            {
                minimizedElements_GO[i].SetActive(false);
                codeProgram_GO.gameObject.SetActive(true);
                break;
            }
            else if (minimizedElements_GO[i].name == twitterProgram_GO.name)
            {
                minimizedElements_GO[i].SetActive(false);
                twitterProgram_GO.gameObject.SetActive(true);
                break;
            }
        }
    }



}
