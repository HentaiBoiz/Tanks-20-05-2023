using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Game_Manager : MonoBehaviour
{
    public static Game_Manager Instance;

    PhotonView _photonView;
    public int Player;
    public float m_StartDelay = 3f;
    public float m_EndDelay = 3f;

    [Header("UI")]
    public Transform winMessage;
    public Transform loseMessage;
    public TextMeshProUGUI waitingMessage;
    public Button btnRestart;

    private int m_RoundNumber;
    private WaitForSeconds m_StartWait;
    private WaitForSeconds m_EndWait;

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        _photonView = GetComponent<PhotonView>();

        m_StartWait = new WaitForSeconds(m_StartDelay);
        m_EndWait = new WaitForSeconds(m_EndDelay);

        winMessage.gameObject.SetActive(false);
        loseMessage.gameObject.SetActive(false);
        waitingMessage.gameObject.SetActive(false);
        btnRestart.gameObject.SetActive(false);

        StartCoroutine(GameLoop());
    }

    // Update is called once per frame
    void Update()
    {

    }
    private IEnumerator GameLoop()
    {
        yield return StartCoroutine(RoundPlaying());
        yield return StartCoroutine(RoundEnding());

        /*        if (m_GameWinner != null)
                {
                    SceneManager.LoadScene(0);
                }
                else
                {
                    StartCoroutine(GameLoop());
                }
        */
    }

    private IEnumerator RoundPlaying()
    {
        yield return null;
    }


    private IEnumerator RoundEnding()
    {
        yield return m_EndWait;
    }
}
