using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject moleContainer;
    public TextMesh InfoText;
    public float spawnDuration = 1.5f;
    public float spawnDecrement= 1.0f;
    public float minimumSpawnTIme = 0.5f;
    public float gameTimer= 15f;


    private Mole[] moles;
    private float spawnTimer= 0f;
    // Start is called before the first frame update
    void Start()
    {
        moles = moleContainer.GetComponentsInChildren<Mole> ();
    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer-= Time.deltaTime;
        if(spawnTimer <= 0f){
        moles[Random.Range(0, moles.Length)].Rise ();

        spawnDuration -= spawnDecrement;
        if(spawnDuration < minimumSpawnTIme){
            spawnDuration= minimumSpawnTIme;
        }
        spawnTimer = spawnDuration;
        gameTimer -= Time.deltaTime;
        
        if (gameTimer >0f){
         InfoText.text= "Hit all the moles!\nTime: "+ Mathf.Floor(gameTimer);
        }

        else
        {
            InfoText.text= "Game Over!";
        }
        }
    }
}
