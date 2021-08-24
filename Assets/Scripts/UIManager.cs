using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TMP_Text _coinCountText;

    public void UpdateCoinDisplay(int value)
    {
        _coinCountText.text = "Coins: " + value;
    }
}
