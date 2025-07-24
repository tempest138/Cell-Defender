using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{

    [SerializeField] private List<PuzzleSlot> slotPrefabs;
    [SerializeField] private Piece piecePrefab;
    [SerializeField] private Transform slotParent, pieceParent;

    void Spawn()
    {
        
    }
}
