# Generated by Django 4.1.5 on 2023-01-22 10:21

from django.db import migrations, models


class Migration(migrations.Migration):

    dependencies = [
        ('core', '0010_alter_receta_descripcion'),
    ]

    operations = [
        migrations.AlterField(
            model_name='receta',
            name='descripcion',
            field=models.CharField(max_length=70, verbose_name='Descripcion de lareceta'),
        ),
    ]