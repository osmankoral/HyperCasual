using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class ATMRushStuckMoneyManager : MonoBehaviour
{
    [SerializeField] Camera mainCamera;
    private Rigidbody rb;
    private Vector3 offset = new Vector3(0, -3, 3);
    private Vector3 mouseVector;
    private float moneyX;
    private bool isPress;
    public static List<GameObject> moneys = new();

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        moneys.Add(gameObject);
    }
    void FixedUpdate()
    {
        if(Input.GetMouseButtonDown(0))
        {
            mouseVector = Input.mousePosition;
            isPress = !isPress;
        }
        if (Input.GetMouseButtonUp(0)) isPress = !isPress;

        MoneyMovement();
        DragMovement();
    }

    private void MoneyMovement()
    {
        rb.position = new Vector3(moneyX, transform.position.y, transform.position.z +Time.deltaTime);
        CameraMovement();
        MoneysMovement();
    }

    private void CameraMovement()
    {
        mainCamera.transform.position = Vector3.Slerp(mainCamera.transform.position, (transform.position - offset),0.5f);
    }

    private void DragMovement()
    {
        if(isPress)
        {
            Vector3 tempMousePos = Input.mousePosition;
            float tempVectorX = tempMousePos.x - mouseVector.x;
            moneyX = tempVectorX / 200;
        }
    }
    private void MoneysMovement()
    {
        if(moneys.Count > 1)
        {
            for(int i=1; i<moneys.Count;i++)
            {
                Vector3 previousMoney = moneys[i - 1].transform.position;
                previousMoney.z += 0.3f; 
                moneys[i].transform.position = new Vector3(moneys[i].transform.position.x, previousMoney.y, previousMoney.z);
                //moneys[i].transform.position = Vector3.Slerp(moneys[i].transform.position, previousMoney, 1f);
                moneys[i].transform.DOMoveX(previousMoney.x, 0.4f);
            }
        }
    }

}
