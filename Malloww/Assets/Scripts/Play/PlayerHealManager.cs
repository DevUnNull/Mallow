using UnityEngine;

public class PlayerHealManager : MonoBehaviour
{
    private int heal=3;

    public static PlayerHealManager instance;
    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }
    private void Update()
    {
        if (heal <= 0) {
            UiPlayManager.instance.ShowGameOverUI();
            Time.timeScale = 0f;
        }
    }

    public void hit(int dashpoint) { 
        heal -= dashpoint;
    }

    public int getHeal() { 
        return heal;
    }
}
