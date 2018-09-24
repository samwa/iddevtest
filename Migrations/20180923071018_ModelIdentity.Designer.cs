﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using iddevtest;

namespace iddevtest.Migrations
{
    [DbContext(typeof(LgaContext))]
    [Migration("20180923071018_ModelIdentity")]
    partial class ModelIdentity
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.3-rtm-32065")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("iddevtest.LgaModel", b =>
                {
                    b.Property<int>("LgaId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Place");

                    b.Property<int>("SEIFADisadvantage2011");

                    b.Property<int>("SEIFADisadvantage2016");

                    b.Property<string>("State");

                    b.HasKey("LgaId");

                    b.ToTable("Lgas");
                });
#pragma warning restore 612, 618
        }
    }
}
