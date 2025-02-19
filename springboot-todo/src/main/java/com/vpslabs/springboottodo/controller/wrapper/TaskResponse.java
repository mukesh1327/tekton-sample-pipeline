package com.vpslabs.springboottodo.controller.wrapper;

import com.vpslabs.springboottodo.model.dto.TasksDto;

public class TaskResponse {
    private TasksDto tasksDto;
    private String message;

    public void setTaskDto(TasksDto tasksDto) {
        this.tasksDto = tasksDto;
    }

    public TasksDto getTaskDto() {
        return tasksDto;
    }

    public void setMessage(String message) {
        this.message = message;
    }

    public String getMessage() {
        return message;
    }

}
