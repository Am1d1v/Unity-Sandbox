using UnityEngine;

public class Slowdown : MonoBehaviour
{
    public float range;

    public float slowdown = 0.5f;

    public Collider[] collidersInRange;

    public LayerMask whatToSlow;

    public GameObject rangeModel;

    public PlayerController thePlayer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rangeModel.transform.localScale = new Vector3(range, rangeModel.transform.position.y, range);
    }

    // Update is called once per frame
    void Update()
    {
        collidersInRange = Physics.OverlapSphere(transform.position, range, whatToSlow);

        foreach(Collider player in collidersInRange)
        {
            if(player.tag == "Player")
            {
                thePlayer.speedMod = 0.3f;
            }
            Debug.Log(player.tag);

        }
        
    }
}
