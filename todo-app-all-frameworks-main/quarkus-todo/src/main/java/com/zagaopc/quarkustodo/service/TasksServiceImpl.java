package com.zagaopc.quarkustodo.service;

import java.util.List;

import com.zagaopc.quarkustodo.exception.TasksExceptions;
import com.zagaopc.quarkustodo.model.entity.Tasks;
import com.zagaopc.quarkustodo.model.entity.TasksStatusEnum;
import com.zagaopc.quarkustodo.repository.TasksRepository;

import jakarta.enterprise.context.ApplicationScoped;
import jakarta.inject.Inject;
import jakarta.transaction.Transactional;
import jakarta.ws.rs.core.Response;
import jakarta.ws.rs.core.Response.Status;

@ApplicationScoped
public class TasksServiceImpl implements TasksService {

    @Inject
    TasksRepository tasksRepository;

    @Transactional
    @Override
    public Tasks createTask(Tasks task) {
        isTaskNameExists(task.getName());
        task.setCreatedAt();
        task.setUpdatedAt();
        task.setStatus(TasksStatusEnum.IN_PROGRESS);
        tasksRepository.persist(task);
        return task;
    }

    @Override
    public List<Tasks> getAllTasks() {
        isTasksExists();
        return tasksRepository.listAll();
    }

    @Override
    public Tasks getTaskById(Integer id) {
        isTaskIdExists(id);
        return tasksRepository.findById(id);
    }

    @Override
    @Transactional
    public Tasks updateTask(Integer id, Tasks updatedTask) {
        isTaskIdExists(id);
        // checkNamewithId(id,updatedTask);
        Tasks existingTask = tasksRepository.findById(id);
        existingTask.setDescription(updatedTask.getDescription());
        existingTask.setStatus(updatedTask.getStatus());
        existingTask.setDueDate(updatedTask.getDueDate());
        tasksRepository.persist(existingTask);
        return existingTask;
    }

    @Override
    @Transactional
    public Response deleteTask(Integer id) {
        isTaskIdExists(id);
        Tasks existingTask = tasksRepository.findById(id);
        tasksRepository.delete(existingTask);
        return Response.status(Status.OK).header("Content-Type", "application/json").entity("Task has been deleted").build();
    }


// Error handling

    private boolean isTaskNameExists(String name) {
        boolean taskNameExists = tasksRepository.existsByName(name);
        if (taskNameExists) {
            throw new TasksExceptions("Name " + name + " already exists", Response.Status.CONFLICT, null);
        }
        return false;
    }

    private boolean isTasksExists() {
        List<Tasks> tasksExists = tasksRepository.listAll();
        if (tasksExists.isEmpty()) {
            throw new TasksExceptions("No tasks exists", Response.Status.OK, null);
        }
        return false;
    }

    private boolean isTaskIdExists(Integer id) {
        Tasks taskIdExists = tasksRepository.findById(id);
        if (taskIdExists == null) {
            throw new TasksExceptions("Id " + id + " not exists", Response.Status.NOT_FOUND, null);
        }
        return false;
    }    

}
