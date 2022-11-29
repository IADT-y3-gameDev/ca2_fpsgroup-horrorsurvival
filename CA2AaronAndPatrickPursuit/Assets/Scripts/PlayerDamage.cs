using UnityEngine;
using UnityEngine.UI;

public class PlayerDamage : MonoBehaviour
{
    public Text healthPanel;

    public int health = 100;
    // Start is called before the first frame update
    private void Start()
    {
       ApplyDamage(0); 
    }

    // Update is called once per frame
    void ApplyDamage(int damage)
    {
        if (healthPanel != null && health > 0) 
        {
            health = health - damage;
            Debug.Log(health);

            healthPanel.text = health.ToString();
        }
    }
}
