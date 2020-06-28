using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BuildManager : MonoBehaviour
{
    public TurretData laserTurretData;
    public TurretData missileTurretData;
    public TurretData standardTurretData;

    //表示当前选择的炮台（要建造的炮台）
    private  TurretData selectedTurretData;

    public Text moneyText;

    public int money = 1000;

    public Animator animatorMoney;

    public GameObject upgradeCanvas;

    public Button buttonUpgrade;

    void ChangeMoney(int change = 0)
    {
        money += change;
        moneyText.text = "¥" + money;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            if (EventSystem.current.IsPointerOverGameObject() == false)
            {
                //开发炮台的建造
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                bool isCollider = Physics.Raycast(ray, out hit, 1000, LayerMask. GetMask("MapCube"));
                if (isCollider) 
                {
                    MapCube mapCube = hit.collider.GetComponent<MapCube>();
                    if (selectedTurretData != null && mapCube.turretGo == null)
                    {
                        //可以创建
                        if (money > selectedTurretData.cost)
                        {
                            ChangeMoney(-selectedTurretData.cost);
                            mapCube.BuildTurret(selectedTurretData.turretPrefab);
                        }
                        else
                        {
                            //TODO 提示钱不够
                            animatorMoney.SetTrigger("flicker");
                        }
                    }
                    else if(mapCube.turretGo != null)
                    {
                        //TODO  升级处理
                    }
                }
            }
        }
    }

    public void OnLaserSelected(bool isOn) 
    {
        if (isOn) 
        {
            selectedTurretData = laserTurretData;
        }
    }

    public void OnMissileSelected(bool isOn) 
    {
        if (isOn)
        {
            selectedTurretData = missileTurretData;
        }
    }

    public void OnStandardSelected(bool isOn) 
    {
        if (isOn)
        {
            selectedTurretData = standardTurretData;
        }
    }

    void ShowUpgradeUI(Vector3 pos, bool isDisableUpgrade =false)
    {
        upgradeCanvas.SetActive(true);
        upgradeCanvas.transform.position = pos;
        buttonUpgrade.interactable = !isDisableUpgrade;
    }

    void HideUpgradeUI()
    {
        upgradeCanvas.SetActive(false);
    }

    public void OnUpgradeButtonDown()
    {
        //TODO
    }

    public void OnDestroyButtonDown()
    {
       //TODO
    }
}
