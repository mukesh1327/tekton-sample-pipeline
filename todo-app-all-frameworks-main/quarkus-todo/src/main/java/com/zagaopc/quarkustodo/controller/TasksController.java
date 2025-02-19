package com.zagaopc.quarkustodo.controller;

import java.util.List;

import com.zagaopc.quarkustodo.model.entity.Tasks;
import com.zagaopc.quarkustodo.service.TasksService;

import jakarta.inject.Inject;
import jakarta.ws.rs.Consumes;
import jakarta.ws.rs.DELETE;
import jakarta.ws.rs.GET;
import jakarta.ws.rs.POST;
import jakarta.ws.rs.PUT;
import jakarta.ws.rs.Path;
import jakarta.ws.rs.PathParam;
import jakarta.ws.rs.Produces;
import jakarta.ws.rs.core.MediaType;
import jakarta.ws.rs.core.Response;

@Path("/api/tasks")
@Produces(MediaType.APPLICATION_JSON)
@Consumes(MediaType.APPLICATION_JSON)
public class TasksController {

    @Inject
    TasksService tasksService;

    @POST
    @Path("/create")
    public Response createTask(Tasks task) {
        Tasks createdTask = tasksService.createTask(task);
        return Response.status(Response.Status.CREATED)
                .entity(createdTask)
                .build();
    }

    @GET
    @Path("/read")
    public List<Tasks> getAllTasks() {
        return tasksService.getAllTasks();
    }

    @GET
    @Path("/get/{id}")
    public Tasks getTaskById(@PathParam("id") Integer id) {
        return tasksService.getTaskById(id);
    }

    @PUT
    @Path("/update/{id}")
    public Tasks updateTask(@PathParam("id") Integer id, Tasks updatedTask) {
        return tasksService.updateTask(id, updatedTask);
    }    

    @DELETE
    @Path("/delete/{id}")
    public void deleteTask(@PathParam("id") Integer id) {
        tasksService.deleteTask(id);
    }

}
