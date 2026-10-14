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
            RaycastHit2D[] hits = Physics2D.GetRayIntersectionAll(ray);
            Collider2D frontCollider = null;
            int frontOrder = int.MinValue;

            foreach (RaycastHit2D item in hits)
            {
                SpriteRenderer sprite = item.collider.GetComponent<SpriteRenderer>();
                int order = sprite != null ? sprite.sortingOrder : 0;

                if (order > frontOrder)
                {
                    frontOrder = order;
                    frontCollider = item.collider;
                }
            }

            if (frontCollider != null) // use the object visibly in front
            {
                //Debug.Log("Hit: " + frontCollider.gameObject.name);
                if (frontCollider.tag == "zombie")
                {
                    //Debug.Log("Zombie hit!");   // debug is console print for unity engine
                    gameObject.GetComponent<GameManager>().zombiekilled(); // call the zombiekilled function in GameManager script
                }
            }
        }

        


    }
}
