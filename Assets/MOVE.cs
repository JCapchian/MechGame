using UnityEngine;

public class MOVE : MonoBehaviour
{
    InputManager inputManager;

    Vector2 currentMouseAxi;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //inputManager.onMouseMovement += GetMouseAxis;
    }

    public void GetMouseAxis(Vector2 _currentMouseAxi)
    {
        //Debug.Log(_currentMouseAxi);
        currentMouseAxi = Camera.main.ScreenToWorldPoint(_currentMouseAxi);
        //currentMouseAxi = _currentMouseAxi;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(currentMouseAxi.x, 0, currentMouseAxi.y);
    }
}
