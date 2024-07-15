using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItem : MonoBehaviour
{
    public bool isMove;
    public RectTransform canvasRectTransform;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    public void StartMove() 
    {
        isMove = true;
    }
    public void StopMove() 
    {
        isMove = false;
    }

    public void Move()
    {
        if(isMove)
        {
            Vector2 screenPoint = Input.mousePosition;

            // Biến để lưu vị trí của chuột trong không gian của Canvas
            Vector2 localPoint;

            // Chuyển đổi từ vị trí màn hình sang vị trí trong RectTransform của Canvas
            RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasRectTransform, screenPoint, null, out localPoint);

            gameObject.transform.position = localPoint;
        }
    }

}
