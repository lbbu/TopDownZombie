using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInput : MonoBehaviour
{

    private CarInputAction carInputActions;

    private void Awake()
    {
        
        carInputActions = new CarInputAction();
        carInputActions.Player.Enable();

    }

    

    public Vector2 GetCarMovementVectorNormalized()
    {

        Vector2 carInput = carInputActions.Player.Move.ReadValue<Vector2>();
        carInput = carInput.normalized;

        return carInput;

    }

    private void Update()
    {
        //Debug.Log(GetCarMovementVectorNormalized());
    }


}
