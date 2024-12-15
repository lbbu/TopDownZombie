using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIFuel : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI fuelAmountText;

    [SerializeField] private BasicCarMovements player;

    [SerializeField] private Slider fuelSlider;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateFuelUI();
    }

    private void UpdateFuelUI()
    {
        //Update Fuel text
        fuelAmountText.text = Mathf.Ceil(player.GetFuelAmount()).ToString();

        //Update Fuel Fill
        fuelSlider.value = player.GetFuelAmount() / player.GetMaxFuelAmount();
    }

}
