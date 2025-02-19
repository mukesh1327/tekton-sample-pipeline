
# Tekton CI CD pipeline build

In this demo a todo application is built using spring boot with postgresql and deployed in openshift platform using tekton pipeline

Endpoints to try 

POST /api/tasks/create (to create a task)

    {
        "name": "Test Task",
        "description": "This is a sample task",
        "status": "PENDING",
        "dueDate": "2025-02-19T00:00:00Z"
    }


GET /api/tasks/read (to get all tasks)


GET /api/tasks/get/{taskId} (to get a task by ID)


PUT /api/tasks/update/{taskId} (to update a task)

    {
    "title": "Updated Task",
    "description": "Updated description"
    }

DELETE /api/tasks/delete/{taskId} (to delete a task)


## Using Helm Charts

<!-- helm upgrade --wait --install --namespace "vps-apps" todo-app spring-boot-todo-app-pipeline/helm  --debug --set replicaCount=3,image.tag=add99de -->