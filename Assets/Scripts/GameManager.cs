using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public InventoryPanel inventoryPanel;
    public bool cursorOn = false;

    public List<ItemData> allItem = new List<ItemData>();
    public float timeCounter = 30f;
    public ItemData targetItem;
    public int targetAmount = 5;
    public List<GameObject> prefabs = new List<GameObject>();

    private void Start()
    {
        CursorMethod();
        Time.timeScale = 1f;
        
        targetItem = allItem[Random.Range(1,allItem.Count)];
        targetIcon.sprite = targetItem.itemIcon;

        foreach(GameObject item in prefabs)
        {
            for(int i = 0; i < targetAmount; i++)
            {
                Instantiate(item, 
                new Vector3(Random.Range(-27f, 27f), 0.5f, Random.Range(-27f, 27f)), 
                Quaternion.identity);
            }
        }
    }

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void ActiveInventoryPanel()
    {
        inventoryPanel.gameObject.SetActive(!inventoryPanel.gameObject.activeSelf);
        inventoryPanel.OnOpen();
        cursorOn = !cursorOn;
        CursorMethod();
        Time.timeScale = Time.timeScale == 0f ? 1f : 0f;
    }

    public void CursorMethod()
    {
        Cursor.visible = cursorOn;
        Cursor.lockState = cursorOn ? CursorLockMode.None : CursorLockMode.Locked;
    }

    public TMP_Text timeCounterText;
    public Image targetIcon;
    public TMP_Text targetAmountText;

    public GameObject winCanvas;
    public GameObject loseCanvas;

    private void Update()
    {
        if(timeCounter > 0f)
        {
            timeCounter -= Time.deltaTime;
            timeCounterText.text = timeCounter.ToString();

            targetAmountText.text = InventoryManager.instance.GetItemAmount(targetItem).ToString() + "/" + targetAmount.ToString();

            if(InventoryManager.instance.GetItemAmount(targetItem) >= targetAmount)
            {
                winCanvas.SetActive(true);
                Time.timeScale = 0f;
                cursorOn = true;
                CursorMethod();
            }
        }
        else
        {
            loseCanvas.SetActive(true);
            Time.timeScale = 0f;
            cursorOn = true;
            CursorMethod();
        }
    }

    public void Replay()
    {
        SceneManager.LoadScene("gameplay");
    }

    public void Menu()
    {
        SceneManager.LoadScene("main_menu");
    }
}
