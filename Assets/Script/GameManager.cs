using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public GameObject[] zombies;

    private bool isrising = false;
    private bool isfalling = false;

    private int activezombieIndex = 0;
    private Vector2 activeZ;
    public float risingspeed;

    public int scorestep = 10;

    private int score;
    private int lives;
    private bool over;

    public Image life_1;
    public Image life_2;
    public Image life_3;
    public Image life_4;
    public Image life_5;
    public Text scoreText;
    public Button gameover;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        over = false;
        score = 0;
        scoreText.text = score.ToString();
        lives = 5;
        //Debug.Log("GameManager has started."); // debug is console print for unity engine
        Pickzombie();
    }

    // Update is called once per frame
    void Update()
    {
        if (!over)
        {
            Movezombie();
            //Debug.Log("GameManager is updating."); // debug is console print for unity engine
        }
        else
        {
            Resetgame();
        }
    }






    private void UpdateLivesUI()
    {
        // Update the life images based on the current number of lives

        if (lives == 5)
        {
            life_1.enabled = true;
            life_2.enabled = true;
            life_3.enabled = true;
            life_4.enabled = true;
            life_5.enabled = true;
            //life_5.enabled = false;
        }
        else if (lives == 4)
        {
            life_5.enabled = false;
            //life_1.gameObject.SetActive(false);
            //life_4.enabled = false;
        }
        else if (lives == 3)
        {
            life_4.enabled = false;
            //life_2.gameObject.SetActive(false);
            //life_3.enabled = false;
        }
        else if (lives == 2)
        {
            life_3.enabled = false;
            //life_3.gameObject.SetActive(false);
            //life_2.enabled = false;
        }
        else if (lives == 1)
        {
            life_2.enabled = false;
            //life_4.gameObject.SetActive(false);
            //life_1.enabled = false;
        }
        else if (lives == 0)
        {
            life_1.enabled = false;
            Gameoverf();
        }

    }

    private void Gameoverf()
    {
        over = true;
        gameover.gameObject.SetActive(true);
    }


    private void Resetgame()
    {
        if (Input.GetMouseButtonDown(0))
        {
            over = false;
            score = 0;
            scoreText.text = score.ToString();
            lives = 5;
            UpdateLivesUI();
            Pickzombie();
            gameover.gameObject.SetActive(false);
        }

    }

    private void Movezombie()
    {
        if (isrising)
        {
            // Handle rising logic
            /*
            zombies[activezombieIndex].transform.Translate(Vector2.up * Time.deltaTime * risingspeed); // rise and rise speed.*/

            if (zombies[activezombieIndex].transform.position.y - activeZ.y >= 3f) // check if the zombie has risen 3 units
            {
                // Stop rising and start falling
                isrising = false;
                isfalling = true;

            }
            else
            {
                zombies[activezombieIndex].transform.Translate(Vector2.up * Time.deltaTime * risingspeed);
            }
        }
        else if (isfalling)
        {
            // Handle falling logic
            if (zombies[activezombieIndex].transform.position.y - activeZ.y <= 0f) // check if the zombie has fallen back to its original position
            {
                // Stop falling and pick a new zombie
                isfalling = false;
                isrising = false;
                lives--;
                Debug.Log("lives = " + lives);
                UpdateLivesUI(); // Update the lives UI


            }
            else
            {
                zombies[activezombieIndex].transform.Translate(Vector2.down * Time.deltaTime * risingspeed);
            }
        }
        else
        {
            // bump to start position
            zombies[activezombieIndex].transform.position = activeZ;
            Pickzombie();

        }
    }

    private void Pickzombie()
    {
        isrising = true;
        isfalling = false;
        int zombieIndex = UnityEngine.Random.Range(0, zombies.Length); //random zombie
        activezombieIndex = zombieIndex;
        activeZ = zombies[activezombieIndex].transform.position;
    }

    public void Zombiekilled()
    {
        score++;
        scoreText.text = score.ToString();
        Increase_speed();
        zombies[activezombieIndex].transform.position = activeZ; // reset the position of the zombie to its original position
        Pickzombie(); // pick a new zombie to rise
        Debug.Log("score = " + score);
    }

    private void Increase_speed()
    {
        if(score >= scorestep)
        {
            risingspeed++;
            scorestep += 10;
        }
    }
}


