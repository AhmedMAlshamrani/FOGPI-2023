using UnityEngine;

public class BallTriangle : MonoBehaviour
{
    public GameObject[] balls; // reference to the game objects representing the balls
    public float spacing = 0.2f; // spacing between the balls in the triangle

    private void Start()
    {
        int numRows = Mathf.FloorToInt(Mathf.Sqrt(balls.Length * 2)); // compute the number of rows in the triangle
        int rowLength = numRows + 1; // compute the number of balls in the bottom row of the triangle
        float xOffset = 0f; // horizontal offset from the center of the triangle

        for (int row = 0; row < numRows; row++)
        {
            float yOffset = spacing * (row - numRows / 2f); // vertical offset from the center of the triangle
            int startIndex = balls.Length - rowLength; // index of the first ball in the current row

            for (int i = 0; i < rowLength; i++)
            {
                balls[startIndex + i].transform.position = transform.position + new Vector3(xOffset + spacing * i, yOffset, 0f); // set the position of the ball based on its index in the row
            }

            xOffset += spacing / 2f; // update the horizontal offset for the next row
            rowLength--; // decrement the number of balls in the bottom row for the next row
        }
    }
}
