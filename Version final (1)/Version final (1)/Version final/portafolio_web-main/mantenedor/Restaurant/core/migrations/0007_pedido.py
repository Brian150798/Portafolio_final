# Generated by Django 4.1.5 on 2023-01-19 04:08

from django.db import migrations, models
import django.db.models.deletion


class Migration(migrations.Migration):

    dependencies = [
        ('core', '0006_alter_bodega_idproducto_alter_categoria_idcategoria_and_more'),
    ]

    operations = [
        migrations.CreateModel(
            name='Pedido',
            fields=[
                ('idPedido', models.AutoField(primary_key=True, serialize=False, verbose_name='id de pedido')),
                ('nombrePedido', models.CharField(max_length=70, verbose_name='Nombre del pedido')),
                ('nplato', models.ForeignKey(on_delete=django.db.models.deletion.CASCADE, to='core.plato')),
            ],
        ),
    ]
