using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject[] zombies;

    private bool isrising = false;
    private bool isfalling = false;

    private int activezombieIndex = 0;
    private Vector2 activeZ;
    public float risingspeed;

    private int score;
    private int lives;
    private bool over;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        over = false;
        score = 0;
        lives = 5;
        //Debug.Log("GameManager has started."); // debug is console print for unity engine
        pickzombie();
    }

    // Update is called once per frame
    void Update()
    {
        if (!over)
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
                if (lives <= 0)
                {
                    Debug.Log("Game Over! Final Score: " + score);
                    over = true;
                    // You can add additional game over logic here, such as restarting the game or showing a game over screen.
                }

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
            pickzombie();

        }
    }
}

    private void pickzombie()
    {
        isrising = true;
        isfalling = false;
        int zombieIndex = UnityEngine.Random.Range(0, zombies.Length); //random zombie
        activezombieIndex = zombieIndex;
        activeZ = zombies[activezombieIndex].transform.position;
    }

    public void zombiekilled()
    {
        score++;

        zombies[activezombieIndex].transform.position = activeZ; // reset the position of the zombie to its original position
        pickzombie(); // pick a new zombie to rise
        Debug.Log("score = " + score);
    }
}
