using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private static UIManager instance;
    public static UIManager Instance
    {
        get
        {
            if (instance == null)
            {
                Debug.LogError("UI manager is null");
            }
            return instance;
        }
    }

    public Text playerGemCount;
    public Image selectionImage;

    public void UpdateShopSelection(int yPos)
    {
        selectionImage.rectTransform.anchoredPosition = new Vector2(selectionImage.rectTransform.anchoredPosition.x, yPos);
    }

    public void OpenShop(int gemCount)
    {
        playerGemCount.text = "" + gemCount + "G";
    }

    private void Awake()
    {
        instance = this;
    }
}
