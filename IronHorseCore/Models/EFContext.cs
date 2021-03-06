using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace IronHorseCore.Models
{
    public partial class EFContext : DbContext
    {
        public EFContext()
        {
        }

        public EFContext(DbContextOptions<EFContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Bill> Bills { get; set; }
        public virtual DbSet<Carrier> Carriers { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Clientrate> Clientrates { get; set; }
        public virtual DbSet<Driver> Drivers { get; set; }
        public virtual DbSet<Driverexpense> Driverexpenses { get; set; }
        public virtual DbSet<Maintenance> Maintenances { get; set; }
        public virtual DbSet<Money> Money { get; set; }
        public virtual DbSet<Operation> Operations { get; set; }
        public virtual DbSet<Operationexpense> Operationexpenses { get; set; }
        public virtual DbSet<Place> Places { get; set; }
        public virtual DbSet<Toll> Tolls { get; set; }
        public virtual DbSet<Truck> Trucks { get; set; }
        public virtual DbSet<Typeexpense> Typeexpenses { get; set; }
        public virtual DbSet<Typeload> Typeloads { get; set; }
        public virtual DbSet<Typeproduct> Typeproducts { get; set; }
        public virtual DbSet<Typeservice> Typeservices { get; set; }
        public virtual DbSet<Unit> Units { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=localhost;port=3306;uid=root;password=root;database=ironhorse", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.24-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_0900_ai_ci");

            modelBuilder.Entity<Bill>(entity =>
            {
                entity.ToTable("bill");

                entity.HasIndex(e => e.OperationId, "FK_bill_operation");

                entity.Property(e => e.Created)
                    .HasColumnType("datetime")
                    .HasComment("Fecha de la factura");

                entity.Property(e => e.Datepay)
                    .HasColumnType("datetime")
                    .HasComment("Fecha de pago");

                entity.Property(e => e.SerialNumber)
                    .HasMaxLength(12)
                    .HasComment("Serie - numero de factura");

                entity.Property(e => e.Status).HasComment("Estado de la factura(Factura generada = 1, Factura pagada = 2, Factura anulada = 3)");

                entity.Property(e => e.Total)
                    .HasPrecision(10, 2)
                    .HasComment("Total de la factura");

                entity.HasOne(d => d.Operation)
                    .WithMany(p => p.Bills)
                    .HasForeignKey(d => d.OperationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_bill_operation");
            });

            modelBuilder.Entity<Carrier>(entity =>
            {
                entity.ToTable("carrier");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(500)
                    .HasDefaultValueSql("'0'");
            });

            modelBuilder.Entity<Client>(entity =>
            {
                entity.ToTable("client");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(150)
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Contact)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.ContactEmail)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.ContactPhone)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.MetaAuth)
                    .IsRequired()
                    .HasColumnType("json");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.UniqueId)
                    .IsRequired()
                    .HasMaxLength(36);
            });

            modelBuilder.Entity<Clientrate>(entity =>
            {
                entity.ToTable("clientrate");

                entity.HasIndex(e => e.ClientId, "FK__client");

                entity.HasIndex(e => e.DestinyId, "FK_clientrate_destiny");

                entity.HasIndex(e => e.SourceId, "FK_clientrate_source");

                entity.HasIndex(e => e.MoneyId, "FK_money");

                entity.HasIndex(e => e.TypeLoadId, "FK_typeload");

                entity.HasIndex(e => e.TypeProductId, "FK_typeproduct");

                entity.HasIndex(e => e.TypeServiceId, "FK_typeservice");

                entity.HasIndex(e => e.UnitId, "FK_unit");

                entity.Property(e => e.ContractExpiration)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("'0'")
                    .HasComment("Vencimiento de contrato");

                entity.Property(e => e.ContractNumber)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("'0'")
                    .HasComment("Número de contrato	");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnType("mediumtext")
                    .HasComment("Descripcion de Tarifa");

                entity.Property(e => e.DestinyId).HasComment("Destino");

                entity.Property(e => e.MetaAuth)
                    .IsRequired()
                    .HasColumnType("json");

                entity.Property(e => e.MoneyId).HasComment("Moneda");

                entity.Property(e => e.PriceWithoutVat)
                    .HasPrecision(10, 2)
                    .HasColumnName("PriceWithoutVAT")
                    .HasComment("Precio sin IGV	");

                entity.Property(e => e.SourceId).HasComment("Origen");

                entity.Property(e => e.TypeLoadId).HasComment("Tipo de Carga");

                entity.Property(e => e.TypeProductId).HasComment("Tipo de Producto");

                entity.Property(e => e.TypeServiceId).HasComment("Tipo de Servicio	");

                entity.Property(e => e.UniqueId)
                    .IsRequired()
                    .HasMaxLength(36);

                entity.Property(e => e.UnitId).HasComment("Unidad");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Clientrates)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_client");

                entity.HasOne(d => d.Destiny)
                    .WithMany(p => p.ClientrateDestinies)
                    .HasForeignKey(d => d.DestinyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_clientrate_destiny");

                entity.HasOne(d => d.Money)
                    .WithMany(p => p.Clientrates)
                    .HasForeignKey(d => d.MoneyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_money");

                entity.HasOne(d => d.Source)
                    .WithMany(p => p.ClientrateSources)
                    .HasForeignKey(d => d.SourceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_clientrate_source");

                entity.HasOne(d => d.TypeLoad)
                    .WithMany(p => p.Clientrates)
                    .HasForeignKey(d => d.TypeLoadId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_typeload");

                entity.HasOne(d => d.TypeProduct)
                    .WithMany(p => p.Clientrates)
                    .HasForeignKey(d => d.TypeProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_typeproduct");

                entity.HasOne(d => d.TypeService)
                    .WithMany(p => p.Clientrates)
                    .HasForeignKey(d => d.TypeServiceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_typeservice");

                entity.HasOne(d => d.Unit)
                    .WithMany(p => p.Clientrates)
                    .HasForeignKey(d => d.UnitId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_unit");
            });

            modelBuilder.Entity<Driver>(entity =>
            {
                entity.ToTable("driver");

                entity.HasComment("Conductor");

                entity.Property(e => e.BirthDay)
                    .HasColumnType("date")
                    .HasDefaultValueSql("'0000-00-00'");

                entity.Property(e => e.CursosPortuarios).HasComment("Cursos portuarios");

                entity.Property(e => e.CursosPortuariosVigencia).HasColumnType("date");

                entity.Property(e => e.Dni)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("DNI")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Dnivigencia)
                    .HasColumnType("date")
                    .HasColumnName("DNIVigencia")
                    .HasDefaultValueSql("'0000-00-00'");

                entity.Property(e => e.InduccionAcerosA).HasComment("Inducción Aceros Arequipa");

                entity.Property(e => e.InduccionImpala).HasComment("Inducción Impala");

                entity.Property(e => e.InduccionImpalaVigencia).HasColumnType("date");

                entity.Property(e => e.InduccionLogisminsa).HasComment("Inducción Logisminsa");

                entity.Property(e => e.InduccionLogisminsaVigencia).HasColumnType("date");

                entity.Property(e => e.InduccionPerubar).HasComment("Inducción Perubar");

                entity.Property(e => e.InduccionPerubarVigencia).HasColumnType("date");

                entity.Property(e => e.InduccionRansa).HasComment("Inducción Ransa");

                entity.Property(e => e.InduccionShouxin).HasComment("Inducción Shouxin");

                entity.Property(e => e.InduccionShouxinVigencia).HasColumnType("date");

                entity.Property(e => e.InduccionTisur).HasComment("Inducción Tisur");

                entity.Property(e => e.Iqpf).HasColumnName("IQPF");

                entity.Property(e => e.LicenseDriver2Number)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.LicenseDriver2Validaty).HasColumnType("date");

                entity.Property(e => e.LicenseDriverNumber)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.LicenseDriverValidaty)
                    .HasColumnType("date")
                    .HasDefaultValueSql("'0000-00-00'");

                entity.Property(e => e.MetaAuth)
                    .IsRequired()
                    .HasColumnType("json");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.UniqueId)
                    .IsRequired()
                    .HasMaxLength(36)
                    .HasDefaultValueSql("'0'");
            });

            modelBuilder.Entity<Driverexpense>(entity =>
            {
                entity.ToTable("driverexpenses");

                entity.HasIndex(e => e.DriverId, "FK_driverexpenses_driver");

                entity.HasIndex(e => e.OperationId, "FK_driverexpenses_operations");

                entity.HasIndex(e => e.TypeExpenseId, "FK_driverexpenses_typeexpenses");

                entity.Property(e => e.AprobadoPor).HasComment("Aprobado por");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(500)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.OperacionDesignada).HasComment("Operación designada");

                entity.HasOne(d => d.Driver)
                    .WithMany(p => p.Driverexpenses)
                    .HasForeignKey(d => d.DriverId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_driverexpenses_driver");

                entity.HasOne(d => d.Operation)
                    .WithMany(p => p.Driverexpenses)
                    .HasForeignKey(d => d.OperationId)
                    .HasConstraintName("FK_driverexpenses_operations");

                entity.HasOne(d => d.TypeExpense)
                    .WithMany(p => p.Driverexpenses)
                    .HasForeignKey(d => d.TypeExpenseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_driverexpenses_typeexpenses");
            });

            modelBuilder.Entity<Maintenance>(entity =>
            {
                entity.ToTable("maintenance");

                entity.Property(e => e.Amount)
                    .IsRequired()
                    .HasMaxLength(20)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsFixedLength(true)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");
            });

            modelBuilder.Entity<Money>(entity =>
            {
                entity.ToTable("money");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(500)
                    .HasDefaultValueSql("'0'");
            });

            modelBuilder.Entity<Operation>(entity =>
            {
                entity.ToTable("operations");

                entity.HasIndex(e => e.CarrierId, "FK_operations_carrier");

                entity.HasIndex(e => e.ClientId, "FK_operations_client");

                entity.HasIndex(e => e.ClientrateId, "FK_operations_clientrate");

                entity.HasIndex(e => e.DriverId, "FK_operations_driver");

                entity.HasIndex(e => e.CarretaId, "FK_operations_truck_carreta");

                entity.HasIndex(e => e.TractoId, "FK_operations_truck_tracto");

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.LoadDate).HasColumnType("datetime");

                entity.Property(e => e.MonthYear).HasMaxLength(50);

                entity.Property(e => e.OutDate).HasColumnType("datetime");

                entity.HasOne(d => d.Carreta)
                    .WithMany(p => p.OperationCarreta)
                    .HasForeignKey(d => d.CarretaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_operations_truck_carreta");

                entity.HasOne(d => d.Carrier)
                    .WithMany(p => p.Operations)
                    .HasForeignKey(d => d.CarrierId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_operations_carrier");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Operations)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_operations_client");

                entity.HasOne(d => d.Clientrate)
                    .WithMany(p => p.Operations)
                    .HasForeignKey(d => d.ClientrateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_operations_clientrate");

                entity.HasOne(d => d.Driver)
                    .WithMany(p => p.Operations)
                    .HasForeignKey(d => d.DriverId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_operations_driver");

                entity.HasOne(d => d.Tracto)
                    .WithMany(p => p.OperationTractos)
                    .HasForeignKey(d => d.TractoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_operations_truck_tracto");
            });

            modelBuilder.Entity<Operationexpense>(entity =>
            {
                entity.ToTable("operationexpenses");

                entity.Property(e => e.Amount)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(500);
            });

            modelBuilder.Entity<Place>(entity =>
            {
                entity.ToTable("place");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(500)
                    .HasDefaultValueSql("'0'");
            });

            modelBuilder.Entity<Toll>(entity =>
            {
                entity.ToTable("toll");

                entity.HasIndex(e => e.OperationsId, "FK_toll_operations");

                entity.Property(e => e.DatePay)
                    .HasColumnType("datetime")
                    .HasComment("Fecha");

                entity.Property(e => e.Pay).HasComment("Pago");

                entity.HasOne(d => d.Operations)
                    .WithMany(p => p.Tolls)
                    .HasForeignKey(d => d.OperationsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_toll_operations");
            });

            modelBuilder.Entity<Truck>(entity =>
            {
                entity.ToTable("truck");

                entity.HasIndex(e => e.CarrierId, "FK_truck_carrier");

                entity.Property(e => e.BonifacionMatpel)
                    .HasMaxLength(50)
                    .HasComment("Bonifación Matpel");

                entity.Property(e => e.BonificacionPesosMedidas)
                    .HasMaxLength(50)
                    .HasComment("BonificaciónPesos y Medidas");

                entity.Property(e => e.CkecklistInspeccionGeneralVigencia).HasColumnType("date");

                entity.Property(e => e.GpscertificadoInstalacion)
                    .HasColumnType("date")
                    .HasColumnName("GPSCertificadoInstalacion");

                entity.Property(e => e.Gpsproveedor)
                    .HasMaxLength(50)
                    .HasColumnName("GPSProveedor")
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.Placa)
                    .HasMaxLength(50)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.PolizaAccidentesPersonalesVigencia).HasColumnType("date");

                entity.Property(e => e.PolizaNro)
                    .HasMaxLength(50)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.PolizaSeguroTrecVigencia).HasColumnType("date");

                entity.Property(e => e.PolizaVigencia).HasColumnType("date");

                entity.Property(e => e.Propietario)
                    .HasMaxLength(50)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.RevisionTecnicaNro)
                    .HasMaxLength(50)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.RevisionTecnicaVigencia).HasColumnType("date");

                entity.Property(e => e.SemiremolqueTipo)
                    .HasMaxLength(50)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.Soatnumero)
                    .HasMaxLength(50)
                    .HasColumnName("SOATNumero")
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.Soatvigencia)
                    .HasColumnType("date")
                    .HasColumnName("SOATVigencia");

                entity.Property(e => e.TarjetaCirualacionVigencia).HasColumnType("date");

                entity.Property(e => e.TarjetaMercaderiaVigencia).HasColumnType("date");

                entity.HasOne(d => d.Carrier)
                    .WithMany(p => p.Trucks)
                    .HasForeignKey(d => d.CarrierId)
                    .HasConstraintName("FK_truck_carrier");
            });

            modelBuilder.Entity<Typeexpense>(entity =>
            {
                entity.ToTable("typeexpenses");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(40);
            });

            modelBuilder.Entity<Typeload>(entity =>
            {
                entity.ToTable("typeload");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(500)
                    .HasDefaultValueSql("'0'");
            });

            modelBuilder.Entity<Typeproduct>(entity =>
            {
                entity.ToTable("typeproduct");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(500)
                    .HasDefaultValueSql("'0'");
            });

            modelBuilder.Entity<Typeservice>(entity =>
            {
                entity.ToTable("typeservice");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(500)
                    .HasDefaultValueSql("'0'");
            });

            modelBuilder.Entity<Unit>(entity =>
            {
                entity.ToTable("unit");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(500)
                    .HasDefaultValueSql("'0'");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("user");

                entity.Property(e => e.CellPhone)
                    .IsRequired()
                    .HasMaxLength(50)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.IsAdmin).HasComment("1: Admin; 2: Usuario Normal");

                entity.Property(e => e.LastAccess).HasColumnType("datetime");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.MetaAuth)
                    .IsRequired()
                    .HasColumnType("json");

                entity.Property(e => e.NumberDoc)
                    .IsRequired()
                    .HasMaxLength(12)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.Phone)
                    .HasMaxLength(50)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.Rol)
                    .IsRequired()
                    .HasMaxLength(50)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.TypeDoc)
                    .IsRequired()
                    .HasMaxLength(18)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.UniqueId)
                    .IsRequired()
                    .HasMaxLength(36);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
