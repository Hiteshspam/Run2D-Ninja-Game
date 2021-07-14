using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Player player;
    public ScoreManager scoremanager;
    public AudioSource backgroundSound;
    public AudioSource deathSound;

    private Vector3 playerStartingPoint;
    private Vector3 groundGenerationStartPoint;
    public GroundGenerator groundGenerator;

    public GameObject largeGround;
    public GameObject mediumGround;

    public GameObject gameOverMenu;

    // Start is called before the first frame update
    void Start()
    {
        playerStartingPoint = player.transform.position;
        groundGenerationStartPoint = groundGenerator.transform.position;
        gameOverMenu.SetActive(false);

    }
    public void Quit()
    {
        Application.Quit(); 
    }
    public void GameOver()
    {
        player.gameObject.SetActive(false);
        gameOverMenu.SetActive(true);
        scoremanager.isScoreIncreasing = false;
        backgroundSound.Stop();
        deathSound.Play();
    }
    public void Restart()
    {
        GroundDestroyer[] destroyer = FindObjectsOfType<GroundDestroyer>();
        for(int i = 0; i<destroyer.Length; i++)
        {
            destroyer[i].gameObject.SetActive(false);
        }
        largeGround.SetActive(true);
        mediumGround.SetActive(true);
        player.transform.position = playerStartingPoint;
        groundGenerator.transform.position = groundGenerationStartPoint;
        gameOverMenu.SetActive(false);
        player.gameObject.SetActive(true);
        backgroundSound.Play();
        scoremanager.Score = 0;
        scoremanager.isScoreIncreasing = true;
    }

}
