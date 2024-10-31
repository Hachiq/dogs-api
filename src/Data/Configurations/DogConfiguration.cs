using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Core.Entities;

namespace Data.Configurations;

public class DogConfiguration : IEntityTypeConfiguration<Dog>
{
    public void Configure(EntityTypeBuilder<Dog> builder)
    {
        builder.HasKey(d => d.Name);
        builder.Property(d => d.Name).HasMaxLength(50).IsRequired().HasColumnName("name");
        builder.Property(d => d.Color).HasMaxLength(50).IsRequired().HasColumnName("color");
        builder.Property(d => d.Tail_length).IsRequired().HasColumnName("tail_length");
        builder.Property(d => d.Weight).IsRequired().HasColumnName("weight");

        builder.HasData(
            new Dog { Name = "Max", Color = "black", Tail_length = 25, Weight = 40 },
            new Dog { Name = "Lucy", Color = "white", Tail_length = 22, Weight = 28 },
            new Dog { Name = "Rocky", Color = "gray", Tail_length = 24, Weight = 35 },
            new Dog { Name = "Charlie", Color = "red", Tail_length = 29, Weight = 32 },
            new Dog { Name = "Jack", Color = "blue", Tail_length = 21, Weight = 29 },
            new Dog { Name = "Lola", Color = "fawn", Tail_length = 19, Weight = 27 },
            new Dog { Name = "Roxy", Color = "brindle", Tail_length = 20, Weight = 34 },
            new Dog { Name = "Bear", Color = "tan", Tail_length = 26, Weight = 33 },
            new Dog { Name = "Ginger", Color = "cream", Tail_length = 18, Weight = 24 },
            new Dog { Name = "Ruby", Color = "apricot", Tail_length = 24, Weight = 30 },
            new Dog { Name = "Nala", Color = "chestnut", Tail_length = 19, Weight = 28 },
            new Dog { Name = "Finn", Color = "black&white", Tail_length = 25, Weight = 37 },
            new Dog { Name = "Sadie", Color = "ivory", Tail_length = 28, Weight = 25 },
            new Dog { Name = "Jasper", Color = "gray", Tail_length = 23, Weight = 30 },
            new Dog { Name = "Thor", Color = "brown", Tail_length = 27, Weight = 30 },
            new Dog { Name = "Maggie", Color = "black", Tail_length = 20, Weight = 32 },
            new Dog { Name = "Oscar", Color = "chocolate", Tail_length = 26, Weight = 26 },
            new Dog { Name = "Bella", Color = "golden", Tail_length = 26, Weight = 31 },
            new Dog { Name = "Penny", Color = "fawn", Tail_length = 22, Weight = 30 },
            new Dog { Name = "Winston", Color = "rust", Tail_length = 19, Weight = 28 },
            new Dog { Name = "Rex", Color = "graphite", Tail_length = 27, Weight = 38 },
            new Dog { Name = "Ellie", Color = "golden&white", Tail_length = 30, Weight = 29 },
            new Dog { Name = "Marley", Color = "black&tan", Tail_length = 20, Weight = 31 },
            new Dog { Name = "Chance", Color = "brown", Tail_length = 21, Weight = 33 },
            new Dog { Name = "Lucky", Color = "tan", Tail_length = 22, Weight = 25 },
            new Dog { Name = "Baxter", Color = "gray", Tail_length = 24, Weight = 39 },
            new Dog { Name = "Ember", Color = "brown", Tail_length = 20, Weight = 32 },
            new Dog { Name = "Ollie", Color = "black", Tail_length = 19, Weight = 30 },
            new Dog { Name = "Simba", Color = "brown&white", Tail_length = 21, Weight = 36 },
            new Dog { Name = "Tina", Color = "white", Tail_length = 26, Weight = 28 },
            new Dog { Name = "Stella", Color = "golden", Tail_length = 23, Weight = 31 },
            new Dog { Name = "Blue", Color = "blue", Tail_length = 20, Weight = 33 },
            new Dog { Name = "Beau", Color = "red", Tail_length = 29, Weight = 29 },
            new Dog { Name = "Gizmo", Color = "tan", Tail_length = 26, Weight = 32 },
            new Dog { Name = "Milo", Color = "black&white", Tail_length = 27, Weight = 38 },
            new Dog { Name = "Koda", Color = "chocolate", Tail_length = 25, Weight = 36 },
            new Dog { Name = "Ryder", Color = "brown", Tail_length = 30, Weight = 37 },
            new Dog { Name = "Fido", Color = "tan", Tail_length = 22, Weight = 28 },
            new Dog { Name = "Yuki", Color = "golden&white", Tail_length = 24, Weight = 31 },
            new Dog { Name = "Dobby", Color = "black", Tail_length = 21, Weight = 29 },
            new Dog { Name = "Gus", Color = "gray", Tail_length = 26, Weight = 32 },
            new Dog { Name = "Mimi", Color = "brown", Tail_length = 20, Weight = 28 },
            new Dog { Name = "Sammy", Color = "brown", Tail_length = 28, Weight = 35 },
            new Dog { Name = "Scout", Color = "golden", Tail_length = 23, Weight = 30 },
            new Dog { Name = "Angel", Color = "cream", Tail_length = 19, Weight = 27 },
            new Dog { Name = "Holly", Color = "fawn", Tail_length = 22, Weight = 34 },
            new Dog { Name = "Niko", Color = "black", Tail_length = 25, Weight = 29 },
            new Dog { Name = "Dash", Color = "tan", Tail_length = 21, Weight = 31 },
            new Dog { Name = "Rocco", Color = "brown&white", Tail_length = 24, Weight = 36 },
            new Dog { Name = "Ella", Color = "cream", Tail_length = 19, Weight = 30 },
            new Dog { Name = "Benny", Color = "black", Tail_length = 30, Weight = 30 },
            new Dog { Name = "Teddy", Color = "gray", Tail_length = 27, Weight = 38 },
            new Dog { Name = "Chester", Color = "brown", Tail_length = 19, Weight = 28 },
            new Dog { Name = "Cleo", Color = "golden", Tail_length = 26, Weight = 32 },
            new Dog { Name = "Ruff", Color = "brown", Tail_length = 25, Weight = 35 },
            new Dog { Name = "Whiskey", Color = "gray", Tail_length = 23, Weight = 27 },
            new Dog { Name = "Bruno", Color = "brown&white", Tail_length = 24, Weight = 31 },
            new Dog { Name = "Tango", Color = "tan", Tail_length = 22, Weight = 29 },
            new Dog { Name = "Biscuit", Color = "golden", Tail_length = 21, Weight = 30 },
            new Dog { Name = "Amber", Color = "brown", Tail_length = 26, Weight = 28 },
            new Dog { Name = "Pepper", Color = "gray", Tail_length = 22, Weight = 33 },
            new Dog { Name = "Sasha", Color = "black", Tail_length = 24, Weight = 35 },
            new Dog { Name = "Buster", Color = "tan", Tail_length = 20, Weight = 31 },
            new Dog { Name = "Nina", Color = "brown&white", Tail_length = 28, Weight = 29 },
            new Dog { Name = "Piper", Color = "golden&white", Tail_length = 25, Weight = 32 },
            new Dog { Name = "Kira", Color = "red", Tail_length = 19, Weight = 30 },
            new Dog { Name = "Rusty", Color = "black&tan", Tail_length = 23, Weight = 36 },
            new Dog { Name = "Luna", Color = "chocolate", Tail_length = 22, Weight = 30 },
            new Dog { Name = "Chloe", Color = "brindle", Tail_length = 20, Weight = 34 },
            new Dog { Name = "Sunny", Color = "fawn", Tail_length = 25, Weight = 29 },
            new Dog { Name = "Misty", Color = "ivory", Tail_length = 21, Weight = 32 },
            new Dog { Name = "Duke", Color = "chestnut", Tail_length = 24, Weight = 33 },
            new Dog { Name = "Snow", Color = "white", Tail_length = 27, Weight = 36 },
            new Dog { Name = "Coco", Color = "brown", Tail_length = 28, Weight = 31 },
            new Dog { Name = "Daisy", Color = "golden", Tail_length = 19, Weight = 30 },
            new Dog { Name = "Buddy", Color = "black&white", Tail_length = 23, Weight = 32 },
            new Dog { Name = "Cindy", Color = "tan", Tail_length = 22, Weight = 29 },
            new Dog { Name = "Toby", Color = "gray", Tail_length = 24, Weight = 35 },
            new Dog { Name = "Zoey", Color = "golden&white", Tail_length = 25, Weight = 30 }
            );
    }
}
