﻿using System.Text.Json.Serialization;

namespace Simulator.Maps;

[JsonPolymorphic(TypeDiscriminatorPropertyName = "Type")]
[JsonDerivedType(typeof(Elf), nameof(Elf))]
[JsonDerivedType(typeof(Orc), nameof(Orc))]
[JsonDerivedType(typeof(Animals), nameof(Animals))]
[JsonDerivedType(typeof(Birds), nameof(Birds))]
public interface IMappable
{
    char Symbol { get; }
    void AssignMap(Map map, Point point);
    string Go(Direction direction);
    string ToString();
    Point GetPos();
}
