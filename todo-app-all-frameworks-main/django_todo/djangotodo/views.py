from django.shortcuts import render

from rest_framework import status
from rest_framework.response import Response
from rest_framework.decorators import api_view
from .models import tasks
from .serializers import tasksSerializer

@api_view(['POST'])
def create_todo_task(request):
    if request.method == 'POST':
        serializer = tasksSerializer(data=request.data)
        if serializer.is_valid():
            serializer.save()
            return Response(serializer.data, status=status.HTTP_201_CREATED)
        return Response(serializer.errors, status=status.HTTP_400_BAD_REQUEST)
    

@api_view(['GET'])
def get_all_tasks(request):
    if request.method == 'GET':
        # Retrieve all tasks from the database
        all_tasks = tasks.objects.all()
        
        # Serialize the tasks using the tasksSerializer
        serializer = tasksSerializer(all_tasks, many=True)
        
        # Return the serialized tasks in the response
        return Response(serializer.data, status=status.HTTP_200_OK)
    

@api_view(['GET'])
def get_task_by_id(request, task_id):
    try:
        # Retrieve the task from the database by its ID
        task = tasks.objects.get(id=task_id)
    except tasks.DoesNotExist:
        return Response({"detail": "Task not found"}, status=status.HTTP_404_NOT_FOUND)

    if request.method == 'GET':
        # Serialize the task using the tasksSerializer
        serializer = tasksSerializer(task)
        
        # Return the serialized task in the response
        return Response(serializer.data, status=status.HTTP_200_OK)
    
    
@api_view(['PUT'])
def update_task_by_id(request, task_id):
    try:
        # Retrieve the task from the database by its ID
        task = tasks.objects.get(id=task_id)
    except tasks.DoesNotExist:
        return Response({"detail": "Task not found"}, status=status.HTTP_404_NOT_FOUND)

    if request.method == 'PUT':
        # Check if the 'name' field is being updated, which should not be allowed
        if 'name' in request.data:
            return Response({"detail": "Cannot update 'name' field"}, status=status.HTTP_400_BAD_REQUEST)

        # Explicitly handle the 'status' field and set its value
        if 'status' in request.data:
            task.status = request.data['status']

        # Serialize the task instance with the provided data
        serializer = tasksSerializer(instance=task, data=request.data, partial=True)

        if serializer.is_valid():
            serializer.save()
            return Response(serializer.data, status=status.HTTP_200_OK)
        return Response(serializer.errors, status=status.HTTP_400_BAD_REQUEST)
    
    
    
@api_view(['DELETE'])
def delete_task_by_id(request, task_id):
    try:
        # Retrieve the task from the database by its ID
        task = tasks.objects.get(id=task_id)
    except tasks.DoesNotExist:
        return Response({"detail": "Task not found"}, status=status.HTTP_404_NOT_FOUND)

    if request.method == 'DELETE':
        # Delete the task
        task.delete()
        return Response({"detail": "Task deleted successfully"}, status=status.HTTP_204_NO_CONTENT)