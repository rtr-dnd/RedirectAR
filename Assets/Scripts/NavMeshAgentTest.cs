using UnityEngine;
using UnityEngine.AI;

public class NavMeshAgentTest : MonoBehaviour
{
    // public Transform goal;

    // void Start()
    // {
    //     NavMeshAgent agent = GetComponent<NavMeshAgent>();
    //     agent.destination = goal.position;
    // }

    [SerializeField] Transform start, goal;
    const int maxPosition = 9; // パスの最大登録数

    // パスと、座標リスト。使い回す
    NavMeshPath path = null;
    Vector3[] positions = new Vector3[maxPosition];
    int pathLength = 0;
    Vector3 previousPos = Vector3.zero;

    void Awake()
    {
        path = new NavMeshPath();
    }

    void Start()
    {
        // パスの計算

    }

    void Update()
    {
        // if (start.position != previousPos)
        // {
        //     previousPos = start.position;
        //     OnPositionChanged();
        // }
        OnPositionChanged();
    }

    private void OnPositionChanged()
    {
        NavMesh.CalculatePath(start.localPosition, goal.localPosition, NavMesh.AllAreas, path);
        path.GetCornersNonAlloc(positions);
        pathLength = path.corners.Length;
    }

    private void OnDrawGizmos()
    {
        for (int i = 0; i < pathLength - 1; i++)
        {
            Gizmos.DrawLine(positions[i], positions[i + 1]);
        }
    }
}

//     [SerializeField] Transform start, goal;
//     const int maxPosition = 9; // パスの最大登録数

//     // パスと、座標リスト。使い回す
//     NavMeshPath path = null;
//     Vector3[] positions = new Vector3[maxPosition];

//     void Awake()
//     {
//         path = new NavMeshPath();
//     }

//     void Start ()
//     {
//         // パスの計算
//         NavMesh.CalculatePath(start.localPosition, goal.localPosition, NavMesh.AllAreas, path);
//         path.GetCornersNonAlloc(positions);
//     }

//     private void OnDrawGizmosSelected()
//     {
//         for (int i = 0; i < positions.Length - 1; i++)
//         {
//             Gizmos.DrawLine(positions[i], positions[i + 1]);
//         }
//     }
// }