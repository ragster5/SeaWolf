using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum Sound
{
    Sail, Leme, Damage
}
public class GameController : MonoBehaviour
{
    public Transform leftUp, rightDown;
    public int obstacleQtd, windQtd, seaQtd;
    public GameObject victory, kitFase, wind, player;
    public GameObject[] obstacleTypes, lifes, seaTypes;
    private GameObject[] tempObstacles, tempWind, tempSea, tempVictory;
    private int lifeId = 0;
    public Camera cam;

    public static GameController instance;
    public AudioClip[] sounds;
    // Start is called before the first frame update
    void Start()
    {
        lifeId = 0;
        instance = this;
        tempObstacles = new GameObject[obstacleQtd];
        tempWind = new GameObject[windQtd];
        tempSea = new GameObject[seaQtd];
        tempVictory = new GameObject[4];

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && SceneManager.GetActiveScene().name.Equals("Load"))
        {
            SceneManager.UnloadSceneAsync(6);
            player.SetActive(true);
            cam.targetDisplay = 0;
            GenerateMap();
            //TakeDamage();
        }
    }
    void GenerateMap()
    {
        //Gerar Posição Inicial
        kitFase.transform.position = new Vector2(Random.Range(leftUp.position.x + 20, rightDown.position.x - 20), Random.Range(rightDown.position.y +20, leftUp.position.y - 20));
        //Gerar ventos
        for (int i = 0; i < tempWind.Length; i++)
        {
            tempWind[i] = Instantiate(wind) as GameObject;
            tempWind[i].transform.position = new Vector2(Random.Range(leftUp.position.x, rightDown.position.x), Random.Range(rightDown.position.y, leftUp.position.y));
        }

        //Gerar Correnteza
        for (int i = 0; i < tempSea.Length; i++)
        {
            tempSea[i] = Instantiate(seaTypes[Random.Range(0, seaTypes.Length)]) as GameObject;
            tempSea[i].transform.position = new Vector2(Random.Range(leftUp.position.x, rightDown.position.x), Random.Range(rightDown.position.y, leftUp.position.y));
        }
        //Gerar Obstáculos
        for (int i = 0; i < tempObstacles.Length; i++)
        {
            tempObstacles[i] = Instantiate(obstacleTypes[Random.Range(0, obstacleTypes.Length)]) as GameObject;
            tempObstacles[i].transform.position = new Vector2(Random.Range(leftUp.position.x, rightDown.position.x), Random.Range(rightDown.position.y, leftUp.position.y));
        }

        //Gerar Vitória
        for (int i = 0; i < tempVictory.Length; i++)
        {
            tempVictory[i] = Instantiate(victory) as GameObject;
            tempVictory[i].transform.position = new Vector2(Random.Range(leftUp.position.x, rightDown.position.x), Random.Range(rightDown.position.y, leftUp.position.y));
        }


    }
    public void TakeDamage()
    {
        lifes[lifeId].GetComponentInChildren<LifeBarr>().life -= Random.Range(1, 4);
        if(lifes[lifeId].GetComponentInChildren<LifeBarr>().life <= 0)
        {
            lifes[lifeId].GetComponentInChildren<LifeBarr>().life = 0;
            lifes[lifeId].AddComponent<Rigidbody2D>();
            if(lifeId == 6)
            {
                SceneManager.LoadScene("GameOver");
            }
            lifeId++;
        }
    }
    public void CreatWind()
    {
        GameObject tempWind = Instantiate(wind) as GameObject;
        tempWind.transform.position = new Vector2(Random.Range(leftUp.position.x, rightDown.position.x), Random.Range(rightDown.position.y, leftUp.position.y));
    }
    public void Victory()
    {
        SceneManager.LoadScene("Finish");
    }

    public static void PlaySound(Sound currentsound)
    {
        switch (currentsound)
        {
            case Sound.Damage:
                instance.GetComponent<AudioSource>().PlayOneShot(instance.sounds[0]);
                break;
            case Sound.Leme:
                instance.GetComponent<AudioSource>().PlayOneShot(instance.sounds[1]);
                break;
            case Sound.Sail:
                instance.GetComponent<AudioSource>().PlayOneShot(instance.sounds[2]);
                break;
        }
    }
}
