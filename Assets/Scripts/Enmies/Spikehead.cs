using UnityEngine;

public class Spikehead : EnemyDamage
{
    [SerializeField] private float speed;
    [SerializeField] private float range;
    [SerializeField] private float checkDelay;
    private float checkTimer;
    private Vector3 destination;
    
    private bool attacking;

    private void Update()
    {
        if (attacking)
            transform.Translate(destination * Time.deltaTime * speed);
        else
        { 
            checkTimer += Time.deltaTime;
            if (checkTimer > checkDelay)
                CheckForPlayer();
        }
    }

    private void CheckForPlayer()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.left, range, LayerMask.GetMask("Player"));
        if (hit)
        {
            attacking = true;
            destination = (hit.point - transform.position).normalized;
        }
        checkTimer = 0;
    }
}
