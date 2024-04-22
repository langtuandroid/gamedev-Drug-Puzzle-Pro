using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class canvasmanager : MonoBehaviour
{

    // Start is called before the first frame update
    [Header("For any Queries Contact Us Gmail id: dollar99games@gmail.com ")]
    [Header("For any Queries Contact Us Skyid: dollar99games@outlook.com ")]
    [SerializeField]
    public string Contact_us_on_Gmail = "dollar99games@gmail.com";
    public string Contact_us_on_Skype = "dollar99games@outlook.com";

    public static canvasmanager Instance;

    public GameObject LevelCompletePanel;
    public GameObject shopPanel;
    public GameObject thankYouPanel;
    public GameObject buttonPanel;

    public List<GameObject> avatarImage;
    public List<int> pricelist;
    public List<float> TimeList;

    public TextMeshProUGUI priceText, timeText, cashText;
    public Animator avatarPanel;
    public RectTransform cashPos;
    public ParticleControlScript coinEffect;

    public float timer;
    int count = 0;
    [HideInInspector]
    public bool startTimer;
    int randomNo;
    public int levelNo = 0;
    public int coins = 0;
    int height, width;

    //==========Start shope var declaration=========
    public Transform Skins_Parent;
    public Sprite[] ui_skins;
    public Texture[] skinTextures;
    //===========End shop variable declaration==========


    //==================shope Board========
    public Transform Board_Parent;
    public Sprite[] ui_Board;
    public Texture[] boardTextures;

    //===================end board===========


    private void Awake()
    {
        if (!Instance)
            Instance = this;
        levelNo = SceneManager.GetActiveScene().buildIndex;
        randomNo = Random.Range(0, avatarImage.Count);
        avatarImage[randomNo].SetActive(true);
        priceText.text = "" + pricelist[count];
        timer = TimeList[count];
        height = Screen.height;
        width = Screen.width;
        print(height + "" + width);

        if (height == 2340 && width == 1080)
        {
            Camera.main.orthographicSize = 6f;
        }

    }
    private void Start()
    {
        Invoke("Starttimer", 3f);
        coins = PlayerPrefs.GetInt("coin", 0);

        for (int i = 0; i < Skins_Parent.transform.childCount; i++)
        {
            Skins_Parent.GetChild(i).gameObject.name = i.ToString();
        }
        for (int i = 0; i < Board_Parent.transform.childCount; i++)
        {
            Board_Parent.GetChild(i).gameObject.name = i.ToString();
        }

        AssingSkinstoshopbuttons();
        Loadcurrentskin();
        AssingBoardtoshopbuttons();
        LoadCurrentBoardSkin();
    }
    void Starttimer()
    {
        startTimer = true;
        avatarPanel.gameObject.SetActive(true);
    }

    public void PlayParticels()
    {
        coinEffect.coinsCount = pricelist[count];
        coinEffect.PlayControlledParticles(new Vector3(Screen.width / 2, Screen.height / 2, 0), cashPos);
    }
    void Update()
    {
        if (startTimer)
            timerMethod();

        cashText.text = "" + coins;
    }
    void timerMethod()
    {

        if (timer < 0)
        {
            count++;
            timer = TimeList[count];
            startTimer = false;
            avatarPanel.gameObject.SetActive(false);
            avatarPanel.gameObject.SetActive(true);
            Invoke("Starttimer", 3f);
            for (int i = 0; i < avatarImage.Count; i++)
            {
                avatarImage[i].SetActive(false);
            }
            avatarImage.Remove(avatarImage[randomNo]);
            randomNo = Random.Range(0, avatarImage.Count);
            avatarImage[randomNo].SetActive(true);
            priceText.text = "" + pricelist[count];
        }
        else
        {
            timer -= Time.deltaTime;
        }
        int showtime = Mathf.FloorToInt(timer);

        float minutes = Mathf.FloorToInt(timer / 60);
        float seconds = Mathf.FloorToInt(timer % 60);
        timeText.text = minutes + ":" + seconds;
    }
    public void NextLevel()
    {
        PlayerPrefs.SetInt("coin", coins);
        PlayerPrefs.Save();
        if (PlayerPrefs.GetInt("unlocked") <= SceneManager.sceneCountInBuildSettings && PlayerPrefs.GetInt("unlocked") < SceneManager.GetActiveScene().buildIndex - 1)
            PlayerPrefs.SetInt("unlocked", SceneManager.GetActiveScene().buildIndex - 1);
        SceneManager.LoadScene("LevelSelection");
    }

    public void onlevelselectionButtonpress()
    {
        SceneManager.LoadScene("LevelSelection");
    }
    
    public void AssingSkinstoshopbuttons()
    {
        for (int i = 0; i < Skins_Parent.transform.childCount; i++)
        {
            Skins_Parent.transform.GetChild(i).GetChild(1).GetComponent<Image>().sprite = ui_skins[i];
            if (PlayerPrefs.GetInt("Foruse" + i) == i)
            {
                Skins_Parent.transform.GetChild(i).GetChild(2).gameObject.SetActive(false);
            }

        }
    }
    public void onbuybuttonpress()
    {
        int cost = 320;

        if (cost < coins)
        {
            int randomskin = Random.Range(0, skinTextures.Length);

            if (PlayerPrefs.GetInt("Foruse" + randomskin) != randomskin)
            {
                assignselectedskin(randomskin);
                coins = coins - cost;
                PlayerPrefs.SetInt("Coinscount", coins);
                cashText.text = coins.ToString();
                AssingSkinstoshopbuttons();
            }
            else
            {
                onbuybuttonpress();
            }

        }

    }

    public void onskinButtonpress()
    {
        int selectedskin = int.Parse(EventSystem.current.currentSelectedGameObject.transform.gameObject.name);
        Debug.Log(selectedskin);
        assignselectedskin(selectedskin);
        onBackbuttonpress();
    }
    public void assignselectedskin(int selectedskin)
    {
        for (int i = 0; i < GameManager.instance.allBricks.Count; i++)
        {
            GameManager.instance.allBricks[i].gameObject.GetComponent<Renderer>().material.SetTexture("_BaseMap", skinTextures[selectedskin]);
            GameManager.instance.allBricks[i].gameObject.GetComponent<Renderer>().material.SetTexture("_EmissionMap", skinTextures[selectedskin]);
        }
        PlayerPrefs.SetInt("currentskin", selectedskin);
        PlayerPrefs.SetInt("Foruse" + selectedskin, selectedskin);
    }
    public void Loadcurrentskin()
    {
        int current = PlayerPrefs.GetInt("currentskin");

        for (int i = 0; i < GameManager.instance.allBricks.Count; i++)
        {
            GameManager.instance.allBricks[i].gameObject.GetComponent<Renderer>().material.SetTexture("_BaseMap", skinTextures[current]);
            GameManager.instance.allBricks[i].gameObject.GetComponent<Renderer>().material.SetTexture("_EmissionMap", skinTextures[current]);
            // cubes[i].gameObject.GetComponent<MeshRenderer>().material = skinMaterials[current];
           
        }
        Debug.Log("current " + GameManager.instance.allBricks.Count);
    }
    public void onBackbuttonpress()
    {
        shopPanel.SetActive(false);
    }
    public void onshopbuttonpress()
    {
        Skins_Parent.parent.gameObject.SetActive(true);
    }


    //=======================================================Board Skin Shop Begin==================
    public void AssingBoardtoshopbuttons()
    {
        for (int i = 0; i < Board_Parent.transform.childCount; i++)
        {
            Board_Parent.transform.GetChild(i).GetChild(1).GetComponent<Image>().sprite = ui_Board[i];
            if (PlayerPrefs.GetInt("ForuseBoard" + i) == i)
            {
                Board_Parent.transform.GetChild(i).GetChild(2).gameObject.SetActive(false);
                Debug.Log(PlayerPrefs.GetInt("ForuseBoard" + i));
            }

        }
    }
    public void onBoardBuyButtonPress()
    {
        int cost = 320;

        if (cost < coins)
        {
            int randomskin = Random.Range(0, boardTextures.Length);

            if (PlayerPrefs.GetInt("ForuseBoard" + randomskin) != randomskin)
            {
                AssignSelectedBoard(randomskin);
                coins = coins - cost;
                PlayerPrefs.SetInt("CoinscountBoard", coins);
                cashText.text = coins.ToString();
                AssingBoardtoshopbuttons();
            }
            else
            {
                onBoardBuyButtonPress();
            }

        }
    }
    
    public void onBoardButtonPress()
    {
        int selectedskin = int.Parse(EventSystem.current.currentSelectedGameObject.transform.gameObject.name);
        Debug.Log(selectedskin);
        AssignSelectedBoard(selectedskin);
        onBackbuttonpress();
    }
    
    public void AssignSelectedBoard(int selectedboard)
    {
        GameManager.instance.ground.material.SetTexture("_BaseMap", boardTextures[selectedboard]);
        GameManager.instance.ground.material.SetTexture("_EmissionMap", boardTextures[selectedboard]);

        PlayerPrefs.SetInt("currentskinBoard", selectedboard);
        PlayerPrefs.SetInt("ForuseBoard" + selectedboard, selectedboard);
        Debug.Log(selectedboard);
    }
    
    public void LoadCurrentBoardSkin()
    {
        int current = PlayerPrefs.GetInt("currentskinBoard");
        GameManager.instance.ground.material.SetTexture("_BaseMap", boardTextures[current]);
        GameManager.instance.ground.material.SetTexture("_EmissionMap", boardTextures[current]);
    }

}
