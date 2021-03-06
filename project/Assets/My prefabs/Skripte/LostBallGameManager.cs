using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class LostBallGameManager : MonoBehaviour
{
    // make game manager public static so can access this from other scripts

    public static LostBallGameManager gm;

    [Tooltip("If not set, the player will default to the gameObject tagged as Player.")]

    // Public variables which are accessible from Unity GUI

    public GameObject player;
    public enum gameStates { Playing, GameOver};
    public gameStates gameState = gameStates.Playing;
    public GameObject mainCanvas;
    public Text mainTimerDisplay;
    public GameObject gameOverCanvas;
    public Text gameOverScreenText;

    public GameObject checkpointButtonGameObject;
    private Button checkpointButton;
    public GameObject playAgainButtonGameObject;
    public string playAgainLevelToLoad;
    public GameObject restartLevelButtonGameObject;

    private float pauseTime = 0;//dopdano
    private float difference=0;//dodano
    private float startTime;
    private float currentTime;
    private int timeToDisplay;
    private Health playerHealth;
    private Button playAgainButton;
    private Button restartButton;

    // ovo je dodnao
    public Vector3 checkPointPosition = new Vector3(0, 0, 0);
    public GameObject rollerBall;

    //dodano
    public GameObject levelInput;
    public GameObject seedInput;
    public GameObject startLevelButtonObject;
    private Button startButton;
    public GameObject startCanvas;

    private void Awake()
    {
        if (player == null)
        {
            player = GameObject.FindWithTag("Player");
        }
        GameObject.FindWithTag("CameraPivot").GetComponent<RollerBallFollow>().enabled = false;
        GameObject.FindWithTag("CameraPivot").transform.GetChild(0).GetComponent<NewCamera>().enabled = false;
        player.GetComponent<Rigidbody>().useGravity = false;
        playerHealth = player.GetComponent<Health>();

    }
    // setup the game
    void Start()
    {
        Cursor.visible = true;


        //subscribe to the onClick event of the button and call the function to load new level
        playAgainButton = playAgainButtonGameObject.GetComponent<Button>();
        playAgainButton.onClick.AddListener(newLevelToLoad);

        //dodano
        checkpointButton = checkpointButtonGameObject.GetComponent<Button>();
        checkpointButton.onClick.AddListener(continueLevel);

        //dodano
        restartButton = restartLevelButtonGameObject.GetComponent<Button>();
        restartButton.onClick.AddListener(restartLevel);

        //dodano
        startButton = startLevelButtonObject.GetComponent<Button>();
        startButton.onClick.AddListener(startGame);
        if (gm == null)
            gm = gameObject.GetComponent<LostBallGameManager>();


        // set the start time which will be used for calculation of finished time
        //startTime = Time.time;

        // inactivate the gameOverScoreOutline gameObject, if it is set
        if (gameOverCanvas)
            gameOverCanvas.SetActive(false);

        // inactivate the playAgainButtons gameObject, if it is set
        if (playAgainButton)
        {
            playAgainButtonGameObject.SetActive(false);
            checkpointButtonGameObject.SetActive(false);
            restartLevelButtonGameObject.SetActive(false);
        }
        if (checkpointButton)
        {
            playAgainButtonGameObject.SetActive(false);
            checkpointButtonGameObject.SetActive(false);
            restartLevelButtonGameObject.SetActive(false);
        }
    }

    // this is the main game event loop
    void Update()
    {
        //calculating the time from the start
        currentTime = Time.time - startTime - pauseTime;
        // displaying only the int value
        timeToDisplay = Mathf.RoundToInt(currentTime);
        mainTimerDisplay.text = timeToDisplay.ToString();
        switch (gameState)
        {
            case gameStates.Playing:

                if (playerHealth.isAlive == false)
                {
                    difference = Time.time;
                    Cursor.visible = true;
                    // update gameState
                    gameState = gameStates.GameOver;

                    //camera stop
                    GameObject.FindWithTag("CameraPivot").GetComponent<RollerBallFollow>().enabled=false;
                    GameObject.FindWithTag("CameraPivot").transform.GetChild(0).GetComponent<NewCamera>().enabled = false;

                    // set the end game score
                    gameOverScreenText.text = currentTime.ToString();

                    // switch which GUI is showing		
                    mainCanvas.SetActive(false);
                    gameOverCanvas.SetActive(true);
                    playAgainButtonGameObject.SetActive(true);
                    checkpointButtonGameObject.SetActive(true);
                    restartLevelButtonGameObject.SetActive(true);
                }
                break;

            case gameStates.GameOver:
                break;
        }

    }

    public void newLevelToLoad()
    {

        Application.LoadLevel(playAgainLevelToLoad);
        gameState = gameStates.Playing;
    }

    public void continueLevel()
    {
        if (player == null)
        {
            player = Instantiate(rollerBall, checkPointPosition, Quaternion.Euler(Vector3.up * 0));
            playerHealth = player.GetComponent<Health>();
            mainCanvas.SetActive(true);
            gameOverCanvas.SetActive(false);
            playAgainButtonGameObject.SetActive(false);
            checkpointButtonGameObject.SetActive(false);
            restartLevelButtonGameObject.SetActive(false);
            gameState = gameStates.Playing;
            pauseTime += Time.time - difference;
            Cursor.visible = false;
            GameObject.FindWithTag("CameraPivot").GetComponent<RollerBallFollow>().enabled = true;
            GameObject.FindWithTag("CameraPivot").transform.GetChild(0).GetComponent<NewCamera>().enabled = true;
        }
    }

    public void restartLevel()
    {
        if (player == null)
        {
            player = Instantiate(rollerBall, new Vector3(0,0,0), Quaternion.Euler(Vector3.up * 0));
            playerHealth = player.GetComponent<Health>();
            mainCanvas.SetActive(true);
            gameOverCanvas.SetActive(false);
            playAgainButtonGameObject.SetActive(false);
            checkpointButtonGameObject.SetActive(false);
            restartLevelButtonGameObject.SetActive(false);
            gameState = gameStates.Playing;
            pauseTime = Time.time - startTime;
            Cursor.visible = false;
            GameObject.FindWithTag("CameraPivot").GetComponent<RollerBallFollow>().enabled = true;
            GameObject.FindWithTag("CameraPivot").transform.GetChild(0).GetComponent<NewCamera>().enabled = true;
        }
    }

    public void startGame()
    {
        startCanvas.SetActive(false);
        mainCanvas.SetActive(true);
        Cursor.visible = false;
        GameObject mapGenerator = GameObject.FindGameObjectWithTag("MapGenerator");
        string seedString = seedInput.GetComponent<InputField>().text;
        if (seedString.Length == 0)
        {
            seedString = "1";
        }
        mapGenerator.GetComponent<MapGenerator>().seedNumber = Convert.ToInt32(seedString);
        string levelLengthString = levelInput.GetComponent<InputField>().text;
        if (levelLengthString.Length == 0)
        {
            levelLengthString = "1";
        }
        mapGenerator.GetComponent<MapGenerator>().levelLength = Convert.ToInt32(levelLengthString);

        GameObject.FindWithTag("CameraPivot").GetComponent<RollerBallFollow>().enabled = true;
        GameObject.FindWithTag("CameraPivot").transform.GetChild(0).GetComponent<NewCamera>().enabled = true;
        startTime = Time.time;
        gameState = gameStates.Playing;
        mapGenerator.GetComponent<MapGenerator>().startGame();
        player.transform.position = new Vector3(0, 1, 0);
        player.GetComponent<Rigidbody>().useGravity = true;
    }
}
