// <auto-generated />
using System;
using CRMManager.Web.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CRMManager.Web.Migrations
{
    [DbContext(typeof(CRMManagerDbContext))]
    [Migration("20220918154753_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.29")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CRMManager.Web.Entities.Call", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CallDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("CallReceiverID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("CallTimeSec")
                        .HasColumnType("int");

                    b.Property<Guid?>("СallerID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ID");

                    b.HasIndex("CallReceiverID");

                    b.HasIndex("СallerID");

                    b.ToTable("Calls");
                });

            modelBuilder.Entity("CRMManager.Web.Entities.Conference", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("ConferenceDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ConferenceTheme")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.HasKey("ID");

                    b.ToTable("Conferences");
                });

            modelBuilder.Entity("CRMManager.Web.Entities.Contact", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ConferenceID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime>("RegistrationDate")
                        .HasColumnType("datetime2");

                    b.HasKey("ID");

                    b.HasIndex("ConferenceID");

                    b.ToTable("Contacts");
                });

            modelBuilder.Entity("CRMManager.Web.Entities.ContactForm", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("ContactID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.Property<string>("Surname")
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.HasKey("ID");

                    b.HasIndex("ContactID")
                        .IsUnique();

                    b.ToTable("ContactForms");
                });

            modelBuilder.Entity("CRMManager.Web.Entities.Phone", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ContactFormID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DeactivationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("DeactivationReason")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("nvarchar(17)")
                        .HasMaxLength(17);

                    b.HasKey("ID");

                    b.HasIndex("ContactFormID")
                        .IsUnique();

                    b.ToTable("Phones");
                });

            modelBuilder.Entity("CRMManager.Web.Entities.Call", b =>
                {
                    b.HasOne("CRMManager.Web.Entities.Phone", "CallReceiver")
                        .WithMany()
                        .HasForeignKey("CallReceiverID");

                    b.HasOne("CRMManager.Web.Entities.Phone", "Сaller")
                        .WithMany()
                        .HasForeignKey("СallerID");
                });

            modelBuilder.Entity("CRMManager.Web.Entities.Contact", b =>
                {
                    b.HasOne("CRMManager.Web.Entities.Conference", null)
                        .WithMany("Members")
                        .HasForeignKey("ConferenceID");
                });

            modelBuilder.Entity("CRMManager.Web.Entities.ContactForm", b =>
                {
                    b.HasOne("CRMManager.Web.Entities.Contact", "Contact")
                        .WithOne("ContactForm")
                        .HasForeignKey("CRMManager.Web.Entities.ContactForm", "ContactID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CRMManager.Web.Entities.Phone", b =>
                {
                    b.HasOne("CRMManager.Web.Entities.ContactForm", "Contact")
                        .WithOne("Phone")
                        .HasForeignKey("CRMManager.Web.Entities.Phone", "ContactFormID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
