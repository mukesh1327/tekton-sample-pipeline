package com.zagaopc.springboottodo.model.dto;

import java.util.Date;

import com.zagaopc.springboottodo.model.entity.TasksStatusEnum;

import lombok.Data;

@Data
public class TasksDto {
    private long id;
    private String name;
    private String description;
    private TasksStatusEnum status;
    private Date dueDate;
    private Date createdAt;
    private Date updatedAt;
}
