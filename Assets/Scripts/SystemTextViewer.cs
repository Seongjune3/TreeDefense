using System.Diagnostics;
using TMPro;
using UnityEngine;

public enum SystemType { Money = 0 , Build}

public class SystemTextViewer : MonoBehaviour
{
    private TextMeshProUGUI textSystem;
    private TMPAlpha tmpAlpha;

    private void Awake()
    {
        textSystem = GetComponent<TextMeshProUGUI>();
        tmpAlpha = GetComponent<TMPAlpha>();
    }

    public void PrintText(SystemType type)
    {
        switch (type)
        {
            case SystemType.Money:
                textSystem.text = "<color=red>" + "Not enough money!";
                break;
            case SystemType.Build:
                textSystem.text = "<color=red>" + "Invalid build tower!";
                break;
        }

        tmpAlpha.FadeOut();
    }
}
