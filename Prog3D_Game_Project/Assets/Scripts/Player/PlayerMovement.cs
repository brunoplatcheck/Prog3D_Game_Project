using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 6f;

    Vector3 movement;
    Animator anim;
    Rigidbody playerRidigbody;
    int floormask;
    float camRayLength = 100f;

    void Awake ()
    {

        floorMask = LayerMask.GetMask("Floor");
        anim = GetComponent<Animator>();
        playerRidigbody = GetComponent<Rigidbody>();
    }

    void fixedupdate ()
    {
        float h = input.getaxixraw("horizontal");
        float v = input.getaxixraw("vertical");

        move(h, v);
        turning();
        animating(h, v);
    }

    void move (float h, float v)
    {
        movement.set(h, 0f, v);

        movemento = movement.normalized * speed * time.deltatime;

        playerrigidbody.moveposition(transform.position + movement);
    }

    void turning()
    {
        Ray camray = Camera.main.screenpointoray(input.mouseposition);

        RayCastHit floorHit;

        if(physics.raycast (camray, out floorhit, camRayLength, floormask))
        {
            vector3 playertomouse = floorhit.point - transform.position;
            playertomouse.y = 0f;

            quaternion newrotation = quaternion.lookrotation(playertomouse);
            playerRidigbody.moverotation(newrotation);
        }
    }

    void animating (float h, float v)
    {
        bool walking = h != 0f || v != 0f;
        anim.setbool("iswalking", walking);

    }
    
    
}
