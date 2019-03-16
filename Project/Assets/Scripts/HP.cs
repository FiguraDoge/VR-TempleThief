using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HP : MonoBehaviour
{
    #region Singleton
    public static HP instance;
    void Awake()
    {
        instance = this;
    }
    #endregion

    public int MAXHP;
    public int currentHP;
    public List<GameObject> blocks = new List<GameObject>();
    public GameObject HPBlocks;
    public GameObject GreenHPblock;

    private Color32 green = new Color32(137, 219, 53, 255);
    private Color32 red = new Color32(224, 73, 42, 255);

    //Check whether player has full HP
    public bool fullHP()
    {
        return currentHP == MAXHP;
    }

    // Modify HP by VALUE
    public void modifyHP(int value)
    {
        currentHP += value;
    }

    // Increase the MAX HP by VALUE
    public void increaseMAXHP(int value)
    {
        MAXHP += value;
        // Need to draw new HP block
        GameObject newHP = Instantiate(GreenHPblock);
        newHP.SetActive(true);
        newHP.transform.SetParent(HPBlocks.transform, false);
    }

    // Simply reload the game scene after death
    void die()
    {
        Debug.Log("You should be dead now!");
        /*
        currentHP = 3;
        MAXHP = 3;
        Destroy(this.transform.parent.parent.parent);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        */
    }

    // When the game begins player has full HP
    void Start()
    {
        for (int i = 0; i < MAXHP; i++)
        {
            // Create MAXHP Green blocks
            GameObject newHP = Instantiate(GreenHPblock);
            newHP.SetActive(true);
            newHP.transform.SetParent(HPBlocks.transform, false);
        }
    }

    void Update()
    {
        if (currentHP == 0)
            die();

        for (int i = 1; i < MAXHP + 1; i++)
        {
            // Get image
            Image icon = HPBlocks.transform.GetChild(i).GetChild(0).GetComponent<Image>();
            if (i <= currentHP)
                icon.color = green;
            else
                icon.color = red;
        }
    }
}
