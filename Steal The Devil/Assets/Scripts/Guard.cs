using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Guard : MonoBehaviour
{
    public static event System.Action OnGuardHasSpottedPlayer;

    public Transform pathHolder;
    public LayerMask viewMask;
    Transform player;
    Color originalSpotlightColour;

    public float speed = 3.5f;
    public float waitTime = .3f;
    public float turnSpeed = 90;
    public float viewDistance;
    public float timeToSpotPlayer = .5f;
    public float chaseSpeed = 5; // Velocidade durante a perseguição
    public float chaseDuration = 3f; // Tempo máximo de perseguição
    public float captureDistance = 1.5f; // Distância mínima para capturar o jogador

    private float viewAngle;
    private float playerVisibleTimer;
    private float chaseTimer;

    private bool isWalking;
    private bool isChasing; // Estado de perseguição

    public Light spotlight;

    private Animator animator;

    private int lastWaypointIndex = -1;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        viewAngle = spotlight.spotAngle;
        originalSpotlightColour = spotlight.color;

        animator = GetComponent<Animator>();

        Vector3[] waypoints = new Vector3[pathHolder.childCount];
        for (int i = 0; i < waypoints.Length; i++)
        {
            waypoints[i] = pathHolder.GetChild(i).position;
            waypoints[i] = new Vector3(waypoints[i].x, transform.position.y, waypoints[i].z);
        }

        StartCoroutine(FollowPath(waypoints));
    }

    private void Update()
    {
        if (CanSeePlayer())
        {
            playerVisibleTimer += Time.deltaTime;
            spotlight.color = Color.red;
        }
        else
        {
            playerVisibleTimer -= Time.deltaTime;
            spotlight.color = originalSpotlightColour;
        }

        playerVisibleTimer = Mathf.Clamp(playerVisibleTimer, 0, timeToSpotPlayer);
        spotlight.color = Color.Lerp(originalSpotlightColour, Color.red, playerVisibleTimer / timeToSpotPlayer);

        if (playerVisibleTimer >= timeToSpotPlayer)
        {
            if (!isChasing)
            {
                StartChasing();
            }
        }

        // Atualiza o parâmetro de animação
        animator.SetBool("IsWalking", isWalking);
    }

    void StartChasing()
    {
        isChasing = true;
        chaseTimer = chaseDuration;
        StopAllCoroutines(); // Para a patrulha
        StartCoroutine(ChasePlayer());
    }

    IEnumerator ChasePlayer()
    {
        while (chaseTimer > 0)
        {
            // Verifica a distância até o jogador
            float distanceToPlayer = Vector3.Distance(transform.position, player.position);

            if (distanceToPlayer <= captureDistance)
            {
                // Guarda captura o jogador
                CapturePlayer();
                yield break; // Sai do loop de perseguição
            }

            // Movimenta o guarda em direção ao jogador
            Vector3 directionToPlayer = (player.position - transform.position).normalized;

            // Fazer o guarda olhar para o jogador
            Quaternion lookRotation = Quaternion.LookRotation(directionToPlayer);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed);  // Ajusta a rotação suavemente

            // Mover o guarda em direção ao jogador
            transform.position = Vector3.MoveTowards(transform.position, player.position, chaseSpeed * Time.deltaTime);

            isWalking = true;

            // Verifica se o guarda ainda pode ver o jogador
            if (!CanSeePlayer())
            {
                chaseTimer -= Time.deltaTime;
            }
            else
            {
                chaseTimer = chaseDuration; // Reseta o tempo de perseguição se o jogador ainda está visível
            }

            yield return null;
        }

        // Quando a perseguição termina, o guarda volta a patrulhar
        isChasing = false;
        isWalking = false;
        StartCoroutine(FollowPath(GetWaypoints()));
    }


    void CapturePlayer()
    {
        // Desativa o ThirdPersonController e PlayerInput
        ThirdPersonController playerController = player.GetComponent<ThirdPersonController>();  // Referência ao ThirdPersonController
#if ENABLE_INPUT_SYSTEM
        PlayerInput playerInput = player.GetComponent<PlayerInput>(); // Referência ao PlayerInput
#endif
        Animator playerAnimator = player.GetComponent<Animator>(); // Referência ao Animator do jogador

        if (playerController != null)
        {
            playerController.enabled = false;  // Desativa o controle de movimento
        }

#if ENABLE_INPUT_SYSTEM
        if (playerInput != null)
        {
            playerInput.enabled = false;  // Desativa as entradas de controle do jogador
        }
#endif

        // Ativa a animação de morte/captura
        if (playerAnimator != null)
        {
            playerAnimator.SetBool("IsDead", true);  // Define o parâmetro IsDead como true para ativar a animação de captura

        }

        Debug.Log("se fodeu");

        // Opcional: Chamar um evento ou ativar a lógica de game over
        OnGuardHasSpottedPlayer?.Invoke();
    }


    bool CanSeePlayer()
    {
        if (Vector3.Distance(transform.position, player.position) < viewDistance)
        {
            Vector3 dirToPlayer = (player.position - transform.position).normalized;
            float angleBetweenGuardAndPlayer = Vector3.Angle(transform.forward, dirToPlayer);
            if (angleBetweenGuardAndPlayer < viewAngle / 2f)
            {
                if (!Physics.Linecast(transform.position, player.position, viewMask))
                {
                    return true;
                }
            }
        }
        return false;
    }

    IEnumerator FollowPath(Vector3[] waypoints)
    {
        transform.position = waypoints[0];
        int targetWaypointIndex = GetRandomWaypoint(waypoints.Length);
        Vector3 targetWaypoint = waypoints[targetWaypointIndex];
        transform.LookAt(targetWaypoint);

        while (!isChasing) // Patrulha apenas quando não está perseguindo
        {
            transform.position = Vector3.MoveTowards(transform.position, targetWaypoint, speed * Time.deltaTime);

            isWalking = (transform.position != targetWaypoint);

            if (transform.position == targetWaypoint)
            {
                lastWaypointIndex = targetWaypointIndex;
                targetWaypointIndex = GetRandomWaypoint(waypoints.Length);
                targetWaypoint = waypoints[targetWaypointIndex];

                isWalking = false;
                yield return new WaitForSeconds(waitTime);
                yield return StartCoroutine(TurnToFace(targetWaypoint));
            }
            yield return null;
        }
    }

    int GetRandomWaypoint(int waypointCount)
    {
        int randomIndex;
        do
        {
            randomIndex = Random.Range(0, waypointCount);
        }
        while (randomIndex == lastWaypointIndex);
        return randomIndex;
    }

    IEnumerator TurnToFace(Vector3 lookTarget)
    {
        Vector3 dirLookTarget = (lookTarget - transform.position).normalized;
        float targetAngle = 90 - Mathf.Atan2(dirLookTarget.z, dirLookTarget.x) * Mathf.Rad2Deg;

        while (Mathf.Abs(Mathf.DeltaAngle(transform.eulerAngles.y, targetAngle)) > 0.05f)
        {
            float angle = Mathf.MoveTowardsAngle(transform.eulerAngles.y, targetAngle, turnSpeed * Time.deltaTime);
            transform.eulerAngles = Vector3.up * angle;
            yield return null;
        }
    }

    private Vector3[] GetWaypoints()
    {
        Vector3[] waypoints = new Vector3[pathHolder.childCount];
        for (int i = 0; i < waypoints.Length; i++)
        {
            waypoints[i] = pathHolder.GetChild(i).position;
            waypoints[i] = new Vector3(waypoints[i].x, transform.position.y, waypoints[i].z);
        }
        return waypoints;
    }

    private void OnDrawGizmos()
    {
        Vector3 startPosition = pathHolder.GetChild(0).position;
        Vector3 previousPosition = startPosition;
        foreach (Transform waypoint in pathHolder)
        {
            Gizmos.DrawSphere(waypoint.position, .3f);
            Gizmos.DrawLine(previousPosition, waypoint.position);
            previousPosition = waypoint.position;
        }
        Gizmos.DrawLine(previousPosition, startPosition);
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, transform.forward * viewDistance);
    }
}
