using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TMP_Text _coinCountText;
    [SerializeField] private TMP_Text _livesCountText;

    public void UpdateCoinDisplay(int value)
    {
        _coinCountText.text = "Coins: " + value;
    }

    public void UpdateLivesDisplay(int value)
    {
        _livesCountText.text = "Lives: " + value;
    }
}
