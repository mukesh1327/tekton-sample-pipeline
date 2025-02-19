package com.vpslabs.springboottodo.service;

import java.util.List;

import com.vpslabs.springboottodo.controller.wrapper.TaskResponse;
import com.vpslabs.springboottodo.model.dto.TasksDto;
import com.vpslabs.springboottodo.model.entity.Tasks;

public interface TasksService {
    TasksDto convertToDTO(Tasks task);
    TaskResponse createTask(TasksDto taskDTO);
    TaskResponse getTaskById(Integer taskId);
    TasksDto updateTask(Integer taskId, TasksDto taskDTO);
    void deleteTask(Integer taskId);
    List<TasksDto> getAllTasks();
}
