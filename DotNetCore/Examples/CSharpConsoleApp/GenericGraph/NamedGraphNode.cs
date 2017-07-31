
using System;
using System.Collections.Generic;

public class NamedGraphNode<T> {
    private Dictionary<string, NamedGraphNode<T>> _Neighbours;

    public string Name { get; private set; }
    public T Value { get; private set; }

    public NamedGraphNode(string name) {
        Name = name;
        _Neighbours = new Dictionary<string, NamedGraphNode<T>>();
    }

    public NamedGraphNode<T> AddNeighbour(NamedGraphNode<T> other) {
        _Neighbours.Add( other.Name, other);
        other._Neighbours.Add( Name, this);
        return this;
    }

    public IEnumerable<string> Neighbours() {
        return _Neighbours.Keys;
    }

    public bool HasNeighbour(string name) {
        return _Neighbours.ContainsKey(name);
    }

    public bool GetNeighbour(string name, out NamedGraphNode<T> neighbour) {
        if (HasNeighbour(name)) {
            neighbour = _Neighbours[name];
            return true;
        } else {
            neighbour = null;
            return false;
        }
    }
}