using UnityEngine;

public class playerinput : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //constantly check input
        if(Input.GetMouseButtonDown(0)) // to ray cast when mouse button is pressed
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); //ray cast initialize from camera to mouse position
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction); //ray cast in 2D

            if (hit.collider != null) // if raycast hits something
            {
                Debug.Log("Hit something!"); // debug is console print for unity engine
            }
        }

        


    }
}
