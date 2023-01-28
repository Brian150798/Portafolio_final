from django.db import models

# Create your models here.
class Categoria(models.Model):
    idCategoria = models.AutoField(primary_key=True,verbose_name="id de Categoria")
    nombreCategoria = models.CharField(max_length=70,verbose_name="Nombre de la Categoria")
    def __str__(self):
        return self.nombreCategoria


class Plato(models.Model):
    idPlato = models.AutoField(primary_key=True,verbose_name="id de Plato")
    nombrePlato = models.CharField(max_length=70,verbose_name="Nombre del Plato")
    valorPlato = models.IntegerField(verbose_name="Valor del Plato")
    categoria = models.ForeignKey(Categoria, on_delete=models.CASCADE)
    def __str__(self):
        return self.nombrePlato


class Hora(models.Model):
    idHora = models.AutoField(primary_key=True,verbose_name="id de hora")
    nombreHora = models.CharField(max_length=70,verbose_name="Valor de la hora")
    def __str__(self):
        return self.nombreHora

class Fecha(models.Model):
    idFecha = models.AutoField(primary_key=True,verbose_name="id de Fecha")
    nombreFecha = models.CharField(max_length=70,verbose_name="Valor de la Fecha")
    def __str__(self):
        return self.nombreFecha

class Estado(models.Model):
    idEstado = models.AutoField(primary_key=True,verbose_name="id de Estado")
    nombreEstado = models.CharField(max_length=70,verbose_name="Valor de la Estado")
    def __str__(self):
        return self.nombreEstado

class Nmesa(models.Model):
    idNmesa = models.AutoField(primary_key=True,verbose_name="id de Estado")
    nombreNmesa = models.CharField(max_length=70,verbose_name="Valor de la Estado")
    def __str__(self):
        return self.nombreNmesa


class Reservacion(models.Model):
    idReservacion = models.AutoField(primary_key=True,verbose_name="id de Reserva")
    nombreReservacion = models.CharField(max_length=70,verbose_name="Nombre del Reservante")
    hora = models.ForeignKey(Hora, on_delete=models.CASCADE)
    fecha = models.ForeignKey(Fecha, on_delete=models.CASCADE)
    
    class Meta:
        unique_together = (('fecha', 'hora'),)

    def __str__(self):  
        return self.nombrePedido

    def __str__(self):
        return self.nombreReservacion


##########################################

class Bodega(models.Model):
    idProducto = models.AutoField(primary_key=True,verbose_name="id de Producto")
    nombreProducto = models.CharField(max_length=70,verbose_name="Nombre del Producto")
    cantidadProducto = models.CharField(max_length=70,verbose_name="Cantidad de Producto")
    def __str__(self):
        return self.nombreProducto

class Disponible(models.Model):
    idDisponible = models.AutoField(primary_key=True,verbose_name="id de Disponible")
    nombreDisponible = models.CharField(max_length=70,verbose_name="Nombre de Disponible")
    def __str__(self):
        return self.nombreDisponible


class Mesa(models.Model):    
    idMesa = models.AutoField(primary_key=True,verbose_name="id de Mesa")
    numeroMesa = models.CharField(max_length=10,verbose_name="Numero de Mesa")
    ubicacion = models.CharField(max_length=50,verbose_name="Ubicacion")   
    descripcion = models.CharField(max_length=70,verbose_name="Descripcion") 
    disponible = models.ForeignKey(Disponible, on_delete=models.CASCADE)    
    def __str__(self):
        return self.numeroMesa


##################

class Pedido(models.Model):
    idPedido = models.AutoField(primary_key=True,verbose_name="id de pedido")
    numeroMesa = models.ForeignKey(Mesa, on_delete=models.CASCADE, verbose_name="Numero Mesa")
    nplato = models.ForeignKey(Plato, on_delete=models.CASCADE, verbose_name="Nombre del plato")
    estado = models.ForeignKey(Estado, on_delete=models.CASCADE, blank=True,null=True)



class Receta(models.Model):
    idReceta = models.AutoField(primary_key=True,verbose_name="id de receta")
    nombreReceta = models.CharField(max_length=70,verbose_name="Nombre de la receta")
    descripcion = models.TextField(max_length=250,verbose_name="Descripcion de la receta")
    def __str__(self):  
        return self.nombreReceta
    
class Rol(models.Model):
    idRol = models.AutoField(primary_key=True, verbose_name="id rol")
    nombreRol = models.CharField(max_length=30, verbose_name="Nombre Rol")
    def __str__(self):  
        return self.nombreRol

class Usuario(models.Model):    
    idUsuario = models.AutoField(primary_key=True,verbose_name="Identificador")
    nombreUsuario = models.CharField(max_length=70,verbose_name="Nombre")
    aPaterno = models.CharField(max_length=70,verbose_name="Apellido Paterno")
    aMaterno = models.CharField(max_length=70,verbose_name="Apellido Materno")
    correo = models.CharField(max_length=50,verbose_name="Correo Electrónico")
    pasw = models.CharField(max_length=20, blank=False, null= False)
    rol = models.ForeignKey(Rol, on_delete=models.CASCADE)
    def __str__(self):
        return self.nombreUsuario   
 

class Producto(models.Model):    
    idProducto = models.AutoField(primary_key=True,verbose_name="id de Producto")    
    nombreProducto = models.CharField(max_length=70,verbose_name="Nombre de Producto")    
    cantidad = models.CharField(max_length=50,verbose_name="Cantidad")     
    def __str__(self):
        return self.nombreProducto

class Solicitar(models.Model):
    idSolicitar = models.AutoField(primary_key=True,verbose_name="id de Producto")
    nombreSolicitar = models.CharField(max_length=70,verbose_name="Nombre del Producto")
    cantidadSolicitar = models.CharField(max_length=70,verbose_name="Cantidad de Producto")
    def __str__(self):
        return self.nombreSolicitar

class Boleta(models.Model):
    idBoleta = models.AutoField(primary_key=True,verbose_name="id de Boleta")
    numeroMesa = models.ForeignKey(Mesa, on_delete=models.CASCADE, blank=False, null= True) 
    detalleBoleta = models.CharField(max_length=70,verbose_name="Detalle Boleta")
    totalBoleta = models.IntegerField(verbose_name="Total Boleta")
    def __str__(self):
        return self.nombreBoleta
    
    
class Reporte(models.Model):
    CantidadEmpleados = models.IntegerField(verbose_name="cantidad empleados")
    CantidadReservas = models.IntegerField(verbose_name="cantidad reservas")
    TotalVendido = models.IntegerField(verbose_name="total")
    CantidadOrdenes = models.IntegerField(verbose_name="cantida de ordenes")
    CantidadBoletas = models.IntegerField(verbose_name="cantidad de boletas")
    TotalMesas = models.IntegerField(verbose_name="total de mesas")
    Correo = models.CharField(max_length=70,verbose_name="correo")
    def __str__(self):
        return self.nombreReporte
    