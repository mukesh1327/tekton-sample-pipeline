from django.db import models

# Create your models here.

class tasks(models.Model):

    class Meta:
        db_table = 'tasks'

    # Unique auto-generated ID starting from 1
    id = models.AutoField(primary_key=True)

    # Unique name field
    name = models.CharField(max_length=255, unique=True)

    # Description field
    description = models.TextField()

    # Status field with enum choices
    STATUS_CHOICES = (
        ('PENDING', 'PENDING'),
        ('IN_PROGRESS', 'IN_PROGRESS'),
        ('DONE', 'DONE'),
        ('DROPPED', 'DROPPED'),
        ('KILLED', 'KILLED'),
    )
      
    status = models.CharField(max_length=20, choices=STATUS_CHOICES,  default='IN_PROGRESS')

    # Due date field
    dueDate = models.DateField()

    # Created at field (auto-generated at creation)
    createdAt = models.DateTimeField(auto_now_add=True)

    # Updated at field (auto-generated at update)
    updatedAt = models.DateTimeField(auto_now=True)

    def __str__(self):
        return self.name