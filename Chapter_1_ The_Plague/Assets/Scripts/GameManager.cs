using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Image blackScreen;
    public Text UIPopup;
    public PlayerInteract playerScript;
    public AudioClip knockSound;
    public AudioClip guyDisappear;
    AudioSource audioSource;
    bool pressed;
    public AudioSource ambience;
    public Transform spawnCamZone;
    public Transform spawnManZone;
    public GameObject man;
    GameObject spawnedGuy;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        Application.targetFrameRate = 30;
        audioSource = GetComponent<AudioSource>();
        //Start game with black screen
        playerScript.disabled = true;
        blackScreen.enabled = true;
        UIPopup.text = "Press 'E' to interact with your surroundings and 'Esc' to Exit";
        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
        if(!pressed)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                StartCoroutine(KnockThenProceed());
            }
        }
        if(spawnedGuy)
        {
            if(Camera.main.transform.position == spawnCamZone.position)
            {
                Destroy(spawnedGuy);
                //Play guydisappear noise
                audioSource.PlayOneShot(guyDisappear);
                playerScript.gameObject.GetComponent<Animator>().speed = 1f;
            }
        }
    }

    IEnumerator KnockThenProceed()
    {
        pressed = true;
        audioSource.PlayOneShot(knockSound);
        yield return new WaitForSecondsRealtime(.2f);
        audioSource.PlayOneShot(knockSound);
        yield return new WaitForSecondsRealtime(.2f);
        audioSource.PlayOneShot(knockSound);
        yield return new WaitForSecondsRealtime(.3f);
        StartCoroutine(WaitThenProceed());
    }

    IEnumerator WaitThenProceed()
    {
        
        UIPopup.text = "Was that the door?";
        yield return new WaitForSecondsRealtime(2f);
        Time.timeScale = 1;
        blackScreen.enabled = false;
        UIPopup.text = "";
        playerScript.disabled = false;
        ambience.gameObject.SetActive(true);
    }

    public void SpawnManInHouse()
    {
        spawnedGuy = Instantiate(man, spawnManZone.position, Quaternion.identity);
        playerScript.gameObject.GetComponent<Animator>().speed = .5f;
    }
}
