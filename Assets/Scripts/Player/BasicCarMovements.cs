using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicCarMovements : MonoBehaviour
{

    [SerializeField] private Rigidbody carRB;
    [SerializeField] private GameInput gameInput;

    private float verticalValue;
    private float horizontalValue;


    [SerializeField] private float rotateSpeed;
    [SerializeField] private float defaulfMoveSpeed;
    [SerializeField] private float currentMoveSpeed;
    [SerializeField] private float noFuelMoveSpeed;

    [SerializeField] private float fuelAmount;
    [SerializeField] private float maxFuelAmount;

    // Start is called before the first frame update
    void Start()
    {

        currentMoveSpeed = defaulfMoveSpeed;
        fuelAmount = maxFuelAmount;

    }

    // Update is called once per frame
    void Update()
    {


        FuelSystem();

    }

    public void HandleMovements(Vector2 inputVector)
    {
        
        //inputVector = gameInput.GetCarMovementVectorNormalized();

        if(inputVector == Vector2.zero)
        {

        }
        else
        {
            carRB.velocity = transform.forward * currentMoveSpeed;
            RotateToDirectionWithSpeed(inputVector);
            //RotateToDirection(moveVector);
        }

    }

    private void RotateToDirection(Vector2 direction)
    {
        if (direction != Vector2.zero)
        {
            // Calculate the angle in radians
            float angle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
            // Set the rotation of the player
            transform.rotation = Quaternion.Euler(new Vector3(0, angle, 0));
        }
    }

    private void RotateToDirectionWithSpeed(Vector2 direction)
    {
        if (direction != Vector2.zero)
        {
            // Calculate the angle in radians
            float targetAngle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
            Quaternion targetRotation = Quaternion.Euler(new Vector3(0, targetAngle, 0));

            // Smoothly rotate towards the target direction at the specified speed
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotateSpeed * Time.deltaTime);
        }
    }

    private void FuelSystem()
    {
        if (fuelAmount > 0)
        {

            currentMoveSpeed = defaulfMoveSpeed;

            if (verticalValue != 0)
            {
                fuelAmount -= Time.deltaTime;
            }
            fuelAmount -= Time.deltaTime * 1f;
        }
        else if (fuelAmount <= 0)
        {
            currentMoveSpeed = noFuelMoveSpeed;
        }

    }

    public float GetFuelAmount()
    {
        return fuelAmount;
    }

    public float GetMaxFuelAmount()
    {
        return maxFuelAmount;
    }

}
