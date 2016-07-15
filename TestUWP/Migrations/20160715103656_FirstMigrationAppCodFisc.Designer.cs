using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using TestUWP;

namespace TestUWP.Migrations
{
    [DbContext(typeof(AppCodFiscContext))]
    [Migration("20160715103656_FirstMigrationAppCodFisc")]
    partial class FirstMigrationAppCodFisc
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431");

            modelBuilder.Entity("TestUWP.ComuneCodCat", b =>
                {
                    b.Property<int>("ComuneCodCatId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("codiceCatastale");

                    b.Property<string>("nome");

                    b.HasKey("ComuneCodCatId");

                    b.ToTable("Comuni");
                });

            modelBuilder.Entity("TestUWP.SoggettoFiscale", b =>
                {
                    b.Property<int>("SoggettoFiscaleId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CodiceCatastale");

                    b.Property<string>("CodiceFiscale");

                    b.Property<string>("Cognome");

                    b.Property<DateTime>("DataNascita");

                    b.Property<string>("Name");

                    b.Property<int>("Sesso");

                    b.HasKey("SoggettoFiscaleId");

                    b.ToTable("SoggettiFiscali");
                });
        }
    }
}
