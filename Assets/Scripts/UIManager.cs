using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    public Text healthText;
    public PlayerController player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        healthText.text = "Health: " + player.playerHealth;
    }
}
