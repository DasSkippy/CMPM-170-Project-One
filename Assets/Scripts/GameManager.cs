using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int passengersDroppedOff;
    public TextMeshProUGUI myText;

    private void Update()
    {
        myText.text = passengersDroppedOff.ToString();
    }
}
