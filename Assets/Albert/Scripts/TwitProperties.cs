using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TwitProperties : MonoBehaviour
{
    public Image AuthorIcon_Image;
    public Text AuthorName_Text;
    public Text TwitText_Text;

    public void SetTwitText(string text)
    {
        TwitText_Text.text = text;
    }

    public void SetAuthorNameText(string text)
    {
        AuthorName_Text.text = text;
    }

    public void SetAuthorIconImage(Sprite sprite)
    {
        AuthorIcon_Image.sprite = sprite;
    }


}
