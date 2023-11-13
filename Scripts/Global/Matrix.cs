using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Matrix : MonoBehaviour
{
    public static Matrix matrix;
    private void Awake()
    {
        if(matrix == null) matrix = this;
    }
    [SerializeField] private int _x, _y;
    [SerializeField] private static int X, Y;
    [SerializeField] private int delay;
    private Tile[,] tiles = new Tile[X,Y];
    public Func<float, float, Tile> GetTile;
    public Vector2 XY => new Vector2(_x,_y);
    public void Initialize()
    {
        X = _x;
        Y = _y;
        GenerateMatrix();
    }
    public IEnumerator GenerateMatrix() 
    {
        for(int i = 0; i < X; i++) 
        {
            for(int j = 0; j < Y; j++) 
            {
                tiles[i,j] = new Tile(i,j);
            }
            yield return new WaitForSeconds(delay);
        }
        
    }
}
public class Tile 
{
    public int x;
    public int y;
    public GameEvent onTop;
    public Tile GetMe(float i, float j) 
    {
        if(Mathf.FloorToInt(i) == x && Mathf.FloorToInt(j) == y) return this;
        return null;
    }
    public Tile(int a, int b) 
    {
        x = a;
        y = b;
        Matrix.matrix.GetTile += this.GetMe;
    }

}

