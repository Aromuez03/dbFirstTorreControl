using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace bdFirstTorreControlDAL.Modelo;

public partial class CspharmaInformacionalContext : DbContext
{
    public CspharmaInformacionalContext()
    {
    }

    public CspharmaInformacionalContext(DbContextOptions<CspharmaInformacionalContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TdcCatEstadosDevolucionPedido> TdcCatEstadosDevolucionPedidos { get; set; }

    public virtual DbSet<TdcCatEstadosEnvioPedido> TdcCatEstadosEnvioPedidos { get; set; }

    public virtual DbSet<TdcCatEstadosPagoPedido> TdcCatEstadosPagoPedidos { get; set; }

    public virtual DbSet<TdcCatLineasDistribucion> TdcCatLineasDistribucions { get; set; }

    public virtual DbSet<TdcTchEstadoPedido> TdcTchEstadoPedidos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Server=localhost;Port=5432;Database=cspharma_informacional;User Id=postgres;Password=Alfminecraft2612#");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TdcCatEstadosDevolucionPedido>(entity =>
        {
            entity.HasKey(e => e.CodEstadoDevolucion).HasName("cod_estado_devolucion_PK");

            entity.ToTable("tdc_cat_estados_devolucion_pedido", "dwh_torrecontrol");

            entity.Property(e => e.CodEstadoDevolucion)
                .HasComment("Código que\nidentifica de forma\nunívoca el estado\nde devolución de\nun pedido")
                .HasColumnType("character varying")
                .HasColumnName("cod_estado_devolucion");
            entity.Property(e => e.DesEstadoDevolucion)
                .HasComment("Descripción del\nestado de\ndevolución del\npedido")
                .HasColumnType("character varying")
                .HasColumnName("des_estado_devolucion");
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasComment("Identificador\nunívoco del\nestado de\ndevolución del\npedido en el\nsistema")
                .HasColumnName("id");
            entity.Property(e => e.MdDate)
                .HasComment("Fecha en la que\nse define el \ngrupo de inserción.")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("md_date");
            entity.Property(e => e.MdUuid)
                .HasComment("Código de metadato\nque indica el grupo\nde inserción al que\npertenece el registro.")
                .HasColumnType("character varying")
                .HasColumnName("md_uuid");
        });

        modelBuilder.Entity<TdcCatEstadosEnvioPedido>(entity =>
        {
            entity.HasKey(e => e.CodEstadoEnvio).HasName("cod_estado_envio_PK");

            entity.ToTable("tdc_cat_estados_envio_pedido", "dwh_torrecontrol");

            entity.Property(e => e.CodEstadoEnvio)
                .HasComment("Código que\nidentifica de forma\nunívoca el estado\nde envío de un\npedido")
                .HasColumnType("character varying")
                .HasColumnName("cod_estado_envio");
            entity.Property(e => e.DesEstadoEnvio)
                .HasComment("Descripción del\nestado de envío\ndel pedido")
                .HasColumnType("character varying")
                .HasColumnName("des_estado_envio");
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasComment("Identificador\nunívoco del\nestado de envío\ndel pedido en el\nsistema")
                .HasColumnName("id");
            entity.Property(e => e.MdDate)
                .HasComment("Fecha en la que \nse define el \ngrupo de inserción.")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("md_date");
            entity.Property(e => e.MdUuid)
                .HasComment("Código de metadato\nque indica el grupo\nde inserción al que\npertenece el registro.")
                .HasColumnType("character varying")
                .HasColumnName("md_uuid");
        });

        modelBuilder.Entity<TdcCatEstadosPagoPedido>(entity =>
        {
            entity.HasKey(e => e.CodEstadoPago).HasName("cod_estado_pago_PK");

            entity.ToTable("tdc_cat_estados_pago_pedido", "dwh_torrecontrol");

            entity.Property(e => e.CodEstadoPago)
                .HasComment("Código que\nidentifica de forma\nunívoca el estado\nde pago de un pedido")
                .HasColumnType("character varying")
                .HasColumnName("cod_estado_pago");
            entity.Property(e => e.DesEstadoPago)
                .HasComment("Descripción del\nestado de pago\ndel pedido")
                .HasColumnType("character varying")
                .HasColumnName("des_estado_pago");
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasComment("Identificador\nunívoco del\nestado de pago\ndel pedido en el\nsistema")
                .HasColumnName("id");
            entity.Property(e => e.MdDate)
                .HasComment("Fecha en la que se\ndefine el grupo de\ninserción.")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("md_date");
            entity.Property(e => e.MdUuid)
                .HasComment("Código de metadato\nque indica el grupo\nde inserción al que\npertenece el registro")
                .HasColumnType("character varying")
                .HasColumnName("md_uuid");
        });

        modelBuilder.Entity<TdcCatLineasDistribucion>(entity =>
        {
            entity.HasKey(e => e.CodLinea).HasName("cod_linea_PK");

            entity.ToTable("tdc_cat_lineas_distribucion", "dwh_torrecontrol");

            entity.Property(e => e.CodLinea)
                .HasComment("Código que\nidentifica de forma\nunívoca la línea\nde distribución por\ncarretera que\nsigue el envío:\ncodprovincia-codmunicipio-codbarrio")
                .HasColumnType("character varying")
                .HasColumnName("cod_linea");
            entity.Property(e => e.CodBarrio)
                .HasComment("Código que\nidentifica de forma\nunívoca el barrio")
                .HasColumnType("character varying")
                .HasColumnName("cod_barrio");
            entity.Property(e => e.CodMunicipio)
                .HasComment("Código que\nidentifica de forma\nunívoca el\nmunicipio")
                .HasColumnType("character varying")
                .HasColumnName("cod_municipio");
            entity.Property(e => e.CodProvincia)
                .HasComment("Código que\nidentifica de forma\nunívoca a la\nprovincia")
                .HasColumnType("character varying")
                .HasColumnName("cod_provincia");
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasComment("Identificador\nunívoco de la\nlínea de\ndistribución en el\nsistema")
                .HasColumnName("id");
            entity.Property(e => e.MdDate)
                .HasComment("Fecha en la que se\ndefine el grupo de\ninserción.")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("md_date");
            entity.Property(e => e.MdUuid)
                .HasComment("Código de metadato\nque indica el grupo\nde inserción al\nque pertenece el\nregistro.")
                .HasColumnType("character varying")
                .HasColumnName("md_uuid");
        });

        modelBuilder.Entity<TdcTchEstadoPedido>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("tdc_tch_estado_pedidos_pkey");

            entity.ToTable("tdc_tch_estado_pedidos", "dwh_torrecontrol");

            entity.Property(e => e.Id)
                .HasComment("Identificador\nunívoco del\npedido en el\nsistema")
                .HasColumnName("id");
            entity.Property(e => e.CodEstadoDevolucion)
                .HasComment("Código que\nidentifica de forma\nunívoca el estado\nde devolución de\nun pedido")
                .HasColumnType("character varying")
                .HasColumnName("cod_estado_devolucion");
            entity.Property(e => e.CodEstadoEnvio)
                .HasComment("Código que\nidentifica de forma\nunívoca el estado\nde envío de un pedido")
                .HasColumnType("character varying")
                .HasColumnName("cod_estado_envio");
            entity.Property(e => e.CodEstadoPago)
                .HasComment("Código que\nidentifica de forma\nunívoca el estado\nde pago de un pedido")
                .HasColumnType("character varying")
                .HasColumnName("cod_estado_pago");
            entity.Property(e => e.CodLinea)
                .HasComment("Código que\nidentifica de forma\nunívoca la línea\nde distribución por\ncarretera que\nsigue el envío:\ncodprovincia-codmunicipio-codbarrio")
                .HasColumnType("character varying")
                .HasColumnName("cod_linea");
            entity.Property(e => e.CodPedido)
                .HasComment("Código que\nidentifica de forma\nunívoca un pedido. \nSe construye con:\nprovincia-codfarmacia-id")
                .HasColumnType("character varying")
                .HasColumnName("cod_pedido");
            entity.Property(e => e.MdDate)
                .HasComment("Fecha en la que se\ndefine el grupo de\ninserción")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("md_date");
            entity.Property(e => e.MdUuid)
                .HasComment("Código de\nmetadato\nque indica el\ngrupo\nde inserción al\nque\npertenece el\nregistro")
                .HasColumnType("character varying")
                .HasColumnName("md_uuid");

            entity.HasOne(d => d.CodEstadoDevolucionNavigation).WithMany(p => p.TdcTchEstadoPedidos)
                .HasForeignKey(d => d.CodEstadoDevolucion)
                .HasConstraintName("cod_estado_devolucion_FK");

            entity.HasOne(d => d.CodEstadoEnvioNavigation).WithMany(p => p.TdcTchEstadoPedidos)
                .HasForeignKey(d => d.CodEstadoEnvio)
                .HasConstraintName("cod_estado_envio_FK");

            entity.HasOne(d => d.CodEstadoPagoNavigation).WithMany(p => p.TdcTchEstadoPedidos)
                .HasForeignKey(d => d.CodEstadoPago)
                .HasConstraintName("cod_estado_pago_FK");

            entity.HasOne(d => d.CodLineaNavigation).WithMany(p => p.TdcTchEstadoPedidos)
                .HasForeignKey(d => d.CodLinea)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("cod_linea_FK");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
