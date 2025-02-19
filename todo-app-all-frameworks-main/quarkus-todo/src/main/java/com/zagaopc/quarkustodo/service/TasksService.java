package com.zagaopc.quarkustodo.service;

import java.util.List;

import com.zagaopc.quarkustodo.model.entity.Tasks;

import jakarta.ws.rs.core.Response;

public interface TasksService {
    Tasks createTask(Tasks task);
    List<Tasks> getAllTasks();
    Tasks getTaskById(Integer id);
    Tasks updateTask(Integer id, Tasks updatedTask);
    Response deleteTask(Integer id);
}
