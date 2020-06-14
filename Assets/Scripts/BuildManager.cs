using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BuildManager : MonoBehaviour
{
    public TurretData laserTurretData;
    public TurretData missileTurretData;
    public TurretData standardTurretData;

    //表示当前选择的炮台（要建造的炮台）
    public  TurretData selectedTurretData;

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
                    GameObject mapCube = hit.collider.gameObject; //得到点击的mapcube
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
}
