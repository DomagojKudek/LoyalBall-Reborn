using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile 
{
    public MapGenerator mapGenerator;
    public Vector3 Position;
    public bool Taken = false;
    public int Level;
    public int Type;
    public int Height;
    public Vector3 direction;

    public Tile(MapGenerator _mapGenerator, Vector3 _Position, bool _Taken, int _Level, int _Type, int _Height, Vector3 _Direction)
    {
        mapGenerator = _mapGenerator;
        Position = _Position;
        Taken = _Taken;
        Level = _Level;
        Type = _Type;
        Height = _Height;
        direction = _Direction;
    }
}
