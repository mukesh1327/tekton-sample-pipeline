from pytz import timezone
from rest_framework import serializers
from .models import tasks

class tasksSerializer(serializers.ModelSerializer):
    status = serializers.CharField(default='IN_PROGRESS', read_only=True)
    createdAt = serializers.DateTimeField(format='%Y-%m-%dT%H:%M:%SZ', read_only=True)
    updatedAt = serializers.DateTimeField(format='%Y-%m-%dT%H:%M:%SZ', read_only=True)

    class Meta:
        model = tasks
        fields = ['id', 'name', 'description', 'dueDate', 'status', 'createdAt', 'updatedAt']
        
    def validate_status(self, value):
        # Add custom validation logic if needed
        return value

    def update(self, instance, validated_data):
        # Allow partial updates and update fields with default values
        for attr, value in validated_data.items():
            setattr(instance, attr, value)
        instance.save()
        return instance