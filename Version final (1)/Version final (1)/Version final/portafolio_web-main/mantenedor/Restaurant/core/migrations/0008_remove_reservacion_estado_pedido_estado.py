# Generated by Django 4.1.5 on 2023-01-22 08:18

from django.db import migrations, models
import django.db.models.deletion


class Migration(migrations.Migration):

    dependencies = [
        ('core', '0007_pedido'),
    ]

    operations = [
        migrations.RemoveField(
            model_name='reservacion',
            name='estado',
        ),
        migrations.AddField(
            model_name='pedido',
            name='estado',
            field=models.ForeignKey(blank=True, null=True, on_delete=django.db.models.deletion.CASCADE, to='core.estado'),
        ),
    ]
