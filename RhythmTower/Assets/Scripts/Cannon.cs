using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Cannon : MonoBehaviour
{

    public enum LookState
    {
        Up = 0, Right = 1, Down = 2, Left = 3, Count = 4,
    }

    public LookState Look { get { return _look; } }
    public LookState _look = LookState.Right;


    public GameObject bulletPrefab;
    public GameObject Barrel;
    public GameObject PlayUI;
    // Update is called once per frame
    void Update()
    {
      
        Vector2 direction = GetDirection(_look);
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Lerp(this.transform.rotation, Quaternion.Euler(Vector3.forward * angle), Time.deltaTime * 10);


        TempTurnCode();

    }

    void TempTurnCode()
    {
        float y = Input.GetAxisRaw("Vertical");
        float x = Input.GetAxisRaw("Horizontal");
        if (Input.GetKeyDown(KeyCode.A))
        {
            TurnLeft();
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            TurnRight();
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    Vector2 GetDirection(LookState ls)
    {
        Vector2 temp = Vector2.zero;
        switch (ls)
        {
            case LookState.Up:
                temp = Vector2.up;
                break;
            case LookState.Right:
                temp = Vector2.right;
                break;
            case LookState.Down:
                temp = Vector2.down;
                break;
            case LookState.Left:
                temp = Vector2.left;
                break;
        }
        return temp;
    }

    void Shoot()
    {
        GameObject obj = Instantiate(bulletPrefab, PlayUI.transform);
        obj.transform.position = Barrel.transform.position;
        obj.GetComponent<Bullet>().SetDirection(GetDirection(_look));
    }

    public void TurnLeft()
    {
        int num = (int)this._look - 1;
        _look = (num < 0) ? (LookState)((int)LookState.Count - 1) : (LookState)num;
    }
    public void TurnRight()
    {
        int num = (int)this._look + 1;
        _look = (num >= (int)(LookState.Count)) ? (LookState)0 : (LookState)num;

    }
}
