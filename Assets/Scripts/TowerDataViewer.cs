using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using UnityEngine.Rendering.UI;

public class TowerDataViewer : MonoBehaviour
{
    [SerializeField]
    private Image imageTower;
    [SerializeField]
    private TextMeshProUGUI textDamage;
    [SerializeField]
    private TextMeshProUGUI textRate;
    [SerializeField]
    private TextMeshProUGUI textRange;
    [SerializeField]
    private TextMeshProUGUI textLevel;
    [SerializeField]
    private TextMeshProUGUI textBurn;
    [SerializeField]
    private TextMeshProUGUI textUpgradeCost;
    [SerializeField]
    private TextMeshProUGUI textSellCost;
    [SerializeField]
    private TowerAttackRange towerAttackRange;
    [SerializeField]
    private Button ButtonUpgrade;
    [SerializeField]
    private SystemTextViewer systemTextViewer;
    [SerializeField]
    private GameObject burnText;

    private TowerWeapon currentTower;

    public bool tutorialTowerUpgrade = false;


    private void Awake()
    {
        OffPanel();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            OffPanel();
        }
    }

    public void OnPanel(Transform towerWepon)
    {
        currentTower = towerWepon.GetComponent<TowerWeapon>();

        gameObject.SetActive(true);

        UpdateTowerData();

        towerAttackRange.OnAttackRange(currentTower.transform.position, currentTower.Range);
    }

    public void OffPanel()
    {
        gameObject.SetActive(false);

        towerAttackRange.OffAttackRange();
    }

    private void UpdateTowerData()
    {
        if (currentTower.WeaponType == WeaponType.Cannon || currentTower.WeaponType == WeaponType.Laser || currentTower.WeaponType == WeaponType.Fire
            || currentTower.WeaponType == WeaponType.Water || currentTower.WeaponType == WeaponType.Stone || currentTower.WeaponType == WeaponType.Wind
            || currentTower.WeaponType == WeaponType.Poison)
        {
            imageTower.rectTransform.sizeDelta = new Vector2(59, 59);
            textDamage.text = "Damage : " + currentTower.Damage + "+" + "<color=red>" + currentTower.AddedDamage.ToString("F1") + "</color>";
        }
        else
        {
            imageTower.rectTransform.sizeDelta = new Vector2(59, 59);
            if (currentTower.WeaponType == WeaponType.Slow)
            {
                textDamage.text = "Slow : " + currentTower.Slow * 100 + "%";
            }
            else if (currentTower.WeaponType == WeaponType.Buff)
            {
                textDamage.text = "Buff : " + currentTower.Buff * 100 + "%";
            }
            else if (currentTower.WeaponType == WeaponType.Money)
            {
                textDamage.text = "GetMoney : " + currentTower.Money;
            }
        }
        if (currentTower.WeaponType == WeaponType.Fire)
        {
            textBurn.text = "Burn : " + currentTower.Burn;
            burnText.SetActive(true);
        }
        else if (currentTower.WeaponType == WeaponType.Poison)
        {
            textBurn.text = "Poison : " + currentTower.Poison;
            burnText.SetActive(true);
        }
        imageTower.sprite = currentTower.TowerSprite;
        textRate.text = "Rate : " + currentTower.Rate;
        textRange.text = "Range : " + currentTower.Range;
        textLevel.text = "Level : " + currentTower.Level;
        textUpgradeCost.text = currentTower.UpgradeCost.ToString();
        textSellCost.text = currentTower.SellCost.ToString();

        ButtonUpgrade.interactable = currentTower.Level < currentTower.MaxLevel ? true : false;
    }

    public void OnClickEventTowerUpgrade()
    {
        bool isSuccess = currentTower.Upgrade();

        if (isSuccess == true)
        {
            UpdateTowerData();

            tutorialTowerUpgrade = true;

            towerAttackRange.OnAttackRange(currentTower.transform.position, currentTower.Range);
        }
        else
        {
            systemTextViewer.PrintText(SystemType.Money);
        }
    }

    public void OnClickEventTowerSell()
    {
        currentTower.Sell();

        OffPanel();
    }
}
