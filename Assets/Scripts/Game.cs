using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class Game : MonoBehaviour
{
    public static Game current;

    public FloatingText floatingDialog;
    public TextMeshProUGUI txtBulliesLeft;
    public TextMeshProUGUI txtHelp;

    public Boss boss;
    public Cinemachine.CinemachineVirtualCamera bossCamera;

    int bulliesLeft = 1;
    public int BulliesLeft
    {
        get => bulliesLeft;
        set
        {
            bulliesLeft = value;
            if(value > 0)
            {
                txtBulliesLeft.SetText($"{value} bullies left");
            }
            else
            {
                txtBulliesLeft.SetText($"Congradulations, you are now alone.\nBullies are gone!\n\nThanks for playing!");
            }

        }
    }

    private void Awake()
    {
        current = this;
        Bully.OnSpawn += HandleAddBully;
        Bully.OnDie += HandleRemoveBully;
        Orange.OnDie += HandleRemoveOrange;
    }

    private void OnDestroy()
    {
        Bully.OnSpawn -= HandleAddBully;
        Bully.OnDie -= HandleRemoveBully;
    }

    private void Start()
    {
        // update UI
        BulliesLeft = BulliesLeft;
    }

    void HandleAddBully(Bully bully)
    {
        BulliesLeft += 1;
    }

    void HandleRemoveBully(Bully bully)
    {
        BulliesLeft -= 1;

        switch (BulliesLeft)
        {
            case 1:
                StartCoroutine(RemoveBoss());
                break;
            case 3:
                boss.ShootRate = 0.75f;
                break;
            case 7:
                boss.ShootRate = 1.85f;
                break;
            case 10:
                boss.ShootRate = 2.5f;
                break;
            case 15:
                boss.ShootRate = 3f;
                break;
            default:
                break;
        }
    }

    void HandleRemoveOrange(Orange orange)
    {
        txtHelp.SetText("Press R to restart!");
    }


    IEnumerator RemoveBoss()
    {
        boss.enabled = false;
        bossCamera.Priority = 20;
        yield return new WaitForSeconds(4f);
        boss.GetComponent<Rigidbody2D>().simulated = true;
        yield return new WaitForSeconds(3f);
        BulliesLeft = 0;
        // ToDo: Play some win music
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            RestartGame();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

#if UNITY_EDITOR
        if (Input.GetKeyDown(KeyCode.P))
        {
            StartCoroutine(RemoveBoss());
        }
#endif
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
