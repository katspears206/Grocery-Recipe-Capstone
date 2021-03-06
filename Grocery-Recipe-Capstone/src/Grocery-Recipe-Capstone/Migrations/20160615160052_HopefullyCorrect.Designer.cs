﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Grocery_Recipe_Capstone.Models;

namespace GroceryRecipeCapstone.Migrations
{
    [DbContext(typeof(GroceryRecipeContext))]
    [Migration("20160615160052_HopefullyCorrect")]
    partial class HopefullyCorrect
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rc2-20901")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Grocery_Recipe_Capstone.Models.FavoritedRecipe", b =>
                {
                    b.Property<int>("FavoritedRecipeId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("FoodEaterId");

                    b.Property<int>("RecipeId");

                    b.HasKey("FavoritedRecipeId");

                    b.HasIndex("FoodEaterId");

                    b.ToTable("FavoritedRecipe");
                });

            modelBuilder.Entity("Grocery_Recipe_Capstone.Models.FoodEater", b =>
                {
                    b.Property<int>("FoodEaterId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<string>("Username");

                    b.HasKey("FoodEaterId");

                    b.ToTable("FoodEater");
                });

            modelBuilder.Entity("Grocery_Recipe_Capstone.Models.GroceryList", b =>
                {
                    b.Property<int>("GroceryListId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("IngredientId");

                    b.HasKey("GroceryListId");

                    b.ToTable("GroceryList");
                });

            modelBuilder.Entity("Grocery_Recipe_Capstone.Models.Ingredient", b =>
                {
                    b.Property<int>("IngredientId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Amount");

                    b.Property<int?>("GroceryListId");

                    b.Property<string>("Name");

                    b.Property<int>("RecipeId");

                    b.HasKey("IngredientId");

                    b.HasIndex("GroceryListId");

                    b.ToTable("Ingredient");
                });

            modelBuilder.Entity("Grocery_Recipe_Capstone.Models.Recipe", b =>
                {
                    b.Property<int>("RecipeId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("FavoritedRecipeId");

                    b.Property<int?>("IngredientId");

                    b.Property<string>("Name");

                    b.Property<string>("ProcessToCook");

                    b.Property<string>("Type");

                    b.HasKey("RecipeId");

                    b.HasIndex("FavoritedRecipeId");

                    b.HasIndex("IngredientId");

                    b.ToTable("Recipe");
                });

            modelBuilder.Entity("Grocery_Recipe_Capstone.Models.FavoritedRecipe", b =>
                {
                    b.HasOne("Grocery_Recipe_Capstone.Models.FoodEater")
                        .WithMany()
                        .HasForeignKey("FoodEaterId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Grocery_Recipe_Capstone.Models.Ingredient", b =>
                {
                    b.HasOne("Grocery_Recipe_Capstone.Models.GroceryList")
                        .WithMany()
                        .HasForeignKey("GroceryListId");
                });

            modelBuilder.Entity("Grocery_Recipe_Capstone.Models.Recipe", b =>
                {
                    b.HasOne("Grocery_Recipe_Capstone.Models.FavoritedRecipe")
                        .WithMany()
                        .HasForeignKey("FavoritedRecipeId");

                    b.HasOne("Grocery_Recipe_Capstone.Models.Ingredient")
                        .WithMany()
                        .HasForeignKey("IngredientId");
                });
        }
    }
}
