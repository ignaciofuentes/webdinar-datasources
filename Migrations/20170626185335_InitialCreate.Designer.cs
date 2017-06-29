using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using demoken.Model;

namespace demoken.Migrations
{
    [DbContext(typeof(StoreContext))]
    [Migration("20170626185335_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2");

            modelBuilder.Entity("demoken.Controllers.MonthlySale", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("BluRays");

                    b.Property<decimal>("DVDs");

                    b.Property<string>("Month");

                    b.Property<decimal>("VideoGames");

                    b.HasKey("Id");

                    b.ToTable("MonthlySales");
                });
        }
    }
}
