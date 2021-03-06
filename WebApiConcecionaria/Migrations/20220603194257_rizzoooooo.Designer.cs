// <auto-generated />
using System;
using API.Core.Business.DBContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace WebApiConcecionaria.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20220603194257_rizzoooooo")]
    partial class rizzoooooo
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("API.Core.Business.Entities.Cliente", b =>
                {
                    b.Property<int>("idCliente")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("idCliente"), 1L, 1);

                    b.Property<string>("Apelido")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("dieccion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("dni")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("idCliente");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("API.Core.Business.Entities.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("API.Core.Business.Entities.Vehiculo", b =>
                {
                    b.Property<int>("idVehculo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("idVehculo"), 1L, 1);

                    b.Property<DateTime>("fechaBaja")
                        .HasColumnType("datetime2");

                    b.Property<string>("marca")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("modelo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("precio")
                        .HasColumnType("real");

                    b.HasKey("idVehculo");

                    b.ToTable("Vehiculos");
                });

            modelBuilder.Entity("API.Core.Business.Entities.Venta", b =>
                {
                    b.Property<int>("idVenta")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("idVenta"), 1L, 1);

                    b.Property<int?>("clienteidCliente")
                        .HasColumnType("int");

                    b.Property<double>("descuento")
                        .HasColumnType("float");

                    b.Property<DateTime>("fecha")
                        .HasColumnType("datetime2");

                    b.Property<int>("idCliente")
                        .HasColumnType("int");

                    b.Property<int>("idVehiculo")
                        .HasColumnType("int");

                    b.Property<double>("importe")
                        .HasColumnType("float");

                    b.Property<int?>("vehiculoidVehculo")
                        .HasColumnType("int");

                    b.HasKey("idVenta");

                    b.HasIndex("clienteidCliente");

                    b.HasIndex("vehiculoidVehculo");

                    b.ToTable("Ventas");
                });

            modelBuilder.Entity("API.Core.Business.Entities.Venta", b =>
                {
                    b.HasOne("API.Core.Business.Entities.Cliente", "cliente")
                        .WithMany()
                        .HasForeignKey("clienteidCliente");

                    b.HasOne("API.Core.Business.Entities.Vehiculo", "vehiculo")
                        .WithMany()
                        .HasForeignKey("vehiculoidVehculo");

                    b.Navigation("cliente");

                    b.Navigation("vehiculo");
                });
#pragma warning restore 612, 618
        }
    }
}
