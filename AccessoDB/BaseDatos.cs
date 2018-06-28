namespace AccessoDB
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class BaseDatos : DbContext
    {
        public BaseDatos()
            : base("name=BaseDatos")
        {
        }

        public virtual DbSet<CATALOGO_CIRUGIAS> CATALOGO_CIRUGIAS { get; set; }
        public virtual DbSet<CATALOGO_CUARTOS> CATALOGO_CUARTOS { get; set; }
        public virtual DbSet<CATALOGO_EQUIPO_HOSPITAL> CATALOGO_EQUIPO_HOSPITAL { get; set; }
        public virtual DbSet<CATALOGO_ESPECIALIDADES> CATALOGO_ESPECIALIDADES { get; set; }
        public virtual DbSet<CATALOGO_ESTUDIOS> CATALOGO_ESTUDIOS { get; set; }
        public virtual DbSet<CATALOGO_MATERIALES> CATALOGO_MATERIALES { get; set; }
        public virtual DbSet<CATALOGO_MEDICAMENTOS> CATALOGO_MEDICAMENTOS { get; set; }
        public virtual DbSet<CIRUGIA> CIRUGIAS { get; set; }
        public virtual DbSet<CLASIFICACION_ESTUDIOS> CLASIFICACION_ESTUDIOS { get; set; }
        public virtual DbSet<COMPRA> COMPRAS { get; set; }
        public virtual DbSet<CONSULTA> CONSULTAS { get; set; }
        public virtual DbSet<CUARTO> CUARTOS { get; set; }
        public virtual DbSet<CUENTA> CUENTAS { get; set; }
        public virtual DbSet<DEPOSITO> DEPOSITOS { get; set; }
        public virtual DbSet<DETALLE_COMPRAS> DETALLE_COMPRAS { get; set; }
        public virtual DbSet<DETALLE_EQUIPO_HOSPITAL> DETALLE_EQUIPO_HOSPITAL { get; set; }
        public virtual DbSet<DETALLE_ESTUDIOS> DETALLE_ESTUDIOS { get; set; }
        public virtual DbSet<DETALLE_MATER_DOCTORES> DETALLE_MATER_DOCTORES { get; set; }
        public virtual DbSet<DETALLE_MATER_ENFERMERAS> DETALLE_MATER_ENFERMERAS { get; set; }
        public virtual DbSet<DETALLE_SUMINISTROS_MEDICAMENTOS> DETALLE_SUMINISTROS_MEDICAMENTOS { get; set; }
        public virtual DbSet<DETALLE_VENTAS> DETALLE_VENTAS { get; set; }
        public virtual DbSet<DEVOLUCIONE> DEVOLUCIONES { get; set; }
        public virtual DbSet<DIAGNOSTICO> DIAGNOSTICOS { get; set; }
        public virtual DbSet<EMPLEADO> EMPLEADOS { get; set; }
        public virtual DbSet<ENFERMERA> ENFERMERAS { get; set; }
        public virtual DbSet<ENFERMERAS_TRATANTES> ENFERMERAS_TRATANTES { get; set; }
        public virtual DbSet<EQUIPO_HOSPITAL> EQUIPO_HOSPITAL { get; set; }
        public virtual DbSet<ESPECIALIDADE> ESPECIALIDADES { get; set; }
        public virtual DbSet<ESPECIALIDADES_ENFERMERAS> ESPECIALIDADES_ENFERMERAS { get; set; }
        public virtual DbSet<ESTADO> ESTADOS { get; set; }
        public virtual DbSet<ESTADOS_PERSONAS> ESTADOS_PERSONAS { get; set; }
        public virtual DbSet<ESTUDIO> ESTUDIOS { get; set; }
        public virtual DbSet<FAM_RESPONSABLES> FAM_RESPONSABLES { get; set; }
        public virtual DbSet<HONORARIOS_MEDICOS> HONORARIOS_MEDICOS { get; set; }
        public virtual DbSet<LOCALIDADE> LOCALIDADES { get; set; }
        public virtual DbSet<MATERIALES_DOCTORES> MATERIALES_DOCTORES { get; set; }
        public virtual DbSet<MATERIALES_ENFERMERAS> MATERIALES_ENFERMERAS { get; set; }
        public virtual DbSet<Medico> MEDICOS { get; set; }
        public virtual DbSet<MEDICOS_TRATANTES> MEDICOS_TRATANTES { get; set; }
        public virtual DbSet<MUNICIPIO> MUNICIPIOS { get; set; }
        public virtual DbSet<PACIENTE> PACIENTES { get; set; }
        public virtual DbSet<PERMISO> PERMISOS { get; set; }
        public virtual DbSet<PERSONA> PERSONAS { get; set; }
        public virtual DbSet<PROVEEDORE> PROVEEDORES { get; set; }
        public virtual DbSet<SUMINISTROS_MEDICAMENTOS> SUMINISTROS_MEDICAMENTOS { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<USUARIO> USUARIOS { get; set; }
        public virtual DbSet<VENTAS_GENERALES> VENTAS_GENERALES { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CATALOGO_CIRUGIAS>()
                .Property(e => e.NOMBRE_CIRUGIA)
                .IsUnicode(false);

            modelBuilder.Entity<CATALOGO_CIRUGIAS>()
                .Property(e => e.DESCRIPCION)
                .IsUnicode(false);

            modelBuilder.Entity<CATALOGO_CIRUGIAS>()
                .Property(e => e.COSTO)
                .HasPrecision(10, 3);

            modelBuilder.Entity<CATALOGO_CIRUGIAS>()
                .Property(e => e.ESTATUS)
                .IsUnicode(false);

            modelBuilder.Entity<CATALOGO_CIRUGIAS>()
                .HasMany(e => e.CIRUGIAS)
                .WithRequired(e => e.CATALOGO_CIRUGIAS)
                .HasForeignKey(e => e.CATALOGO_CIRUGIAID);

            modelBuilder.Entity<CATALOGO_CUARTOS>()
                .Property(e => e.NOMBRE_CUARTO)
                .IsUnicode(false);

            modelBuilder.Entity<CATALOGO_CUARTOS>()
                .Property(e => e.DESCRIPCION)
                .IsUnicode(false);

            modelBuilder.Entity<CATALOGO_CUARTOS>()
                .Property(e => e.COSTO)
                .HasPrecision(10, 3);

            modelBuilder.Entity<CATALOGO_CUARTOS>()
                .Property(e => e.ESTADO)
                .IsUnicode(false);

            modelBuilder.Entity<CATALOGO_CUARTOS>()
                .Property(e => e.STATUS)
                .IsUnicode(false);

            modelBuilder.Entity<CATALOGO_CUARTOS>()
                .HasMany(e => e.CUARTOS)
                .WithRequired(e => e.CATALOGO_CUARTOS)
                .HasForeignKey(e => e.CATALOGO_CUARTOID);

            modelBuilder.Entity<CATALOGO_EQUIPO_HOSPITAL>()
                .Property(e => e.NOM_EQUIPO_HOSPITAL)
                .IsUnicode(false);

            modelBuilder.Entity<CATALOGO_EQUIPO_HOSPITAL>()
                .Property(e => e.DESCRIPCION)
                .IsUnicode(false);

            modelBuilder.Entity<CATALOGO_EQUIPO_HOSPITAL>()
                .Property(e => e.COSTO)
                .HasPrecision(10, 3);

            modelBuilder.Entity<CATALOGO_EQUIPO_HOSPITAL>()
                .Property(e => e.STATUS)
                .IsUnicode(false);

            modelBuilder.Entity<CATALOGO_EQUIPO_HOSPITAL>()
                .HasMany(e => e.DETALLE_EQUIPO_HOSPITAL)
                .WithOptional(e => e.CATALOGO_EQUIPO_HOSPITAL)
                .HasForeignKey(e => e.CATALOGO_EQUIPO_HOSPITALID)
                .WillCascadeOnDelete();

            modelBuilder.Entity<CATALOGO_ESPECIALIDADES>()
                .Property(e => e.NOMBRE_ESPECIALIDAD)
                .IsUnicode(false);

            modelBuilder.Entity<CATALOGO_ESPECIALIDADES>()
                .Property(e => e.DESCRIPCION)
                .IsUnicode(false);

            modelBuilder.Entity<CATALOGO_ESPECIALIDADES>()
                .Property(e => e.STATUS)
                .IsUnicode(false);

            modelBuilder.Entity<CATALOGO_ESPECIALIDADES>()
                .HasMany(e => e.ESPECIALIDADES_ENFERMERAS)
                .WithRequired(e => e.CATALOGO_ESPECIALIDADES)
                .HasForeignKey(e => e.CATALOGO_ESPECIALIDADESID);

            modelBuilder.Entity<CATALOGO_ESPECIALIDADES>()
                .HasMany(e => e.ESPECIALIDADES)
                .WithRequired(e => e.CATALOGO_ESPECIALIDADES)
                .HasForeignKey(e => e.CATALOGO_ESPECIALIDAD_ID);

            modelBuilder.Entity<CATALOGO_ESTUDIOS>()
                .Property(e => e.NOMBRE)
                .IsUnicode(false);

            modelBuilder.Entity<CATALOGO_ESTUDIOS>()
                .Property(e => e.DESCRIPCION)
                .IsUnicode(false);

            modelBuilder.Entity<CATALOGO_ESTUDIOS>()
                .Property(e => e.COSTO)
                .HasPrecision(10, 3);

            modelBuilder.Entity<CATALOGO_ESTUDIOS>()
                .Property(e => e.STATUS)
                .IsUnicode(false);

            modelBuilder.Entity<CATALOGO_ESTUDIOS>()
                .HasMany(e => e.DETALLE_ESTUDIOS)
                .WithOptional(e => e.CATALOGO_ESTUDIOS)
                .HasForeignKey(e => e.CATALOGO_ESTUDIOS_ID)
                .WillCascadeOnDelete();

            modelBuilder.Entity<CATALOGO_MATERIALES>()
                .Property(e => e.NOMBRE)
                .IsUnicode(false);

            modelBuilder.Entity<CATALOGO_MATERIALES>()
                .Property(e => e.COMENTARIO)
                .IsUnicode(false);

            modelBuilder.Entity<CATALOGO_MATERIALES>()
                .Property(e => e.COSTO)
                .HasPrecision(10, 3);

            modelBuilder.Entity<CATALOGO_MATERIALES>()
                .Property(e => e.U_MEDIDA)
                .IsUnicode(false);

            modelBuilder.Entity<CATALOGO_MEDICAMENTOS>()
                .Property(e => e.NOMBRE_MEDI)
                .IsUnicode(false);

            modelBuilder.Entity<CATALOGO_MEDICAMENTOS>()
                .Property(e => e.COMENTARIO)
                .IsUnicode(false);

            modelBuilder.Entity<CATALOGO_MEDICAMENTOS>()
                .Property(e => e.P_VENTA)
                .HasPrecision(10, 3);

            modelBuilder.Entity<CATALOGO_MEDICAMENTOS>()
                .Property(e => e.P_COMPRA)
                .HasPrecision(10, 3);

            modelBuilder.Entity<CATALOGO_MEDICAMENTOS>()
                .Property(e => e.P_MEDICOS)
                .HasPrecision(10, 3);

            modelBuilder.Entity<CATALOGO_MEDICAMENTOS>()
                .Property(e => e.DESCUENTO)
                .HasPrecision(10, 3);

            modelBuilder.Entity<CATALOGO_MEDICAMENTOS>()
                .Property(e => e.U_MEDIDA)
                .IsUnicode(false);

            modelBuilder.Entity<CATALOGO_MEDICAMENTOS>()
                .Property(e => e.ALMACEN)
                .IsUnicode(false);

            modelBuilder.Entity<CATALOGO_MEDICAMENTOS>()
                .Property(e => e.COD_BARRAS)
                .IsUnicode(false);

            modelBuilder.Entity<CATALOGO_MEDICAMENTOS>()
                .Property(e => e.IVA)
                .HasPrecision(10, 3);

            modelBuilder.Entity<CATALOGO_MEDICAMENTOS>()
                .Property(e => e.STATUS)
                .IsUnicode(false);

            modelBuilder.Entity<CATALOGO_MEDICAMENTOS>()
                .HasMany(e => e.DETALLE_MATER_ENFERMERAS)
                .WithRequired(e => e.CATALOGO_MEDICAMENTOS)
                .HasForeignKey(e => e.MATERIALID);

            modelBuilder.Entity<CATALOGO_MEDICAMENTOS>()
                .HasMany(e => e.DETALLE_COMPRAS)
                .WithRequired(e => e.CATALOGO_MEDICAMENTOS)
                .HasForeignKey(e => e.MEDICAMENTOID);

            modelBuilder.Entity<CATALOGO_MEDICAMENTOS>()
                .HasMany(e => e.DETALLE_VENTAS)
                .WithRequired(e => e.CATALOGO_MEDICAMENTOS)
                .HasForeignKey(e => e.MEDICAMENTOID);

            modelBuilder.Entity<CATALOGO_MEDICAMENTOS>()
                .HasMany(e => e.DETALLE_SUMINISTROS_MEDICAMENTOS)
                .WithRequired(e => e.CATALOGO_MEDICAMENTOS)
                .HasForeignKey(e => e.MEDICAMENTOID);

            modelBuilder.Entity<CATALOGO_MEDICAMENTOS>()
                .HasMany(e => e.DEVOLUCIONES)
                .WithRequired(e => e.CATALOGO_MEDICAMENTOS)
                .HasForeignKey(e => e.MEDICMANETOID);

            modelBuilder.Entity<CIRUGIA>()
                .Property(e => e.DESCRIPCION)
                .IsUnicode(false);

            modelBuilder.Entity<CIRUGIA>()
                .Property(e => e.TOTAL)
                .HasPrecision(10, 3);

            modelBuilder.Entity<CLASIFICACION_ESTUDIOS>()
                .Property(e => e.NOMBRE)
                .IsUnicode(false);

            modelBuilder.Entity<CLASIFICACION_ESTUDIOS>()
                .Property(e => e.STATUS)
                .IsUnicode(false);

            modelBuilder.Entity<COMPRA>()
                .Property(e => e.COMENTARIO)
                .IsUnicode(false);

            modelBuilder.Entity<COMPRA>()
                .Property(e => e.IMPORTE)
                .HasPrecision(10, 3);

            modelBuilder.Entity<COMPRA>()
                .Property(e => e.IVA)
                .HasPrecision(10, 3);

            modelBuilder.Entity<COMPRA>()
                .Property(e => e.TOTAL)
                .HasPrecision(10, 3);

            modelBuilder.Entity<COMPRA>()
                .HasMany(e => e.DETALLE_COMPRAS)
                .WithRequired(e => e.COMPRA)
                .HasForeignKey(e => e.COMPRAID);

            modelBuilder.Entity<CONSULTA>()
                .Property(e => e.COSTO)
                .HasPrecision(10, 3);

            modelBuilder.Entity<CONSULTA>()
                .Property(e => e.NOM_PACIENTE)
                .IsUnicode(false);

            modelBuilder.Entity<CONSULTA>()
                .Property(e => e.DIAGNOSTICO)
                .IsUnicode(false);

            modelBuilder.Entity<CONSULTA>()
                .Property(e => e.DESCRIPCION)
                .IsUnicode(false);

            modelBuilder.Entity<CONSULTA>()
                .Property(e => e.MEDICAMENTOS)
                .IsUnicode(false);

            modelBuilder.Entity<CONSULTA>()
                .Property(e => e.TALLA)
                .HasPrecision(10, 2);

            modelBuilder.Entity<CONSULTA>()
                .Property(e => e.PESO)
                .HasPrecision(10, 3);

            modelBuilder.Entity<CONSULTA>()
                .Property(e => e.TEMPERATURA)
                .HasPrecision(10, 2);

            modelBuilder.Entity<CONSULTA>()
                .Property(e => e.ALERGIAS)
                .IsUnicode(false);

            modelBuilder.Entity<CONSULTA>()
                .Property(e => e.P_ARTERIAL)
                .HasPrecision(10, 2);

            modelBuilder.Entity<CONSULTA>()
                .Property(e => e.GLUCOSA)
                .HasPrecision(10, 2);

            modelBuilder.Entity<CONSULTA>()
                .Property(e => e.STATUS)
                .IsUnicode(false);

            modelBuilder.Entity<CUARTO>()
                .Property(e => e.TOTAL)
                .HasPrecision(10, 3);

            modelBuilder.Entity<CUENTA>()
                .Property(e => e.TOTAL)
                .HasPrecision(10, 3);

            modelBuilder.Entity<CUENTA>()
                .Property(e => e.ESTADO)
                .IsUnicode(false);

            modelBuilder.Entity<CUENTA>()
                .Property(e => e.SALDO)
                .HasPrecision(10, 3);

            modelBuilder.Entity<CUENTA>()
                .Property(e => e.IVA)
                .HasPrecision(10, 3);

            modelBuilder.Entity<CUENTA>()
                .HasMany(e => e.CIRUGIAS)
                .WithRequired(e => e.CUENTA)
                .HasForeignKey(e => e.CUENTAID);

            modelBuilder.Entity<CUENTA>()
                .HasMany(e => e.CUARTOS)
                .WithRequired(e => e.CUENTA)
                .HasForeignKey(e => e.CUENTAID);

            modelBuilder.Entity<CUENTA>()
                .HasMany(e => e.DEPOSITOS)
                .WithOptional(e => e.CUENTA)
                .HasForeignKey(e => e.CUENTAID)
                .WillCascadeOnDelete();

            modelBuilder.Entity<CUENTA>()
                .HasMany(e => e.DEVOLUCIONES)
                .WithOptional(e => e.CUENTA)
                .HasForeignKey(e => e.CUENTAID);

            modelBuilder.Entity<CUENTA>()
                .HasMany(e => e.EQUIPO_HOSPITAL)
                .WithRequired(e => e.CUENTA)
                .HasForeignKey(e => e.CUENTAID);

            modelBuilder.Entity<CUENTA>()
                .HasMany(e => e.ESTUDIOS)
                .WithOptional(e => e.CUENTA)
                .HasForeignKey(e => e.CUENTAID)
                .WillCascadeOnDelete();

            modelBuilder.Entity<CUENTA>()
                .HasMany(e => e.MEDICOS_TRATANTES)
                .WithRequired(e => e.CUENTA)
                .HasForeignKey(e => e.CUENTAID);

            modelBuilder.Entity<CUENTA>()
                .HasMany(e => e.SUMINISTROS_MEDICAMENTOS)
                .WithRequired(e => e.CUENTA)
                .HasForeignKey(e => e.CUENTAID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DEPOSITO>()
                .Property(e => e.MONTO)
                .HasPrecision(10, 3);

            modelBuilder.Entity<DEPOSITO>()
                .Property(e => e.CONCEPTO)
                .IsUnicode(false);

            modelBuilder.Entity<DEPOSITO>()
                .Property(e => e.COMENTARIO)
                .IsUnicode(false);

            modelBuilder.Entity<DETALLE_COMPRAS>()
                .Property(e => e.COSTO_UNITARIO)
                .HasPrecision(10, 3);

            modelBuilder.Entity<DETALLE_COMPRAS>()
                .Property(e => e.U_MEDIDA)
                .IsUnicode(false);

            modelBuilder.Entity<DETALLE_COMPRAS>()
                .Property(e => e.SUBTOTAL)
                .HasPrecision(10, 3);

            modelBuilder.Entity<DETALLE_COMPRAS>()
                .Property(e => e.ALMACEN)
                .IsUnicode(false);

            modelBuilder.Entity<DETALLE_COMPRAS>()
                .Property(e => e.NOMEDI)
                .IsUnicode(false);

            modelBuilder.Entity<DETALLE_EQUIPO_HOSPITAL>()
                .Property(e => e.COSTO)
                .HasPrecision(10, 3);

            modelBuilder.Entity<DETALLE_ESTUDIOS>()
                .Property(e => e.COSTO)
                .HasPrecision(10, 3);

            modelBuilder.Entity<DETALLE_ESTUDIOS>()
                .Property(e => e.SUBTOTAL)
                .HasPrecision(10, 3);

            modelBuilder.Entity<DETALLE_MATER_DOCTORES>()
                .Property(e => e.COSTO)
                .HasPrecision(10, 3);

            modelBuilder.Entity<DETALLE_MATER_ENFERMERAS>()
                .Property(e => e.COSTO)
                .HasPrecision(10, 3);

            modelBuilder.Entity<DETALLE_MATER_ENFERMERAS>()
                .Property(e => e.SUBTOTAL)
                .HasPrecision(10, 3);

            modelBuilder.Entity<DETALLE_SUMINISTROS_MEDICAMENTOS>()
                .Property(e => e.PRECIO)
                .HasPrecision(10, 3);

            modelBuilder.Entity<DETALLE_SUMINISTROS_MEDICAMENTOS>()
                .Property(e => e.IVA)
                .HasPrecision(10, 3);

            modelBuilder.Entity<DETALLE_VENTAS>()
                .Property(e => e.COSTO)
                .HasPrecision(10, 3);

            modelBuilder.Entity<DETALLE_VENTAS>()
                .Property(e => e.NOMMEDICAMENTO)
                .IsUnicode(false);

            modelBuilder.Entity<DETALLE_VENTAS>()
                .Property(e => e.SUBTOTAL)
                .HasPrecision(10, 3);

            modelBuilder.Entity<DIAGNOSTICO>()
                .Property(e => e.DIAGNOSTICO1)
                .IsUnicode(false);

            modelBuilder.Entity<EMPLEADO>()
                .Property(e => e.PUESTO)
                .IsUnicode(false);

            modelBuilder.Entity<EMPLEADO>()
                .HasMany(e => e.USUARIOS)
                .WithRequired(e => e.EMPLEADO)
                .HasForeignKey(e => e.EMPLEADOID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ENFERMERA>()
                .Property(e => e.C_PROFESIONAL)
                .IsUnicode(false);

            modelBuilder.Entity<ENFERMERA>()
                .HasMany(e => e.ESPECIALIDADES_ENFERMERAS)
                .WithRequired(e => e.ENFERMERA)
                .HasForeignKey(e => e.ENFERMERAID);

            modelBuilder.Entity<ENFERMERA>()
                .HasMany(e => e.ENFERMERAS_TRATANTES)
                .WithRequired(e => e.ENFERMERA)
                .HasForeignKey(e => e.ENFERMERAID);

            modelBuilder.Entity<ENFERMERA>()
                .HasMany(e => e.MATERIALES_ENFERMERAS)
                .WithRequired(e => e.ENFERMERA)
                .HasForeignKey(e => e.ENFERMERAID);

            modelBuilder.Entity<ENFERMERA>()
                .HasMany(e => e.SUMINISTROS_MEDICAMENTOS)
                .WithRequired(e => e.ENFERMERA)
                .HasForeignKey(e => e.ENFERMERAID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<EQUIPO_HOSPITAL>()
                .Property(e => e.TOTAL)
                .HasPrecision(10, 3);

            modelBuilder.Entity<EQUIPO_HOSPITAL>()
                .HasMany(e => e.DETALLE_EQUIPO_HOSPITAL)
                .WithOptional(e => e.EQUIPO_HOSPITAL)
                .HasForeignKey(e => e.EQUIPO_HOSPITALID)
                .WillCascadeOnDelete();

            modelBuilder.Entity<ESTADO>()
                .Property(e => e.clave)
                .IsUnicode(false);

            modelBuilder.Entity<ESTADO>()
                .Property(e => e.nombre)
                .IsUnicode(false);

            modelBuilder.Entity<ESTADO>()
                .Property(e => e.abrev)
                .IsUnicode(false);

            modelBuilder.Entity<ESTADO>()
                .HasMany(e => e.MUNICIPIOS)
                .WithRequired(e => e.ESTADO)
                .HasForeignKey(e => e.estado_id);

            modelBuilder.Entity<ESTADO>()
                .HasMany(e => e.PERSONAS)
                .WithOptional(e => e.ESTADO1)
                .HasForeignKey(e => e.ESTADO)
                .WillCascadeOnDelete();

            modelBuilder.Entity<ESTADOS_PERSONAS>()
                .Property(e => e.ESTADO)
                .IsUnicode(false);

            modelBuilder.Entity<ESTUDIO>()
                .Property(e => e.TOTAL)
                .HasPrecision(10, 3);

            modelBuilder.Entity<ESTUDIO>()
                .Property(e => e.CARGO_EXTRA)
                .HasPrecision(10, 3);

            modelBuilder.Entity<ESTUDIO>()
                .Property(e => e.MEDICO_SOLICITANTE)
                .IsUnicode(false);

            modelBuilder.Entity<ESTUDIO>()
                .Property(e => e.PACIENTE_SOLICITANTE)
                .IsUnicode(false);

            modelBuilder.Entity<ESTUDIO>()
                .HasMany(e => e.DETALLE_ESTUDIOS)
                .WithOptional(e => e.ESTUDIO)
                .HasForeignKey(e => e.ESTUDIOSID)
                .WillCascadeOnDelete();

            modelBuilder.Entity<FAM_RESPONSABLES>()
                .Property(e => e.PARENTESCO)
                .IsUnicode(false);

            modelBuilder.Entity<HONORARIOS_MEDICOS>()
                .Property(e => e.HONORIARIO)
                .HasPrecision(10, 3);

            modelBuilder.Entity<HONORARIOS_MEDICOS>()
                .Property(e => e.TOTAL)
                .HasPrecision(10, 3);

            modelBuilder.Entity<LOCALIDADE>()
                .Property(e => e.clave)
                .IsUnicode(false);

            modelBuilder.Entity<LOCALIDADE>()
                .Property(e => e.nombre)
                .IsUnicode(false);

            modelBuilder.Entity<LOCALIDADE>()
                .Property(e => e.latitud)
                .IsUnicode(false);

            modelBuilder.Entity<LOCALIDADE>()
                .Property(e => e.longitud)
                .IsUnicode(false);

            modelBuilder.Entity<LOCALIDADE>()
                .Property(e => e.lat)
                .HasPrecision(10, 7);

            modelBuilder.Entity<LOCALIDADE>()
                .Property(e => e.lng)
                .HasPrecision(10, 7);

            modelBuilder.Entity<LOCALIDADE>()
                .Property(e => e.altitud)
                .IsUnicode(false);

            modelBuilder.Entity<MATERIALES_DOCTORES>()
                .Property(e => e.TOTAL)
                .HasPrecision(10, 3);

            modelBuilder.Entity<MATERIALES_DOCTORES>()
                .HasMany(e => e.DETALLE_MATER_DOCTORES)
                .WithRequired(e => e.MATERIALES_DOCTORES)
                .HasForeignKey(e => e.MATERIALES_DOCTORESID);

            modelBuilder.Entity<MATERIALES_ENFERMERAS>()
                .Property(e => e.TOTAL)
                .HasPrecision(10, 3);

            modelBuilder.Entity<MATERIALES_ENFERMERAS>()
                .HasMany(e => e.DETALLE_MATER_ENFERMERAS)
                .WithRequired(e => e.MATERIALES_ENFERMERAS)
                .HasForeignKey(e => e.MATERIALES_ENFERMERASID);

            modelBuilder.Entity<Medico>()
                .Property(e => e.T_CONSULTORIO)
                .IsUnicode(false);

            modelBuilder.Entity<Medico>()
                .Property(e => e.T_PARTICULAR)
                .IsUnicode(false);

            modelBuilder.Entity<Medico>()
                .Property(e => e.CORREO)
                .IsUnicode(false);

            modelBuilder.Entity<Medico>()
                .Property(e => e.C_PROFESIONAL)
                .IsUnicode(false);

            modelBuilder.Entity<Medico>()
                .HasMany(e => e.CIRUGIAS)
                .WithRequired(e => e.Medico)
                .HasForeignKey(e => e.MEDICOID);

            modelBuilder.Entity<Medico>()
                .HasMany(e => e.CONSULTAS)
                .WithRequired(e => e.Medico)
                .HasForeignKey(e => e.MEDICOID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Medico>()
                .HasMany(e => e.CUARTOS)
                .WithRequired(e => e.Medico)
                .HasForeignKey(e => e.MEDICOID);

            modelBuilder.Entity<Medico>()
                .HasMany(e => e.EQUIPO_HOSPITAL)
                .WithRequired(e => e.Medico)
                .HasForeignKey(e => e.MEDICOID);

            modelBuilder.Entity<Medico>()
                .HasMany(e => e.ESPECIALIDADES)
                .WithRequired(e => e.Medico)
                .HasForeignKey(e => e.MEDICOID);

            modelBuilder.Entity<Medico>()
                .HasMany(e => e.ESTUDIOS)
                .WithOptional(e => e.Medico)
                .HasForeignKey(e => e.MEDICOID)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Medico>()
                .HasMany(e => e.HONORARIOS_MEDICOS)
                .WithRequired(e => e.Medico)
                .HasForeignKey(e => e.MEDICOID);

            modelBuilder.Entity<Medico>()
                .HasMany(e => e.MATERIALES_DOCTORES)
                .WithRequired(e => e.Medico)
                .HasForeignKey(e => e.DOCTORID);

            modelBuilder.Entity<Medico>()
                .HasMany(e => e.MEDICOS_TRATANTES)
                .WithRequired(e => e.Medico)
                .HasForeignKey(e => e.MEDICOID);

            modelBuilder.Entity<MEDICOS_TRATANTES>()
                .HasMany(e => e.DIAGNOSTICOS)
                .WithRequired(e => e.MEDICOS_TRATANTES)
                .HasForeignKey(e => e.MEDICO_TRATANTEID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MUNICIPIO>()
                .Property(e => e.clave)
                .IsUnicode(false);

            modelBuilder.Entity<MUNICIPIO>()
                .Property(e => e.nombre)
                .IsUnicode(false);

            modelBuilder.Entity<MUNICIPIO>()
                .HasMany(e => e.LOCALIDADES)
                .WithRequired(e => e.MUNICIPIO)
                .HasForeignKey(e => e.municipio_id);

            modelBuilder.Entity<PACIENTE>()
                .Property(e => e.TIPO_PACIENTE)
                .IsUnicode(false);

            modelBuilder.Entity<PACIENTE>()
                .HasMany(e => e.CONSULTAS)
                .WithOptional(e => e.PACIENTE)
                .HasForeignKey(e => e.PACIENTEID);

            modelBuilder.Entity<PACIENTE>()
                .HasMany(e => e.CUENTAS)
                .WithRequired(e => e.PACIENTE)
                .HasForeignKey(e => e.PACIENTEID);

            modelBuilder.Entity<PACIENTE>()
                .HasMany(e => e.ENFERMERAS_TRATANTES)
                .WithRequired(e => e.PACIENTE)
                .HasForeignKey(e => e.PACIENTEID);

            modelBuilder.Entity<PACIENTE>()
                .HasMany(e => e.FAM_RESPONSABLES)
                .WithRequired(e => e.PACIENTE)
                .HasForeignKey(e => e.PACIENTEID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PACIENTE>()
                .HasMany(e => e.HONORARIOS_MEDICOS)
                .WithRequired(e => e.PACIENTE)
                .HasForeignKey(e => e.PACIENTEID);

            modelBuilder.Entity<PERMISO>()
                .Property(e => e.NOM_PERMISO)
                .IsUnicode(false);

            modelBuilder.Entity<PERMISO>()
                .Property(e => e.DESCIPCION)
                .IsUnicode(false);

            modelBuilder.Entity<PERMISO>()
                .Property(e => e.MODULOS)
                .IsUnicode(false);

            modelBuilder.Entity<PERMISO>()
                .Property(e => e.ROL)
                .IsUnicode(false);

            modelBuilder.Entity<PERMISO>()
                .HasMany(e => e.USUARIOS)
                .WithRequired(e => e.PERMISO)
                .HasForeignKey(e => e.PERMISOSID);

            modelBuilder.Entity<PERSONA>()
                .Property(e => e.NOMBRE)
                .IsUnicode(false);

            modelBuilder.Entity<PERSONA>()
                .Property(e => e.CURP)
                .IsUnicode(false);

            modelBuilder.Entity<PERSONA>()
                .Property(e => e.A_PATERNO)
                .IsUnicode(false);

            modelBuilder.Entity<PERSONA>()
                .Property(e => e.A_MATERNO)
                .IsUnicode(false);

            modelBuilder.Entity<PERSONA>()
                .Property(e => e.SEXO)
                .IsUnicode(false);

            modelBuilder.Entity<PERSONA>()
                .Property(e => e.T_CELULAR)
                .IsUnicode(false);

            modelBuilder.Entity<PERSONA>()
                .Property(e => e.CALLE)
                .IsUnicode(false);

            modelBuilder.Entity<PERSONA>()
                .Property(e => e.NOMMUNICIPIO)
                .IsUnicode(false);

            modelBuilder.Entity<PERSONA>()
                .Property(e => e.NOMLOCALIDAD)
                .IsUnicode(false);

            modelBuilder.Entity<PERSONA>()
                .Property(e => e.ESTADOPERSONA)
                .IsUnicode(false);

            modelBuilder.Entity<PERSONA>()
                .HasMany(e => e.EMPLEADOS)
                .WithRequired(e => e.PERSONA)
                .HasForeignKey(e => e.PERSONAID);

            modelBuilder.Entity<PERSONA>()
                .HasMany(e => e.ENFERMERAS)
                .WithRequired(e => e.PERSONA)
                .HasForeignKey(e => e.PERSONAID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PERSONA>()
                .HasMany(e => e.FAM_RESPONSABLES)
                .WithRequired(e => e.PERSONA)
                .HasForeignKey(e => e.PERSONAID);

            modelBuilder.Entity<PERSONA>()
                .HasMany(e => e.MEDICOS)
                .WithRequired(e => e.PERSONA)
                .HasForeignKey(e => e.PERSONAID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PERSONA>()
                .HasMany(e => e.PACIENTES)
                .WithRequired(e => e.PERSONA)
                .HasForeignKey(e => e.PERSONAID);

            modelBuilder.Entity<PERSONA>()
                .HasMany(e => e.PROVEEDORES)
                .WithRequired(e => e.PERSONA)
                .HasForeignKey(e => e.PERSONAID);

            modelBuilder.Entity<PROVEEDORE>()
                .Property(e => e.NOTA)
                .IsUnicode(false);

            modelBuilder.Entity<PROVEEDORE>()
                .Property(e => e.RFC)
                .IsUnicode(false);

            modelBuilder.Entity<PROVEEDORE>()
                .HasMany(e => e.COMPRAS)
                .WithRequired(e => e.PROVEEDORE)
                .HasForeignKey(e => e.PROVEEDORID);

            modelBuilder.Entity<SUMINISTROS_MEDICAMENTOS>()
                .Property(e => e.TOTAL)
                .HasPrecision(10, 3);

            modelBuilder.Entity<SUMINISTROS_MEDICAMENTOS>()
                .HasMany(e => e.DETALLE_SUMINISTROS_MEDICAMENTOS)
                .WithRequired(e => e.SUMINISTROS_MEDICAMENTOS)
                .HasForeignKey(e => e.SUMINISTRO_MEDICAMENTOID);

            modelBuilder.Entity<USUARIO>()
                .Property(e => e.CONTRASENA)
                .IsUnicode(false);

            modelBuilder.Entity<USUARIO>()
                .HasMany(e => e.CIRUGIAS)
                .WithOptional(e => e.USUARIO)
                .HasForeignKey(e => e.USUARIOID)
                .WillCascadeOnDelete();

            modelBuilder.Entity<USUARIO>()
                .HasMany(e => e.COMPRAS)
                .WithRequired(e => e.USUARIO)
                .HasForeignKey(e => e.USUARIOID);

            modelBuilder.Entity<USUARIO>()
                .HasMany(e => e.CONSULTAS)
                .WithOptional(e => e.USUARIO)
                .HasForeignKey(e => e.USUARIOID);

            modelBuilder.Entity<USUARIO>()
                .HasMany(e => e.DEPOSITOS)
                .WithRequired(e => e.USUARIO)
                .HasForeignKey(e => e.USUARIOID);

            modelBuilder.Entity<USUARIO>()
                .HasMany(e => e.DEVOLUCIONES)
                .WithRequired(e => e.USUARIO)
                .HasForeignKey(e => e.USUARIOID);

            modelBuilder.Entity<USUARIO>()
                .HasMany(e => e.EQUIPO_HOSPITAL)
                .WithOptional(e => e.USUARIO)
                .HasForeignKey(e => e.USUARIOID)
                .WillCascadeOnDelete();

            modelBuilder.Entity<USUARIO>()
                .HasMany(e => e.ESTUDIOS)
                .WithOptional(e => e.USUARIO)
                .HasForeignKey(e => e.USUARIOID);

            modelBuilder.Entity<USUARIO>()
                .HasMany(e => e.HONORARIOS_MEDICOS)
                .WithRequired(e => e.USUARIO)
                .HasForeignKey(e => e.USUARIOID);

            modelBuilder.Entity<USUARIO>()
                .HasMany(e => e.MATERIALES_DOCTORES)
                .WithRequired(e => e.USUARIO)
                .HasForeignKey(e => e.USUARIOID);

            modelBuilder.Entity<USUARIO>()
                .HasMany(e => e.MATERIALES_ENFERMERAS)
                .WithRequired(e => e.USUARIO)
                .HasForeignKey(e => e.USUARIOID);

            modelBuilder.Entity<USUARIO>()
                .HasMany(e => e.VENTAS_GENERALES)
                .WithRequired(e => e.USUARIO)
                .HasForeignKey(e => e.USUARIOID);

            modelBuilder.Entity<VENTAS_GENERALES>()
                .Property(e => e.TOTAL)
                .HasPrecision(10, 3);

            modelBuilder.Entity<VENTAS_GENERALES>()
                .Property(e => e.IMPORTE)
                .HasPrecision(10, 3);

            modelBuilder.Entity<VENTAS_GENERALES>()
                .Property(e => e.IVA)
                .HasPrecision(10, 3);

            modelBuilder.Entity<VENTAS_GENERALES>()
                .Property(e => e.DESCUENTO)
                .HasPrecision(10, 3);

            modelBuilder.Entity<VENTAS_GENERALES>()
                .Property(e => e.CLIENTE)
                .IsUnicode(false);

            modelBuilder.Entity<VENTAS_GENERALES>()
                .HasMany(e => e.DETALLE_VENTAS)
                .WithRequired(e => e.VENTAS_GENERALES)
                .HasForeignKey(e => e.VENTAID);
        }
    }
}
