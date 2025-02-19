from django.urls import path
from .views import create_todo_task, delete_task_by_id, get_all_tasks, get_task_by_id, update_task_by_id

urlpatterns = [
    path('create', create_todo_task, name='create-task'),
    path('read', get_all_tasks, name='get-all-tasks'),
    path('get/<int:task_id>/', get_task_by_id, name='get-task-by-id'),
    path('update/<int:task_id>/', update_task_by_id, name='update-task-by-id'),
    path('delete/<int:task_id>/', delete_task_by_id, name='delete-task-by-id'), 
]