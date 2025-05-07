using System;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class Obstacle : MonoBehaviour
{
    public float highPosY = 1f;
    public float lowPosY = -1f;

    public float holeSizeMin = 1f;
    public float holeSizeMax = 3f;

    public Transform topObject;
    public Transform bottomObject;

    public float widthPadding = 4f;

    public Vector3 SetRandomPlace(Vector3 lastPos, int totalCount)
{
    float offsetX = Random.Range(5f, 8f); // 장애물 간 X 간격
    float offsetY = Random.Range(-2.5f, 2.5f); // Y축 제한

    // 제한된 범위로 장애물 위치 지정
    Vector3 newPos = new Vector3(lastPos.x + offsetX, Mathf.Clamp(offsetY, -2.5f, 2.5f), 0);

    transform.position = newPos;

    Debug.Log($"[SetRandomPlace] 위치 재배치됨: {transform.position}");

    return newPos;
}

}