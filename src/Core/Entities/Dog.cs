namespace Core.Entities;

/// <summary>
/// Represents a Dog entity with properties defining its name, color, tail length, and weight.
/// </summary>
public class Dog
{
    /// <summary>
    /// Gets or sets the name of the dog.
    /// This property is required and should represent a unique or identifying name for the dog.
    /// </summary>
    /// <example>Max</example>
    public required string Name { get; set; }
    /// <summary>
    /// Gets or sets the color of the dog.
    /// This property is required and should describe the primary color of the dog's coat.
    /// </summary>
    /// <example>Brown</example>

    public required string Color { get; set; }
    /// <summary>
    /// Gets or sets the length of the dog's tail, measured in centimeters.
    /// This property is required and represents a positive integer indicating tail length.
    /// </summary>
    /// <example>25</example>

    public required int TailLength { get; set; }
    /// <summary>
    /// Gets or sets the weight of the dog, measured in kilograms.
    /// This property is required and represents a positive integer indicating the dog's weight.
    /// </summary>
    /// <example>10</example>

    public required int Weight { get; set; }
}
